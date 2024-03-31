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
    }
}
