using FluentAssertions;
using Microsoft.Playwright;
using NUnit.Framework;
using PlaywrightSpecFlow.NET_SauceDemo.Interfaces;
using SpecFlow.Internal.Json;
using System.Text.Json;
using PlaywrightSpecFlow.NET_SauceDemo.API_Models;
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
       _scenarioContext["response"] = await response?.JsonAsync();
       var resp = await response.JsonAsync();
       _scenarioContext["DeserializedResponse"] = resp.Value.Deserialize<SingleUserDataModel>();
    }


    [Then(@"I verify '(.*)' field in response")]
    public async Task ThenIVerifyFieldInResponse(string name)
    {
        var response = (JsonElement)_scenarioContext["response"];
        var deserializedResponse = (SingleUserDataModel)_scenarioContext["DeserializedResponse"];
        Console.WriteLine((JsonElement)_scenarioContext["response"]);
        Assert.AreEqual(response.GetProperty("data").GetProperty("first_name").ToString(),"Janet");
        Assert.AreEqual(deserializedResponse.data.first_name, "Janet");
        Assert.AreEqual(deserializedResponse.support.text,"To keep ReqRes free, contributions towards server costs are appreciated!");
    }
}