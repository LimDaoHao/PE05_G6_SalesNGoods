using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesNGoods.Shared.Domain
{
    public class Category : BaseDomainModel
    {
        public string Name { get; set; }
        public string Type { get; set; }
    }
}
