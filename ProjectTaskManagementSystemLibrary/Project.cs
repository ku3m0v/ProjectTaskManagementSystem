namespace ProjectTaskManagementSystemLibrary;
public class Project
{
    private int projectId;
    private string name;
    private string description;
    private DateTime startDate;
    private DateTime endDate;
    private List<Task> taskList;

    public int ProjectId
    {
        get { return projectId; }
    }

    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    public string Description
    {
        get { return description; }
        set { description = value; }
    }

    public DateTime StartDate
    {
        get { return startDate; }
        set { startDate = value; }
    }

    public DateTime EndDate
    {
        get { return endDate; }
        set { endDate = value; }
    }

    public List<Task> TaskList
    {
        get { return taskList; }
    }

    private Generator gen = new Generator();

    public Project(string name, string description, DateTime startDate, DateTime endDate, List<Task>? taskList)
    {
        if (string.IsNullOrEmpty(name))
            throw new ArgumentException("Project name cannot be null or empty.");

        if (startDate >= endDate)
            throw new ArgumentException("Project start date must be before end date.");

        projectId = Generator.GenerateId();
        this.name = name;
        this.description = description;
        this.startDate = startDate;
        this.endDate = endDate;
        this.taskList = taskList ?? new List<Task>();
    }

    public override bool Equals(object obj)
    {
        if (obj == null || !(obj is Project))
            return false;

        Project other = (Project)obj;

        return projectId == other.projectId &&
               name == other.name &&
               description == other.description &&
               startDate == other.startDate &&
               endDate == other.endDate &&
               taskList.SequenceEqual(other.taskList);
    }

    public override int GetHashCode()
    {
        int hash = 17;
        hash = hash * 23 + projectId.GetHashCode();
        hash = hash * 23 + name.GetHashCode();
        hash = hash * 23 + description.GetHashCode();
        hash = hash * 23 + startDate.GetHashCode();
        hash = hash * 23 + endDate.GetHashCode();
        hash = hash * 23 + taskList.GetHashCode();
        return hash;
    }

    public override string ToString()
    {
        return string.Format("Project ID: {0}, Name: {1}, Description: {2}, Start Date: {3}, End Date: {4}, Tasks: {5}",
            projectId, name, description, startDate.ToShortDateString(),
            endDate.ToShortDateString(), taskList.Count);
    }
}