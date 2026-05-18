using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;

namespace ELGlamPOS.Services
{
    public class LocalAuthenticationStateProvider : AuthenticationStateProvider, IDisposable
    {
        private readonly PosSessionState _sessionState;

        public LocalAuthenticationStateProvider(PosSessionState sessionState)
        {
            _sessionState = sessionState;
            _sessionState.OnChange += StateChanged;
        }

        public override Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            if (_sessionState.CurrentUser == null)
            {
                // Unauthenticated
                return Task.FromResult(new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity())));
            }

            // Authenticated
            var identity = new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.NameIdentifier, _sessionState.CurrentUser.Id),
                new Claim(ClaimTypes.Name, _sessionState.CurrentUser.Email ?? string.Empty),
                new Claim("EmployeeId", _sessionState.CurrentEmployeeId.ToString() ?? string.Empty)
            }, "LocalAuth");

            var user = new ClaimsPrincipal(identity);
            return Task.FromResult(new AuthenticationState(user));
        }

        private void StateChanged()
        {
            NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
        }

        public void Dispose()
        {
            _sessionState.OnChange -= StateChanged;
        }
    }
}
