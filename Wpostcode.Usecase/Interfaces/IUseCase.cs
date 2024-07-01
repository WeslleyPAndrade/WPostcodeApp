using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wpostcode.Data.Models;

namespace Wpostcode.Usecase.Interfaces
{
    public interface IUseCase
    {
        Task<List<AddressOutput>> GetAddressByPostcode(string postcode);
    }
}
