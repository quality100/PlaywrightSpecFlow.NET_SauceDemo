using NUnit.Framework;
using PlaywrightSauceDemo.Pages;
using PlaywrightSpecFlow.NET_SauceDemo.Interfaces;
using SpecFlowSauceDemo_.NET.Drivers;
using TechTalk.SpecFlow.Assist;

namespace PlaywrightSpecFlow.NET_SauceDemo.Steps;

[Binding]
public class LoginTestSteps
{
    private Driver _driver;
    public LoginTestSteps(Driver driver) => _driver = driver;
    private LoginPage _loginPage => new LoginPage(_driver.Page);
    private ProductsPage _productsPage =>new ProductsPage(_driver.Page);
    

    [Given(@"I navigate to Sauce Demo")]
    public void GivenINavigateToSauceDemo()
    {
         _driver.Page.GotoAsync("https://www.saucedemo.com/");
    }

    [When(@"I enter following login details")]
    public async Task WhenIEnterFollowingLoginDetails(Table table)
    {
        dynamic data = table.CreateDynamicInstance();
        await _loginPage.TypeUsername((string)data.username);
        await _loginPage.TypePassword((string)data.password);
    }

    [When(@"I click Login button")]
    public async Task WhenIClickLoginButton()
    {
        await _loginPage.ClickLoginButton();
    }

    [Then(@"I verify Products page title is visible")]
    public async Task ThenIVerifyProductsPageTitleIsVisible()
    {
       Assert.AreEqual(_productsPage.productsPageTitle,  await _productsPage.getProductsPageTitle());
    }

   

    [When(@"I close error message")]
    public async Task WhenICloseErrorMessage()
    {
        await _loginPage.ClickCloseErrorMessageButton();
    }

    [Then(@"I verify error message not visible")]
    public async Task ThenIVerifyErrorMessageNotVisible()
    {
        Assert.IsTrue( await _loginPage._errorMessagePoppup.IsVisibleAsync());
        
    }

    [When(@"I clear username and password fields")]
    public async Task WhenIClearUsernameAndPasswordFields()
    {
        await _loginPage.clearInputFields();
    }

    [Then(@"I verify (.*) error message")]
    public void ThenIVerifyEmptyCredentialsErrorMessage(string messageType)
    {
        switch (messageType.ToUpper())
        {
            case "EMPTY CREDENTIALS":
                Assert.AreEqual(ErrorMessages_LoginPage.emptyUsernameErrorMessage, _loginPage.getInvalidCredentialsErrorMessage());
                break;
            case "INVALID CREDENTIALS":
                Assert.AreEqual(ErrorMessages_LoginPage.invalidCredentialsErrorMessage, _loginPage.getInvalidCredentialsErrorMessage());
                break;
            case "EMPTY PASSWORD":
                Assert.AreEqual(ErrorMessages_LoginPage.emptyPasswordErrorMessage, _loginPage.getInvalidCredentialsErrorMessage());
                break;
            default:
                Console.WriteLine("Verify error message!");
                break;
        }
    }

    [When(@"I successfully looged in")]
    public async Task WhenISuccessfullyLoogedIn(Table table)
    {
        await WhenIEnterFollowingLoginDetails(table);
        await WhenIClickLoginButton();
        //await _driver.Page.PauseAsync();
    }
}