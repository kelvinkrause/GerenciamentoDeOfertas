using CommonTestUtilities.Requests;
using FluentAssertions;
using System.Globalization;
using System.Net;
using System.Net.Http.Json;
using System.Text.Json;
using WebApi.Test.Fixture;

namespace WebApi.Test.Oferta.Registrar
{
    public class RegistrarOfertaTest : IClassFixture<CustomWebApplicationFactory>
    {
        private readonly HttpClient _httpClient;
        public RegistrarOfertaTest(CustomWebApplicationFactory _factory) =>
            _httpClient = _factory.CreateClient();

        [Fact]
        public async Task Success()
        {
            var request = RequestRegistrarOfertaJsonBuilder.Build();

            var response = await _httpClient.PostAsJsonAsync("Oferta", request);

            response.StatusCode.Should().Be(HttpStatusCode.Created);

            await using var responseBuilder = await response.Content.ReadAsStreamAsync();

            var responseJson = await JsonDocument.ParseAsync(responseBuilder);

            responseJson.RootElement.GetProperty("nome").GetString().Should().NotBeNullOrWhiteSpace()
                .And.Be(request.Nome);
        }

        [Fact]
        public async Task Error_Nome_Vazio()
        {
            var request = RequestRegistrarOfertaJsonBuilder.Build();
            request.Nome = string.Empty;

            var response = await _httpClient.PostAsJsonAsync("Oferta", request);

            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);

            await using var responseBuilder = await response.Content.ReadAsStreamAsync();

            var responseJson = await JsonDocument.ParseAsync(responseBuilder);

            var errors = responseJson.RootElement.GetProperty("errosMessage").EnumerateArray();

            errors.Should().ContainSingle()
                .And.Contain(error => error.GetString()!.Equals("Nome não pode ser vazio."));
        }
    }
}