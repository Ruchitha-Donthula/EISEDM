using System;
using System.Linq;
using EISDataModel;

namespace EmployeeInformationSystemDataAccess
{
    public class EmployeeDataAccess
    {
        public void AddEmployee(Employee employee)
        {
            try
            {
                using (var dbContext = new EISEDMContainer())
                {
                    dbContext.Employees.Add(employee);
                    dbContext.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                // Handle exception, log, or throw further
                Console.WriteLine("An error occurred while adding an employee: " + ex.Message);
                throw;
            }
        }

        public void DeleteEmployeeByName(string name)
        {
            try
            {
                using (var dbContext = new EISEDMContainer())
                {
                    var employeeToDelete = dbContext.Employees.FirstOrDefault(e => e.Name == name);
                    if (employeeToDelete != null)
                    {
                        dbContext.Employees.Remove(employeeToDelete);
                        dbContext.SaveChanges();
                        Console.WriteLine("Employee with name " + name + " deleted successfully.");
                    }
                    else
                    {
                        Console.WriteLine("Employee with name " + name + " not found.");
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle exception, log, or throw further
                Console.WriteLine("An error occurred while deleting an employee: " + ex.Message);
                throw;
            }
        }

        public void UpdateEmployee(Employee updatedEmployee)
        {
            try
            {
                using (var dbContext = new EISEDMContainer())
                {
                    var existingEmployee = dbContext.Employees.Find(updatedEmployee.Id);
                    if (existingEmployee != null)
                    {
                        existingEmployee.Name = updatedEmployee.Name;
                        existingEmployee.DateOfBirth = updatedEmployee.DateOfBirth;
                        // Update other properties as needed

                        dbContext.SaveChanges();
                        Console.WriteLine("Employee with ID " + updatedEmployee.Id + " updated successfully.");
                    }
                    else
                    {
                        Console.WriteLine("Employee with ID " + updatedEmployee.Id + " not found.");
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle exception, log, or throw further
                Console.WriteLine("An error occurred while updating an employee: " + ex.Message);
                throw;
            }
        }

        public Employee GetEmployeeByName(string name)
        {
            try
            {
                using (var dbContext = new EISEDMContainer())
                {
                    return dbContext.Employees.FirstOrDefault(e => e.Name == name);
                }
            }
            catch (Exception ex)
            {
                // Handle exception, log, or throw further
                Console.WriteLine("An error occurred while fetching an employee by name: " + ex.Message);
                throw;
            }
        }
    }
}
