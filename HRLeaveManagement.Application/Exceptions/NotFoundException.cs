namespace HRLeaveManagement.Application.Exceptions;

public class NotFoundException : Exception
{
    public NotFoundException(string type, object key) : base($"{type} ({key}) was not found")
    {

    }
}
