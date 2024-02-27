using HRLeaveManagement.BlazorUI.Models;

namespace HRLeaveManagement.BlazorUI.Contracts
{
    public interface IAuthenticationService
    {
        Task<bool> Login(LoginVM model);
        Task<bool> RegisterAsync(RegisterVM model);
        Task Logout();

    }
}
