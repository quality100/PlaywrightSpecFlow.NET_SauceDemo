using Microsoft.Playwright;

namespace PlaywrightSauceDemo.Pages;

public class ProductsPage
{
    public string productsPageTitle = "PRODUCTS";
    
    private readonly IPage _page;
    public ProductsPage(IPage page) => _page = page;
    private ILocator _productsPageTitle => _page.Locator("//span[@class = 'title']");
    

    public string getProductsPageTitle()
    {
        return _productsPageTitle.InnerTextAsync().Result;
    }
}