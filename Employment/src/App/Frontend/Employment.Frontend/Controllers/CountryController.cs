using Employment.Frontend.Models;

using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Employment.Frontend.Controllers;
public class CountryController : Controller
{
    private readonly HttpClient _httpClient;
    public CountryController()
    {
        _httpClient = new HttpClient();
        _httpClient.BaseAddress = new Uri("https://localhost:7273/api/");
    }

    public async Task<List<Country>> GetAllCountry()
    {
        var response = await _httpClient.GetAsync("Country");
        if (response.IsSuccessStatusCode)
        {
            var newData = await response.Content.ReadAsStringAsync();
            var countries = JsonConvert.DeserializeObject<List<Country>>(newData);
            return countries;
        }
        return new List<Country>();
    }

    public async Task<IActionResult> Index()
    {
        var data = await GetAllCountry();
        return View(data);
    }

    [HttpGet]
    public async Task<IActionResult> AddorEdit(int id)
    {
        if (id == 0)
        {
            return View(new Country());

        }


        else
        {
            var response = await _httpClient.GetAsync($"Country/{id}");
            if (response.IsSuccessStatusCode)
            {
                var countries = await response.Content.ReadFromJsonAsync<Country>();
                return View(countries);
            }
            else
            {
                return NotFound();
            }
        }
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> AddorEdit(int id, Country country)
    {
        if (ModelState.IsValid)
        {
            if (id == 0)
            {
                //save//
                var response = await _httpClient.PostAsJsonAsync("Country", country);
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("", "Failed to create the country");
                    return View(country);
                }
            }
            else
            {
                //update//
                if (id != country.Id)
                {
                    return BadRequest();
                }
                if (ModelState.IsValid)
                {
                    var response = await _httpClient.PutAsJsonAsync($"Country/{id}", country);

                    if (response.IsSuccessStatusCode)
                    {

                        return RedirectToAction("Index");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Failed to update the Country.");
                        return View(country);
                    }
                }
                return View(country);
            }
        }

        return View(new Country());
    }

    public async Task<IActionResult> Delete(int id)
    {
        var response = await _httpClient.DeleteAsync($"Country/{id}");
        if (response.IsSuccessStatusCode)
        {
            return RedirectToAction("Index");
        }
        else
        {
            return NotFound();
        }
    }

}
