using HRLeaveManagement.Application.Contracts.Persistence;
using HRLeaveManagement.Domain;
using HRLeaveManagement.Presistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace HRLeaveManagement.Presistence.Repositories;

public class LeaveAllocationRepository : GenericRepository<LeaveAllocation>, ILeaveAllocationRepository
{
    public LeaveAllocationRepository(HrDatabaseContext context) : base(context)
    {
    }
    public async Task<List<LeaveAllocation>> GetLeaveAllocationsWithDetails()
    {
        return await _context.LeaveAllocations
                             .Include(p => p.LeaveType)
                             .AsNoTracking()
                             .ToListAsync();
    }

    public async Task<LeaveAllocation?> GetLeaveAllocationWithDetails(int id)
    {
        return await _context.LeaveAllocations
                             .Include(p => p.LeaveType)
                             .AsNoTracking()
                             .FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task<LeaveAllocation?> GetLeaveAllocationWithDetailsByEmployee(string employeeId)
    {
        return await _context.LeaveAllocations
                             .Include(p => p.LeaveType)
                             .AsNoTracking()
                             .FirstOrDefaultAsync(p => p.EmployeeId == employeeId);
    }
    public async Task<LeaveAllocation?> GetEmployeeAllocations(string employeeId, int leaveTypeId)
    {
        return await _context.LeaveAllocations
                             .Include(p => p.LeaveType)
                             .AsNoTracking()
                             .FirstOrDefaultAsync(p => p.EmployeeId == employeeId);
    }


    public async Task AddAllocations(List<LeaveAllocation> allocations)
    {
        await _context.AddRangeAsync(allocations);
    }

    public async Task<bool> AllocationExists(string employeeId, int leaveTypeId, int period)
    {
        return await _context.LeaveAllocations.AnyAsync(p =>
                                                        p.EmployeeId == employeeId &&
                                                        p.LeaveTypeId == leaveTypeId &&
                                                        p.Period == period);
    }

}

