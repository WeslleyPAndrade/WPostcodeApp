using Wpostcode.Data.Models;
using Wpostcode.Repository.Interfaces;

namespace Wpostcode.Repository
{
    public class Repository : IRepository
    {
        const int ListMaximumSize = 3;
        const int ListMinimumSize = 1;
        int takeItem = 0;
        private List<AddressOutput> AddressList { get; set; }

        public Repository()
        {
                AddressList = new List<AddressOutput>();
        }



        public List<AddressOutput> Save(AddressModel address, string quilometersDistance, string milesDistance)
        {


            takeItem = AddressList.Count() + ListMinimumSize;

            var output = ConvertModelToOutput(address, quilometersDistance, milesDistance);

            AddressList.Add(output);

            if (takeItem < ListMaximumSize) return AddressList.TakeLast(takeItem).Reverse().ToList();

            return AddressList.TakeLast(ListMaximumSize).Reverse().ToList();
        }

        private AddressOutput ConvertModelToOutput(AddressModel address, string quilometersDistance, string milesDistance)
        {
            return new AddressOutput
            {
                Index = takeItem,
                Address = $"{address.Postcode}, {address.AdminDistrict}, {address.Country}",
                QuilometersDistance = quilometersDistance,
                MilesDistance = milesDistance
            };
        }
    }
}