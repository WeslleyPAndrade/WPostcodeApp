using Moq;
using Wpostcode.Data.Models;
using Wpostcode.Repository.Interfaces;
using Wpostcode.Service.Interfaces;
using Wpostcode.Usecase;
using Xunit;

namespace Wpostcode.Tests
{
    public class AddressUseCaseTests
    {
        private readonly Mock<IService> _serviceMock;
        private readonly Mock<IRepository> _repositoryMock;
        private readonly AddressUseCase _addressUseCase;

        public AddressUseCaseTests()
        {
            _serviceMock = new Mock<IService>();
            _repositoryMock = new Mock<IRepository>();
            _addressUseCase = new AddressUseCase(_serviceMock.Object, _repositoryMock.Object);
        }

        [Fact]
        public async Task GetAddressByPostcode_WithValidPostcode_ReturnsAdressList()
        {
            //Arrange
            var validPostcode = "N7 6RS";
            var expectedAddressModel = new AddressModel { Postcode = "N7 6RS", Latitude = 51.560414, Longitude = -0.116805 };
            var quilometersDistance = "25,42";
            var milesDistance = "15,8";
            var expectedAddress = new List<AddressOutput>
            {
                new AddressOutput {Index = 1, Address = "N7 6RS, Islington, England",KilometersDistance = quilometersDistance, MilesDistance = milesDistance}
            };

            _serviceMock.Setup(x => x.CallPostcodeAPI(validPostcode)).ReturnsAsync(expectedAddressModel);
            _repositoryMock.Setup(x => x.Save(expectedAddressModel, quilometersDistance, milesDistance)).Returns(expectedAddress);

            //Act
            var result = await _addressUseCase.GetAddressByPostcode(validPostcode);

            //Assert
            Assert.Equal(expectedAddress, result);

        }

        [Fact]
        public async Task GetAddressByPostcode_WithInvalidPostcode_ThrowsException()
        {
            //Arrange
            var invalidPostcode = "Invalid postcode.";
            

            //Act
            var exception = await Assert.ThrowsAsync<NullReferenceException>(() => _addressUseCase.GetAddressByPostcode(invalidPostcode));

            //Assert
            Assert.IsType<NullReferenceException>(exception);
        }
    }
}
