using System;
using System.Collections.Generic;

#nullable disable

namespace Demo_API_NET5.Models
{
    public partial class Counter
    {
        public Counter()
        {
            MoneyTransaction1s = new HashSet<MoneyTransaction1>();
        }

        public int Id { get; set; }
        public bool IsDeleted { get; set; }

        public virtual ICollection<MoneyTransaction1> MoneyTransaction1s { get; set; }
    }
}
