using AutoMapper;
using HRLeaveManagement.Application.Features.LeaveRequest.Commands.CreateLeaveRequest;
using HRLeaveManagement.Application.Features.LeaveRequest.Commands.UpdateLeaveRequest;
using HRLeaveManagement.Application.Features.LeaveRequest.Queries.GetLeaveRequestDetails;
using HRLeaveManagement.Application.Features.LeaveRequest.Queries.GetLeaveRequests;
using HRLeaveManagement.Domain;

namespace HRLeaveManagement.Application.MappingProfiles;
public class LeaveRequestProfile : Profile
{
    public LeaveRequestProfile()
    {
        CreateMap<LeaveRequestListDTO, LeaveRequest>().ReverseMap();
        CreateMap<LeaveRequestDetailDTO, LeaveRequest>().ReverseMap();
        //CreateMap<LeaveRequest, LeaveRequestDetailsDto>();
        CreateMap<CreateLeaveRequestCommand, LeaveRequest>();
        CreateMap<UpdateLeaveRequestCommand, LeaveRequest>();
    }
}
