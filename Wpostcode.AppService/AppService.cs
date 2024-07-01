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
    public class AppService : IAppService
    {
        private readonly IUseCase _useCase;

        public AppService(IUseCase useCase)
        {
            _useCase = useCase;
        }

        public async Task<List<AddressOutput>> GetAddressByPostCode(string postCode)
        {
            if (string.IsNullOrEmpty(postCode))
            {
                throw new ArgumentException(message: "Erro no postcode");
            }
            
            
            return await _useCase.GetAddressByPostcode(postCode);
        }
    }
}
