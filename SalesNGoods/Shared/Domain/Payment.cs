using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesNGoods.Shared.Domain
{
    public class Payment : BaseDomainModel
    {
        [Required]
        public string Method { get; set; }
        public DateTime DateTime { get; set; }
        public int OrderId { get; set; }
        public virtual Order Order { get; set; }

    }
}
