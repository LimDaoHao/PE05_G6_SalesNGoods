using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesNGoods.Shared.Domain
{
    public class Product : BaseDomainModel
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public int Stock { get; set; }
        public string Brand { get; set; }
        public string Condition { get; set; }
        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
    }
}
