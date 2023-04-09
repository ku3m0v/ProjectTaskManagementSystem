namespace ProjectTaskManagementSystemLibrary;
public class Employee
{
    private int employeeId;
    private string firstName;
    private string lastName;
    private string email;

    public int EmployeeId
    {
        get { return employeeId; }
    }

    public string FirstName
    {
        get { return firstName; }
        set
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentException("First name cannot be null or empty.");
            }
            firstName = value;
        }
    }

    public string LastName
    {
        get { return lastName; }
        set
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentException("Last name cannot be null or empty.");
            }
            lastName = value;
        }
    }

    public string Email
    {
        get { return email; }
        set
        {
            if (!IsValidEmail(value))
            {
                throw new ArgumentException("Invalid email format.");
            }
            email = value;
        }
    }

    private bool IsValidEmail(string email)
    {
        try
        {
            var addr = new System.Net.Mail.MailAddress(email);
            return addr.Address == email;
        }
        catch
        {
            return false;
        }
    }

    public Employee(string firstName, string lastName, string email)
    {
        employeeId = Generator.GenerateId();
        this.firstName = firstName;
        this.lastName = lastName;
        this.email = email;
    }
}