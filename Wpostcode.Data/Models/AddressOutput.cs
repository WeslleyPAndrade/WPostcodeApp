using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wpostcode.Data.Models
{
    public class AddressOutput
    {
        public int Index { get; set; }
        public string? Address { get; set; }
        public string? KilometersDistance { get; set; }
        public string? MilesDistance { get; set; }
    }
}
