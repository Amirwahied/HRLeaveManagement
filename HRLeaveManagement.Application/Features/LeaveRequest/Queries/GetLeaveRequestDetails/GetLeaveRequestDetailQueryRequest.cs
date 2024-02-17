using MediatR;

namespace HRLeaveManagement.Application.Features.LeaveRequest.Queries.GetLeaveRequestDetails;

public record GetLeaveRequestDetailQueryRequest(int Id) : IRequest<LeaveRequestDetailDTO>;
