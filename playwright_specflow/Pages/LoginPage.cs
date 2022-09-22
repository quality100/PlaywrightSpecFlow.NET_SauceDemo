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

    private string usernameInputSelector = "#user-name";
    private string passwordInputSelector = "#password";
    private string loginButtonSelector = "#login-button ";

    public async Task<ILocator> getUsernameInputLocator()
    {
        return _page.Locator(this.usernameInputSelector);
    }
    public ILocator getPasswordInputLocator()
    {
        return _page.Locator(passwordInputSelector);
    }
    public async Task<ILocator> getLoginBtnLocator()
    {
        return _page.Locator(this.loginButtonSelector);
    }
    public async Task loginBtnClickAsync()
    {
        await getLoginBtnLocator().Result.ClickAsync();
    }

    public async Task fillUsernameInputAsync(string username)
    {
        await getUsernameInputLocator().Result.FillAsync(username);
    }

    public async Task fillPasswordInputAsync(string password)
    {
        await getPasswordInputLocator().FillAsync(password);
    }
    
    public async Task<string?> getInvalidCredentialsErrorMessage()
    {
        return await _errorMessage.InnerTextAsync();
    }

    public async Task clearInputFields()
    {
       await _usernameInput.FillAsync("");
       await _passwordInput.FillAsync("");
    }

}