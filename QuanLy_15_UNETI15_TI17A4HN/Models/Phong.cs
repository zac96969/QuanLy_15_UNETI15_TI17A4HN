<<<<<<< HEAD
// Họ và tên: Vũ Xuân Tuấn
// Mã sinh viên: 23103100035
// Nội dung thực hiện: Models Phong



using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuanLy_15_UNETI15_TI17A4HN.Models;

public class Phong
{
    [Key]
    public int MaPhong { get; set; }

    [Required(ErrorMessage = "Số phòng là bắt buộc")]
    [StringLength(10)]
    [Display(Name = "Số phòng")]
    public string SoPhong { get; set; } = string.Empty;

    [Required]
    [Display(Name = "Loại phòng")]
    public int MaLoaiPhong { get; set; }

    [Display(Name = "Tầng")]
    public int Tang { get; set; }

    [StringLength(50)]
    [Display(Name = "Hướng phòng")]
    public string? HuongPhong { get; set; }

    [StringLength(500)]
    [Display(Name = "Tiện nghi")]
    public string? TienNghi { get; set; }

    [Range(0, double.MaxValue)]
    [Column(TypeName = "decimal(18,2)")]
    [Display(Name = "Đơn giá/ngày")]
    public decimal DonGia { get; set; }

    // TrangThai: "TrongRanh", "DangSuDung", "BaoTri", "KhongKinhDoanh"
    [Required]
    [StringLength(30)]
    [Display(Name = "Trạng thái")]
    public string TrangThai { get; set; } = "TrongRanh";

    [StringLength(500)]
    [Display(Name = "Ghi chú")]
    public string? GhiChu { get; set; }

    [Display(Name = "Ngày bảo trì")]
    public DateTime? NgayBaoTri { get; set; }

    [StringLength(500)]
    [Display(Name = "Ghi chú bảo trì")]
    public string? GhiChuBaoTri { get; set; }

    // Navigation Property
    public LoaiPhong LoaiPhong { get; set; } = null!;
    public ICollection<DatPhong> DatPhongs { get; set; } = new List<DatPhong>();
}
=======
// Họ và tên: Nguyễn Đình Tuấn
// Mã sinh viên: 23103100235
// Nội dung thực hiện: Entity phòng khách sạn và trạng thái kinh doanh.
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace QuanLy_15_UNETI15_TI17A4HN.Models;
public static class TrangThaiPhong
{
    public const string Trong = "Trong";
    public const string DaDat = "DaDat";
    public const string DangSuDung = "DangSuDung";
    public const string BaoTri = "BaoTri";
    public const string NgungKinhDoanh = "NgungKinhDoanh";
}
public class Phong
{
    [Key] public int MaPhong { get; set; }
    [Required, StringLength(20), Display(Name="Số phòng")]
    public string SoPhong { get; set; } = string.Empty;
    [Required, Display(Name="Loại phòng")]
    public int MaLoaiPhong { get; set; }
    public LoaiPhong? LoaiPhong { get; set; }
    [Range(1,100)] public int Tang { get; set; }
    [StringLength(50), Display(Name="Hướng phòng")]
    public string? HuongPhong { get; set; }
    [StringLength(1000), Display(Name="Tiện nghi")]
    public string? TienNghi { get; set; }
    [Range(typeof(decimal),"0","9999999999999999.99"), Column(TypeName="decimal(18,2)"), Display(Name="Đơn giá")]
    public decimal DonGia { get; set; }
    [Required, StringLength(20), RegularExpression("^(Trong|DaDat|DangSuDung|BaoTri|NgungKinhDoanh)$")]
    public string TrangThai { get; set; } = TrangThaiPhong.Trong;
    [StringLength(500)] public string? GhiChu { get; set; }
    [DataType(DataType.Date), Display(Name="Ngày bảo trì")]
    public DateTime? NgayBaoTri { get; set; }
    [StringLength(500), Display(Name="Ghi chú bảo trì")]
    public string? GhiChuBaoTri { get; set; }
    public ICollection<ChiTietDatPhong> ChiTietDatPhongs { get; set; } = new List<ChiTietDatPhong>();
}
>>>>>>> model1
