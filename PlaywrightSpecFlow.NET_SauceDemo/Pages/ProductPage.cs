using Microsoft.Playwright;

namespace PlaywrightSauceDemo.Pages;

public class ProductPage
{
    private IPage _page;
    public ProductPage(IPage page) => _page = page;
    private ILocator productLabel => _page.Locator(".inventory_details_name");
    private ILocator productPrice => _page.Locator(".inventory_details_price");
    private ILocator productDescription => _page.Locator(".inventory_details_desc");
    private ILocator cartIcon => _page.Locator(".shopping_cart_link");
    private ILocator addToCartButton => _page.Locator("#add-to-cart-sauce-labs-bike-light");
    
    public string getProductLabel()
    {
        return productLabel.InnerTextAsync().Result;
    }

    public string getProductPrice()
    {
        return productPrice.InnerTextAsync().Result;
    }

    public string getProductDescription()
    {
        return productDescription.InnerTextAsync().Result;
    }

    public async Task clickCartIcon()
    {
        await cartIcon.ClickAsync();
    }

    public async Task clickAddtoCartButton()
    {
        await addToCartButton.ClickAsync();
    }
}