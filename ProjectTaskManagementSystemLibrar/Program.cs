using ProjectTaskManagementSystemLibrary;
using System;
using Task = ProjectTaskManagementSystemLibrary.Task;

namespace ProjectTaskManagementSystemConsoleApp
{
    internal static class Program
    {
        static void Main(string[] args)
        {
            Repository repository = new Repository();

            Console.WriteLine("Welcome to the Project Task Management System!");

            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("Please choose an option:");
                Console.WriteLine("1. Add an employee");
                Console.WriteLine("2. Edit an employee");
                Console.WriteLine("3. Delete an employee");
                Console.WriteLine("4. Add a project");
                Console.WriteLine("5. Edit a project");
                Console.WriteLine("6. Delete a project");
                Console.WriteLine("7. Add a task");
                Console.WriteLine("8. Edit a task");
                Console.WriteLine("9. Delete a task");
                Console.WriteLine("10. Exit");

                string input = Console.ReadLine();
                int choice;
                if (!int.TryParse(input, out choice))
                {
                    Console.WriteLine("Invalid input. Please enter a number between 1 and 10.");
                    continue;
                }

                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Enter the employee's first name:");
                        string firstName = Console.ReadLine();
                        Console.WriteLine("Enter the employee's last name:");
                        string lastName = Console.ReadLine();
                        Console.WriteLine("Enter the employee's email:");
                        string email = Console.ReadLine();
                        repository.AddEmployee(new Employee(firstName, lastName, email));
                        Console.WriteLine("Employee added successfully.");
                        break;

                    case 2:
                        Console.WriteLine("Enter the ID of the employee to edit:");
                        int employeeId = int.Parse(Console.ReadLine());
                        Console.WriteLine("Enter the new first name for the employee:");
                        firstName = Console.ReadLine();
                        Console.WriteLine("Enter the new last name for the employee:");
                        lastName = Console.ReadLine();
                        Console.WriteLine("Enter the new email for the employee:");
                        email = Console.ReadLine();
                        repository.EditEmployee(employeeId, firstName, lastName, email);
                        Console.WriteLine("Employee updated successfully.");
                        break;

                    case 3:
                        Console.WriteLine("Enter the ID of the employee to delete:");
                        employeeId = int.Parse(Console.ReadLine());
                        repository.DeleteEmployee(employeeId);
                        Console.WriteLine("Employee deleted successfully.");
                        break;

                    case 4:
                        Console.WriteLine("Enter the name of the project:");
                        string name = Console.ReadLine();
                        Console.WriteLine("Enter the description of the project:");
                        string description = Console.ReadLine();
                        Console.WriteLine("Enter the start date of the project (yyyy-mm-dd):");
                        DateTime startDate = DateTime.Parse(Console.ReadLine());
                        Console.WriteLine("Enter the end date of the project (yyyy-mm-dd):");
                        DateTime endDate = DateTime.Parse(Console.ReadLine());
                        repository.AddProject(new Project(name, description, startDate, endDate));
                        Console.WriteLine("Project added successfully.");
                        break;

                    case 5:
                        Console.WriteLine("Enter the ID of the project to edit:");
                        int projectId = int.Parse(Console.ReadLine());
                        Console.WriteLine("Enter the new name for the project:");
                        name = Console.ReadLine();
                        Console.WriteLine("Enter the new description for the project:");
                        description = Console.ReadLine();
                        Console.WriteLine("Enter the new start date for the project (yyyy-mm-dd):");
                        startDate = DateTime.Parse(Console.ReadLine());
                        Console.WriteLine("Enter the new end date for the project (yyyy-mm-dd):");
                        endDate = DateTime.Parse(Console.ReadLine());
                        repository.EditProject(projectId, name, description, startDate, endDate);
                        Console.WriteLine("Project updated successfully.");
                        break;

                    case 6:
                        Console.WriteLine("Enter the ID of the project to delete:");
                        projectId = int.Parse(Console.ReadLine());
                        repository.DeleteProject(projectId);
                        Console.WriteLine("Project deleted successfully.");
                        break;
                    case 7:
                        Console.WriteLine("Enter the ID of the project for the task:");
                        projectId = int.Parse(Console.ReadLine());
                        Console.WriteLine("Enter the name of the task:");
                        name = Console.ReadLine();
                        Console.WriteLine("Enter the description of the task:");
                        description = Console.ReadLine();
                        Console.WriteLine("Enter the start date of the task (yyyy-mm-dd):");
                        startDate = DateTime.Parse(Console.ReadLine());
                        Console.WriteLine("Enter the end date of the task (yyyy-mm-dd):");
                        endDate = DateTime.Parse(Console.ReadLine());
                        Console.WriteLine("Enter the ID of the employee responsible for the task:");
                        int responsibleEmployeeId = int.Parse(Console.ReadLine());
                        try
                        {
                            repository.AddTask(new Task(projectId, name, description, startDate, endDate, responsibleEmployeeId));
                            Console.WriteLine("Task added successfully.");
                        }
                        catch (ArgumentException ex)
                        {
                            Console.WriteLine("Error: " + ex.Message);
                        }
                        break;
                    case 8:
                        Console.WriteLine("Enter the ID of the task to edit:");
                        int taskId = int.Parse(Console.ReadLine());
                        Console.WriteLine("Enter the new name for the task:");
                        String taskName = Console.ReadLine();
                        Console.WriteLine("Enter the new description for the task:");
                        String taskDescription = Console.ReadLine();
                        Console.WriteLine("Enter the new start date for the task (yyyy-mm-dd):");
                        DateTime newStartDate = DateTime.Parse(Console.ReadLine());
                        Console.WriteLine("Enter the new end date for the task (yyyy-mm-dd):");
                        DateTime newEndDate = DateTime.Parse(Console.ReadLine());
                        Console.WriteLine("Enter the new ID of the project for the task:");
                        projectId = int.Parse(Console.ReadLine());
                        Console.WriteLine("Enter the new ID of the employee assigned to the task:");
                        employeeId = int.Parse(Console.ReadLine());
                        repository.EditTask(taskId, projectId, taskName, taskDescription, newStartDate, newEndDate, employeeId);
                        Console.WriteLine("Task updated successfully.");
                        break;


                    case 9:
                        Console.WriteLine("Enter the ID of the task to delete:");
                        taskId = int.Parse(Console.ReadLine());
                        repository.DeleteTask(taskId);
                        Console.WriteLine("Task deleted successfully.");
                        break;

                    case 10:
                        Console.WriteLine("Goodbye!");
                        return;

                    default:
                        Console.WriteLine("Invalid input. Please enter a number between 1 and 10.");
                        break;
                }
            }
        }
    }
}
