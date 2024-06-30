using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wpostcode.Service.Interfaces
{
    public interface IService
    {
        Task<string> CallPostcodeAPI(string postcode);
    }
}
