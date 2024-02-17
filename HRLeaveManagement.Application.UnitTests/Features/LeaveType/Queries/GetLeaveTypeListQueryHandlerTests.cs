using AutoMapper;
using HRLeaveManagement.Application.Contracts.Logging;
using HRLeaveManagement.Application.Contracts.Persistence;
using HRLeaveManagement.Application.Features.LeaveType.Queries.GetAllLeaveTypes;
using HRLeaveManagement.Application.MappingProfiles;
using HRLeaveManagement.Application.UnitTests.Mocks;
using Moq;
using Shouldly;


namespace HRLeaveManagement.Application.UnitTests.Features.LeaveType.Queries;

public class GetLeaveTypeListQueryHandlerTests
{
    private readonly IMapper _mapper;
    private readonly Mock<ILeaveTypeRepository> _mockLeaveTypeRepository;
    private readonly Mock<IAppLogger<GetLeaveTypesQueryRequestHandler>> _mockAppLogger;

    public GetLeaveTypeListQueryHandlerTests()
    {
        _mockLeaveTypeRepository = MockLeaveTypeRepository.GetMockLeaveTypeRepository();
        _mockAppLogger = new Mock<IAppLogger<GetLeaveTypesQueryRequestHandler>>();

        var mapperConfig = new MapperConfiguration(c =>
        {
            c.AddProfile<LeaveTypeProfile>();
        });

        _mapper = mapperConfig.CreateMapper();
    }


    [Fact]
    public async Task GetLeaveTypeListTest()
    {
        var handler = new GetLeaveTypesQueryRequestHandler(_mapper, _mockLeaveTypeRepository.Object, _mockAppLogger.Object);

        var result = await handler.Handle(new GetLeaveTypesQueryRequest(), CancellationToken.None);

        result.ShouldBeOfType<List<LeaveTypeDTO>>()
              .Count.ShouldBe(3);

    }
}
