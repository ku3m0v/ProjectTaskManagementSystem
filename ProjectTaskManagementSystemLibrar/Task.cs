namespace ProjectTaskManagementSystemLibrary
{
    public class Task
    {
        private int taskId;
        private int projectId;
        private string name;
        private string description;
        private DateTime startDate;
        private DateTime endDate;
        private int responsibleEmployeeId;

        public int TaskId
        {
            get { return taskId; }
        }

        public int ProjectId
        {
            get { return projectId; }
            set { projectId = value; }
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
        }

        public DateTime EndDate
        {
            get { return endDate; }
            set { endDate = value; }
        }

        public int ResponsibleEmployeeId
        {
            get { return responsibleEmployeeId; }
            set { responsibleEmployeeId = value; }
        }

        public Task(int taskId, int projectId, string name, string description, DateTime startDate, DateTime endDate, int responsibleEmployeeId)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentException("Task name cannot be null or empty.");

            if (startDate >= endDate)
                throw new ArgumentException("Task start date must be before end date.");

            this.taskId = taskId;
            this.projectId = projectId;
            this.name = name;
            this.description = description;
            this.startDate = startDate;
            this.endDate = endDate;
            this.responsibleEmployeeId = responsibleEmployeeId;
        }

        public Task(int projectId, string name, string description, DateTime startDate, DateTime endDate, int responsibleEmployeeId)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentException("Task name cannot be null or empty.");

            if (startDate >= endDate)
                throw new ArgumentException("Task start date must be before end date.");

            taskId = Generator.GenerateId();
            this.projectId = projectId;
            this.name = name;
            this.description = description;
            this.startDate = startDate;
            this.endDate = endDate;
            this.responsibleEmployeeId = responsibleEmployeeId;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is Task))
                return false;

            Task other = (Task)obj;

            return taskId == other.taskId &&
                   projectId == other.projectId &&
                   name == other.name &&
                   description == other.description &&
                   startDate == other.startDate &&
                   endDate == other.endDate &&
                   responsibleEmployeeId == other.responsibleEmployeeId;
        }

        public override int GetHashCode()
        {
            int hash = 17;
            hash = hash * 23 + taskId.GetHashCode();
            hash = hash * 23 + projectId.GetHashCode();
            hash = hash * 23 + name.GetHashCode();
            hash = hash * 23 + description.GetHashCode();
            hash = hash * 23 + startDate.GetHashCode();
            hash = hash * 23 + endDate.GetHashCode();
            hash = hash * 23 + responsibleEmployeeId.GetHashCode();
            return hash;
        }

        public override string ToString()
        {
            return string.Format("Task ID: {0}, Project ID: {1}, Name: {2}, Description: {3}, Start Date: {4}, End Date: {5}, Responsible Employee ID: {6}",
                taskId, projectId, name, description, startDate.ToShortDateString(), endDate.ToShortDateString(), responsibleEmployeeId);
        }
    }
}
