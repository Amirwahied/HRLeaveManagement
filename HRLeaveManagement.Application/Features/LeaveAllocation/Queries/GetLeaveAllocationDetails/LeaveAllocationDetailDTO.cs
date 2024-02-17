using HRLeaveManagement.Application.Features.LeaveType.Queries.GetAllLeaveTypes;

namespace HRLeaveManagement.Application.Features.LeaveAllocation.Queries.GetLeaveAllocationDetails;

public class LeaveAllocationDetailDTO
{
    public int Id { get; set; }
    public required LeaveTypeDTO LeaveType { get; set; }
    public int LeaveTypeId { get; set; }
    public int Period { get; set; }
    public int NumberOfDays { get; set; }
    public DateTime DateCreated { get; set; }
    public DateTime DateModified { get; set; }
}
