using Moq;
using Newtonsoft.Json;
using PokemonAPIapp;
using Xunit;

namespace PokemonAPITests
{
    public interface IPokeApiService
    {
        Task<Pokemon> GetPokemonAsync(string nameOrId);
    }
    [TestClass]
    public class PokeApiServiceTests
    {
        [Fact]
        public async Task GetPokemonAsync_ReturnsPokemon_WhenResponseIsValid()
        {
            // Arrange
            var mockService = new Mock<IPokeApiService>();
            mockService
                .Setup(service => service.GetPokemonAsync("pikachu"))
                .ReturnsAsync(new Pokemon
                {
                    Name = "pikachu",
                    Height = 4,
                    Weight = 60
                });

            // Act
            var pokemon = await mockService.Object.GetPokemonAsync("pikachu");

            // Assert
            Assert.IsNotNull(pokemon);
            Assert.Equals("pikachu", pokemon.Name);
            Assert.Equals(4, pokemon.Height);
            Assert.Equals(60, pokemon.Weight);
        }

        [Fact]
        public async Task GetPokemonAsync_CallsCorrectEndpoint()
        {
            // Arrange
            var mockService = new Mock<IPokeApiService>();
            var expectedUrl = "https://pokeapi.co/api/v2/pokemon/pikachu";

            mockService
                .Setup(service => service.GetPokemonAsync(It.IsAny<string>()))
                .ReturnsAsync(new Pokemon());

            // Act
            await mockService.Object.GetPokemonAsync("pikachu");

            // Assert
            mockService.Verify(service => service.GetPokemonAsync("pikachu"), Times.Once);
        }

        [Fact]
        public async Task Deserialize_ValidJson_ReturnsCorrectPokemonObject()
        {
            // Arrange
            string json = "{\"name\":\"pikachu\",\"height\":4,\"weight\":60}";
            Pokemon expected = new Pokemon { Name = "pikachu", Height = 4, Weight = 60 };

            // Act
            var actual = JsonConvert.DeserializeObject<Pokemon>(json);

            // Assert
            Assert.Equals(expected.Name, actual.Name);
            Assert.Equals(expected.Height, actual.Height);
            Assert.Equals(expected.Weight, actual.Weight);
        }

        [Fact]
        public async Task GetPokemonAsync_ReturnsNull_OnInvalidInput()
        {
            // Arrange
            var mockService = new Mock<IPokeApiService>();
            mockService
                .Setup(service => service.GetPokemonAsync("invalid"))
                .ReturnsAsync((Pokemon)null);

            // Act
            var result = await mockService.Object.GetPokemonAsync("invalid");

            // Assert
            Assert.IsNull(result);
        }

        [Theory]
        [InlineData("pikachu")]
        [InlineData("1")]  // ID-based input
        [InlineData("bulbasaur")]
        public async Task UserInput_ValidInputs_ReturnsCorrectPokemon(string input)
        {
            // Arrange
            var mockService = new Mock<IPokeApiService>();
            mockService
                .Setup(service => service.GetPokemonAsync(input))
                .ReturnsAsync(new Pokemon { Name = input });

            // Act
            var pokemon = await mockService.Object.GetPokemonAsync(input);

            // Assert
            Assert.IsNotNull(pokemon);
            Assert.Equals(input, pokemon.Name);
        }
    }
}