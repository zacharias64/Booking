using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Book.Models.Cart
{
    [Serializable]
    public class CartItem
    {
        public int bId { get; set; }
        public string bTitle { get; set; }
        public decimal bMoney { get; set; }
        public int Quantity { get; set; }
        public decimal Amount
        {
            get
            {
                return this.bMoney * this.Quantity;
            }
        }
        public string bURL { get; set; }
    }
}