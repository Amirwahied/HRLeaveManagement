using MediatR;

namespace HRLeaveManagement.Application.Features.LeaveRequest.Queries.GetLeaveRequests;

public record GetLeaveRequestsListQueryRequest : IRequest<IReadOnlyList<LeaveRequestListDTO>>;