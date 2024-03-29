﻿

using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace HRLeaveManagement.Application;

public static class ApplicationServiceRegestration
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddMediatR(opt => opt.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
        return services;
    }
}
