using NUnit.Framework;
using PlaywrightSauceDemo.Pages;
using SpecFlowSauceDemo_.NET.Drivers;

namespace PlaywrightSpecFlow.NET_SauceDemo.Steps;

[Binding]
public class ProductDescriptionSteps
{
    private Driver _driver;
    public ProductDescriptionSteps(Driver driver) => _driver = driver;
    private ProductsPage _productsPage => new ProductsPage(_driver.Page);
    private ProductDescriptionPage _productDescriptionPage => new ProductDescriptionPage(_driver.Page);
    
    [Then(@"I verify Product Description page is opened")]
    public async Task ThenIVerifyProductDescriptionPageIsOpened()
    {
       Assert.True(_productDescriptionPage.getBackToProductsBtn().GetAwaiter().GetResult().IsVisibleAsync().GetAwaiter().GetResult());
    }

    [Then(@"I verify Product description is the same as on Products Page")]
    public async Task ThenIVerifyProductDescriptionIsTheSameAsOnProductsPage()
    {
        Assert.AreEqual( _productsPage.getProductLabelText(), await _productDescriptionPage.getProductDescriptionText());
    }
}