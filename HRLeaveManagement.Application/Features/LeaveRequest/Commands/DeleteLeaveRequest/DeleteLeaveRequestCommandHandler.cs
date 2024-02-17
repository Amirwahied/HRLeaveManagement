using HRLeaveManagement.Application.Contracts.Persistence;
using HRLeaveManagement.Application.Exceptions;
using MediatR;


namespace HRLeaveManagement.Application.Features.LeaveRequest.Commands.DeleteLeaveRequest;

public class DeleteLeaveRequestCommandHandler
{
    private readonly ILeaveRequestRepository _leaveRequestRepository;

    public DeleteLeaveRequestCommandHandler(ILeaveRequestRepository leaveRequestRepository)
    {
        _leaveRequestRepository = leaveRequestRepository;
    }

    public async Task<Unit> Handle(DeleteLeaveRequestCommand request, CancellationToken cancellationToken)
    {
        //Get leave request from DB
        var leaveRequest = await _leaveRequestRepository.GetByIdAsync(request.Id);

        //Throw error if request is null
        if (leaveRequest == null)
            throw new NotFoundException(nameof(LeaveRequest), request.Id);

        //Delete request from DB
        await _leaveRequestRepository.DeleteAsync(leaveRequest);

        //Return Unit Value
        return Unit.Value;
    }
}
