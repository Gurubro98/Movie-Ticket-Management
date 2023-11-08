using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Movie_Ticket_Web_App.Models;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;

namespace Movie_Ticket_Web_App.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        Uri baseAdderess = new Uri("https://localhost:7170/api");
        private readonly HttpClient _httpClient;

        public AdminController(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = baseAdderess;
        }
        public async Task<IActionResult> Index()
        {
            string token = HttpContext.Session.GetString("jwt");
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            string userId = User.FindFirst(x => x.Type == ClaimTypes.NameIdentifier)?.Value;
            List<Movie> movies = new List<Movie>();
            HttpResponseMessage response = await _httpClient.GetAsync(_httpClient.BaseAddress + "/Admin/GetAll/" + userId);
            string data = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
            {
                movies = JsonConvert.DeserializeObject<List<Movie>>(data);
                if (movies.Count == 0)
                {
                    TempData["Empty"] = "There is No Movie";
                }
                return View(movies);
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }

        public async Task<IActionResult> Add()
        {
            string token = HttpContext.Session.GetString("jwt");
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(Movie movieModel)
        {
            string token = HttpContext.Session.GetString("jwt");
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            if (!ModelState.IsValid)
            {
                return View(movieModel);
            }
            movieModel.UserId = User.FindFirst(x => x.Type == ClaimTypes.NameIdentifier)?.Value;
            string data = JsonConvert.SerializeObject(movieModel);
            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await _httpClient.PostAsync(_httpClient.BaseAddress + "/Admin/Create", content);

            if (response.IsSuccessStatusCode)
            {
                TempData["Add"] = "Data Added Successfully";
                return RedirectToAction("Index");
            }
            else
            {
                return View(movieModel);
            }
        }
    }
}

//you are Garvit Sharma