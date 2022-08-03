using Microsoft.Playwright;

namespace PlaywrightSauceDemo.Pages;

public class LoginPage
{
    private IPage _page;
    private readonly ILocator _usernameInput;
    private readonly ILocator _passwordInput;
    private readonly ILocator _loginButton;
    private readonly ILocator _errorMessage;
    private readonly ILocator _closeErrorMessageButton;
    public readonly ILocator _errorMessagePoppup;

    public readonly string invalidCredentialsErrorMessage =
        "Epic sadface: Username and password do not match any user in this service";
    
    public LoginPage(IPage page)
    {
        _page = page;
        _usernameInput = _page.Locator("#user-name");
        _passwordInput = _page.Locator("#password");
        _loginButton = _page.Locator("#login-button");
        _errorMessage = _page.Locator("//h3[@data-test='error']");
        _closeErrorMessageButton = _page.Locator("//button[@class = 'error-button']");
        _errorMessagePoppup = _page.Locator("//div[@class='error-message-container']");
    }

    public async Task TypeUsername(string username) => await _usernameInput.FillAsync(username);
    public async Task TypePassword(string password) => await _passwordInput.FillAsync(password);
    public async Task ClickLoginButton() => await _loginButton.ClickAsync();
    public async Task ClickCloseErrorMessageButton() => await _closeErrorMessageButton.ClickAsync();

    public string getInvalidCredentialsErrorMessage()
    {
        return _errorMessage.TextContentAsync().Result;
    }

    public async Task clearInputFields()
    {
       await _usernameInput.FillAsync("");
       await _passwordInput.FillAsync("");
    }

}