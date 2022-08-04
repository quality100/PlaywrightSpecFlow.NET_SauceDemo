using Microsoft.Playwright;

namespace PlaywrightSauceDemo.Pages;

public class LoginPage
{
    private IPage _page;
    public LoginPage(IPage page) => _page = page;
    private ILocator _usernameInput => _page.Locator("#user-name");
    private ILocator _passwordInput => _page.Locator("#password");
    private ILocator _loginButton => _page.Locator("#login-button");
    private ILocator _errorMessage => _page.Locator("//h3[@data-test='error']");
    private ILocator _closeErrorMessageButton => _page.Locator("//button[@class = 'error-button']");
    public  ILocator _errorMessagePoppup =>_page.Locator("//div[@class='error-message-container']");
    
    public async Task TypeUsername(string username) => await _usernameInput.FillAsync(username);
    public async Task TypePassword(string password) => await _passwordInput.FillAsync(password);
    public async Task ClickLoginButton() => await _loginButton.ClickAsync();
    public async Task ClickCloseErrorMessageButton() => await _closeErrorMessageButton.ClickAsync();

    public string? getInvalidCredentialsErrorMessage()
    {
        return _errorMessage.TextContentAsync().Result;
    }

    public async Task clearInputFields()
    {
       await _usernameInput.FillAsync("");
       await _passwordInput.FillAsync("");
    }

}