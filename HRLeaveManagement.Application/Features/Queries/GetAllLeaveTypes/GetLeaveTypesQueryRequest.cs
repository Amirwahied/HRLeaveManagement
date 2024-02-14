
using MediatR;

namespace HRLeaveManagement.Application.Features.Queries.GetAllLeaveTypes;

public record GetLeaveTypesQueryRequest : IRequest<List<LeaveTypeDTO>>;
