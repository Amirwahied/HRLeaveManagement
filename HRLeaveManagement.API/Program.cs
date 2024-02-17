using HRLeaveManagement.Application;
using HRLeaveManagement.Presistence;
using HRLeaveManagement.Infrastructure;
using HRLeaveManagement.API.Middleware;

var builder = WebApplication.CreateBuilder(args);

//Add Projects services
builder.Services.AddApplicationServices()
                .AddPresistenceServices(builder.Configuration)
                .AddInfrastructureServices(builder.Configuration);

//Add CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("all", builder => builder.AllowAnyOrigin()
                                                    .AllowAnyMethod()
                                                    .AllowAnyHeader());
});

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseMiddleware<ExceptionMiddleware>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
