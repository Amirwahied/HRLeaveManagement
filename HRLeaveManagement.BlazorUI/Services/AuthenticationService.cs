using Blazored.LocalStorage;
using HRLeaveManagement.BlazorUI.Contracts;
using HRLeaveManagement.BlazorUI.Models;
using HRLeaveManagement.BlazorUI.Providers;
using HRLeaveManagement.BlazorUI.Services.Base;
using Microsoft.AspNetCore.Components.Authorization;

namespace HRLeaveManagement.BlazorUI.Services
{
    public class AuthenticationService : BaseHttpService, IAuthenticationService
    {
        private readonly AuthenticationStateProvider _authenticationStateProvider;

        public AuthenticationService(IClient client,
            ILocalStorageService localStorage,
            AuthenticationStateProvider authenticationStateProvider) : base(client, localStorage)
        {
            _authenticationStateProvider = authenticationStateProvider;
        }

        public async Task<bool> Login(LoginVM login)
        {
            try
            {
                AuthRequest authResponse = new()
                {
                    Email = login.Email,
                    Password = login.Password
                };
                var authenticationResponse = await _client.LoginAsync(authResponse);
                if (authenticationResponse.Token is not null)
                {
                    await _localStorage.SetItemAsync("token", authenticationResponse.Token);
                    // Set claims in Blazor and login state
                    await ((ApiAuthenticationStateProvider)_authenticationStateProvider).LoggedIn();

                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task Logout()
        {
            await ((ApiAuthenticationStateProvider)_authenticationStateProvider).LoggedOut();
        }

        public async Task<bool> RegisterAsync(RegisterVM register)
        {
            var registrationRequest = new RegistrationRequest()
            {
                FirstName = register.FirstName,
                LastName = register.LastName,
                UserName = register.UserName,
                Email = register.Email,
                Password = register.Password
            };

            var registrationResponse = await _client.RegisterAsync(registrationRequest);

            if (!string.IsNullOrEmpty(registrationResponse.UserId))
            {
                return true;
            }
            return false;
        }
    }
}
