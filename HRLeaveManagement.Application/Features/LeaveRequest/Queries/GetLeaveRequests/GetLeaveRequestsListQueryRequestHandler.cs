using AutoMapper;
using HRLeaveManagement.Application.Contracts.Persistence;
using MediatR;

namespace HRLeaveManagement.Application.Features.LeaveRequest.Queries.GetLeaveRequests;

public class GetLeaveRequestsListQueryRequestHandler : IRequestHandler<GetLeaveRequestsListQueryRequest, IReadOnlyList<LeaveRequestListDTO>>
{
    private readonly IMapper _mapper;
    private readonly ILeaveRequestRepository _leaveRequestRepository;

    public GetLeaveRequestsListQueryRequestHandler(IMapper mapper, ILeaveRequestRepository leaveRequestRepository)
    {
        _mapper = mapper;
        _leaveRequestRepository = leaveRequestRepository;
    }
    public async Task<IReadOnlyList<LeaveRequestListDTO>> Handle(GetLeaveRequestsListQueryRequest request, CancellationToken cancellationToken)
    {
        //TODO: Check if it is logged in employee

        //Query Data
        var leaveRequests = await _leaveRequestRepository.GetLeaveRequestsWithDetails();
        //Mapping
        var leaveRequestDTOs = _mapper.Map<List<LeaveRequestListDTO>>(leaveRequests);

        //TODO: Fill requests with employee information

        //Return DTO
        return leaveRequestDTOs;
    }
}
