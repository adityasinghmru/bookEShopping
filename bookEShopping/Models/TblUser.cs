using System;
using System.Collections.Generic;

namespace bookEShopping.Models
{
    public partial class TblUser
    {
        public TblUser()
        {
            TblOrders = new HashSet<TblOrder>();
        }

        public int UserId { get; set; }
        public string? UserCategory { get; set; }
        public string? UserName { get; set; }
        public string? UserPassword { get; set; }
        public string? UserContact { get; set; }
        public string? UserEmail { get; set; }
        public DateTime? UserDob { get; set; }
        public string? UserGender { get; set; }

        public virtual ICollection<TblOrder> TblOrders { get; set; }
    }
}
