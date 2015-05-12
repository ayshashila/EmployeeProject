using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeInfoSystemApp
{
     class EmployeeMnager
    {
        EmployeeGateway gateway = new EmployeeGateway();
        Employee aEmployee = new Employee();
        public bool Insert(Employee aEmployee)
        {

            if (gateway.Save(aEmployee) > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
         public Employee GetEmployeeById(int employeeId)
        {
            Employee aEmployee = gateway.GetEmployeeById(employeeId);
            return aEmployee;
        }
        public bool Delete(Employee aEmployee)
        {
            if(aEmployee==null)
            {
                return false;
            }
            Employee anEmployee = gateway.GetEmployeeByEmail(aEmployee.Email);
            if (anEmployee == null)
            {
                return false;
            }
            int rowAffected = gateway.Delete(aEmployee);
            return rowAffected > 0;


        }
         public bool Update (Employee aEmployee)
        {
            if (gateway.Update(aEmployee) > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
         public List <Employee>GetAllemployees()
         {
             return gateway.GetAllEmployee();
         }
         public bool GetEmployeeByEmail(string email)
         {
             Employee aEmployee = gateway.GetEmployeeByEmail(email);
             if (aEmployee != null)
             {
                 return true;
             }
             else
             {
                 return false;
             }
         }

            




        

    }
}
