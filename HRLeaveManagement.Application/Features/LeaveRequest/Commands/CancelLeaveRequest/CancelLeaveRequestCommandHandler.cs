using HRLeaveManagement.Application.Contracts.Email;
using HRLeaveManagement.Application.Contracts.Persistence;
using HRLeaveManagement.Application.Exceptions;
using HRLeaveManagement.Application.Models.Email;
using MediatR;

namespace HRLeaveManagement.Application.Features.LeaveRequest.Commands.CancelLeaveRequest;

public class CancelLeaveRequestCommandHandler : IRequestHandler<CancelLeaveRequestCommand, Unit>
{
    private readonly ILeaveRequestRepository _leaveRequestRepository;
    private readonly IEmailSender _emailSender;

    public CancelLeaveRequestCommandHandler(ILeaveRequestRepository leaveRequestRepository, IEmailSender emailSender)
    {
        this._leaveRequestRepository = leaveRequestRepository;
        this._emailSender = emailSender;
    }

    public async Task<Unit> Handle(CancelLeaveRequestCommand request, CancellationToken cancellationToken)
    {
        //Query the database for leave request
        var leaveRequest = await _leaveRequestRepository.GetByIdAsync(request.Id);

        // if null throw not found exception
        if (leaveRequest is null)
            throw new NotFoundException(nameof(leaveRequest), request.Id);

        // cancel leave request
        leaveRequest.Cancelled = true;

        //TODO: if already approved, re-evaluate the employee's allocations for the leave type

        // send confirmation email
        var email = new EmailMessage
        {
            //TODO: Get email of employee from employee record 
            To = string.Empty,
            Body = $"Your leave request for {leaveRequest.StartDate:D} to {leaveRequest.EndDate:D} " +
                    $"has been cancelled successfully.",
            Subject = "Leave Request Cancelled"
        };

        await _emailSender.SendEmailAsync(email);
        return Unit.Value;
    }
}

