using System;
using Microsoft.Playwright;

namespace SpecFlowSauceDemo_.NET.Drivers
{
    public class Driver
    {
        private readonly Task<IPage> _page;
        private IBrowser? _browser;

        public Driver()
        {
            _page = InitializePlaywright();
        }

        public IPage Page => _page.Result;

        public async Task<IPage> InitializePlaywright()
        {
            var playwright = await Playwright.CreateAsync();
            _browser = await playwright.Chromium.LaunchAsync(new()
            {
                Headless = false,
                //SlowMo = 50
            });
            return await _browser.NewPageAsync();
        }

        /*public void Dispose()
        {
            _browser?.CloseAsync();
        }
    }*/
    }
}