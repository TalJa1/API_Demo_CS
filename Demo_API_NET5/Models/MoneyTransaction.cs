using System;
using System.Collections.Generic;

#nullable disable

namespace Demo_API_NET5.Models
{
    public partial class MoneyTransaction
    {
        public int Id { get; set; }
        public decimal? Amount { get; set; }
        public int? Counterid { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? Customerid { get; set; }
        public bool? IsDeleted { get; set; }
        public string Method { get; set; }
        public bool? State { get; set; }
        public int? Walletid { get; set; }
    }
}
