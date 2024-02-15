using FluentValidation;
using HRLeaveManagement.Application.Contracts.Persistence;

namespace HRLeaveManagement.Application.Features.Command.UpdateLeaveType;

public class UpdateLeaveTypeCommandValidator : AbstractValidator<UpdateLeaveTypeCommand>
{
    private readonly ILeaveTypeRepository _leaveTypeRepository;

    public UpdateLeaveTypeCommandValidator(ILeaveTypeRepository leaveTypeRepository)
    {
        _leaveTypeRepository = leaveTypeRepository;

        RuleFor(x => x.Id)
            .NotNull()
            .MustAsync(LeaveTypeMustExist);

        RuleFor(x => x.Name)
            .NotNull().NotEmpty().WithMessage("{PropertyName} is required.")
            .MaximumLength(70).WithMessage("{PropertyName} must not exceed {MaxLength} characters.")
            .MustAsync(LeaveTypeNameUnique);

        RuleFor(p => p.DefaultDays)
            .GreaterThan(1).WithMessage("{PropertyName} must be greater than {ComparisonValue}.")
            .LessThan(100).WithMessage("{PropertyName} must be less than {ComparisonValue}.");

    }

    private async Task<bool> LeaveTypeMustExist(int id, CancellationToken token)
    {
        var leaveType = await _leaveTypeRepository.GetByIdAsync(id);
        return leaveType is not null;
    }
    private async Task<bool> LeaveTypeNameUnique(string name, CancellationToken token)
    {
        return await _leaveTypeRepository.IsLeaveTypeUnique(name);
    }
}
