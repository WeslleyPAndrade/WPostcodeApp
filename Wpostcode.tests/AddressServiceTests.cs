using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wpostcode.Data.Models;
using Wpostcode.Service;
using Xunit;

namespace Wpostcode.Tests
{
    public class AddressServiceTests
    {
        private readonly AddressService _service;
        public AddressServiceTests() 
        { 
            _service = new AddressService();
        }

        [Fact]
        public async Task CallAPI_WithValidPostco_ReturnAddressModel()
        {
            // Arrange
            string validPostCode = "N7 6RS";
            var expectedAddressModel = new AddressModel { Postcode = "N7 6RS", Country = "England", AdminDistrict = "Islington", Latitude = 51.560414, Longitude = -0.116805 };

            //Act
            var result = await _service.CallPostcodeAPI(validPostCode);

            //Assert
            Assert.Equal(expectedAddressModel.Postcode, result.Postcode);
            Assert.Equal(expectedAddressModel.Country, result.Country);
            Assert.Equal(expectedAddressModel.AdminDistrict, result.AdminDistrict);
            Assert.Equal(expectedAddressModel.Latitude, result.Latitude);
            Assert.Equal(expectedAddressModel.Longitude, result.Longitude);
        }

        [Fact]
        public async Task CallAPI_WithInvalidPostco_ThrowsException()
        {
            //Arrange
            var invalidPostcode = "Invalid postcode.";


            //Act
            var exception = await Assert.ThrowsAsync<Exception>(() => _service.CallPostcodeAPI(invalidPostcode));

            //Assert
            Assert.Equal("Invalid postcode.", exception.Message);
        }
    }
}
