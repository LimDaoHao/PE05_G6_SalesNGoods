﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesNGoods.Shared.Domain
{
    public class OrderItem : BaseDomainModel
    {
        [Required]
        public int OrderQty { get; set; }
        public int? OrderId { get; set; }
        public virtual Order Order { get; set; }
        public int ProductId { get; set; }
        public virtual Product Product { get;set; }

    }
}
