﻿using System;
using System.Collections.Generic;

#nullable disable

namespace Demo_API_NET5.Models
{
    public partial class Wallet
    {
        public Wallet()
        {
            TransactionShared1s = new HashSet<TransactionShared1>();
        }

        public int Id { get; set; }
        public int CustomerId { get; set; }
        public bool IsDeleted { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual ICollection<TransactionShared1> TransactionShared1s { get; set; }
    }
}
