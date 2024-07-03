using Moq;
using Wpostcode.AppService;
using Wpostcode.Data.Models;
using Wpostcode.Usecase.Interfaces;
using Xunit;

namespace Wpostcode.Tests
{
    public class AddressAppServiceTests
    {
        private readonly Mock<IAddressUseCase> _useCaseMock;
        private readonly AddressAppService _appService;

        public AddressAppServiceTests()
        {
            _useCaseMock = new Mock<IAddressUseCase>();
            _appService = new AddressAppService(_useCaseMock.Object);
        }

        [Fact]
        public async Task GetAddressByPostCode_WithEmptyPostCode_ThrowsArgumentException()
        {
            // Arrange
            string emptyPostCode = string.Empty;

            // Act and Assert
            var exception = await Assert.ThrowsAsync<ArgumentException>(() => _appService.GetAddressByPostCode(emptyPostCode));
            Assert.Equal("Postcode is empty.", exception.Message);
        }

        [Fact]
        public async Task GetAddressByPostCode_WithValidPostCode_ReturnsAddressList()
        {
            // Arrange
            string validPostCode = "N7 6RS";
            var quilometersDistance = "25,42";
            var milesDistance = "15,8";
            var expectedAddresses = new List<AddressOutput>
            {
                new AddressOutput { Index = 1, Address = "N7 6RS, Islington, England",KilometersDistance = quilometersDistance, MilesDistance = milesDistance}
            };

            _useCaseMock.Setup(x => x.GetAddressByPostcode(validPostCode)).ReturnsAsync(expectedAddresses);

            // Act
            var result = await _appService.GetAddressByPostCode(validPostCode);

            // Assert
            Assert.Equal(expectedAddresses, result);
        }

        [Fact]
        public async Task GetAddressByPostCode_WithNullPostCode_ThrowsArgumentException()
        {
            // Arrange
            string nullPostCode = null;

            // Act & Assert
            var exception = await Assert.ThrowsAsync<ArgumentException>(() => _appService.GetAddressByPostCode(nullPostCode));
            Assert.Equal("Postcode is empty.", exception.Message);
        }
    }
}

