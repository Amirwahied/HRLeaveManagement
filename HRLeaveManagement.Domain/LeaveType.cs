using HRLeaveManagement.Domain.Common;

namespace HRLeaveManagement.Domain;

public class LeaveType : BaseEntity
{
    public required string Name { get; set; }
    public int DefaultDays { get; set; }
}
