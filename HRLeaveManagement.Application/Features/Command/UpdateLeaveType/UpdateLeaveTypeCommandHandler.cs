﻿using AutoMapper;
using HRLeaveManagement.Application.Contracts.Logging;
using HRLeaveManagement.Application.Contracts.Persistence;
using HRLeaveManagement.Application.Exceptions;
using HRLeaveManagement.Application.Features.Command.CreateLeaveType;
using HRLeaveManagement.Domain;
using MediatR;

namespace HRLeaveManagement.Application.Features.Command.UpdateLeaveType;

public class UpdateLeaveTypeCommandHandler : IRequestHandler<UpdateLeaveTypeCommand, Unit>
{
    private readonly IMapper _mapper;
    private readonly ILeaveTypeRepository _leaveTypeRepository;
    private readonly IAppLogger<UpdateLeaveTypeCommandHandler> _logger;

    public UpdateLeaveTypeCommandHandler(IMapper mapper, ILeaveTypeRepository leaveTypeRepository,
        IAppLogger<UpdateLeaveTypeCommandHandler> logger)
    {
        _mapper = mapper;
        _leaveTypeRepository = leaveTypeRepository;
        _logger = logger;
    }

    public async Task<Unit> Handle(UpdateLeaveTypeCommand request, CancellationToken cancellationToken)
    {
        //Validate incming data
        var validationResult = await new UpdateLeaveTypeCommandValidator(_leaveTypeRepository).ValidateAsync(request);

        if (validationResult.Errors.Any())
        {
            _logger.LogWarning("Validation errors in update request for {0} - {1}", nameof(LeaveType), request.Id);
            throw new BadRequestException($"Invalid {nameof(LeaveType)}", validationResult);
        }
        //Mapping to Domain
        var leaveTypeToUpdate = _mapper.Map<Domain.LeaveType>(request);

        //Update database
        await _leaveTypeRepository.UpdateAsync(leaveTypeToUpdate);

        //retur unit
        return Unit.Value;
    }
}
