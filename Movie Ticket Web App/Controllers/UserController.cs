using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Movie_Ticket_Web_App.Models;
using Newtonsoft.Json;
using System.Diagnostics.Contracts;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;

namespace Movie_Ticket_Web_App.Controllers
{
    [Authorize(Roles = "Admin, User")]
    public class UserController : Controller
    {

        Uri baseAdderess = new Uri("https://localhost:7170/api");
        private readonly HttpClient _httpClient;


        public UserController(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = baseAdderess;
        }
        public async Task<IActionResult> Index(string? searchTxt = "", string sortOrder= "",int pageNumber = 1)
        {
            ViewBag.PageNumber = pageNumber;
            
            ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewData["DateSortParm"] = sortOrder == "Date" ? "date_desc" : "Date";
            ViewBag.Search = searchTxt;
            string token = HttpContext.Session.GetString("jwt");
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            
            HttpResponseMessage response = await _httpClient.GetAsync(_httpClient.BaseAddress + "/user/GetAll?pageNumber=" + pageNumber + "&search=" + searchTxt + "&sort=" + sortOrder);
             var data = await response.Content.ReadAsStringAsync();
             var ticketBookedData = await GetBookedTicket();
            if (response.IsSuccessStatusCode)
            {
                ViewBag.Booked = ticketBookedData;
                Tuple<List<Movie>, int> data1 = JsonConvert.DeserializeObject<Tuple<List<Movie>, int>>(data);
                ViewBag.TotalPage = data1.Item2;
                return View(data1.Item1);
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }

        private async Task<List<int>> GetBookedTicket()
        {
            List<Movie> bookedTicket = new List<Movie>();
            List<int> bookedMovieId = new List<int>();
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            HttpResponseMessage response = await _httpClient.GetAsync(_httpClient.BaseAddress + "/user/BokkedTicket/" + userId);
            string data = await response.Content.ReadAsStringAsync();
            if(response.IsSuccessStatusCode)
            {
                bookedTicket = JsonConvert.DeserializeObject<List<Movie>>(data);
                foreach(var item in bookedTicket)
                {
                    bookedMovieId.Add(item.MovieId);
                }
                return bookedMovieId;
            }
            return null;
        }

        [HttpPost]
        public async Task<IActionResult> Ticketbooking(int Id)
        {
            string token = HttpContext.Session.GetString("jwt");
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            string userId = User.FindFirst(x => x.Type == ClaimTypes.NameIdentifier)?.Value;
            BookingCart cart = new BookingCart()
            {
                UserId = userId,
                MovieId = Id
            };
            string data = JsonConvert.SerializeObject(cart);
            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await _httpClient.PostAsync(_httpClient.BaseAddress + "/User/TicketBooking/",content);
            if (response.IsSuccessStatusCode)
            {
                string bookedData = await response.Content.ReadAsStringAsync();
                bool isCheck = JsonConvert.DeserializeObject<bool>(bookedData);
                if(isCheck)
                {
                    TempData["Success"] = "Ticket Booked Successfully";
                }
                else
                {
                    TempData["Error"] = "Ticket Already Booked!!";
                }
                return RedirectToAction("Index");
            }
            else
            {
                return View("Index");
            }
        }
    }
}
