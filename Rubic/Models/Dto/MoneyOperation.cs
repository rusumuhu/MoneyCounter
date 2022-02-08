using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rubic.Models.Dto
{
    public class MoneyOperation
    {
        public double Sum { get; set; }
        public string Operation { get; set; }
        public DateTime DateTime{ get; set; }
    }
}
