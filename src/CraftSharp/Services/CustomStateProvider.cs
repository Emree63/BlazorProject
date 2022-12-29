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

        [CascadingParameter]
        public CurrentUser UserObject { get; set; }

        public CustomStateProvider(IAuthService authService)
        {
            this._authService = authService;
        }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var identity = new ClaimsIdentity();
            try
            {
                var userInfo = GetCurrentUser();
                if (userInfo.IsAuthenticated)
                {
                    var claims = new[] { new Claim(ClaimTypes.Name, UserObject.UserName) }.Concat(UserObject.Claims.Select(c => new Claim(c.Key, c.Value)));
                    identity = new ClaimsIdentity(claims, "Server authentication");
                }
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine("Request failed:" + ex);
            }

            return new AuthenticationState(new ClaimsPrincipal(identity));
        }

        public async Task Login(ConnexionModel loginParameters)
        {
            _authService.Login(loginParameters);
            // No error - Login the user
            CurrentUser user;
            user = _authService.GetUser(loginParameters.UserName);
            UserObject = user;
            Console.WriteLine("\t\tLOGIN: " + UserObject.UserName);
            NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
        }

        public async Task Logout()
        {

            UserObject = new CurrentUser();
            NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
        }

        public async Task Register(InscriptionModel registerParameters)
        {
            _authService.Register(registerParameters);

            // No error - Login the user
            var user = _authService.GetUser(registerParameters.UserName);
            UserObject = user;
            NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
        }

        public CurrentUser GetCurrentUser()
        {
            CurrentUser cacheUser;

            if (UserObject != null && UserObject.IsAuthenticated)
            {
                Console.WriteLine("Return user");
                return UserObject;
            }
            return new CurrentUser();
        }
    }
}
