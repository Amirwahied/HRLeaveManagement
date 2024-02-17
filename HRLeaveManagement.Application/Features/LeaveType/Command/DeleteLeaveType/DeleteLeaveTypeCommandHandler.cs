using HRLeaveManagement.Application.Contracts.Persistence;
using HRLeaveManagement.Application.Exceptions;
using HRLeaveManagement.Domain;
using MediatR;

namespace HRLeaveManagement.Application.Features.LeaveType.Command.DeleteLeaveType;

public class DeleteLeaveTypeCommandHandler : IRequestHandler<DeleteLeaveTypeCommand, Unit>
{
    private readonly ILeaveTypeRepository _leaveTypeRepository;

    public DeleteLeaveTypeCommandHandler(ILeaveTypeRepository leaveTypeRepository)
    {
        _leaveTypeRepository = leaveTypeRepository;
    }

    public async Task<Unit> Handle(DeleteLeaveTypeCommand request, CancellationToken cancellationToken)
    {
        //Retrieve Domain entity object
        var leaveTypeToDelete = await _leaveTypeRepository.GetByIdAsync(request.Id)
                                //If record is null throw exception
                                ?? throw new NotFoundException(nameof(LeaveType), request.Id);

        //Remove record from database
        await _leaveTypeRepository.DeleteAsync(leaveTypeToDelete);

        //Return unit
        return Unit.Value;
    }
}
