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
    private ScenarioContext _scenarioContext;

    public LoginTestSteps(Driver driver, ScenarioContext scenarioContext)
    {
        _scenarioContext = scenarioContext;
        _driver = driver;
    }

    private LoginPage _loginPage => new LoginPage(_driver.Page);
    private ProductsPage _productsPage =>new ProductsPage(_driver.Page, _scenarioContext);
    

    [Given(@"I navigate to Sauce Demo")]
    public void GivenINavigateToSauceDemo()
    {
         _driver.Page.GotoAsync(ReadProperties.GetInstance().GetBaseURL());
    }

    [When(@"I enter following login details")]
    public async Task WhenIEnterFollowingLoginDetails(Table table)
    {
        dynamic data = table.CreateDynamicInstance();
        await _loginPage.TypeUsername((string)data.username);
        await _loginPage.TypePassword((string)data.password);
    }
    [When(@"I enter following login details from file")]
    public async Task EnterLoginDetailsFromFile()
    {
        await _loginPage.TypeUsername(ReadProperties.GetInstance().GetUsername());
        await _loginPage.TypePassword(ReadProperties.GetInstance().GetPassword());
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

    [When(@"I successfully logged in")]
    public async Task WhenISuccessfullyLoggedIn()
    {
        await EnterLoginDetailsFromFile();
        await _driver.Page.PauseAsync();
        await WhenIClickLoginButton();
       // await _driver.Page.PauseAsync();
    }

    [When(@"I enter following login details --new design")]
    public async Task WhenIEnterFollowingLoginDetailsNewDesign(Table table)
    {
       await _loginPage.fillUsernameInputAsync(table.Rows[0]["username"]);
       await _loginPage.fillPasswordInputAsync(table.Rows[0]["password"]);
       await _loginPage.loginBtnClickAsync();
    }
}