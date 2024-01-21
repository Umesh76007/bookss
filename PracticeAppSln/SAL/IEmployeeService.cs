using Entity;
using DAO;
namespace SAL;

public interface IEmployeeService
{
   public  List<Employee> GetEmployees();
   public void AddEmployee(Employee employee);

   public Employee GetById(int id);
   public void UpdateEmployees(Employee employees);

   public void Delete(int id);

}