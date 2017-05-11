using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCTest.Models.ViewModels
{
    public class 客戶資料清單
    { 

        [Required]
        public int Id { get; set; }

        [StringLength(50, ErrorMessage = "欄位長度不得大於 50 個字元")]
        [Required]
        public string 客戶名稱 { get; set; }
        
        [Required]
        public int 客戶Id { get; set; }

        //[StringLength(50, ErrorMessage = "欄位長度不得大於 50 個字元")]
        //[Required]
        //public string 職稱 { get; set; }

        //[StringLength(50, ErrorMessage = "欄位長度不得大於 50 個字元")]
        //[Required]
        //public string 姓名 { get; set; }
        
    }
}