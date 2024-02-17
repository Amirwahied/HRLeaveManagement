using AutoMapper;
using HRLeaveManagement.Application.Contracts.Email;
using HRLeaveManagement.Application.Contracts.Persistence;
using HRLeaveManagement.Application.Exceptions;
using HRLeaveManagement.Application.Models.Email;
using MediatR;

namespace HRLeaveManagement.Application.Features.LeaveRequest.Commands.ChangeLeaveRequestApproval;

public class ChangeLeaveRequestApprovalCommandHandler : IRequestHandler<ChangeLeaveRequestApprovalCommand, Unit>
{
    private readonly IMapper _mapper;
    private readonly IEmailSender _emailSender;
    private readonly ILeaveRequestRepository _leaveRequestRepository;
    private readonly ILeaveTypeRepository _leaveTypeRepository;

    public ChangeLeaveRequestApprovalCommandHandler(
         ILeaveRequestRepository leaveRequestRepository,
         ILeaveTypeRepository leaveTypeRepository,
         IMapper mapper,
         IEmailSender emailSender)
    {
        _leaveRequestRepository = leaveRequestRepository;
        _leaveTypeRepository = leaveTypeRepository;
        _mapper = mapper;
        this._emailSender = emailSender;
    }

    public async Task<Unit> Handle(ChangeLeaveRequestApprovalCommand request, CancellationToken cancellationToken)
    {
        //Query from DB
        var leaveRequest = await _leaveRequestRepository.GetByIdAsync(request.Id);

        //Check if null or not
        if (leaveRequest is null)
            throw new NotFoundException(nameof(LeaveRequest), request.Id);

        //Approve or Reject
        leaveRequest.Approved = request.Approved;
        //Update Request
        await _leaveRequestRepository.UpdateAsync(leaveRequest);

        //TODO: if request is approved, get and update the employee's allocations


        // send confirmation email
        var email = new EmailMessage
        {
            //TODO: Get email of employee from employee record 
            To = string.Empty,
            Body = $"The approval status for your leave request for {leaveRequest.StartDate:D} to {leaveRequest.EndDate:D} " +
                    $"has been updated.",
            Subject = "Leave Request Approval Status Updated"
        };

        await _emailSender.SendEmailAsync(email);

        return Unit.Value;
    }
}
