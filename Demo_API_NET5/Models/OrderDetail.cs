using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Demo_API_NET5.Models
{
    public partial class OrderDetail
    {
        [Key]
        public int OrderId { get; set; }
        public string ProId { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public decimal? Amount { get; set; }
        public bool IsDeleted { get; set; }

        public virtual Order Order { get; set; }
        public virtual Product Pro { get; set; }
    }
}
