using System;
using System.Collections.Generic;

#nullable disable

namespace Demo_API_NET5.Models
{
    public partial class TransactionShared
    {
        public int Id { get; set; }
        public decimal? Amount { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string HashValue { get; set; }
        public bool? IsDeleted { get; set; }
        public int? MoneyTransactionid { get; set; }
        public int? Paymentid { get; set; }
        public decimal? PreviousBalance { get; set; }
        public string PreviousHash { get; set; }
        public bool? Status { get; set; }
        public int? Walletid { get; set; }
    }
}
