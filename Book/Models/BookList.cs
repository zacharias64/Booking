//------------------------------------------------------------------------------
// <auto-generated>
//     這個程式碼是由範本產生。
//
//     對這個檔案進行手動變更可能導致您的應用程式產生未預期的行為。
//     如果重新產生程式碼，將會覆寫對這個檔案的手動變更。
// </auto-generated>
//------------------------------------------------------------------------------

namespace Book.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class BookList
    {
        [Display(Name = "編號")]
        public int bId { get; set; }
        [Display(Name = "書名")]
        public string bTitle { get; set; }
        [Display(Name = "英文書名")]
        public string bOriginal { get; set; }
        [Display(Name = "作者")]
        public string bAuthor { get; set; }
        [Display(Name = "出版年份")]
        public int bYear { get; set; }
        [Display(Name = "出版商")]
        public string bPubHouse { get; set; }
        [Display(Name = "ISBN碼")]
        public long bISBN { get; set; }
        [Display(Name = "譯者")]
        public string bTrans { get; set; }
        [Display(Name = "價格")]
        public decimal bMoney { get; set; }
        [Display(Name = "語言")]
        public string bLaun { get; set; }
        [Display(Name = "介紹")]
        public string bIntroduce { get; set; }
        [Display(Name = "圖片位置")]
        public string bURL { get; set; }
        [Display(Name = "數量")]
        public int bQuan { get; set; }
    }
}
