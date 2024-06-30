using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wpostcode.AppService.Interfaces
{
    public interface IAppService
    {
        List<string> GetAddressByPostCode(string postCode);
    }
}
