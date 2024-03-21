using System;
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
                };
            }
            catch (Exception ex)
            {
                // Handle exception, log, or throw further
                Console.WriteLine("An error occurred while adding an employee: " + ex.Message);
                throw;
            }
        }
    }
}
