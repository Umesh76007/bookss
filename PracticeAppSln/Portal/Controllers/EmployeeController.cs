using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Portal.Models;
using SAL;
using Entity;

namespace Portal.Controllers;

public class EmployeeController : Controller
{
    
    private IEmployeeService employeeService;

    public EmployeeController(IEmployeeService employeeService)
    {
        this.employeeService = employeeService;
    }
    public IActionResult Display()
    {

        List<Employee> emp=employeeService.GetEmployees();
        ViewData["employees"]=emp;
        return View();
    }

    public IActionResult Add()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Add(Employee  emp)
    {
        employeeService.AddEmployee(emp);
        return RedirectToAction("Display","Employee",null);
    }
    
    public IActionResult Update(int id)
    {
        Employee emp=employeeService.GetById(id);
       // ViewBag.employee=emp;
        return View(emp);
    }

    [HttpPost]
    public IActionResult Update(Employee employee)
    {
        employeeService.UpdateEmployees(employee);
        return RedirectToAction("Display","Employee",null);
    }

    public IActionResult Delete(int id)
    {
        employeeService.Delete(id);
        return RedirectToAction("Display","Employee",null);
    }
}
