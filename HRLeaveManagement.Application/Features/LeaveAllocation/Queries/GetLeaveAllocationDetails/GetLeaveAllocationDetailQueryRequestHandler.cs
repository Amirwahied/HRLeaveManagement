using AutoMapper;
using HRLeaveManagement.Application.Contracts.Persistence;
using HRLeaveManagement.Application.Exceptions;
using MediatR;

namespace HRLeaveManagement.Application.Features.LeaveAllocation.Queries.GetLeaveAllocationDetails;

public class GetLeaveAllocationDetailQueryRequestHandler : IRequestHandler<GetLeaveAllocationDetailQueryRequest, LeaveAllocationDetailDTO>
{
    private readonly IMapper _mapper;
    private readonly ILeaveAllocationRepository _leaveAllocationRepository;

    public GetLeaveAllocationDetailQueryRequestHandler(IMapper mapper, ILeaveAllocationRepository leaveAllocationRepository)
    {
        _mapper = mapper;
        _leaveAllocationRepository = leaveAllocationRepository;
    }
    public async Task<LeaveAllocationDetailDTO> Handle(GetLeaveAllocationDetailQueryRequest request, CancellationToken cancellationToken)
    {
        //Query data from database
        var leaveAllocation = await _leaveAllocationRepository.GetLeaveAllocationWithDetails(request.Id);

        //Check if data is null
        if (leaveAllocation is null)
            throw new NotFoundException(nameof(leaveAllocation), request.Id);

        //Map data
        var leaveAllocationDetailDTO = _mapper.Map<LeaveAllocationDetailDTO>(leaveAllocation);

        //Return DTO
        return leaveAllocationDetailDTO;
    }
}
