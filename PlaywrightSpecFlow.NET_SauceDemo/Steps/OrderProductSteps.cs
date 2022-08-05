using PlaywrightSauceDemo.Pages;
using SpecFlowSauceDemo_.NET.Drivers;

namespace PlaywrightSpecFlow.NET_SauceDemo.Steps;

[Binding]
public class OrderProductSteps
{
    private Driver _driver;
    public OrderProductSteps(Driver driver) => _driver = driver;
    private ProductsPage _productsPage => new ProductsPage(_driver.Page);
    
    [When(@"I select random product")]
    public async Task WhenISelectRandomProduct()
    {
        await _productsPage._randomProductLabel.ClickAsync();
    }
}