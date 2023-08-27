using Employment.Frontend.Models;

using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Employment.Frontend.Controllers;
public class EmployeeController : Controller
{
    private readonly HttpClient _httpClient;
    public EmployeeController()
    {
        _httpClient = new HttpClient();
        _httpClient.BaseAddress = new Uri("https://localhost:7273/api/");
    }

    public async Task<List<Employee>> GetAllEmployee()
    {
        var data = await _httpClient.GetAsync("Employee");
        if (data.IsSuccessStatusCode)
        {
            var newData = await data.Content.ReadAsStringAsync();
            var employees = JsonConvert.DeserializeObject<List<Employee>>(newData);
            return employees;
        }
        return new List<Employee>();
    }

    public async Task<IActionResult> Index()
    {
        var data = await GetAllEmployee();
        return View(data);
    }

    [HttpGet]
    public async Task<IActionResult> AddorEdit(int id)
    {
        if (id == 0)
        {
            return View(new Employee());

        }


        else
        {
            var response = await _httpClient.GetAsync($"Employee/{id}");
            if (response.IsSuccessStatusCode)
            {
                var employees = await response.Content.ReadFromJsonAsync<Employee>();
                return View(employees);
            }
            else
            {
                return NotFound();
            }
        }
    }


    public async Task<IActionResult> AddorEdit(Employee employee, int id)
    {
        if (id == 0)
        {
            //save//
            var data = await _httpClient.PostAsJsonAsync("Employee", employee);
            if (data.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
        }
        else
        {
            //update//
            if (id != employee.id)
            {
                return BadRequest();
            }
            if (ModelState.IsValid)
            {
                var response = await _httpClient.PutAsJsonAsync($"Employee/{id}", employee);

                if (response.IsSuccessStatusCode)
                {

                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("", "Failed to update the Employee.");
                    return View(employee);
                }
            }
            return View(employee);
        }
        return View(new Employee());
    }

    public async Task<ActionResult> Delete(int id)
    {
        var response = await _httpClient.DeleteAsync($"Employee/{id}");
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
