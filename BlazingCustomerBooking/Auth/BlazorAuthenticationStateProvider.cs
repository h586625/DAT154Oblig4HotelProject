using Library.Data;
using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;

namespace BlazingCustomerBooking.Auth
{
    public class BlazorAuthenticationStateProvider : AuthenticationStateProvider, IHostEnvironmentAuthenticationStateProvider
    {
        private dat154_2022_42Context _ctx;

        private ClaimsPrincipal AnonymousUser => new(new ClaimsIdentity(Array.Empty<Claim>()));
        private Task<AuthenticationState> _authenticationStateTask;

        public BlazorAuthenticationStateProvider(dat154_2022_42Context ctx)
        {
            _ctx = ctx;
        }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            if (_authenticationStateTask == null)
                return await Task.FromResult(new AuthenticationState(AnonymousUser));

            return await _authenticationStateTask;
        }

        public void SetAuthenticationState(Task<AuthenticationState> authenticationStateTask)
        {
            _authenticationStateTask = authenticationStateTask ?? throw new ArgumentNullException(nameof(authenticationStateTask));
            NotifyAuthenticationStateChanged(_authenticationStateTask);
        }

        private ClaimsPrincipal AsClaimsPrincipale(Library.Models.User user)
        {
            var claims = new[] {
                new Claim(ClaimTypes.Name, user.Name),
                new Claim(ClaimTypes.Role, "user"),
                new Claim("known_user", "known_user"),
            };
            var identity = new ClaimsIdentity(claims, "faked");
            return new ClaimsPrincipal(identity);
        }

        public bool SignIn(Library.Models.User user)
        {
            if (_ctx?.Users?.FirstOrDefault(x => x.Name == user.Name && x.Password == user.Password) != null)
            {
                var result = Task.FromResult(new AuthenticationState(AsClaimsPrincipale(user)));
                SetAuthenticationState(result);
                return true;
            }

            return false;
        }

        public void SignOut()
        {
            var result = Task.FromResult(new AuthenticationState(AnonymousUser));
            SetAuthenticationState(result);
        }
    }
}
