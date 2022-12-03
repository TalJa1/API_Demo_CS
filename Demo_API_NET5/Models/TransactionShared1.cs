using System;
using System.Collections.Generic;

#nullable disable

namespace Demo_API_NET5.Models
{
    public partial class TransactionShared1
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public int WalletId { get; set; }
        public string PreviousHash { get; set; }
        public string HashValue { get; set; }
        public decimal PreviousBalance { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool? Status { get; set; }
        public int? MoneyTransactionId { get; set; }
        public int? PaymentId { get; set; }
        public bool IsDeleted { get; set; }

        public virtual MoneyTransaction1 MoneyTransaction { get; set; }
        public virtual Payment Payment { get; set; }
        public virtual Wallet Wallet { get; set; }
    }
}
