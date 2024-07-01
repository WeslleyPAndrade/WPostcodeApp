using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wpostcode.Data.Models;

namespace Wpostcode.Repository.Interfaces
{
    public interface IRepository
    {
        List<AddressOutput> Save(AddressModel address, string quilometersDistance, string milesDistance);
    }
}
