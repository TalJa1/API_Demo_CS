using System;
using System.Collections.Generic;

#nullable disable

namespace Demo_API_NET5.Models
{
    public partial class Payment
    {
        public Payment()
        {
            TransactionShared1s = new HashSet<TransactionShared1>();
        }

        public int Id { get; set; }
        public int OrderId { get; set; }
        public decimal Amount { get; set; }
        public bool IsDeleted { get; set; }

        public virtual Order Order { get; set; }
        public virtual ICollection<TransactionShared1> TransactionShared1s { get; set; }
    }
}
