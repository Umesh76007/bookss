using Entity;
using DAO;
namespace SAL;

public class EmployeeService : IEmployeeService
{
    

    public List<Employee> GetEmployees()
    {
        Console.WriteLine("In service method");

        EmployeeDao empDao=new EmployeeDao();

        return empDao.GetEmployees();
    }

    public void  AddEmployee(Employee employee)
    {
        EmployeeDao empDao=new EmployeeDao();
        empDao.AddNewEmployee(employee);
    }

    public Employee GetById(int id)
    {
        EmployeeDao empDao=new EmployeeDao();
        return empDao.GetById(id);
    }

    public void UpdateEmployees(Employee employees)
    {
        EmployeeDao empDao=new EmployeeDao();
        empDao.UpdateEmployee(employees);
    }

    public void Delete(int id)
    {
        EmployeeDao empDao=new EmployeeDao();
        empDao.DeleteEmployee(id);
    }
}