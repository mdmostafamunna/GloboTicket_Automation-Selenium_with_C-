using GloboTicket_Automation_Selenium_with_C__.Configuration;
using OpenQA.Selenium.Chromium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GloboTicket_Automation_Selenium_with_C__
{
    internal class ChromeDevToolsProtocolTests : BaseTest
    {

        private OpenQA.Selenium.DevTools.DevToolsSession session;

        [SetUp]

        public override void Setup()
        {
            SetDriver(CreateDriver(ConfigurationProvider.Configuration["browser"]));
            var devTools = GetDriver() as OpenQA.Selenium.DevTools.IDevTools;
            session = devTools.GetDevToolsSession();
        }

        [Test]

        public async Task EmulateDeviceModeTest()
        {
            var deviceSettings = new OpenQA.Selenium.DevTools.V114.Emulation.SetDeviceMetricsOverrideCommandSettings()
            {
                Width = 400,
                Height = 600,
                DeviceScaleFactor = 2,
                Mobile = true
            };

            await session.GetVersionSpecificDomains<OpenQA.Selenium.DevTools.V114.DevToolsSessionDomains>()
                .Emulation
                .SetDeviceMetricsOverride(deviceSettings);

            GetDriver().Navigate().GoToUrl("http://localhost:4200");

            Thread.Sleep(5000);
        }

        [Test]

        public async Task EmulateNetworkConditionsTest()
        {
            var networkConditions = new OpenQA.Selenium.DevTools.V114.Network.EmulateNetworkConditionsCommandSettings()
            {
                DownloadThroughput = 10000000
            };

            await session.GetVersionSpecificDomains<OpenQA.Selenium.DevTools.V114.DevToolsSessionDomains>()
                .Network
                .EmulateNetworkConditions(networkConditions);

            GetDriver().Navigate().GoToUrl("https://selenium.dev");
        }

    }
}
