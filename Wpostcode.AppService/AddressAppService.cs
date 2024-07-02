using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wpostcode.AppService.Interfaces;
using Wpostcode.Data.Models;
using Wpostcode.Usecase.Interfaces;

namespace Wpostcode.AppService
{
    public class AddressAppService : IAddressAppService
    {
        private readonly IAddressUseCase _useCase;

        public AddressAppService(IAddressUseCase useCase)
        {
            _useCase = useCase;
        }

        public async Task<List<AddressOutput>> GetAddressByPostCode(string postCode)
        {
            if (string.IsNullOrEmpty(postCode))
            {
                throw new ArgumentException(message: "Postcode is empty.");
            }
            
            
            return await _useCase.GetAddressByPostcode(postCode);
        }
    }
}
