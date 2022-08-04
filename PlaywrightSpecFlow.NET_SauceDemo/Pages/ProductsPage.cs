using Microsoft.Playwright;

namespace PlaywrightSauceDemo.Pages;

public class ProductsPage
{
    public string productsPageTitle = "PRODUCTS";
    
    private readonly IPage _page;
    public ProductsPage(IPage page) => _page = page;
    private ILocator _productsPageTitle => _page.Locator("//span[@class = 'title']");
    private ILocator _randomProductLabel => _page.Locator("(//div[@class = 'inventory_item_name'])["+ new Random().Next(1,7) +"]");
    private ILocator _productDescription => _page.Locator("//div[contains(text(), '" + getProductLabelText() +
                                                          "')]/ancestor::div[@class ='inventory_item_description']//div[@class = 'inventory_item_desc']");
    private ILocator _productLabels => _page.Locator("(//div[@class = 'inventory_item_name'])");
    public string getProductLabelText()
    {
        return _randomProductLabel.InnerTextAsync().Result;
    }

    public string getProductsPageTitle()
    {
        return _productsPageTitle.InnerTextAsync().Result;
    }
}