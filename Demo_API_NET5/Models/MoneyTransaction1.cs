using System;
using System.Collections.Generic;

#nullable disable

namespace Demo_API_NET5.Models
{
    public partial class MoneyTransaction1
    {
        public MoneyTransaction1()
        {
            TransactionShared1s = new HashSet<TransactionShared1>();
        }

        public int Id { get; set; }
        public int? CustomerId { get; set; }
        public decimal Amount { get; set; }
        public int WalletId { get; set; }
        public string Method { get; set; }
        public int? CounterId { get; set; }
        public bool State { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsDeleted { get; set; }

        public virtual Counter Counter { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual ICollection<TransactionShared1> TransactionShared1s { get; set; }
    }
}
