using NUnit.Framework;
using PlaywrightSauceDemo.Pages;
using SpecFlowSauceDemo_.NET.Drivers;
using TechTalk.SpecFlow.Assist;

namespace PlaywrightSpecFlow.NET_SauceDemo.Steps;

[Binding]
public class SmokeTestSteps
{
    private readonly Driver _driver;
    private readonly LoginPage _loginPage;
    private readonly ProductsPage _productsPage;
    
    public SmokeTestSteps(Driver driver)
    {
        _driver = driver;
        _loginPage = new LoginPage(_driver.Page);
        _productsPage = new ProductsPage(_driver.Page);
    }
    
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
    public void ThenIVerifyProductsPageTitleIsVisible()
    {
        Assert.AreEqual(_productsPage.productsPageTitle,_productsPage.getProductsPageTitle());
    }

    [Then(@"I verify invalid credentials error message")]
    public void ThenIVerifyInvalidCredentialsErrorMessage()
    {
        Assert.AreEqual(_loginPage.invalidCredentialsErrorMessage, _loginPage.getInvalidCredentialsErrorMessage());
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
}