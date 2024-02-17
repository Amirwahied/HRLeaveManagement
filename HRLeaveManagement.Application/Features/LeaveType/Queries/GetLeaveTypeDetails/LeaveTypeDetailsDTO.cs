namespace HRLeaveManagement.Application.Features.LeaveType.Queries.GetLeaveTypeDetails;

public class LeaveTypeDetailsDTO
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public int DefaultDays { get; set; }
    public DateTime DateCreated { get; set; }
    public DateTime DateModified { get; set; }

}
