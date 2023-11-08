using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Movie_Ticket_Web_API.Models;
using Movie_Ticket_Web_API.Repository;

namespace Movie_Ticket_Web_API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController, Authorize(AuthenticationSchemes = "Bearer", Roles = "Admin")]
    public class AdminController : ControllerBase
    {
        private readonly IMovieRepository _movieRepository;

        public AdminController(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAll(string id)
        {
            try
            {
                var data = await _movieRepository.GetByAdmineId(id);
                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create(Movie movieModel)
        {
            try
            {
                await _movieRepository.CreateAsync(movieModel);
                await _movieRepository.SaveAsync();
                return StatusCode(201, movieModel);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);  
            }
        }
    }
}
