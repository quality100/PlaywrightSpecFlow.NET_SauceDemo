using System.Data.SqlClient;
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


    [Then(@"I verify '(.*)' field in response is '(.*)'")]
    public async Task ThenIVerifyFieldInResponse(string field, string expectedValue)
    {
        var response = (JsonElement) _scenarioContext["response"];
        var deserializedResponse = (SingleUserDataModel) _scenarioContext["DeserializedResponse"];
        switch (field.ToUpper())
        {
            case "NAME":
                Assert.AreEqual(expectedValue, deserializedResponse.data.first_name);
                break;
            case "SUPPORT TEXT":
                Assert.AreEqual(expectedValue, deserializedResponse.support.text);
                break;
        }
    }

    [Then(@"Db test")]
    public void ThenDbTest()
    {
        string connectionString =
            "Server=db4free.net:3306;Database=itech_cypress;User Id=admin12345654321;Password=password;";
        SqlConnection connection = new SqlConnection(connectionString);

        SqlCommand command = new SqlCommand(
            "select First_Name from Employees where Employee_ID = 1", connection);

        connection.Open();
        string result = (string) command.ExecuteScalar();
        Assert.AreEqual("Andrew", result);
    }
}