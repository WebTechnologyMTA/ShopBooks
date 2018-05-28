namespace ShopBooks.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Sach")]
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

        public DateTime? NgayCapNhat { get; set; }

        public string AnhBia { get; set; }

        [Required(ErrorMessage = "Nhập số lượng!")]
        public int? SoLuongTon { get; set; }

        public int? MaChuDe { get; set; }

        public int? MaNXB { get; set; }

        [Range(0, 1, ErrorMessage = "Sách mới ứng với giá trị 1!")]
        public int? Moi { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietDonHang> ChiTietDonHangs { get; set; }

        public virtual ChuDe ChuDe { get; set; }

        public virtual NhaXuatBan NhaXuatBan { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ThamGia> ThamGias { get; set; }
    }
}
