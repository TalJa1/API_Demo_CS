using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Demo_API_NET5.Models
{
    public partial class Customer
    {
        public Customer()
        {
            IdentityCard1s = new HashSet<IdentityCard1>();
            MoneyTransaction1s = new HashSet<MoneyTransaction1>();
            Wallets = new HashSet<Wallet>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime? DoB { get; set; }
        public string Address { get; set; }
        public byte? Gender { get; set; }
        public string Phone { get; set; }
        public bool IsDeleted { get; set; }

        public virtual ICollection<IdentityCard1> IdentityCard1s { get; set; }
        public virtual ICollection<MoneyTransaction1> MoneyTransaction1s { get; set; }
        public virtual ICollection<Wallet> Wallets { get; set; }
    }
}
