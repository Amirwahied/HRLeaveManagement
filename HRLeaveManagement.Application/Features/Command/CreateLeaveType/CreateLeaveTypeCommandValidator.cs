using FluentValidation;
using HRLeaveManagement.Application.Contracts.Persistence;

namespace HRLeaveManagement.Application.Features.Command.CreateLeaveType;

public class CreateLeaveTypeCommandValidator : AbstractValidator<CreateLeaveTypeCommand>
{
    private readonly ILeaveTypeRepository _leaveTypeRepository;

    public CreateLeaveTypeCommandValidator(ILeaveTypeRepository leaveTypeRepository)
    {
        _leaveTypeRepository = leaveTypeRepository;

        RuleFor(p => p.Name)
            .NotEmpty().NotNull().WithMessage("{PropertyName} is required.")
            .MaximumLength(70).WithMessage("{PropertyName} must not exceed 70 characters.")
            .MustAsync(LeaveTypeNameUnique).WithMessage("Leave type already exists.");

        RuleFor(p => p.DefaultDays)
            .GreaterThan(1).WithMessage("{PropertyName} must be greater than {ComparisonValue}.")
            .LessThan(100).WithMessage("{PropertyName} must be less than {ComparisonValue}.");
    }

    private async Task<bool> LeaveTypeNameUnique(string name, CancellationToken token)
    {
        return await _leaveTypeRepository.IsLeaveTypeUnique(name);
    }
}
