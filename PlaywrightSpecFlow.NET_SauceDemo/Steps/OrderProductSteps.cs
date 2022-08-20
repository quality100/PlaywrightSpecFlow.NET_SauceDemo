using NUnit.Framework;
using PlaywrightSauceDemo.Pages;
using SpecFlowSauceDemo_.NET.Drivers;

namespace PlaywrightSpecFlow.NET_SauceDemo.Steps;

[Binding]
public class OrderProductSteps
{
    private Driver _driver;
    public OrderProductSteps(Driver driver) => _driver = driver;
    private ProductsPage _productsPage => new ProductsPage(_driver.Page);
    private ProductPage _productPage => new ProductPage(_driver.Page);
    
    [When(@"I select random product")]
    public async Task WhenISelectRandomProduct()
    {
        await _productsPage.setProductLabelText();
        await _productsPage.clickRandomElementLabel();
    }

    [Then(@"I verify (.*) on Products Page and Single Product Page are equal")]
    public void ThenIVerifyLabelOnProductsPageAndSingleProductPageAreEqual(string part)
    {
        switch (part.ToUpper())
        {
            case "LABEL":
                Assert.AreEqual(_productsPage.getProductLabelText(),_productPage.getProductLabel());
                break;
        }
    }
    
}