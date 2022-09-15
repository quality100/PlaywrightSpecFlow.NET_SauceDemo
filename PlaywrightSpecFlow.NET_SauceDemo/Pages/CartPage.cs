using Microsoft.Playwright;

namespace PlaywrightSauceDemo.Pages;

public class CartPage
{
    private IPage _page;

    public CartPage(IPage page) => _page = page;
    private ILocator CartPageTitle => _page.Locator("span.title");
    private ILocator CartPageProductLabel => _page.Locator("div.inventory_item_name");
    private ILocator CartPageProductDescription => _page.Locator("div.inventory_item_desc");
    private ILocator CartPageProductPrice => _page.Locator("div.inventory_item_price");
    private ILocator CartPageCheckoutBtn => _page.Locator("button#checkout");
    
    public async Task<string> GetProductLabelTextCartPageAsync()
    {
        return await CartPageProductLabel.InnerTextAsync();
    }
    public async Task<string> GetProductDescriptionTextCartPageAsync()
    {
        return await CartPageProductDescription.InnerTextAsync();
    }
    public async Task<string> GetProductPriceTextCartPageAsync()
    {
        return await CartPageProductPrice.InnerTextAsync();
    }
    public ILocator getCartPageTitle()
    {
        return CartPageTitle;
    }
    public ILocator getCartPageCheckoutBtn()
    {
        return CartPageCheckoutBtn;
    }
}