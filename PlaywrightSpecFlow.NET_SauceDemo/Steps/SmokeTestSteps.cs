using PlaywrightSauceDemo.Pages;
using SpecFlowSauceDemo_.NET.Drivers;
using TechTalk.SpecFlow.Assist;

namespace PlaywrightSpecFlow.NET_SauceDemo.Steps;

[Binding]
public class SmokeTestSteps
{
    private readonly Driver _driver;
    private readonly LoginPage _loginPage;
    
    public SmokeTestSteps(Driver driver)
    {
        _driver = driver;
        _loginPage = new LoginPage(_driver.Page);
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
}