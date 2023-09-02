using Employment.Frontend.Models;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;

namespace Employment.Frontend.Controllers;
public class StateController : Controller
{
    private readonly HttpClient _httpClient;
    public StateController()
    {
        _httpClient = new HttpClient();
        _httpClient.BaseAddress = new Uri("https://localhost:7273/api/");
    }

    public async Task<List<State>> GetAllState()
    {
        var response = await _httpClient.GetAsync("State");
        if (response.IsSuccessStatusCode)
        {
            var content = await response.Content.ReadAsStringAsync();
            var StateList = JsonConvert.DeserializeObject<List<State>>(content);
            return StateList;
        }
        return new List<State>();
    }

    public async Task<IActionResult> Index()
    {
        var listState = await GetAllState();
        return View(listState);
    }

    [HttpGet]

    public async Task<IActionResult> AddorEdit(int id)
    {
        if (id == 0)
        {
            var CountryResponse = await _httpClient.GetAsync("Country");
            if (CountryResponse.IsSuccessStatusCode)
            {
                var content = await CountryResponse.Content.ReadAsStringAsync();
                var CountryList = JsonConvert.DeserializeObject<List<Country>>(content);
                ViewData["CountryId"] = new SelectList(CountryList, "Id", "CountryName");
            }
            return View(new State());
        }


        else
        {

            var response = await _httpClient.GetAsync("Country");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var CountryList = JsonConvert.DeserializeObject<List<Country>>(content);
                ViewData["CountryId"] = new SelectList(CountryList, "Id", "CountryName");
            }
            var Stateresponse = await _httpClient.GetAsync($"State/{id}");
            if (Stateresponse.IsSuccessStatusCode)
            {
                var Statedata = await Stateresponse.Content.ReadFromJsonAsync<State>();
                return View(Statedata);
            }
            else
            {
                return NotFound();
            }
        }
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> AddorEdit(int id, State state)
    {
        if (ModelState.IsValid)
        {
            if (id == 0)
            {
                //save//
                var resposnse = await _httpClient.PostAsJsonAsync("State", state);
                if (resposnse.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("", "Failed to create the State");
                    return View(state);
                }
            }
            else
            {
                //update//
                if (id != state.Id)
                {
                    return BadRequest();
                }
                if (ModelState.IsValid)
                {
                    var response = await _httpClient.PutAsJsonAsync($"State/{id}", state);

                    if (response.IsSuccessStatusCode)
                    {

                        return RedirectToAction("Index");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Failed to update the State.");
                        return View(state);
                    }
                }
                return View(state);
            }
        }
        return View(new State());
    }

    public async Task<IActionResult> Delete(int id)
    {
        var response = await _httpClient.DeleteAsync($"State/{id}");
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
