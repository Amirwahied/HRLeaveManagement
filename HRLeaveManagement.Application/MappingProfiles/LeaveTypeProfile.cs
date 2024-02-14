using AutoMapper;
using HRLeaveManagement.Application.Features.Queries.GetAllLeaveTypes;
using HRLeaveManagement.Application.Features.Queries.GetLeaveTypeDetails;
using HRLeaveManagement.Domain;


namespace HRLeaveManagement.Application.MappingProfiles;

public class LeaveTypeProfile : Profile
{
    public LeaveTypeProfile()
    {
        CreateMap<LeaveTypeDTO, LeaveType>().ReverseMap();
        CreateMap<LeaveType, LeaveTypeDetailsDTO>();
    }
}
