using Microsoft.Playwright;

namespace PlaywrightSauceDemo.Pages;

public class ProductsPage
{
    public string productsPageTitle = "PRODUCTS";

    private readonly IPage _page;
    private readonly ScenarioContext _scenarioContext;

    public ProductsPage(IPage page, ScenarioContext scenarioContext)
    {
        _page = page;
        _scenarioContext = scenarioContext;
    }

    
    private ILocator _productsPageTitle => _page.Locator("//span[@class = 'title']");
    private ILocator _randomProductLabel => _page.Locator("//div[@class = 'inventory_item_name' and contains(text(), '" + _scenarioContext["label"] + "')]");
    private ILocator _productDescription => _page.Locator("//div[contains(text(), '" + _scenarioContext["label"] +
                                                          "')]/ancestor::div[@class ='inventory_item_description']//div[@class = 'inventory_item_desc']");
    private ILocator _productPrice => _page.Locator("//div[contains(text(), '" + _scenarioContext["label"] +
                                                    "')]/ancestor::div[@class ='inventory_item_description']//div[@class = 'inventory_item_price']"); 
    private ILocator _productLabels => _page.Locator("(//div[@class = 'inventory_item_name'])");
    
    public async Task<string> getProductDescriptionTextAsync()
    {
        var description = await _productDescription.InnerTextAsync();
        _scenarioContext["description"] = description;
        return description;
    }
    public async Task<string> getProductPriceAsync()
    {
        _scenarioContext["price"] = await _productPrice.InnerTextAsync();
        return (string)_scenarioContext["price"];
    }
    public async Task<string> getProductLabelText() 
    {
        return await _randomProductLabel.InnerTextAsync();
    }

    public async Task<string> getProductsPageTitle()
    {
        var text = await _productsPageTitle.InnerTextAsync();
        return text;
    }

    public async Task<string> getLabel()
    {
        var rows = _productLabels;
        var count =  await rows.CountAsync();
        List<string> list = new List<string>();
        for (int i = 0; i < count; i++)
        {
            list.Add(await rows.Nth(i).TextContentAsync());
        }
        var label2 = list.ElementAt(new Random().Next(1, list.Count));
        _scenarioContext["label"] = label2;
        return label2;
    }
    public async Task clickRandomElementLabel()
    {
        await getLabel();
        await getProductDescriptionTextAsync();
        await getProductPriceAsync();
        await _randomProductLabel.ClickAsync();
    }
}