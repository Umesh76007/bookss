using Entity;
using MySql.Data.MySqlClient;
namespace DAO;

public class EmployeeDao 
{
    public List<Employee> GetEmployees()
    {
        List<Employee> emps=new List<Employee>();

        MySqlConnection conn=new MySqlConnection();
        conn.ConnectionString = @"server=localhost; port=3306; user=root; password=admin@123; database=test";

        MySqlCommand cmd=new MySqlCommand();
        cmd.Connection=conn;
        cmd.CommandText="select * from employees";
        try
        {
            conn.Open();
            MySqlDataReader reader=cmd.ExecuteReader();
            while(reader.Read())
            {
                int id=int.Parse(reader["id"].ToString());
                string name=reader["name"].ToString();

                Employee  emp =new Employee();

                emp.Id=id;
                emp.Name=name;

                emps.Add(emp);
                Console.WriteLine("In Dao while loop "+emp);
            }

            reader.Close();
        }
        catch(Exception e)
        {
            Console.WriteLine(e.Message);
        }
        finally
        {
            conn.Close();
        }
        Console.WriteLine("In Dao at return statement");
        return emps;
    }

    public void AddNewEmployee(Employee employee)
    {

        MySqlConnection conn=new MySqlConnection();
       conn.ConnectionString = @"server=localhost; port=3306; user=root; password=admin@123; database=test";

        MySqlCommand cmd=new MySqlCommand();
        cmd.Connection=conn;
        // cmd.CommandText="insert into employees values("+employee.Id+","+employee.Name+")";
        cmd.CommandText="insert into employees values(@id,@name)";
        cmd.Parameters.AddWithValue("@id",employee.Id);
        cmd.Parameters.AddWithValue("@name",employee.Name);
        
        try
        {
            conn.Open();
            cmd.ExecuteNonQuery();
        }
        catch(Exception e)
        {
            Console.WriteLine(e.Message);
        }
        finally
        {
            conn.Close();
        }
        
    }

    public Employee GetById(int id)
    {
        Employee emp =new Employee();
        MySqlConnection conn =new MySqlConnection(); 
        conn.ConnectionString=@"server=localhost,port=3306,user=root,password=admin@123,database=test"; 
        MySqlCommand cmd=new MySqlCommand();
        cmd.Connection=conn;
        cmd.CommandText="select * from employees where id="+id;  
       // cmd.Parameters.AddWithValue("@Id",id);
        try
        {
            conn.Open();
            MySqlDataReader reader=cmd.ExecuteReader();
            while(reader.Read())
            {
                int tempid=int.Parse(reader["id"].ToString());
                string name=reader["name"].ToString();
                
                emp.Id=tempid;
                emp.Name=name;

            }
            reader.Close();
        }
        catch(Exception e)
        {
            Console.WriteLine(e.Message);
        }
        finally
        {
            conn.Close();
        }

        return emp;
    }

    public void UpdateEmployee(Employee employee)
    {
        MySqlConnection conn=new MySqlConnection();
        conn.ConnectionString = @"server=localhost; port=3306; user=root; password=admin@123; database=test";
        MySqlCommand cmd=new MySqlCommand();
        cmd.Connection=conn;
        cmd.CommandText="update employees set name=@Name where id=@Id" ;
        cmd.Parameters.AddWithValue("@Name",employee.Name);
        cmd.Parameters.AddWithValue("@Id",employee.Id);
        try
        {
            conn.Open();
            cmd.ExecuteNonQuery();
        }
        catch(Exception e)
        {
            Console.WriteLine(e.Message);
        }
        finally
        {
            conn.Close();
        }
    }

    public void DeleteEmployee(int id)
    {
        MySqlConnection conn=new MySqlConnection();
        conn.ConnectionString = @"server=localhost; port=3306; user=root; password=admin@123; database=test";
        MySqlCommand cmd=new MySqlCommand();
        cmd.Connection=conn;
        cmd.CommandText="delete from employees where id="+id;
        try{
            conn.Open();
            cmd.ExecuteNonQuery();
        }
        catch(Exception e)
        {
            Console.WriteLine(e.Message);
        }
        finally
        {
            conn.Close();
        }

    }
}
