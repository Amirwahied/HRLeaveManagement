using MediatR;

namespace HRLeaveManagement.Application.Features.LeaveType.Queries.GetLeaveTypeDetails;

public record GetLeaveTypeDetailsQueryRequest(int Id) : IRequest<LeaveTypeDetailsDTO>;
