
using AutoMapper;
using HRLeaveManagement.Application.Contracts.Logging;
using HRLeaveManagement.Application.Contracts.Persistence;
using MediatR;

namespace HRLeaveManagement.Application.Features.LeaveType.Queries.GetAllLeaveTypes;

public class GetLeaveTypesQueryRequestHandler : IRequestHandler<GetLeaveTypesQueryRequest, List<LeaveTypeDTO>>
{
    private readonly IMapper _mapper;
    private readonly ILeaveTypeRepository _leaveTypeRepository;
    private readonly IAppLogger<GetLeaveTypesQueryRequestHandler> _logger;

    public GetLeaveTypesQueryRequestHandler(IMapper mapper, ILeaveTypeRepository leaveTypeRepository,
        IAppLogger<GetLeaveTypesQueryRequestHandler> logger)
    {
        _mapper = mapper;
        _leaveTypeRepository = leaveTypeRepository;
        _logger = logger;
    }

    public async Task<List<LeaveTypeDTO>> Handle(GetLeaveTypesQueryRequest request, CancellationToken cancellationToken)
    {
        //Query data from database
        var leaveTypes = await _leaveTypeRepository.GetAsync();

        //Convert data to DTO
        var leaveTypesDto = _mapper.Map<List<LeaveTypeDTO>>(leaveTypes);

        //Log data
        _logger.LogInformation("Get leave types successfully");

        // return Data
        return leaveTypesDto;
    }
}
