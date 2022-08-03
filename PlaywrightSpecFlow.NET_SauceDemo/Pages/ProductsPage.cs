using Microsoft.Playwright;

namespace PlaywrightSauceDemo.Pages;

public class ProductsPage
{
    public string productsPageTitle = "PRODUCTS";
    private readonly IPage _page;
    private readonly ILocator _productsPageTitle;

    public ProductsPage(IPage page)
    {
        _page = page;
        _productsPageTitle = _page.Locator("//span[@class = 'title']");
    }

    public string getProductsPageTitle()
    {
        return _productsPageTitle.InnerTextAsync().Result;
    }
}