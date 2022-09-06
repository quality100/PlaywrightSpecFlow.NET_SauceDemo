﻿using Gherkin;
using Microsoft.Playwright;
using NUnit.Framework;
using PlaywrightSauceDemo.Pages;
using SpecFlowSauceDemo_.NET.Drivers;

namespace PlaywrightSpecFlow.NET_SauceDemo.Steps;

[Binding]
public class OrderProductSteps
{
    private Driver _driver;
    private readonly ScenarioContext _scenarioContext;


    public OrderProductSteps(Driver driver, ScenarioContext scenarioContext)
    {
        _driver = driver;
        _scenarioContext = scenarioContext;
    }

    private IPage _page => _driver.Page;
    private ProductsPage _productsPage => new ProductsPage(_page, _scenarioContext);
    private ProductPage _productPage => new ProductPage(_page);
    private CartPage _cartPage => new CartPage(_page);

    [When(@"I select random product")]
    public async Task WhenISelectRandomProduct()
    {
        //await _productsPage.getProductDescriptionTextAsync();
        await _productsPage.clickRandomElementLabel();
    }

    [Then(@"I verify (.*) on Products Page and Single Product Page are equal")]
    public async Task VerifyProductsPageAndSingleProductPageAreEqual(string part)
    {
        switch (part.ToUpper())
        {
            case "LABEL":
                Assert.AreEqual(_scenarioContext["label"], _productPage.getProductLabel());
                break;
            case "DESCRIPTION":
                Assert.AreEqual(_scenarioContext["description"], _productPage.getProductDescription());
                break;
            case "PRICE":
                Assert.AreEqual(_scenarioContext["price"], _productPage.getProductPrice());
                break;
        }
    }

    [When(@"I click '(.*)' button on Product Page")]
    public async Task WhenIClickAddToCartButton(string dummy)
    {
        await _productPage.clickAddtoCartButton();
    }

    [Then(@"I verify cart badge contains value '(.*)'")]
    public async Task ThenIVerifyCartBadgeContainsNumber(string cartBadgeNum)
    {
        var badgeValue = await _productPage.getCartBadgeValue();
        Assert.AreEqual(cartBadgeNum, badgeValue);
    }

    [Then(@"I verify cart badge not visible")]
    public async Task ThenIVerifyCartBadgeNotVisible()
    {
        Assert.True(!await _productPage.getCartBadge().GetAwaiter().GetResult().IsVisibleAsync());
    }

    [When(@"Click on cart icon")]
    public async Task WhenClickOnCartIcon()
    {
        await _productPage.clickCartIcon();
    }

    [Then(@"I verify Cart Page is opened")]
    public async Task ThenIVerifyCartPageIsOpened()
    {
       Assert.True(await _cartPage.getCartPageTitle().GetAwaiter().GetResult().IsVisibleAsync());
    }
}