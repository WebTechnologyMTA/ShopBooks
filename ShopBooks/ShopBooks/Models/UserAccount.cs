namespace ShopBooks.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Web.Mvc;

    [Table("UserAccount")]
    [HiddenInput(DisplayValue = false)]
    public class UserAccount
    {
        [Key]
        [ScaffoldColumn(false)]
        public int id { get; set; }

        [Required(ErrorMessage = "Địa chỉ Email không hợp lệ!")]
        [EmailAddress(ErrorMessage = "Địa chỉ Email không hợp lệ!")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Nhập mật khẩu!")]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "Mật khẩu không hợp lệ!")]
        public string Password { get; set; }

        public bool IsAdmin { get; set; }
    }
}