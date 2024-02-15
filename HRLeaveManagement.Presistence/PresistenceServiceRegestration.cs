using HRLeaveManagement.Application.Contracts.Persistence;
using HRLeaveManagement.Presistence.DatabaseContext;
using HRLeaveManagement.Presistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HRLeaveManagement.Presistence;

public static class PresistenceServiceRegestration
{
    public static IServiceCollection AddPresistenceServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<HrDatabaseContext>(options =>
        options.UseSqlServer(configuration.GetConnectionString("HrDatabaseConnectionString")));

        services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
        services.AddScoped<ILeaveTypeRepository, LeaveTypeRepository>();
        services.AddScoped<ILeaveRequestRepository, LeaveRequestRepository>();
        services.AddScoped<ILeaveAllocationRepository, LeaveAllocationRepository>();

        return services;
    }
}
