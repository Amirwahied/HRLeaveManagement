using AutoMapper;
using HRLeaveManagement.Application.Contracts.Persistence;
using MediatR;

namespace HRLeaveManagement.Application.Features.LeaveAllocation.Queries.GetLeaveAllocations;

public class GetLeaveAllocationListQueryRequestHandler : IRequestHandler<GetLeaveAllocationListQueryRequest, IReadOnlyList<LeaveAllocationDTO>>
{
    private readonly IMapper _mapper;
    private readonly ILeaveAllocationRepository _leaveAllocationRepository;

    public GetLeaveAllocationListQueryRequestHandler(IMapper mapper, ILeaveAllocationRepository leaveAllocationRepository)
    {
        _mapper = mapper;
        _leaveAllocationRepository = leaveAllocationRepository;
    }
    public async Task<IReadOnlyList<LeaveAllocationDTO>> Handle(GetLeaveAllocationListQueryRequest request, CancellationToken cancellationToken)
    {
        // TODO:
        // - Get records for specific user
        // - Get allocations per employee

        //Query from database
        var result = await _leaveAllocationRepository.GetLeaveAllocationsWithDetails();
        //Map to DTO
        var leaveAllocationDTOs = _mapper.Map<List<LeaveAllocationDTO>>(result);
        //Return DTO
        return leaveAllocationDTOs;
    }
}
