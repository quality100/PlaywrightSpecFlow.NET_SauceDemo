using Dynamitey;
using Microsoft.Playwright;

namespace PlaywrightSauceDemo.Pages;

public class ProductsPage
{
    public string productsPageTitle = "PRODUCTS";
    
    private readonly IPage _page;
    public ProductsPage(IPage page) => _page = page;
    private ILocator _productsPageTitle => _page.Locator("//span[@class = 'title']");
    public ILocator _randomProductLabel => _page.Locator("//div[@class = 'inventory_item_name' and contains(text(), '" + productLabelText + "')]");
    private ILocator _productDescription => _page.Locator("//div[contains(text(), '" + productLabelText +
                                                          "')]/ancestor::div[@class ='inventory_item_description']//div[@class = 'inventory_item_desc']");
    private ILocator _productLabels => _page.Locator("(//div[@class = 'inventory_item_name'])");
    public string productLabelText => getRandomElementTextFromList();
    
    public string getProductLabelText()
    {
        return _randomProductLabel.InnerTextAsync().Result;
    }

    public string getProductsPageTitle()
    {
        return _productsPageTitle.InnerTextAsync().Result;
    }

    public  List<string> getProductsLabels()
    {
        var rows = _productLabels;
        int count = rows.CountAsync().Result;
        List<string> list = new List<string>();
        for (int i = 0; i < count; i++)
        {
           list.Add(rows.Nth(i).TextContentAsync().Result);
        }
        return list;
    }

    public string getRandomElementTextFromList()
    {
        var list = getProductsLabels();
        return list.ElementAt(new Random().Next(1, list.Count-1));
    }

    public async Task clickRandomElementLabel()
    {
        await _randomProductLabel.ClickAsync();
    }

    public string getProductsDescriptionText()
    {
        return _productDescription.InnerTextAsync().Result;
    }
}