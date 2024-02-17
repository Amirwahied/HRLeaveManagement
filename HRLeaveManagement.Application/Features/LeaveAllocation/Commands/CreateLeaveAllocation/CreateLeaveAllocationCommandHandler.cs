using AutoMapper;
using FluentValidation;
using HRLeaveManagement.Application.Contracts.Persistence;
using HRLeaveManagement.Application.Exceptions;
using MediatR;


namespace HRLeaveManagement.Application.Features.LeaveAllocation.Commands.CreateLeaveAllocation;

public class CreateLeaveAllocationCommandHandler : IRequestHandler<CreateLeaveAllocationCommand, Unit>
{
    private readonly IMapper _mapper;
    private readonly ILeaveAllocationRepository _leaveAllocationRepository;
    private readonly ILeaveTypeRepository _leaveTypeRepository;

    public CreateLeaveAllocationCommandHandler(IMapper mapper,
        ILeaveAllocationRepository leaveAllocationRepository,
        ILeaveTypeRepository leaveTypeRepository)
    {
        _mapper = mapper;
        _leaveAllocationRepository = leaveAllocationRepository;
        _leaveTypeRepository = leaveTypeRepository;
    }
    public async Task<Unit> Handle(CreateLeaveAllocationCommand request, CancellationToken cancellationToken)
    {
        //Validate Data
        var validateResult = await new CreateLeaveAllocationCommandValidator(_leaveTypeRepository).ValidateAsync(request);

        if (validateResult.Errors.Any())
            throw new BadRequestException("Invalid Leave Allocation Request", validateResult);

        // Get Leave type for allocations
        var leaveType = await _leaveTypeRepository.GetByIdAsync(request.LeaveTypeId);

        // Get Employees

        //Get Period

        //Mapping DTO to Entity
        var leaveAllocation = _mapper.Map<Domain.LeaveAllocation>(request);

        //Save Entity to Database
        await _leaveAllocationRepository.CreateAsync(leaveAllocation);

        //return Unit
        return Unit.Value;


    }
}
