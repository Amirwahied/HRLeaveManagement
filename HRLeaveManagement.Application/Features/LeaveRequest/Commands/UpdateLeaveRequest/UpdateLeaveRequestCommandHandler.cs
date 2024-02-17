
using AutoMapper;
using HRLeaveManagement.Application.Contracts.Email;
using HRLeaveManagement.Application.Contracts.Logging;
using HRLeaveManagement.Application.Contracts.Persistence;
using HRLeaveManagement.Application.Exceptions;
using HRLeaveManagement.Application.Models.Email;
using MediatR;

namespace HRLeaveManagement.Application.Features.LeaveRequest.Commands.UpdateLeaveRequest;

public class UpdateLeaveRequestCommandHandler : IRequestHandler<UpdateLeaveRequestCommand, Unit>
{
    private readonly IMapper _mapper;
    private readonly IEmailSender _emailSender;
    private readonly IAppLogger<UpdateLeaveRequestCommandHandler> _appLogger;
    private readonly ILeaveRequestRepository _leaveRequestRepository;
    private readonly ILeaveTypeRepository _leaveTypeRepository;

    public UpdateLeaveRequestCommandHandler(
         ILeaveRequestRepository leaveRequestRepository,
         ILeaveTypeRepository leaveTypeRepository,
         IMapper mapper,
         IEmailSender emailSender,
         IAppLogger<UpdateLeaveRequestCommandHandler> appLogger)
    {
        _leaveRequestRepository = leaveRequestRepository;
        _leaveTypeRepository = leaveTypeRepository;
        _mapper = mapper;
        this._emailSender = emailSender;
        this._appLogger = appLogger;
    }

    public async Task<Unit> Handle(UpdateLeaveRequestCommand request, CancellationToken cancellationToken)
    {
        //Query from DB
        var leaveRequest = await _leaveRequestRepository.GetByIdAsync(request.Id);

        //Check if null
        if (leaveRequest is null)
            throw new NotFoundException(nameof(LeaveRequest), request.Id);

        //Validate Data
        var validationResult = await new UpdateLeaveRequestCommandValidator(_leaveTypeRepository, _leaveRequestRepository).ValidateAsync(request);

        //Invalid Data
        if (validationResult.Errors.Any())
            throw new BadRequestException("Invalid Leave Request", validationResult);

        //Mapping
        _mapper.Map(request, leaveRequest);

        //Update Request
        await _leaveRequestRepository.UpdateAsync(leaveRequest);

        try
        {
            // send confirmation email
            var email = new EmailMessage
            {
                //TODO: Get email of employee from employee record 
                To = string.Empty,
                Body = $"Your leave request for {request.StartDate:D} to {request.EndDate:D} " +
                        $"has been updated successfully.",
                Subject = "Leave Request Updated"
            };

            await _emailSender.SendEmailAsync(email);
        }
        catch (Exception ex)
        {
            _appLogger.LogWarning(ex.Message);
        }

        return Unit.Value;
    }
}
