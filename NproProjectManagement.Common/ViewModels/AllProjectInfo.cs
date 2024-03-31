namespace NproProjectManagement.Common.ViewModels
{
    public class AllProjectInfo
    {
        public int AllProjectCount { get; set; }

        public int AllTaskCount { get; set; }

        public int CompletedTaskCount { get; set; }

        public int PendingTaskCount { get; set; }

        public List<ProjectUserTask> ProjectUserTaskGridInfo = new List<ProjectUserTask>();
    }
}
