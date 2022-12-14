using System;
using System.Collections.Generic;

#nullable disable

namespace Demo_API_NET5.Models
{
    public partial class IdentityCard1
    {
        public int Id { get; set; }
        public bool? Status { get; set; }
        public int? CustomerId { get; set; }
        public bool IsDeleted { get; set; }

        public virtual Customer Customer { get; set; }
    }
}
