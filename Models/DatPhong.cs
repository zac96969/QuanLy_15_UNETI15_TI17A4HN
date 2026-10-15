<<<<<<< HEAD:QuanLy_15_UNETI15_TI17A4HN/Models/DatPhong.cs
<<<<<<< HEAD
// Họ và tên: Vũ Xuân Tuấn
// Mã sinh viên: 23103100035
// Nội dung thực hiện: Models DatPhong




=======
// Họ và tên: Lê Văn Thanh
// Mã sinh viên: 23103100200
// Nội dung thực hiện: Module 5 - Entity DatPhong (nền tảng) liên kết khóa ngoại với ChiTietDatPhong.
// Entity nền tảng (khung tối thiểu theo đề) để Module 5 liên kết khóa ngoại.
// Module 3 (tạo đặt phòng) và Module 4 (tiếp nhận, nhận/trả phòng, luồng trạng thái) sẽ hoàn thiện nghiệp vụ.
>>>>>>> md5:Models/DatPhong.cs
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuanLy_15_UNETI15_TI17A4HN.Models;

<<<<<<< HEAD:QuanLy_15_UNETI15_TI17A4HN/Models/DatPhong.cs
=======
// Luồng: Chờ xử lý -> Đang xử lý -> Hoàn thành; có thể Đã hủy khi còn Chờ xử lý.
public static class TrangThaiDatPhong
{
    public const string ChoXuLy = "Chờ xử lý";
    public const string DangXuLy = "Đang xử lý";
    public const string HoanThanh = "Hoàn thành";
    public const string DaHuy = "Đã hủy";

    public static readonly string[] TatCa = { ChoXuLy, DangXuLy, HoanThanh, DaHuy };
}

>>>>>>> md5:Models/DatPhong.cs
public class DatPhong
{
    [Key]
    public int MaDatPhong { get; set; }

<<<<<<< HEAD:QuanLy_15_UNETI15_TI17A4HN/Models/DatPhong.cs
    [Required]
    [Display(Name = "Khách hàng")]
    public int MaKhachHang { get; set; }

    [Required]
    [Display(Name = "Phòng")]
    public int MaPhong { get; set; }
=======
    [Display(Name = "Khách hàng")]
    public int MaKhachHang { get; set; }
    public KhachHang KhachHang { get; set; } = null!;
>>>>>>> md5:Models/DatPhong.cs

    [Display(Name = "Ngày đặt")]
    public DateTime NgayDat { get; set; } = DateTime.Now;

<<<<<<< HEAD:QuanLy_15_UNETI15_TI17A4HN/Models/DatPhong.cs
    [Required]
    [Display(Name = "Ngày nhận (dự kiến)")]
    public DateTime NgayNhan { get; set; }

    [Required]
    [Display(Name = "Ngày trả (dự kiến)")]
    public DateTime NgayTraDuKien { get; set; }

    // ─── 3 trường Module 4 quản lý ───
    [Display(Name = "Ngày nhận thực tế")]
    public DateTime? NgayNhanThucTe { get; set; }

    [Display(Name = "Ngày trả thực tế")]
    public DateTime? NgayTraThucTe { get; set; }

    [StringLength(500)]
    [Display(Name = "Lý do hủy")]
    public string? LyDoHuy { get; set; }
    // ──────────────────────────────────

    [Range(1, 20)]
    [Display(Name = "Số người")]
    public int SoNguoi { get; set; } = 1;

    [Range(0, double.MaxValue)]
=======
    [DataType(DataType.Date)]
    [Display(Name = "Ngày nhận")]
    public DateTime NgayNhan { get; set; }

    [DataType(DataType.Date)]
    [Display(Name = "Ngày trả dự kiến")]
    public DateTime NgayTraDuKien { get; set; }

    [Range(1, 50, ErrorMessage = "Số người phải lớn hơn 0")]
    [Display(Name = "Số người")]
    public int SoNguoi { get; set; } = 1;

    [Range(0, 1_000_000_000, ErrorMessage = "Tiền cọc phải lớn hơn hoặc bằng 0")]
>>>>>>> md5:Models/DatPhong.cs
    [Column(TypeName = "decimal(18,2)")]
    [Display(Name = "Tiền cọc")]
    public decimal TienCoc { get; set; }

<<<<<<< HEAD:QuanLy_15_UNETI15_TI17A4HN/Models/DatPhong.cs
    // TrangThai: "ChoDuyet", "DaDuyet", "DaNhanPhong", "DaTraPhong", "Huy"
    [Required]
    [StringLength(30)]
    [Display(Name = "Trạng thái")]
    public string TrangThai { get; set; } = "ChoDuyet";
=======
    [Required]
    [StringLength(30)]
    [Display(Name = "Trạng thái")]
    public string TrangThai { get; set; } = TrangThaiDatPhong.ChoXuLy;
>>>>>>> md5:Models/DatPhong.cs

    [StringLength(500)]
    [Display(Name = "Ghi chú")]
    public string? GhiChu { get; set; }

<<<<<<< HEAD:QuanLy_15_UNETI15_TI17A4HN/Models/DatPhong.cs
    // Navigation
    public KhachHang KhachHang { get; set; } = null!;
    public Phong Phong { get; set; } = null!;
}
=======
// Họ và tên: Nguyễn Đình Tuấn
// Mã sinh viên: 23103100235
// Nội dung thực hiện: Entity giao dịch đặt phòng, người đặt, nhân viên tiếp nhận và trạng thái.
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace QuanLy_15_UNETI15_TI17A4HN.Models;
public static class TrangThaiDatPhong
{
    public const string ChoXuLy = "ChoXuLy";
    public const string DangXuLy = "DangXuLy";
    public const string HoanThanh = "HoanThanh";
    public const string Huy = "Huy";
    public const string TuChoi = "TuChoi";
}
public class DatPhong
{
    [Key] public int MaDatPhong { get; set; }
    [Required] public int MaKhachHang { get; set; }
    public KhachHang? KhachHang { get; set; }
    public int? MaNhanVienTiepNhan { get; set; }
    [ForeignKey(nameof(MaNhanVienTiepNhan))]
    public TaiKhoan? NhanVienTiepNhan { get; set; }
    [DataType(DataType.DateTime), Display(Name="Ngày đặt")]
    public DateTime NgayDat { get; set; } = DateTime.UtcNow;
    [Required, DataType(DataType.DateTime), Display(Name="Ngày nhận phòng")]
    public DateTime NgayNhan { get; set; }
    [Required, DataType(DataType.DateTime), Display(Name="Ngày trả dự kiến")]
    public DateTime NgayTraDuKien { get; set; }
    [Range(1,100), Display(Name="Số người")]
    public int SoNguoi { get; set; }
    [Range(typeof(decimal),"0","9999999999999999.99"), Column(TypeName="decimal(18,2)"), Display(Name="Tiền cọc")]
    public decimal TienCoc { get; set; }
    [Required, StringLength(20), RegularExpression("^(ChoXuLy|DangXuLy|HoanThanh|Huy|TuChoi)$")]
    public string TrangThai { get; set; } = TrangThaiDatPhong.ChoXuLy;
    [StringLength(1000)] public string? GhiChu { get; set; }
    public ICollection<ChiTietDatPhong> ChiTietDatPhongs { get; set; } = new List<ChiTietDatPhong>();
}
>>>>>>> model1
=======
    public ICollection<ChiTietDatPhong> ChiTietDatPhongs { get; set; } = new List<ChiTietDatPhong>();
}
>>>>>>> md5:Models/DatPhong.cs
