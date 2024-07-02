using Wpostcode.Data.Models;
using Wpostcode.Repository.Interfaces;
using Wpostcode.Service.Interfaces;
using Wpostcode.Usecase.Interfaces;

namespace Wpostcode.Usecase
{
    public class AddressUseCase : IAddressUseCase
    {
        private readonly IService _service;
        private readonly IRepository _repository;

        private const double EARTH_RADIUS = 6371.01; // Earth Radius in Quilometers
        private const double LONDON_HEATHROW_AIRPORT_LAT = 51.4700223;
        private const double LONDON_HEATHROW_AIRPORT_LONG = -0.4542955;

        public AddressUseCase(IService service, IRepository repository)
        {
            _service = service;
            _repository = repository;
        }

        public async Task<List<AddressOutput>> GetAddressByPostcode(string postcode)
        {
            var addressModel = await _service.CallPostcodeAPI(postcode);
            string quilometersDistance = CalculateDistanceInKilometers(addressModel.Latitude, addressModel.Longitude, LONDON_HEATHROW_AIRPORT_LAT, LONDON_HEATHROW_AIRPORT_LONG).ToString();
            string milesDistance = CalculateDistanceInMiles(addressModel.Latitude, addressModel.Longitude, LONDON_HEATHROW_AIRPORT_LAT, LONDON_HEATHROW_AIRPORT_LONG).ToString();

            return _repository.Save(addressModel, quilometersDistance, milesDistance);
        }


        private double CalculateDistanceInKilometers(double latitude1, double longitude1, double latitude2, double longitude2)
        {
            double deltaLatitude = (latitude2 - latitude1) * Math.PI / 180;
            double deltaLongitude = (longitude2 - longitude1) * Math.PI / 180;

            double haversineParameter = Math.Sin(deltaLatitude / 2) * Math.Sin(deltaLatitude / 2) +
                      Math.Cos(latitude1 * Math.PI / 180) * Math.Cos(latitude2 * Math.PI / 180) *
                      Math.Sin(deltaLongitude / 2) * Math.Sin(deltaLongitude / 2);

            double calculatedDistance = 2 * Math.Atan2(Math.Sqrt(haversineParameter), Math.Sqrt(1 - haversineParameter));

            return Math.Round((EARTH_RADIUS * calculatedDistance),2);
        }

        private double CalculateDistanceInMiles(double latitude1, double longitude1, double latitude2, double longitude2)
        {
            double distanceInKm = CalculateDistanceInKilometers(latitude1, longitude1, latitude2, longitude2);
            return Math.Round((distanceInKm * 0.621371),2); 
        }
    }
}
