using MediatR;

namespace HRLeaveManagement.Application.Features.LeaveAllocation.Queries.GetLeaveAllocationDetails;

public record GetLeaveAllocationDetailQueryRequest(int Id) : IRequest<LeaveAllocationDetailDTO>;