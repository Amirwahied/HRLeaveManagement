using AutoMapper;
using HRLeaveManagement.Application.Contracts.Email;
using HRLeaveManagement.Application.Contracts.Persistence;
using HRLeaveManagement.Application.Exceptions;
using HRLeaveManagement.Application.Models.Email;
using MediatR;

namespace HRLeaveManagement.Application.Features.LeaveRequest.Commands.CreateLeaveRequest;

public class CreateLeaveRequestCommandHandler : IRequestHandler<CreateLeaveRequestCommand, Unit>
{
    private readonly IEmailSender _emailSender;
    private readonly IMapper _mapper;
    private readonly ILeaveTypeRepository _leaveTypeRepository;
    private readonly ILeaveRequestRepository _leaveRequestRepository;

    public CreateLeaveRequestCommandHandler(
        IEmailSender emailSender,
        IMapper mapper,
        ILeaveTypeRepository leaveTypeRepository,
        ILeaveRequestRepository leaveRequestRepository)
    {
        _emailSender = emailSender;
        _mapper = mapper;
        this._leaveTypeRepository = leaveTypeRepository;
        this._leaveRequestRepository = leaveRequestRepository;
    }

    public async Task<Unit> Handle(CreateLeaveRequestCommand request, CancellationToken cancellationToken)
    {
        //Validate Data
        var validationResult = await new CreateLeaveRequestCommandValidator(_leaveTypeRepository).ValidateAsync(request);

        // If validation fails, throw an exception
        if (validationResult.Errors.Any())
            throw new BadRequestException("Invalid Leave Request", validationResult);

        //TODO: Get requesting employee's id

        //TODO: Check on employee's allocation

        //TODO: if allocations aren't enough, return validation error with message

        //Mapping Dto to entity
        var leaveRequest = _mapper.Map<Domain.LeaveRequest>(request);
        // Create leave request
        await _leaveRequestRepository.CreateAsync(leaveRequest);

        // send confirmation email
        var email = new EmailMessage
        {
            //TODO: Get email of employee from employee record 
            To = "mywindowsapplication@gmail.com",
            Body = $"Your leave request for {request.StartDate:D} to {request.EndDate:D} " +
                    $"has been submitted successfully.",
            Subject = "Leave Request Submitted"
        };

        await _emailSender.SendEmailAsync(email);

        return Unit.Value;
    }
}

