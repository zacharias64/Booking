using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Book.Models.Cart
{
    [Serializable]
    public class Cart : IEnumerable<CartItem>
    {
        private List<CartItem> cartItems;
        public Cart()
        {
            this.cartItems = new List<CartItem>();
        }
        public int Count
        {
            get
            {
                return this.cartItems.Count;
            }
        }
        public decimal TotalAmount
        {
            get
            {
                decimal totalAmount = 0.0m;
                foreach (var cartItem in this.cartItems)
                {
                    totalAmount = totalAmount + cartItem.Amount;

                }
                return totalAmount;
            }
        }
        private bool AddProduct(BookList book)
        {
            //將 Product 轉換為 CartItem
            var cartItem = new Models.Cart.CartItem()
            {
                bId = book.bId,
                bTitle = book.bTitle,
                bMoney = book.bMoney,
                Quantity = 1,
                //Day24 新增圖片 (新增項目，故前面的「Quantity = 1」後,要加個「,」。)
                bURL = book.bURL
            };

            //將 CartItem 加入到購物車
            this.cartItems.Add(cartItem);
            return true;
        }
        public bool AddProduct(int bId)
        {
            var FindItem = this.cartItems.Where(w => w.bId == bId)
                .Select(s => s).FirstOrDefault();

            // 判斷相同 Id 的 CartItem 是否已經存在購物車內
            if (FindItem == default(Models.Cart.CartItem))
            {
                //若不存在於購物車內，則新增一筆
                using (Models.AllBookEntities1 db = new AllBookEntities1())
                {
                    var product = db.BookList.Where(w => w.bId == bId)
                        .Select(s => s).FirstOrDefault();

                    if (product != default(Models.BookList))
                    {
                        this.AddProduct(product);
                    }
                }
            }
            else
            {
                // 存在於購物車，則將商品數量累加
                FindItem.Quantity += 1;
            }
            return true;
        }
        public bool RemoveProduct(int productId)
        {
            var FindItem = this.cartItems.Where(w => w.bId == productId)
                .Select(s => s).FirstOrDefault();

            //判斷相同 Id 的 CartItem 是否已經存在購物車內
            if (FindItem != default(Models.Cart.CartItem))
            /*
                {
                //不存在購物車內，不需做任何動作
                 }
            else
           */
            {
                // 存在於購物車內，將商品移除
                this.cartItems.Remove(FindItem);
            }

            return true;
        }


        //Day23 新增ClearCart()方法，直接將購物車內的cartItems清空。
        /// <summary>
        /// 清空購物車
        /// </summary>
        /// <returns></returns>
        public bool ClearCart()
        {
            this.cartItems.Clear();
            return true;
        }

        public IEnumerator<CartItem> GetEnumerator()
        {
            return ((IEnumerable<CartItem>)cartItems).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)cartItems).GetEnumerator();
        }
    }
}