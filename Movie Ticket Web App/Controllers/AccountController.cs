using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Text;
using Newtonsoft.Json;
using System.IdentityModel.Tokens.Jwt;
using Movie_Ticket_Web_App.Models;

namespace Movie_Ticket_Web_App.Controllers
{
    public class AccountController : Controller
    {
        Uri baseAdderess = new Uri("https://localhost:7170/api");
        private readonly HttpClient _httpClient;

        public AccountController(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = baseAdderess;
        }
        [HttpGet]
        public async Task<IActionResult> Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(Register registerModel)
        {
            if (!ModelState.IsValid)
            {
                return View(registerModel);
            }
            string data = JsonConvert.SerializeObject(registerModel);
            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await _httpClient.PostAsync(_httpClient.BaseAddress + "/Account/Register", content);

            if (response.IsSuccessStatusCode)
            {
                TempData["Register"] = "User Registered Successfully";
                return RedirectToAction("Login");
            }
            else
            {
                return View();
            }
        }
        [HttpGet]
        public async Task<IActionResult> Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(Login loginModel)
        {
            if (!ModelState.IsValid)
            {
                return View(loginModel);
            }
            string data = JsonConvert.SerializeObject(loginModel);
            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await _httpClient.PostAsync(_httpClient.BaseAddress + "/Account/Login", content);


            if (response.IsSuccessStatusCode)
            {
                string token = await response.Content.ReadAsStringAsync();
                var tokenHandler = new JwtSecurityTokenHandler();
                var securityToken = (JwtSecurityToken)tokenHandler.ReadToken(token);
                var claimsIdentity = new ClaimsIdentity(securityToken.Claims, CookieAuthenticationDefaults.AuthenticationScheme);
                HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity));
                string role = securityToken.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Role)?.Value;
                HttpContext.Session.SetString("jwt", token);
                if (role == "Admin")
                {
                    TempData["Login"] = "User Logged In Successfully";
                    return RedirectToAction("Index", "Admin");
                }
                else
                {
                    return RedirectToAction("Index", "User");
                }
            }
            else
            {
                ModelState.TryAddModelError("", "Invalid Credentials");
                return View();
            }
        }


        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            HttpContext.Session.Clear();
            TempData["Logout"] = "User Logout Successfully";
            return RedirectToAction("Login");
        }
    }
}
