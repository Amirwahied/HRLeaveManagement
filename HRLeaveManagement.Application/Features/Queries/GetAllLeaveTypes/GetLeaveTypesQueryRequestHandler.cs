
using AutoMapper;
using HRLeaveManagement.Application.Contracts.Persistence;
using MediatR;

namespace HRLeaveManagement.Application.Features.Queries.GetAllLeaveTypes;

public class GetLeaveTypesQueryRequestHandler : IRequestHandler<GetLeaveTypesQueryRequest, List<LeaveTypeDTO>>
{
    private readonly IMapper _mapper;
    private readonly ILeaveTypeRepository _leaveTypeRepository;

    public GetLeaveTypesQueryRequestHandler(IMapper mapper, ILeaveTypeRepository leaveTypeRepository)
    {
        _mapper = mapper;
        _leaveTypeRepository = leaveTypeRepository;
    }

    public async Task<List<LeaveTypeDTO>> Handle(GetLeaveTypesQueryRequest request, CancellationToken cancellationToken)
    {
        //Query data from database
        var leaveTypes = await _leaveTypeRepository.GetAsync();

        //Convert data to DTO
        var leaveTypesDto = _mapper.Map<List<LeaveTypeDTO>>(leaveTypes);

        // return Data
        return leaveTypesDto;
    }
}
