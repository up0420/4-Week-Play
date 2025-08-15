using Xunit;
using System.Net.Http;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Threading.Tasks;
using FluentAssertions;

namespace Tests.Integration
{
    public class CharacterApiTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly HttpClient _client;

        public CharacterApiTests(WebApplicationFactory<Program> factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task 캐릭터_조회_API_성공()
        {
            // Arrange & Act
            var response = await _client.GetAsync("/api/character/1");

            // Assert
            response.EnsureSuccessStatusCode();
            var json = await response.Content.ReadAsStringAsync();
            json.Should().Contain("characterId");
        }
    }
}
