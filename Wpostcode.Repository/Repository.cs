using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wpostcode.Repository.Interfaces;

namespace Wpostcode.Repository
{
    public class Repository : IRepository
    {
        public List<string> Save(string address)
        {
            return new List<string>();
        }
    }
}
