using Microsoft.Playwright;

namespace PlaywrightSauceDemo.Pages;

public class CartPage
{
    private IPage _page;

    public CartPage(IPage page) => _page = page;
    private ILocator CartPageTitle => _page.Locator("span.title");


    public async Task<ILocator> getCartPageTitle()
    {
        return CartPageTitle;
    }
}