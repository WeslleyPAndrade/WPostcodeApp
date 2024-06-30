using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wpostcode.Repository.Interfaces
{
    public interface IRepository
    {
        List<string> Save(string address);
    }
}
