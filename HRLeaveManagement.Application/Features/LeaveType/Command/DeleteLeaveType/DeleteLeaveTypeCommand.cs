﻿using MediatR;

namespace HRLeaveManagement.Application.Features.LeaveType.Command.DeleteLeaveType;

public class DeleteLeaveTypeCommand : IRequest<Unit>
{
    public int Id { get; set; }
}
