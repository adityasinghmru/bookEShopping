using System;
using System.Collections.Generic;

namespace bookEShopping.Models
{
    public partial class TblBook
    {
        public TblBook()
        {
            TblOrders = new HashSet<TblOrder>();
        }

        public int BookId { get; set; }
        public string? BookName { get; set; }
        public string? BookImage { get; set; }
        public double? BookPrice { get; set; }
        public int? BookQuantity { get; set; }
        public bool? BookSatuts { get; set; }
        public string? BookAuthor { get; set; }
        public string? BookCategory { get; set; }

        public virtual ICollection<TblOrder> TblOrders { get; set; }
    }
}
