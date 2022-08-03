using Microsoft.Playwright;

namespace PlaywrightSauceDemo.Pages;

public class LoginPage
{
    private IPage _page;
    private readonly ILocator _usernameInput;
    private readonly ILocator _passwordInput;
    private readonly ILocator _loginButton;
    
    public LoginPage(IPage page)
    {
        _page = page;
        _usernameInput = _page.Locator("#user-name");
        _passwordInput = _page.Locator("#password");
        _loginButton = _page.Locator("#login-button");
    }

    public async Task TypeUsername(string username) => await _usernameInput.TypeAsync(username);
    public async Task TypePassword(string password) => await _passwordInput.TypeAsync(password);
    public async Task ClickLoginButton() => await _loginButton.ClickAsync();
    
}