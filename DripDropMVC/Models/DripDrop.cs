using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DripDropMVC.Models
{
    public class DripDrop
    {
        public int DripValue { get; set; }
        public int DropValue { get; set; }
        public List<string> Result { get; set; } = new();
    }
}
