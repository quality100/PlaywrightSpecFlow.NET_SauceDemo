using Microsoft.Playwright;

namespace PlaywrightSauceDemo.Pages;

public class ProductDescriptionPage
{
    private IPage _page;
    public ProductDescriptionPage(IPage page) => _page = page;
    private ILocator productLabel => _page.Locator(".inventory_details_name.large_size");
    private ILocator elementDescription => _page.Locator(".inventory_details_desc");
    private ILocator backToProductsBtn => _page.Locator("//button[contains(text(),'Back to products')]");

    public async Task<string> getProductLabelText()
    {
        return  productLabel.TextContentAsync().GetAwaiter().GetResult().Trim();
    }

    public async Task<string> getProductDescriptionText()
    {
       string res = await Task.Run(() => elementDescription.InnerTextAsync());
       return res.Trim();
    }

    public async Task<ILocator> getBackToProductsBtn()
    {
        return backToProductsBtn;
    }
}