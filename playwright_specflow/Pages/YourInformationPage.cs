using Microsoft.Playwright;

namespace PlaywrightSauceDemo.Pages;

public class YourInformationPage
{
    private IPage _page;
    public YourInformationPage(IPage page) => _page = page;
    private ILocator YourInfoPageTitle => _page.Locator("span.title");
    private ILocator firstNameInput => _page.Locator("input#first-name");
    private ILocator lastNameInput => _page.Locator("input#last-name");
    private ILocator postalCodeInput => _page.Locator("input#postal-code");

    public string yourInformationPageTitle = "CHECKOUT: YOUR INFORMATION";
    public ILocator getYourInfoPageTitleAsync()
    {
        return YourInfoPageTitle;
    }
    public async Task fillFirstNameInputAsync(string firstName)
    {
        await firstNameInput.FillAsync(firstName);
    }
    public async Task fillLastNameInputAsync(string lastName)
    {
        await lastNameInput.FillAsync(lastName);
    }
    public async Task fillPostalCodeInputAsync(string postalCode)
    {
        await postalCodeInput.FillAsync(postalCode);
    }
}