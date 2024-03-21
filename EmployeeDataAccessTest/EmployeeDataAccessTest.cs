using System;
using EISDataModel;
using EmployeeInformationSystemDataAccess;

namespace EmployeeDataAccessTest
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Choose an option:");
                Console.WriteLine("1. Add an employee");
                Console.WriteLine("2. Delete an employee");
                Console.WriteLine("3. Update an employee");
                Console.WriteLine("4. Get employee by name");
                Console.WriteLine("5. Exit");

                Console.Write("Enter your choice (1/2/3/4/5): ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddEmployee();
                        break;
                    case "2":
                        DeleteEmployee();
                        break;
                    case "3":
                        UpdateEmployee();
                        break;
                    case "4":
                        GetEmployeeByName();
                        break;
                    case "5":
                        Console.WriteLine("Exiting...");
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }

                Console.WriteLine();
            }
        }

        static void AddEmployee()
        {
            try
            {
                // Generate test data for one department
                Department department = new Department()
                {
                    ManagerName = "Ruchitha",
                    DepartmentName = "IT"
                };

                // Generate test data for one employee with inline address creation
                Employee employee = new Employee()
                {
                    Name = "Rani",
                    DateOfBirth = new DateTime(1990, 5, 15),
                    Addresses = new System.Collections.Generic.List<Address>()
                    {
                        new Address() // Inline address creation
                        {
                            DoorNumber = "123",
                            StreetName = "Main Street12",
                            City = "City11",
                            PinCode = "12345",
                            State = "State2"
                        }
                    },
                    Department = department // Associate employee with department
                };

                // Add the department and the employee to the database
                EmployeeDataAccess dataAccess = new EmployeeDataAccess();
                dataAccess.AddEmployee(employee);

                Console.WriteLine("Employee added successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }

        static void DeleteEmployee()
        {
            try
            {
                Console.Write("Enter the name of the employee to delete: ");
                string name = Console.ReadLine();

                // Create an instance of EmployeeDataAccess
                EmployeeDataAccess dataAccess = new EmployeeDataAccess();

                // Call the DeleteEmployeeByName method to delete the employee by name
                dataAccess.DeleteEmployeeByName(name);

                Console.WriteLine("Employee with name " + name + " deleted successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }

        static void UpdateEmployee()
        {
            try
            {
                // Prompt user to enter employee details
                Console.WriteLine("Enter details of the employee to update:");

                Console.Write("Enter the ID of the employee to update: ");
                int id = int.Parse(Console.ReadLine());

                Console.Write("Enter the new name of the employee: ");
                string newName = Console.ReadLine();

                Console.Write("Enter the new date of birth of the employee (yyyy-MM-dd): ");
                DateTime newDateOfBirth = DateTime.Parse(Console.ReadLine());

                // Create an instance of EmployeeDataAccess
                EmployeeDataAccess dataAccess = new EmployeeDataAccess();

                // Create an Employee object with updated details
                Employee updatedEmployee = new Employee()
                {
                    Id = id,
                    Name = newName,
                    DateOfBirth = newDateOfBirth
                    // Add other properties as needed
                };

                // Call the UpdateEmployee method to update the employee
                dataAccess.UpdateEmployee(updatedEmployee);

                Console.WriteLine("Employee with ID " + id + " updated successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }

        static void GetEmployeeByName()
        {
            try
            {
                // Prompt user to enter employee name
                Console.Write("Enter the name of the employee to get: ");
                string name = Console.ReadLine();

                // Create an instance of EmployeeDataAccess
                EmployeeDataAccess dataAccess = new EmployeeDataAccess();

                // Call the GetEmployeeByName method to fetch the employee by name
                Employee employee = dataAccess.GetEmployeeByName(name);

                if (employee != null)
                {
                    Console.WriteLine("Employee found:");
                    Console.WriteLine("ID: " + employee.Id);
                    Console.WriteLine("Name: " + employee.Name);
                    Console.WriteLine("Date of Birth: " + employee.DateOfBirth);
                    // Display other properties as needed
                }
                else
                {
                    Console.WriteLine("Employee with name " + name + " not found.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}
