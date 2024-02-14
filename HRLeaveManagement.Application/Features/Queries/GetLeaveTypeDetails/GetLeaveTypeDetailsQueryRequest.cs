using MediatR;

namespace HRLeaveManagement.Application.Features.Queries.GetLeaveTypeDetails;

public record GetLeaveTypeDetailsQueryRequest(int Id) : IRequest<LeaveTypeDetailsDTO>;
