using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
namespace EmployeeInfoSystemApp
{
   class EmployeeGateway
    {
      
       Employee aEmployee = new Employee();

         public int Save(Employee aEployee)
         {
             string connectionString = ConfigurationManager.ConnectionStrings["emplyeeConnString"].ConnectionString;
             SqlConnection connection = new SqlConnection(connectionString);
             string query = "INSERT INTO EmployeeTable VALUES('" + aEployee.Name + "','" + aEployee.Email + "','" + aEployee.Address + "','" + aEployee.Salary + "')";
             SqlCommand command = new SqlCommand(query, connection);
             connection.Open();
             int rowAffected = command.ExecuteNonQuery();
             connection.Close();
             return rowAffected;
         }
       public int Delete (Employee aEmployee)
         {
             string connectionString = ConfigurationManager.ConnectionStrings["emplyeeConnString"].ConnectionString;
             SqlConnection connection = new SqlConnection(connectionString);
             string query = "DELETE FROM EmployeeTable WHERE Email= "+ aEmployee.Email ;
             SqlCommand command = new SqlCommand(query, connection);
             connection.Open();
             int rowAffected = command.ExecuteNonQuery();
             connection.Close();
             return rowAffected;
         }
       public int Update (Employee aEmployee)
       {
           string connectionString = ConfigurationManager.ConnectionStrings["emplyeeConnString"].ConnectionString;
           SqlConnection connection = new SqlConnection(connectionString);
           string query = "UPDATE EmployeeTable SET Name='" + aEmployee.Name + "',Email='" + aEmployee.Email + "',Address='" + aEmployee.Address + "',Salary='" + aEmployee.Salary + "' WHERE Id= " +aEmployee.Id;
           SqlCommand command = new SqlCommand(query, connection);
           connection.Open();
           int rowAffected = command.ExecuteNonQuery();
           connection.Close();
           return rowAffected;
       }
       List<Employee> allEmployees = new List<Employee>();
       public List <Employee>GetAllEmployee()
       {
           string connectionString = ConfigurationManager.ConnectionStrings["emplyeeConnString"].ConnectionString;
           SqlConnection connection = new SqlConnection(connectionString);
           string query = "SELECT * FROM EmployeeTable";
           SqlCommand command = new SqlCommand(query, connection);
           connection.Open();
           SqlDataReader reader = command.ExecuteReader();

           while (reader.Read())
           {
               Employee aEmployee = aEmployee = new Employee();
               aEmployee.Id = int.Parse(reader[0].ToString());
               aEmployee.Name = reader["Name"].ToString();
               aEmployee.Email = reader["Email"].ToString();
               aEmployee.Address = reader["Address"].ToString();
               aEmployee.Salary = int.Parse(reader["Salary"].ToString());
               allEmployees.Add(aEmployee);

           }
           reader.Close();
           connection.Close();
           return allEmployees;

       }
       public Employee GetEmployeeByEmail(string employeeEmail)
       {
           string connectionString = ConfigurationManager.ConnectionStrings["emplyeeConnString"].ConnectionString;
           SqlConnection connection = new SqlConnection(connectionString);
           string query = "SELECT * FROM EmployeeTable WHERE Email = '" + employeeEmail + "'";
           SqlCommand command = new SqlCommand(query, connection);
           connection.Open();
           SqlDataReader reader = command.ExecuteReader();
           Employee aEmployee = null;
           while (reader.Read())
           {
               if (aEmployee == null)
               {
                   aEmployee = new Employee();
               }
               aEmployee.Id = int.Parse(reader[0].ToString());
               aEmployee.Name = reader["Name"].ToString();
               aEmployee.Email = reader["Email"].ToString();
               aEmployee.Address = reader["Address"].ToString();
               aEmployee.Salary = int.Parse(reader["Salary"].ToString());

           }
           reader.Close();
           connection.Close();
           return aEmployee;
       }
       public Employee GetEmployeeById(int employeeId)
       {
           string connectionString = ConfigurationManager.ConnectionStrings["emplyeeConnString"].ConnectionString;
           SqlConnection connection = new SqlConnection(connectionString);
           string query = "SELECT * FROM EmployeeTable WHERE ID = '" + employeeId + "'";
           SqlCommand command = new SqlCommand(query, connection);
           connection.Open();
           SqlDataReader reader = command.ExecuteReader();
           Employee aEmployee = null;
           while (reader.Read())
           {
               if (aEmployee == null)
               {
                   aEmployee = new Employee();
               }
               aEmployee.Id = int.Parse(reader[0].ToString());
               aEmployee.Name = reader["Name"].ToString();
               aEmployee.Email = reader["Email"].ToString();
               aEmployee.Address = reader["Address"].ToString();
               aEmployee.Salary = int.Parse(reader["Salary"].ToString());

           }
           reader.Close();
           connection.Close();
           return aEmployee;
       }
           
    }
}
