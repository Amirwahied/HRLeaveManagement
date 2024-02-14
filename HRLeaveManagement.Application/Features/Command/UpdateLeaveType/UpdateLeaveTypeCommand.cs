using MediatR;

namespace HRLeaveManagement.Application.Features.Command.UpdateLeaveType;

public class UpdateLeaveTypeCommand : IRequest<Unit>
{
    public required string Name { get; set; }
    public int DefaultDays { get; set; }
}
