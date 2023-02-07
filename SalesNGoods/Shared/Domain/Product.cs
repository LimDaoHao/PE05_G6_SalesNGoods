using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesNGoods.Shared.Domain
{
    public class Product : BaseDomainModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public double Price { get; set; }
        [Required]
        public int Stock { get; set; }
        [Required]
        public string Brand { get; set; }
        [Required]
        public string Condition { get; set; }
        //public int CustomerId { get; set; }
        //public virtual Customer Customer { get; set; }
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
    }
}
