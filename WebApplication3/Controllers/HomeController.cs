using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text.Json;
using WebApplication3.Models;
using System.Collections.Generic;

namespace WebApplication3.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHttpClientFactory _clientFactory;
        private const string API_BASE_URL = "https://wizard-world-api.herokuapp.com";

        public HomeController(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Houses()
        {
            var client = _clientFactory.CreateClient();
            var response = await client.GetAsync($"{API_BASE_URL}/Houses");
            
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var houses = JsonSerializer.Deserialize<List<House>>(content, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });
                return View(houses);
            }

            // If API call fails, return empty list
            return View(new List<House>());
        }

        public async Task<IActionResult> Spells()
        {
            var client = _clientFactory.CreateClient();
            var response = await client.GetAsync($"{API_BASE_URL}/Spells");
            
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var spells = JsonSerializer.Deserialize<List<Spell>>(content, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });
                return View(spells);
            }

            return View(new List<Spell>());
        }

        public async Task<IActionResult> Elixirs()
        {
            using (var client = new HttpClient())
            {
                try
                {
                    var response = await client.GetAsync("https://wizard-world-api.herokuapp.com/Elixirs");
                    if (response.IsSuccessStatusCode)
                    {
                        var jsonString = await response.Content.ReadAsStringAsync();
                        var elixirs = JsonSerializer.Deserialize<List<Elixir>>(jsonString, new JsonSerializerOptions
                        {
                            PropertyNameCaseInsensitive = true
                        });
                        return View(elixirs);
                    }
                    return View(new List<Elixir>());
                }
                catch (Exception)
                {
                    // Return empty list on error
                    return View(new List<Elixir>());
                }
            }
        }

        public async Task<IActionResult> Wizards()
        {
            var client = _clientFactory.CreateClient();
            var response = await client.GetAsync($"{API_BASE_URL}/Wizards");
            
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var wizards = JsonSerializer.Deserialize<List<Wizard>>(content, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });
                return View(wizards);
            }

            return View(new List<Wizard>());
        }
    }
} 