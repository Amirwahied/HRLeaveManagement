using HRLeaveManagement.BlazorUI.Contracts;
using HRLeaveManagement.BlazorUI.Models.LeaveType;
using Microsoft.AspNetCore.Components;

namespace HRLeaveManagement.BlazorUI.Pages.LeaveTypes
{
    public partial class Create
    {
        [Inject]
        NavigationManager? _navManager { get; set; }
        [Inject]
        ILeaveTypeService? _client { get; set; }
        [Inject]
        public string? Message { get; private set; } = string.Empty;

        LeaveTypeVM leaveType = new() { Name = "Test", DefaultDays = 10 };
        async Task CreateLeaveType()
        {
            var response = await _client.CreateLeaveType(leaveType);
            if (response.IsSuccess)
            {
                _navManager.NavigateTo("/leavetypes/");
            }
            Message = response.Message;
        }
    }
}