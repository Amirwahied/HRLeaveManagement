using HRLeaveManagement.Application.Contracts.Persistence;
using HRLeaveManagement.Domain;
using Moq;

namespace HRLeaveManagement.Application.UnitTests.Mocks;

public static class MockLeaveTypeRepository
{
    public static Mock<ILeaveTypeRepository> GetMockLeaveTypeRepository()
    {
        var leaveTypes = new List<LeaveType>
            {
                new() {
                    Id = 1,
                    DefaultDays = 10,
                    Name = "Test Vacation"
                },
                new() {
                    Id = 2,
                    DefaultDays = 15,
                    Name = "Test Sick"
                },
                new() {
                    Id = 3,
                    DefaultDays = 15,
                    Name = "Test Maternity"
                }
            };
        var mockRepository = new Mock<ILeaveTypeRepository>();

        mockRepository.Setup(r => r.GetAsync()).ReturnsAsync(leaveTypes);

        mockRepository.Setup(r => r.CreateAsync(It.IsAny<LeaveType>())).Returns((LeaveType leaveType) =>
        {
            leaveTypes.Add(leaveType);
            return Task.CompletedTask;
        });

        return mockRepository;
    }
}
