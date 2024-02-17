using AutoMapper;
using HRLeaveManagement.Application.Contracts.Persistence;
using HRLeaveManagement.Application.Exceptions;
using MediatR;

namespace HRLeaveManagement.Application.Features.LeaveRequest.Queries.GetLeaveRequestDetails;

public class GetLeaveRequestDetailQueryRequestHandler : IRequestHandler<GetLeaveRequestDetailQueryRequest, LeaveRequestDetailDTO>
{
    private readonly IMapper _mapper;
    private readonly ILeaveRequestRepository _leaveRequestRepository;

    public GetLeaveRequestDetailQueryRequestHandler(IMapper mapper, ILeaveRequestRepository leaveRequestRepository)
    {
        _mapper = mapper;
        _leaveRequestRepository = leaveRequestRepository;
    }
    public async Task<LeaveRequestDetailDTO> Handle(GetLeaveRequestDetailQueryRequest request, CancellationToken cancellationToken)
    {
        //Query Leave Request from DB and Map to DTO
        var leaveRequest = _mapper.Map<LeaveRequestDetailDTO>(await _leaveRequestRepository.GetLeaveRequestWithDetails(request.Id));
        //Check if it is null
        if (leaveRequest is null)
            throw new NotFoundException(nameof(leaveRequest), request.Id);

        //TODO: Add Employee details as needed


        //Return DTO
        return leaveRequest;
    }
}
