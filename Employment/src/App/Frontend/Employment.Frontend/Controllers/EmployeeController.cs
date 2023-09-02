using Employment.Frontend.Models;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
        var response = await _httpClient.GetAsync("Employee");
        if (response.IsSuccessStatusCode)
        {
            var content = await response.Content.ReadAsStringAsync();
            var EmployeeList = JsonConvert.DeserializeObject<List<Employee>>(content);
            return EmployeeList;
        }
        return new List<Employee>();
    }

    public async Task<IActionResult> Index()
    {
        var listEmployee = await GetAllEmployee();
        return View(listEmployee);
    }

    [HttpGet]
    public async Task<IActionResult> AddorEdit(int id)
    {
        if (id == 0)
        {
            var Stateresponse = await _httpClient.GetAsync("State");
            if (Stateresponse.IsSuccessStatusCode)
            {
                var content = await Stateresponse.Content.ReadAsStringAsync();
                var StateList = JsonConvert.DeserializeObject<List<State>>(content);
                ViewData["StateId"] = new SelectList(StateList, "Id", "StateName");
            }
            var Countryresponse = await _httpClient.GetAsync("Country");
            if (Countryresponse.IsSuccessStatusCode)
            {
                var content = await Countryresponse.Content.ReadAsStringAsync();
                var CountryList = JsonConvert.DeserializeObject<List<Country>>(content);
                ViewData["CountryId"] = new SelectList(CountryList, "Id", "CountryName");
            }
            var Departmentresponse = await _httpClient.GetAsync("Department");
            if (Departmentresponse.IsSuccessStatusCode)
            {
                var content = await Departmentresponse.Content.ReadAsStringAsync();
                var DepartmentList = JsonConvert.DeserializeObject<List<Department>>(content);
                ViewData["DepartmentId"] = new SelectList(DepartmentList, "Id", "DepartmentName");
            }
            var Cityresponse = await _httpClient.GetAsync("City");
            if (Cityresponse.IsSuccessStatusCode)
            {
                var content = await Cityresponse.Content.ReadAsStringAsync();
                var CityList = JsonConvert.DeserializeObject<List<City>>(content);
                ViewData["CityId"] = new SelectList(CityList, "Id", "CityName");
            }


            return View(new Employee());

        }


        else
        {
            var Stateresponse = await _httpClient.GetAsync("State");
            if (Stateresponse.IsSuccessStatusCode)
            {
                var content = await Stateresponse.Content.ReadAsStringAsync();
                var StateList = JsonConvert.DeserializeObject<List<State>>(content);
                ViewData["StateId"] = new SelectList(StateList, "Id", "StateName");
            }
            var Countryresponse = await _httpClient.GetAsync("Country");
            if (Countryresponse.IsSuccessStatusCode)
            {
                var content = await Countryresponse.Content.ReadAsStringAsync();
                var CountryList = JsonConvert.DeserializeObject<List<Country>>(content);
                ViewData["CountryId"] = new SelectList(CountryList, "Id", "CountryName");
            }
            var Departmentresponse = await _httpClient.GetAsync("Department");
            if (Departmentresponse.IsSuccessStatusCode)
            {
                var content = await Departmentresponse.Content.ReadAsStringAsync();
                var DepartmentList = JsonConvert.DeserializeObject<List<Department>>(content);
                ViewData["DepartmentId"] = new SelectList(DepartmentList, "Id", "DepartmentName");
            }
            var Cityresponse = await _httpClient.GetAsync("City");
            if (Cityresponse.IsSuccessStatusCode)
            {
                var content = await Cityresponse.Content.ReadAsStringAsync();
                var CityList = JsonConvert.DeserializeObject<List<City>>(content);
                ViewData["CityId"] = new SelectList(CityList, "Id", "CityName");
            }
            var response = await _httpClient.GetAsync($"Employee/{id}");
            if (response.IsSuccessStatusCode)
            {
                var Employees = await response.Content.ReadFromJsonAsync<Employee>();
                return View(Employees);
            }
            else
            {
                return NotFound();
            }
        }
    }
    [HttpPost]
    [ValidateAntiForgeryToken]

    public async Task<IActionResult> AddorEdit(int id, Employee employee, IFormFile pictureFile)
    {
        if (ModelState.IsValid)
        {
            if (id == 0)
            {
                if (pictureFile != null && pictureFile.Length > 0)
                {
                    var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", pictureFile.FileName);
                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        pictureFile.CopyTo(stream);
                    }
                    employee.Picture = $"{pictureFile.FileName}";
                }
                var response = await _httpClient.PostAsJsonAsync("Employee", employee);
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("", "Failed to create employee");
                    return View(employee);
                }
            }
            else
            {
                //update 
                if (id != employee.Id)
                {
                    return BadRequest();
                }
                if (ModelState.IsValid)
                {
                    if (pictureFile != null && pictureFile.Length > 0)
                    {
                        var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", pictureFile.FileName);
                        using (var stream = new FileStream(path, FileMode.Create))
                        {
                            pictureFile.CopyTo(stream);
                        }
                        employee.Picture = $"{pictureFile.FileName}";
                    }
                    var response = await _httpClient.PostAsJsonAsync("Employee", employee);
                    if (response.IsSuccessStatusCode)
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Failed to create employee");
                        return View(employee);
                    }
                }
                return View(employee);
            }
        }
        return View(new Employee());

    }

    public async Task<IActionResult> Delete(int id)
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
