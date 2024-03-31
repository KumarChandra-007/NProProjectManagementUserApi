namespace NproProjectManagement.Common.Models;
public partial class UserProjectMapping
{
    public int MappingId { get; set; }

    public int ProjectId { get; set; }

    public int UserId { get; set; }

    public bool? IsActive { get; set; }

    public DateTime CreatedOn { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public int? UpdatedBy { get; set; }
}
