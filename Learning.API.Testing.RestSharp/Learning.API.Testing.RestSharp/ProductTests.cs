using System;
using System.Threading.Tasks;
using FluentAssertions;
using Learning.API.Testing.RestSharp.Models;
using RestSharp;
using Xunit;
using Xunit.Abstractions;

namespace Learning.API.Testing.RestSharp
{
    public class ProductTests
    {
        private readonly ITestOutputHelper _testOutputHelper;

        public ProductTests(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
        }

        [Fact]
        public async Task Product_GetProductById_ReturnOk()
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
            var response = await client.GetAsync<Product>(request);

            // Assertion
            response.Should().NotBeNull();
            response?.Name.Should().Be("Keyboard");
        }

        [Fact]
        public async Task Product_GetProductById_QuerySegment_ReturnOk()
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
            var request = new RestRequest("/Product/GetProductById/{id}");
            request.AddUrlSegment("id", 1);

            // Perform the Get Operation
            var response = await client.GetAsync<Product>(request);

            // Assertion
            response.Should().NotBeNull();
            response?.Name.Should().Be("Keyboard");
            response?.Price.Should().Be(150);
        }

        [Fact]
        public async Task Product_GetProductByIdAndName_ReturnOk()
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
            var request = new RestRequest("/Product/GetProductByIdAndName");
            request.AddParameter("id", 1);
            request.AddParameter("name", "Keyboard");

            // Perform the Get Operation
            var response = await client.GetAsync<Product>(request);

            // Assertion
            response.Should().NotBeNull();
            response?.Name.Should().Be("Keyboard");
            response?.Price.Should().Be(150);
            response?.ProductId.Should().Be(1);
            response?.ProductType.Should().Be(ProductType.PERIPHARALS);
        }

        [Fact]
        public async Task Product_CreateProduct_ReturnCreated()
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

            var product = new Product
            {
                Name = "Monitor",
                Price = 999,
                ProductType = ProductType.MONITOR,
                Description = "MONITOR"
            };

            var request = new RestRequest("/Product/Create");
            request.AddJsonBody(product);

            // Perform the Get Operation
            var response = await client.PostAsync<Product>(request);

            // Assertion
            response?.ProductId.Should().BeGreaterThan(0);
            response?.Name.Should().Be(product.Name);
            response?.Price.Should().Be(product.Price);
            response?.ProductType.Should().Be(product.ProductType);
            response?.Description.Should().Be(product.Description);
        }
    }
}