using Microsoft.Playwright;
using NUnit.Framework;
using PlaywrightSpecFlow.NET_SauceDemo.Interfaces;
using SpecFlowSauceDemo_.NET.Drivers;

namespace PlaywrightSpecFlow.NET_SauceDemo;

[Binding]
public class ApiTestsSteps
{
    private ScenarioContext _scenarioContext;
    public ApiTestsSteps(ScenarioContext scenarioContext) => _scenarioContext = scenarioContext;
    
    
    [Given(@"I execute '(.*)' request")]
    public async Task GivenIExecuteRequest(string endpointLabel)
    {
        var playwright = await Playwright.CreateAsync();
        var requestContext = await playwright.APIRequest.NewContextAsync(new APIRequestNewContextOptions()
        {
            BaseURL = ReadProperties.GetInstance().GetBBaseApiUrl(),
            IgnoreHTTPSErrors = true
        });
        IAPIResponse response = null;
        switch (endpointLabel.ToUpper())
        {
            case "GET SINGLE USER":
                response = await requestContext.GetAsync(API_Endpoints.getSingleUser);
                break;
        }
        Console.WriteLine(await response.JsonAsync());
        _scenarioContext["response"] = await response.JsonAsync();
    }


    [Then(@"I verify '(.*)' field in response")]
    public async Task ThenIVerifyFieldInResponse(string name)
    {
        var response = _scenarioContext["response"];
        
    }
}