using AutoMapper;
using HRLeaveManagement.Application.Contracts.Persistence;
using HRLeaveManagement.Application.Exceptions;
using MediatR;

namespace HRLeaveManagement.Application.Features.LeaveType.Command.CreateLeaveType;

public class CreateLeaveTypeCommandHandler : IRequestHandler<CreateLeaveTypeCommand, int>
{
    private readonly IMapper _mapper;
    private readonly ILeaveTypeRepository _leaveTypeRepository;

    public CreateLeaveTypeCommandHandler(IMapper mapper, ILeaveTypeRepository leaveTypeRepository)
    {
        _mapper = mapper;
        _leaveTypeRepository = leaveTypeRepository;
    }

    public async Task<int> Handle(CreateLeaveTypeCommand request, CancellationToken cancellationToken)
    {

        //TODO: Validate request
        var validateResult = await new CreateLeaveTypeCommandValidator(_leaveTypeRepository).ValidateAsync(request);

        if (validateResult.Errors.Any())
            throw new BadRequestException($"Invalid {nameof(Domain.LeaveType)}", validateResult);
        //Mapping to domain entity
        var leaveTypeToCreate = _mapper.Map<Domain.LeaveType>(request);
        //Add to database
        await _leaveTypeRepository.CreateAsync(leaveTypeToCreate);
        //return id
        return leaveTypeToCreate.Id;
    }
}
