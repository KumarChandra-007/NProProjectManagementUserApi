using System.ComponentModel.DataAnnotations;

namespace NproProjectManagement.Common.Models;
public partial class TaskManagement
{
    [Key]
    public int TaskId { get; set; }

    public string Title { get; set; } = null!;

    public string? Description { get; set; }

    public string Deadline { get; set; }

    public string Status { get; set; } = null!;

    public int ProjectId { get; set; }

    public bool? IsActive { get; set; }

    public DateTime CreatedOn { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public int? UpdatedBy { get; set; }
}
