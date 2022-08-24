using Microsoft.Playwright;

namespace PlaywrightSauceDemo.Pages;

public class ProductsPage
{
    public string productsPageTitle = "PRODUCTS";
    
    private readonly IPage _page;
    
    public ProductsPage(IPage page) => _page = page;
    private ILocator _productsPageTitle => _page.Locator("//span[@class = 'title']");
    private ILocator _randomProductLabel => _page.Locator("//div[@class = 'inventory_item_name' and contains(text(), '" + productLabelText + "')]");
    private ILocator _productDescription => _page.Locator("//div[contains(text(), '" + productLabelText +
                                                          "')]/ancestor::div[@class ='inventory_item_description']//div[@class = 'inventory_item_desc']");
    private ILocator _productLabels => _page.Locator("(//div[@class = 'inventory_item_name'])");
    public string productLabelText;
    public async Task<string> setProductLabelText()
    {
       return  productLabelText = getRandomElementTextFromList().GetAwaiter().GetResult();
    }

    

    public string getProductLabelText() 
    {
        return _randomProductLabel.InnerTextAsync().Result;
    }

    public async Task<string> getProductsPageTitle()
    {
        var text = _productsPageTitle.InnerTextAsync().GetAwaiter().GetResult();
        return text;
    }

    

    public async Task<List<string>> getProductsLabels()
    {
        var rows = _productLabels;
        var count = rows.CountAsync().Result;
        List<string> list = new List<string>();
        for (int i = 0; i < count; i++)
        {
           list.Add( rows.Nth(i).TextContentAsync().GetAwaiter().GetResult());
        }
        return list;
    }

    public async Task<string> getRandomElementTextFromList()
    {
        List<string> list = await getProductsLabels();
        return list.ElementAt(new Random().Next(1, list.Count));
    }

    public async Task clickRandomElementLabel()
    {
        await _randomProductLabel.ClickAsync();
    }
}