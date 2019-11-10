using Xunit;
//using Microsoft.AspNetCore.Components.;
using BlazorApp.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

namespace BlazorApp.Data.Tests
{
    public class JsonPullServiceTests
    {
        //private Program host = new TestHost();

        [Fact()]
        public void GetPullsTest()
        {
            var pulls = JsonPullService.GetPulls();
            Debug.WriteLine(pulls);
            Debug.WriteLine("SSS");
            Assert.NotNull(pulls);
        }
    }
}