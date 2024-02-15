using HRLeaveManagement.Domain;

namespace HRLeaveManagement.Application.Contracts.Persistence;

public interface ILeaveAllocationRepository : IGenericRepository<LeaveAllocation>
{
    Task<LeaveAllocation?> GetLeaveAllocationWithDetails(int id);
    Task<LeaveAllocation?> GetLeaveAllocationWithDetailsByEmployee(string employeeId);
    Task<List<LeaveAllocation>> GetLeaveAllocationsWithDetails();
    Task<LeaveAllocation?> GetEmployeeAllocations(string employeeId, int leaveTypeId);
    Task<bool> AllocationExists(string employeeId, int leaveTypeId, int period);
    Task AddAllocations(List<LeaveAllocation> allocations);
}