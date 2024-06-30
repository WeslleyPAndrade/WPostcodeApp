using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wpostcode.Usecase.Interfaces
{
    public interface IUseCase
    {
        List<string> GetAddressByPostcode(string postcode);
    }
}
