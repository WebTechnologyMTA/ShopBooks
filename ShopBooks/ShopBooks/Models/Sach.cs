namespace ShopBooks.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Web.Mvc;

    [Table("Sach")]
    [HiddenInput(DisplayValue = false)]
    public partial class Sach
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Sach()
        {
            ChiTietDonHangs = new HashSet<ChiTietDonHang>();
            ThamGias = new HashSet<ThamGia>();
        }

        [Key]
        [ScaffoldColumn(false)]
        public int MaSach { get; set; }

        [Required(ErrorMessage = "Nhập tên sách!")]
        [StringLength(100)]
        public string TenSach { get; set; }

        [Required(ErrorMessage = "Giá bán không được để trống!")]
        [Range(0, 1000000, ErrorMessage = "Giá bán không hợp lệ!")]
        public decimal? GiaBan { get; set; }

        [Required(ErrorMessage = "Nhập mô tả!")]
        public string MoTa { get; set; }

        [Required(ErrorMessage = "Nhập ngày cập nhật!")]
        public DateTime? NgayCapNhat { get; set; }

        public string AnhBia { get; set; }

        [Required(ErrorMessage = "Nhập số lượng!")]
        public int? SoLuongTon { get; set; }

        [Required(ErrorMessage = "Chọn chủ đề!")]
        public int? MaChuDe { get; set; }

        [Required(ErrorMessage = "Chọn nhà xuất bản!")]
        public int? MaNXB { get; set; }

        public int? Moi { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietDonHang> ChiTietDonHangs { get; set; }

        public virtual ChuDe ChuDe { get; set; }

        public virtual NhaXuatBan NhaXuatBan { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ThamGia> ThamGias { get; set; }
    }
}
