namespace HRLeaveManagement.Application.Features.Queries.GetAllLeaveTypes;

public class LeaveTypeDTO
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public int DefaultDays { get; set; }
}
