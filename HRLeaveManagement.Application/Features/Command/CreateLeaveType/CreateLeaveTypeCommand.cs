using MediatR;

namespace HRLeaveManagement.Application.Features.Command.CreateLeaveType;

public class CreateLeaveTypeCommand : IRequest<int>
{
    public required string Name { get; set; }
    public int DefaultDays { get; set; }
}
