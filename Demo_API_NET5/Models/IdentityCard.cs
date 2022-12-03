using System;
using System.Collections.Generic;

#nullable disable

namespace Demo_API_NET5.Models
{
    public partial class IdentityCard
    {
        public int Id { get; set; }
        public int? Customerid { get; set; }
        public bool? IsDeleted { get; set; }
        public bool? Status { get; set; }
    }
}
