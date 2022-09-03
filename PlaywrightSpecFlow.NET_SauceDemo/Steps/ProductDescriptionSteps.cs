using NUnit.Framework;
using PlaywrightSauceDemo.Pages;
using SpecFlowSauceDemo_.NET.Drivers;

namespace PlaywrightSpecFlow.NET_SauceDemo.Steps;

[Binding]
public class ProductDescriptionSteps
{
    private Driver _driver;
    private ScenarioContext _scenarioContext;
    public ProductDescriptionSteps(Driver driver, ScenarioContext scenarioContext)
    {
        _driver = driver;
        _scenarioContext = scenarioContext;
    } 
    private ProductsPage _productsPage => new ProductsPage(_driver.Page, _scenarioContext);
    private ProductDescriptionPage _productDescriptionPage => new ProductDescriptionPage(_driver.Page);
    
    [Then(@"I verify Product Description page is opened")]
    public async Task ThenIVerifyProductDescriptionPageIsOpened()
    {
       Assert.True(await _productDescriptionPage.getBackToProductsBtn().GetAwaiter().GetResult().IsVisibleAsync());
    }

    [Then(@"I verify Product description is the same as on Products Page")]
    public async Task ThenIVerifyProductDescriptionIsTheSameAsOnProductsPage()
    {
        Assert.AreEqual( _productsPage.getProductLabelText(), await _productDescriptionPage.getProductDescriptionText());
    }
}