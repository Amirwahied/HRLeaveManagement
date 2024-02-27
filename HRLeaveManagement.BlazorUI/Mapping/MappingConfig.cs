using AutoMapper;
using HRLeaveManagement.BlazorUI.Models.LeaveType;
using HRLeaveManagement.BlazorUI.Services.Base;

namespace HRLeaveManagement.BlazorUI.Mapping
{
    public class MappingConfig : Profile
    {
        public MappingConfig()
        {
            CreateMap<LeaveTypeVM, LeaveTypeDTO>().ReverseMap();
            CreateMap<LeaveTypeVM, LeaveTypeDetailsDTO>().ReverseMap();
            CreateMap<LeaveTypeVM, CreateLeaveTypeCommand>().ReverseMap();
            CreateMap<LeaveTypeVM, UpdateLeaveTypeCommand>().ReverseMap();
        }
    }
}
