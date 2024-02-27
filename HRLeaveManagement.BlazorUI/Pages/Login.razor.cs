using HRLeaveManagement.BlazorUI.Contracts;
using HRLeaveManagement.BlazorUI.Models;
using Microsoft.AspNetCore.Components;

namespace HRLeaveManagement.BlazorUI.Pages
{
    public partial class Login
    {
        public LoginVM Model { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }
        public string Message { get; set; }

        [Inject]
        private IAuthenticationService AuthenticationService { get; set; }

        public Login()
        {

        }

        protected override void OnInitialized()
        {
            Model = new LoginVM() { Email = string.Empty, Password = string.Empty };
        }

        protected async Task HandleLogin()
        {
            if (await AuthenticationService.Login(Model))
            {
                NavigationManager.NavigateTo("/");
            }
            Message = "Username/password combination unknown";
        }

    }
}