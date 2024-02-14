using MediatR;

namespace HRLeaveManagement.Application.Features.Command.DeleteLeaveType;

public class DeleteLeaveTypeCommand : IRequest<Unit>
{
    public int Id { get; set; }
}
