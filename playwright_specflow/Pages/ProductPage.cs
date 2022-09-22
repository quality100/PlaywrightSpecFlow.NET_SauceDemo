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
    private ILocator cartIconBadge => _page.Locator("span.shopping_cart_badge");
    private ILocator addToCartButton_or_Remove => _page.Locator("//button[contains(@class, 'btn_inventory')]");
    
    public async Task<string> getProductLabel()
    {
        return await productLabel.InnerTextAsync();
    }
    public async Task<string> getProductPrice()
    {
        return await productPrice.InnerTextAsync();
    }
    public async Task<string> getProductDescription()
    {
        return await productDescription.InnerTextAsync();
    }
    public async Task clickCartIcon()
    {
        await cartIcon.ClickAsync();
    }
    public async Task clickAddtoCartButton()
    {
        await addToCartButton_or_Remove.ClickAsync();
    }
    public ILocator getCartBadge()
    {
        return cartIconBadge;
    }
    public async Task<string> getCartBadgeValue()
    {
        return await cartIconBadge.TextContentAsync();
    }

}