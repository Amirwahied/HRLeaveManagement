
using AutoMapper;
using HRLeaveManagement.Application.Contracts.Persistence;
using HRLeaveManagement.Application.Exceptions;
using HRLeaveManagement.Domain;
using MediatR;

namespace HRLeaveManagement.Application.Features.LeaveType.Queries.GetLeaveTypeDetails;

public class GetLeaveTypeDetailsRequestHandler : IRequestHandler<GetLeaveTypeDetailsQueryRequest, LeaveTypeDetailsDTO>
{
    private readonly IMapper _mapper;
    private readonly ILeaveTypeRepository _leaveTypeRepository;

    public GetLeaveTypeDetailsRequestHandler(IMapper mapper, ILeaveTypeRepository leaveTypeRepository)
    {
        _mapper = mapper;
        _leaveTypeRepository = leaveTypeRepository;
    }
    public async Task<LeaveTypeDetailsDTO> Handle(GetLeaveTypeDetailsQueryRequest request, CancellationToken cancellationToken)
    {
        //Query data from database
        var leaveType = await _leaveTypeRepository.GetByIdAsync(request.Id)
                        //If record is null throw exception
                        ?? throw new NotFoundException(nameof(LeaveType), request.Id);


        //Mapping
        var leaveTypeDetails = _mapper.Map<LeaveTypeDetailsDTO>(leaveType);

        //Return data
        return leaveTypeDetails;
    }
}
