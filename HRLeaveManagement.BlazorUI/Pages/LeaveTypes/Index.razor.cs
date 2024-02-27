using HRLeaveManagement.BlazorUI.Contracts;
using HRLeaveManagement.BlazorUI.Models.LeaveType;
using Microsoft.AspNetCore.Components;

namespace HRLeaveManagement.BlazorUI.Pages.LeaveTypes
{
    public partial class Index
    {
        [Inject]
        public NavigationManager? NavigationManager { get; set; }

        [Inject]
        public required ILeaveTypeService LeaveTypeService { get; set; }
        [Inject]
        public required ILeaveAllocationService LeaveAllocationService { get; set; }

        public List<LeaveTypeVM>? LeaveTypes { get; private set; }
        public string? Message { get; set; }

        protected void CreateLeaveType()
        {
            NavigationManager?.NavigateTo("/leavetypes/create/");
        }

        protected void AllocateLeaveType(int id)
        {
            //TODO: Use Leave Allocation Service here
        }

        protected void EditLeaveType(int id)
        {
            NavigationManager?.NavigateTo($"/leavetypes/edit/{id}");
        }

        protected void DetailsLeaveType(int id)
        {
            NavigationManager?.NavigateTo($"/leavetypes/details/{id}");
        }

        protected async Task DeleteLeaveType(int id)
        {
            var response = await LeaveTypeService.DeleteLeaveType(id);
            if (response.IsSuccess)
            {
                await OnInitializedAsync();
            }
            else
            {
                Message = response.Message;
            }
        }

        protected override async Task OnInitializedAsync()
        {
            LeaveTypes = await LeaveTypeService.GetLeaveTypes();
        }


    }
}