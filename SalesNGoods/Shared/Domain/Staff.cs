using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesNGoods.Shared.Domain
{
    public class Staff : BaseDomainModel
    {
        public string Name { get; set; }
        public int Contact { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
    }
}
