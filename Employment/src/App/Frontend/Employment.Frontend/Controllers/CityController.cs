using Employment.Frontend.Models;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;

namespace Employment.Frontend.Controllers;
public class CityController : Controller
{
    private readonly HttpClient _httpClient;
    public CityController()
    {
        _httpClient = new HttpClient();
        _httpClient.BaseAddress = new Uri("https://localhost:7273/api/");
    }

    public async Task<List<City>> GetAllCity()
    {
        var CityResponse = await _httpClient.GetAsync("City");
        if (CityResponse.IsSuccessStatusCode)
        {
            var content = await CityResponse.Content.ReadAsStringAsync();
            var CityList = JsonConvert.DeserializeObject<List<City>>(content);
            return CityList;
        }
        return new List<City>();
    }
    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var listCity = await GetAllCity();
        return View(listCity);
    }

    [HttpGet]
    public async Task<IActionResult> AddorEdit(int id)
    {
        if (id == 0)
        {

            var StateResponse = await _httpClient.GetAsync("State");
            if (StateResponse.IsSuccessStatusCode)
            {
                var content = await StateResponse.Content.ReadAsStringAsync();
                var StateList = JsonConvert.DeserializeObject<List<State>>(content);
                ViewData["StateId"] = new SelectList(StateList, "Id", "StateName");

            }
            return View(new City());

        }


        else
        {
            var response = await _httpClient.GetAsync("State");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var StateList = JsonConvert.DeserializeObject<List<State>>(content);
                ViewData["StateId"] = new SelectList(StateList, "Id", "StateName");

            }
            var Cityresponse = await _httpClient.GetAsync($"City/{id}");
            if (Cityresponse.IsSuccessStatusCode)
            {
                var cities = await Cityresponse.Content.ReadFromJsonAsync<City>();
                return View(cities);
            }
            else
            {
                return NotFound();
            }
        }
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> AddorEdit(int id, City city)
    {
        if (ModelState.IsValid)
        {
            if (id == 0)
            {
                //save//
                var response = await _httpClient.PostAsJsonAsync("City", city);
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("", "Failed to create City");
                    return View(city);
                }
            }
            else
            {
                //update//
                if (id != city.Id)
                {
                    return BadRequest();
                }
                if (ModelState.IsValid)
                {
                    var response = await _httpClient.PutAsJsonAsync($"City/{id}", city);

                    if (response.IsSuccessStatusCode)
                    {

                        return RedirectToAction("Index");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Failed to update the City.");
                        return View(city);
                    }
                }
                return View(city);
            }
        }
        return View(new City());
    }

    public async Task<IActionResult> Delete(int id)
    {
        var response = await _httpClient.DeleteAsync($"City/{id}");
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
