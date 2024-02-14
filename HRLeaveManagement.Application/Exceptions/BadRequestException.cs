using FluentValidation.Results;

namespace HRLeaveManagement.Application.Exceptions;

public class BadRequestException : Exception
{
    public BadRequestException(string message, ValidationResult validationResult) : base(message)
    {
        foreach (var item in validationResult.Errors)
        {
            _errors.Add(item.ErrorMessage);
        }
    }

    List<string> _errors = new();
}
