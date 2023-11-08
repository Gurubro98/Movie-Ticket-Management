using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Movie_Ticket_Web_App.Models;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Claims;

namespace Movie_Ticket_Web_App.Controllers
{
    [Authorize(Roles = "Admin, User")]
    public class BookingCartController : Controller
    {
        Uri baseAdderess = new Uri("https://localhost:7170/api");
        private readonly HttpClient _httpClient;

        public BookingCartController(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = baseAdderess;
        }
        public async Task<IActionResult> BokkedTicket()
        {
            string token = HttpContext.Session.GetString("jwt");
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            string userId = User.FindFirst(x => x.Type == ClaimTypes.NameIdentifier)?.Value;
            List<BookingCart> bookedTickets = new List<BookingCart>();
            HttpResponseMessage response = await _httpClient.GetAsync(_httpClient.BaseAddress + "/User/BokkedTicket/" + userId);
            string data = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
            {
                bookedTickets = JsonConvert.DeserializeObject<List<BookingCart>>(data);
                if (bookedTickets.Count == 0)
                {
                    TempData["Empty"] = "There is No Movie";
                }
                return View(bookedTickets);
            }
            else
            {
                return View(bookedTickets);
            }
        }
    }
}
