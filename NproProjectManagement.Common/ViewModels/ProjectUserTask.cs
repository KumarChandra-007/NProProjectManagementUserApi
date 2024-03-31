using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NproProjectManagement.Common.ViewModels
{
    public class ProjectUserTask
    {
        public int ProjectId { get; set; }

        public string Title { get; set; }

        public int UserCount { get; set; }

        public int TaskCount { get; set; }

        public string StatusPercentage { get; set; }

    }

    public class AllProjectInfo
    {
        public int AllProjectCount { get; set; }

        public int AllTaskCount { get; set; }

        public int CompletedTaskCount { get; set; }

        public int PendingTaskCount { get; set; }

        public List<ProjectUserTask> ProjectUserTaskGridInfo = new List<ProjectUserTask>();
    }
}
