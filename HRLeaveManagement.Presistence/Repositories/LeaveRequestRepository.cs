using HRLeaveManagement.Application.Contracts.Persistence;
using HRLeaveManagement.Domain;
using HRLeaveManagement.Presistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace HRLeaveManagement.Presistence.Repositories;

public class LeaveRequestRepository : GenericRepository<LeaveRequest>, ILeaveRequestRepository
{
    public LeaveRequestRepository(HrDatabaseContext context) : base(context)
    {

    }

    public async Task<List<LeaveRequest>> GetLeaveRequestsWithDetails()
    {
        return await _context.LeaveRequests
                             .Include(p => p.LeaveType)
                             .AsNoTracking()
                             .ToListAsync();
    }

    public async Task<LeaveRequest?> GetLeaveRequestWithDetails(int id)
    {
        return await _context.LeaveRequests
                             .Include(p => p.LeaveType)
                             .AsNoTracking()
                             .FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task<List<LeaveRequest>> GetLeaveRequestWithDetailsByEmployee(string employeeId)
    {
        return await _context.LeaveRequests
                             .Where(p => p.RequestingEmployeeId == employeeId)
                             .Include(p => p.LeaveType)
                             .AsNoTracking()
                             .ToListAsync();
    }
}

