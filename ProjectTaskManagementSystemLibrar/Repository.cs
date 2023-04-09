using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTaskManagementSystemLibrary
{
    public class Repository
    {
        private string connectionString = "Data Source=my_database.db;Version=3;";

        public Repository()
        {
            SQLiteConnection.CreateFile("my_database.db");

            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                string createEmployeeTable = @"CREATE TABLE IF NOT EXISTS Employee (
                                            EmployeeId INTEGER PRIMARY KEY AUTOINCREMENT,
                                            FirstName TEXT NOT NULL,
                                            LastName TEXT NOT NULL,
                                            Email TEXT NOT NULL UNIQUE)";
                SQLiteCommand createEmployeeCommand = new SQLiteCommand(createEmployeeTable, connection);
                createEmployeeCommand.ExecuteNonQuery();
            }

            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string sql = @"CREATE TABLE IF NOT EXISTS Projects 
                               (ProjectId INTEGER PRIMARY KEY AUTOINCREMENT, 
                                Name TEXT NOT NULL, 
                                Description TEXT, 
                                StartDate TEXT NOT NULL, 
                                EndDate TEXT NOT NULL)";

                SQLiteCommand cmd = new SQLiteCommand(sql, connection);
                cmd.ExecuteNonQuery();
            }

            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                string createTaskTable = @"CREATE TABLE IF NOT EXISTS Task (
                            taskId INTEGER PRIMARY KEY,
                            projectId INTEGER NOT NULL,
                            name TEXT NOT NULL,
                            description TEXT,
                            startDate TEXT NOT NULL,
                            endDate TEXT NOT NULL,
                            responsibleEmployeeId INTEGER NOT NULL,
                            FOREIGN KEY(projectId) REFERENCES Projects(ProjectId),
                            FOREIGN KEY(responsibleEmployeeId) REFERENCES Employee(EmployeeId)
                        )";
                SQLiteCommand createTaskCommand = new SQLiteCommand(createTaskTable, connection);
                createTaskCommand.ExecuteNonQuery();
            }
        }

        public void AddEmployee(Employee employee)
        {
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string sql = "INSERT INTO Employee (FirstName, LastName, Email) VALUES (@firstName, @lastName, @email)";
                SQLiteCommand command = new SQLiteCommand(sql, connection);
                command.Parameters.AddWithValue("@firstName", employee.FirstName);
                command.Parameters.AddWithValue("@lastName", employee.LastName);
                command.Parameters.AddWithValue("@email", employee.Email);
                command.ExecuteNonQuery();
            }
        }

        public void AddProject(Project project)
        {
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string sql = "INSERT INTO Projects (Name, Description, StartDate, EndDate) VALUES (@name, @description, @startDate, @endDate)";
                SQLiteCommand command = new SQLiteCommand(sql, connection);
                command.Parameters.AddWithValue("@name", project.Name);
                command.Parameters.AddWithValue("@description", project.Description);
                command.Parameters.AddWithValue("@startDate", project.StartDate);
                command.Parameters.AddWithValue("@endDate", project.EndDate);
                command.ExecuteNonQuery();
            }
        }

        public void AddTask(Task task)
        {
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string sql = "INSERT INTO Task (projectId, name, description, startDate, endDate, responsibleEmployee) VALUES (@projectId, @name, @description, @startDate, @endDate, @responsibleEmployee)";
                SQLiteCommand command = new SQLiteCommand(sql, connection);
                command.Parameters.AddWithValue("@projectId", task.ProjectId);
                command.Parameters.AddWithValue("@name", task.Name);
                command.Parameters.AddWithValue("@description", task.Description);
                command.Parameters.AddWithValue("@startDate", task.StartDate);
                command.Parameters.AddWithValue("@endDate", task.EndDate);
                command.Parameters.AddWithValue("@responsibleEmployee", task.ResponsibleEmployeeId);
                command.ExecuteNonQuery();
            }
        }

        public void DeleteEmployee(int employeeId)
        {
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string sql = "DELETE FROM Employee WHERE EmployeeId = @EmployeeId";
                SQLiteCommand command = new SQLiteCommand(sql, connection);
                command.Parameters.AddWithValue("@EmployeeId", employeeId);
                command.ExecuteNonQuery();
            }
        }

        public void DeleteProject(int projectId)
        {
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string sql = "DELETE FROM Projects WHERE ProjectId = @ProjectId";
                SQLiteCommand command = new SQLiteCommand(sql, connection);
                command.Parameters.AddWithValue("@ProjectId", projectId);
                command.ExecuteNonQuery();
            }
        }

        public void DeleteTask(int taskId)
        {
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string sql = "DELETE FROM Task WHERE taskId = @TaskId";
                SQLiteCommand command = new SQLiteCommand(sql, connection);
                command.Parameters.AddWithValue("@TaskId", taskId);
                command.ExecuteNonQuery();
            }
        }

        public void EditEmployee(int employeeId, string firstName, string lastName, string email)
        {
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                string sql = @"UPDATE Employee SET FirstName = @FirstName, LastName = @LastName, Email = @Email WHERE EmployeeId = @EmployeeId";
                SQLiteCommand command = new SQLiteCommand(sql, connection);

                command.Parameters.AddWithValue("@FirstName", firstName);
                command.Parameters.AddWithValue("@LastName", lastName);
                command.Parameters.AddWithValue("@Email", email);
                command.Parameters.AddWithValue("@EmployeeId", employeeId);

                int rowsAffected = command.ExecuteNonQuery();

                if (rowsAffected == 0)
                {
                    throw new Exception("No rows were updated.");
                }
            }
        }

        public void EditProject(int projectId, string name, string description, DateTime startDate, DateTime endDate)
        {
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                string sql = @"UPDATE Projects SET Name = @Name, Description = @Description, StartDate = @StartDate, EndDate = @EndDate WHERE ProjectId = @ProjectId";
                SQLiteCommand command = new SQLiteCommand(sql, connection);

                command.Parameters.AddWithValue("@Name", name);
                command.Parameters.AddWithValue("@Description", description);
                command.Parameters.AddWithValue("@StartDate", startDate);
                command.Parameters.AddWithValue("@EndDate", endDate);
                command.Parameters.AddWithValue("@ProjectId", projectId);

                int rowsAffected = command.ExecuteNonQuery();

                if (rowsAffected == 0)
                {
                    throw new Exception("No rows were updated.");
                }
            }
        }

        public void EditTask(int taskId, int projectId, string name, string description, DateTime startDate, DateTime endDate, int responsibleEmployeeId)
        {
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                string sql = @"UPDATE Task SET projectId = @ProjectId, name = @Name, description = @Description, startDate = @StartDate, endDate = @EndDate, responsibleEmployee = @ResponsibleEmployee WHERE taskId = @TaskId";
                SQLiteCommand command = new SQLiteCommand(sql, connection);

                command.Parameters.AddWithValue("@ProjectId", projectId);
                command.Parameters.AddWithValue("@Name", name);
                command.Parameters.AddWithValue("@Description", description);
                command.Parameters.AddWithValue("@StartDate", startDate);
                command.Parameters.AddWithValue("@EndDate", endDate);
                command.Parameters.AddWithValue("@ResponsibleEmployee", responsibleEmployeeId);
                command.Parameters.AddWithValue("@TaskId", taskId);

                int rowsAffected = command.ExecuteNonQuery();

                if (rowsAffected == 0)
                {
                    throw new Exception("No rows were updated.");
                }
            }
        }

        public Employee FindEmployeeById(int employeeId)
        {
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string sql = "SELECT * FROM Employee WHERE EmployeeId = @employeeId";
                SQLiteCommand command = new SQLiteCommand(sql, connection);
                command.Parameters.AddWithValue("@employeeId", employeeId);
                SQLiteDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    string firstName = reader.GetString(1);
                    string lastName = reader.GetString(2);
                    string email = reader.GetString(3);
                    return new Employee(firstName, lastName, email);
                }
                return null;
            }
        }

        public Project FindProjectById(int projectId)
        {
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string sql = "SELECT * FROM Projects WHERE ProjectId = @projectId";
                SQLiteCommand command = new SQLiteCommand(sql, connection);
                command.Parameters.AddWithValue("@projectId", projectId);
                SQLiteDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    string name = reader.GetString(1);
                    string description = reader.IsDBNull(2) ? null : reader.GetString(2);
                    DateTime startDate = reader.GetDateTime(3);
                    DateTime endDate = reader.GetDateTime(4);
                    return new Project(name, description, startDate, endDate);
                }
                return null;
            }
        }

        public Task FindTaskById(int taskId)
        {
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string sql = "SELECT * FROM Task WHERE taskId = @taskId";
                SQLiteCommand command = new SQLiteCommand(sql, connection);
                command.Parameters.AddWithValue("@taskId", taskId);
                SQLiteDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    int projectId = reader.GetInt32(1);
                    string name = reader.GetString(2);
                    string description = reader.IsDBNull(3) ? null : reader.GetString(3);
                    DateTime startDate = reader.GetDateTime(4);
                    DateTime endDate = reader.GetDateTime(5);
                    int responsibleEmployeeId = reader.GetInt32(6);
                    Employee responsibleEmployee = FindEmployeeById(responsibleEmployeeId);
                    return new Task(projectId, name, description, startDate, endDate, responsibleEmployeeId);
                }
                return null;
            }
        }

        public List<Task> GetTasksByProjectId(int projectId)
        {
            List<Task> tasks = new List<Task>();
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                string sql = "SELECT * FROM Task WHERE projectId = @projectId";
                using (SQLiteCommand command = new SQLiteCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@projectId", projectId);
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int taskId = reader.GetInt32(0);
                            int projectTaskId = reader.GetInt32(1);
                            string name = reader.GetString(2);
                            string description = reader.GetString(3);
                            DateTime startDate = reader.GetDateTime(4);
                            DateTime endDate = reader.GetDateTime(5);
                            int responsibleEmployeeId = reader.GetInt32(6);

                            tasks.Add(new Task(taskId, projectTaskId, name, description, startDate, endDate, responsibleEmployeeId));
                        } 
                    }
                }
            }
            return tasks;
        }

        public List<Project> GetProjects()
        {
            List<Project> projects = new List<Project>();

            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string sql = "SELECT * FROM Projects";
                SQLiteCommand command = new SQLiteCommand(sql, connection);

                using (SQLiteDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int projectId = reader.GetInt32(0);
                        string name = reader.GetString(1);
                        string description = reader.IsDBNull(2) ? null : reader.GetString(2);
                        DateTime startDate = DateTime.Parse(reader.GetString(3));
                        DateTime endDate = DateTime.Parse(reader.GetString(4));

                        Project project = new Project(projectId, name, description, startDate, endDate);
                        projects.Add(project);
                    }
                }
            }

            return projects;
        }

    }
}
