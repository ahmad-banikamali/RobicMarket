using System.Security.Claims;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using Newtonsoft.Json;

namespace AdminPanel.auth;

public class Authenticator:AuthenticationStateProvider
{
    private ProtectedLocalStorage  _protectedLocalStorage;

    public Authenticator(ProtectedLocalStorage protectedLocalStorage)
    {
        _protectedLocalStorage = protectedLocalStorage;
    }


    public override async Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        var principal = new ClaimsPrincipal();

        try
        {
            var storedPrincipal = await _protectedLocalStorage.GetAsync<string>("identity");

            if (storedPrincipal is { Success: true, Value: not null })
            {
                var user = JsonConvert.DeserializeObject<User>(storedPrincipal.Value);
                if (user != null)
                {
                    var (_, isLookUpSuccess) = LookUpUser(user.Username, user.Password);

                    if (isLookUpSuccess)
                    {
                        var identity = CreateIdentityFromUser(user);
                        principal = new(identity);
                    }
                }
            }
        }
        catch
        {
            // ignored
        }

        return new AuthenticationState(principal);
    }
    
    public async Task LoginAsync(User loginFormModel)
    {
        var (userInDatabase, isSuccess) = LookUpUser(loginFormModel.Username, loginFormModel.Password);
        var principal = new ClaimsPrincipal();

        if (isSuccess)
        {
            var identity = CreateIdentityFromUser(userInDatabase);
            principal = new ClaimsPrincipal(identity);
            await _protectedLocalStorage.SetAsync("identity", JsonConvert.SerializeObject(userInDatabase));
        }

        NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(principal)));
    }
    
    public async Task LogoutAsync()
    {
        await _protectedLocalStorage.DeleteAsync("identity");
        var principal = new ClaimsPrincipal();
        NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(principal)));
    }

    
    private static ClaimsIdentity CreateIdentityFromUser(User user)
    {
        return new ClaimsIdentity(new Claim[]
        {
            new (ClaimTypes.Name, user.Username),
            new (ClaimTypes.Hash, user.Password),
            new("age", "30")
        }, "ApplicationCookie");
    }

    public class User
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }

    private List<User> _users = new()
    {
        new(){Username = "admin",Password = "admin"},
        new(){Username = "user",Password = "user"},
    };
    
    
    private (User, bool) LookUpUser(string username, string password)
    {
        // var result = _users.FirstOrDefault(u => username == u.Username && password == u.Password);
        var result = _users.First();

        return (result, true);
    }
}