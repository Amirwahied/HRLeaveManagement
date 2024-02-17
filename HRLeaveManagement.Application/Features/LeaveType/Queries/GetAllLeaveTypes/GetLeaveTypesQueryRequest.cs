using MediatR;

namespace HRLeaveManagement.Application.Features.LeaveType.Queries.GetAllLeaveTypes;

public record GetLeaveTypesQueryRequest : IRequest<List<LeaveTypeDTO>>;
