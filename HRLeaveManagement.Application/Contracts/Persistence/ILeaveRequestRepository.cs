using HRLeaveManagement.Domain;

namespace HRLeaveManagement.Application.Contracts.Persistence;

public interface ILeaveRequestRepository : IGenericRepository<LeaveRequest>
{
    Task<LeaveRequest?> GetLeaveRequestWithDetails(int id);
    Task<List<LeaveRequest>> GetLeaveRequestWithDetailsByEmployee(string employeeId);
    Task<List<LeaveRequest>> GetLeaveRequestsWithDetails();

}