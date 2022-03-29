using System;
using System.Net.Security;
using System.Threading.Tasks;
using FluentAssertions;
using RestSharp;
using Xunit;
using Xunit.Abstractions;

namespace Learning.API.Testing.RestSharp
{
    public class UnitTest1
    {
        private readonly ITestOutputHelper _testOutputHelper;

        public UnitTest1(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
        }

        [Fact]
        public async Task Test1()
        {
            _testOutputHelper.WriteLine("First Test");

            var options = new RestClientOptions
            {
                BaseUrl = new Uri("https://localhost:44330/"),
                RemoteCertificateValidationCallback = (sender, certificate, chain, errors) => true
            };

            // Rest Client
            var client = new RestClient(options);

            // Rest Request
            var request = new RestRequest("/Product/GetProductById/1");

            // Perform the Get Operation
            var response = await client.GetAsync(request);

            // Assertion
            response.Should().NotBeNull();

        }
    }
}