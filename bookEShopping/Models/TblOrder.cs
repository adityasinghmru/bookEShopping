using System;
using System.Collections.Generic;

namespace bookEShopping.Models
{
    public partial class TblOrder
    {
        public int OrderId { get; set; }
        public int? BookId { get; set; }
        public DateTime? OrderDate { get; set; }
        public int? UserId { get; set; }

        public virtual TblBook? Book { get; set; }
        public virtual TblUser? User { get; set; }
    }
}
