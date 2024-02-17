using MediatR;

namespace HRLeaveManagement.Application.Features.LeaveAllocation.Queries.GetLeaveAllocations;

public record GetLeaveAllocationListQueryRequest : IRequest<IReadOnlyList<LeaveAllocationDTO>>;
