using System;
using System.Collections.Generic;

namespace NproProjectManagement.Common.Models;

public partial class Project
{
    public int ProjectId { get; set; }

    public string Title { get; set; } = null!;

    public string? Description { get; set; }

    public DateTime Deadline { get; set; }

    public DateTime StartDate { get; set; }

    public string Status { get; set; } = null!;

    //public bool? IsActive { get; set; }

    //public DateTime? CreatedOn { get; set; }

    //public int? CreatedBy { get; set; }

    //public DateTime? UpdatedAt { get; set; }

    //public int? UpdatedBy { get; set; }
}
