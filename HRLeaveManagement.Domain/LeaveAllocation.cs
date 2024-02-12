using HR.LeaveManagement.Domain.Common;
using HRLeaveManagement.Domain.Common;

namespace HRLeaveManagement.Domain;

public class LeaveAllocation : BaseEntity
{
    public LeaveType? LeaveType { get; set; }

    public int NumberOfDays { get; set; }

    public int LeaveTypeId { get; set; }

    public int Period { get; set; }
}
