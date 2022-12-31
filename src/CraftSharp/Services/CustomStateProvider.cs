using CraftSharp.Models;
using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Components;
using Blazorise;
using Microsoft.JSInterop;
using Microsoft.Extensions.Caching.Memory;

namespace CraftSharp.Services
{
    public class CustomStateProvider : AuthenticationStateProvider
    {
        private readonly IAuthService _authService;
        private readonly ILogger<CustomStateProvider> _logger;

        private CurrentUser _currentUser { get; set; }

        public CustomStateProvider(IAuthService authService, ILogger<CustomStateProvider> logger)
        {
            this._authService = authService;
            this._logger = logger;
        }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var identity = new ClaimsIdentity();
            try
            {
                var userInfo = GetCurrentUser();
                if (userInfo.IsAuthenticated)
                {
                    var claims = new[] { new Claim(ClaimTypes.Name, _currentUser.UserName) }.Concat(_currentUser.Claims.Select(c => new Claim(c.Key, c.Value)));
                    identity = new ClaimsIdentity(claims, "Server authentication");
                }
            }
            catch (HttpRequestException ex)
            {
                _logger.Log(LogLevel.Error, $"Auth Request failed : {ex}");
            }

            return new AuthenticationState(new ClaimsPrincipal(identity));
        }

        public async Task Login(ConnexionModel loginParameters)
        {
            _authService.Login(loginParameters);
            // No error - Login the user
            CurrentUser user;
            user = _authService.GetUser(loginParameters.UserName);
            _currentUser = user;
            _logger.Log(LogLevel.Information, $"Login : {_currentUser.UserName}");
            NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
        }

        public async Task Logout()
        {
            _logger.Log(LogLevel.Information, $"Logout : {_currentUser.UserName}");
            _authService.Logout(_currentUser);
            _currentUser = new CurrentUser();
            NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
        }

        public async Task Register(InscriptionModel registerParameters)
        {
            _authService.Register(registerParameters);

            // No error - Login the user
            var user = _authService.GetUser(registerParameters.UserName);
            _currentUser = user;
            _logger.Log(LogLevel.Information, $"Register :  {_currentUser.UserName}");
            NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
        }

        public CurrentUser GetCurrentUser()
        {
            if (_currentUser != null && _currentUser.IsAuthenticated)
            {
                return _currentUser;
            }
            return new CurrentUser();
        }
    }
}
