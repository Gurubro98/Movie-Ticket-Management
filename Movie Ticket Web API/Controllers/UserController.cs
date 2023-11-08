using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Movie_Ticket_Web_API.Models;
using Movie_Ticket_Web_API.Repository;
using System.Data;
using System.Security.Claims;

namespace Movie_Ticket_Web_API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController, Authorize(AuthenticationSchemes = "Bearer", Roles = "User, Admin")]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly IBookingRepository _bookingRepository;
        private readonly IMovieRepository _movieRepository;

        public UserController(IUserRepository userRepository ,IBookingRepository bookingRepository, IMovieRepository movieRepository)
        {
            _userRepository = userRepository;
            _bookingRepository = bookingRepository;
            _movieRepository = movieRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] int pageNumber = 1, [FromQuery] string? search = "", [FromQuery] string? sort="")
        {
            try
            {
                var data = await _userRepository.GetAllData(pageNumber, search, sort);
                if(data == null)
                {
                    return NotFound("Empty");
                }
                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> TicketBooking(BookingCart model)
        {
            try
            {
                Movie movie = await _movieRepository.GetById(model.MovieId);
                if (movie == null)
                {
                    return NotFound("Empty");
                }
                var CheckBookedTicket = await _bookingRepository.GetByMovieandUserId(movie.MovieId,model.UserId);
                if (CheckBookedTicket == null)
                {
                    BookingCart bookedTicket = new BookingCart();
                    bookedTicket.MovieId = movie.MovieId;
                    bookedTicket.UserId = model.UserId;
                    await _bookingRepository.CreateAsync(bookedTicket);
                    await _bookingRepository.SaveAsync();
                    return StatusCode(201, true);
                }
                else
                {
                    return Ok(false);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> BokkedTicket(string id)
        {
            try
            {
                return StatusCode(201, await _bookingRepository.GetByUserId(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
