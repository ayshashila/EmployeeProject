using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EmployeeInfoSystemApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        EmployeeMnager manager = new EmployeeMnager();
        private  int_employeeId=0;

        private void saveButton_Click(object sender, EventArgs e)
        {
            string name = nameTextBox.Text;
            string email = emailTextBox.Text;
            string address = addressTextBox.Text;
            int salary = Convert.ToInt32(salaryTextBox.Text);

            Employee aEmployee = new Employee();

            aEmployee.Name = name;
            aEmployee.Email = email;
            aEmployee.Address = address;
            aEmployee.Salary = salary;

            bool issuccess = false;
            issuccess = manager.Insert(aEmployee);
            if (issuccess)
            {
                MessageBox.Show("Succefully Save");
            }
            else
            {
                MessageBox.Show("Oparetion Unsuccefully");
            }
            ShowAllEmployee();
            ClearText();
        }

        List<Employee> employees = new List<Employee>();
        private void ShowAllEmployee()
        {
            employees.Clear();

            employees= manager.GetAllEmployees();
            employeeListView.Items.Clear();
            foreach (Employee employee in employees)
            {
                ListViewItem item = new ListViewItem(employee.Id.ToString());
                item.SubItems.Add(employee.Name);
                item.SubItems.Add(employee.Email);
                item.SubItems.Add(employee.Address);
                item.SubItems.Add(employee.Salary.ToString());
                employeeListView.Items.Add(item);
            
            }
        }
      
        private void ClearText()
        {
            nameTextBox.Clear();
            emailTextBox.Clear();
            addressTextBox.Clear();
            salaryTextBox.Clear();

        }
        
            
           


        


        private void Form1_Load(object sender, EventArgs e)
        {
            ShowAllEmployee();

        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            Employee aEmployee = new Employee();
            
       
            aEmployee.Name = nameTextBox.Text;
            aEmployee.Email = emailTextBox.Text;
            aEmployee.Address = addressTextBox.Text;
            aEmployee.Salary = Convert.ToInt32(salaryTextBox.Text);
            bool issuccess = manager.Delete(aEmployee);
            if(issuccess)
            {
                MessageBox.Show("Deleted Successfully!");
                
            }
            else
            {
                MessageBox.Show("Could not deleted");
            }
            ShowAllEmployee();
            ClearText();
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            Employee aEmployee = new Employee();
            
            aEmployee.Name = nameTextBox.Text;
            aEmployee.Email = emailTextBox.Text;
            aEmployee.Address = addressTextBox.Text;
            aEmployee.Salary = Convert.ToInt32(salaryTextBox.Text);
            bool issuccess = manager.Update(aEmployee);
            if (issuccess)
            {
                MessageBox.Show("Update Successfully!");
                ClearText();
            }
            else
            {
                MessageBox.Show("Could not Update");
            }
            ShowAllEmployee();
            ClearText();
        }

        private void employeeListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (employeeListView.SelectedItems.Count > 0)
            {
                ListViewItem firstSelectedListViewItem = employeeListView.SelectedItems[0];
                int employeeId = int.Parse(firstSelectedListViewItem.Text);

                Employee employee = manager.GetEmployeeById(employeeId);
                nameTextBox.Text = employee.Name;
                emailTextBox.Text = employee.Email;
                addressTextBox.Text = employee.Address;
                salaryTextBox.Text = employee.Salary.ToString();

                this._employeeId = employee.Id;
            }
        }

    }
}


