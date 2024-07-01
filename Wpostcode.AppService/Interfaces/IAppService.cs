using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wpostcode.Data.Models;

namespace Wpostcode.AppService.Interfaces
{
    public interface IAppService
    {
        Task<List<AddressOutput>> GetAddressByPostCode(string postCode);
    }
}
