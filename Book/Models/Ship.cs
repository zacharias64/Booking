using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Book.Models
{
    public class Ship
    {
        [Required]
        [Display(Name = "收貨人姓名")]
        [StringLength(maximumLength: 30, ErrorMessage = "{0} 的長度至少必須為 {2} 個字元。"
            , MinimumLength = 2)]// 字元長度：2~30
        public string RecieverName { get; set; }

       [Required]
        [Display(Name = "收貨人電話")]
        [StringLength(maximumLength: 15, ErrorMessage = "{0}的長度至少必須為 {2} 個字元。"
            , MinimumLength = 8)]// 字元長度：8~15
        public string RecieverPhone { get; set; }

       [Required]
        [Display(Name = "收貨人地址")]
        [StringLength(maximumLength: 256, ErrorMessage = "{0} 的長度至少必須為 {2} 個字元。"
            , MinimumLength = 8)]// 字元長度：8~256
        public string RecieverAddress { get; set; }
    }
}