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
        var data = await _httpClient.GetAsync("State");
        if (data.IsSuccessStatusCode)
        {
            var newData = await data.Content.ReadAsStringAsync();
            var states = JsonConvert.DeserializeObject<List<State>>(newData);
            return states;
        }
        return new List<State>();
    }

    public async Task<IActionResult> Index()
    {
        var data = await GetAllState();
        return View(data);
    }

    [HttpGet]
    public async Task<IActionResult> AddorEdit(int id)
    {
        if (id == 0)
        {
            var response = await _httpClient.GetAsync("Country");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var stateList = JsonConvert.DeserializeObject<List<Country>>(content);
                ViewData["countryId"] = new SelectList(stateList, "id", "countryName");
            }
            return View(new State());
        }


        else
        {

            var response = await _httpClient.GetAsync("Country");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var stateList = JsonConvert.DeserializeObject<List<Country>>(content);
                ViewData["countryId"] = new SelectList(stateList, "id", "countryName");
            }
            var stateresponse = await _httpClient.GetAsync($"State/{id}");
            if (response.IsSuccessStatusCode)
            {
                var statedata = await stateresponse.Content.ReadFromJsonAsync<State>();
                return View(statedata);
            }
            else
            {
                return NotFound();
            }
        }
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> AddorEdit(State state, int id)
    {
        if (id == 0)
        {
            //save//
            var data = await _httpClient.PostAsJsonAsync("State", state);
            if (data.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
        }
        else
        {
            //update//
            if (id != state.id)
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
        return View(new State());
    }

    public async Task<ActionResult> Delete(int id)
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
