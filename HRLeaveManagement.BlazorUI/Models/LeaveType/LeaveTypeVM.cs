using System.ComponentModel.DataAnnotations;

namespace HRLeaveManagement.BlazorUI.Models.LeaveType
{
    public class LeaveTypeVM
    {
        public int Id { get; set; }

        public required string Name { get; set; }

        [Display(Name = "Default Number Of Days")]
        public required int DefaultDays { get; set; }
    }
}
