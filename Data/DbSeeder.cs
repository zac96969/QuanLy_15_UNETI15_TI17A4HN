<<<<<<< HEAD:QuanLy_15_UNETI15_TI17A4HN/Data/DbSeeder.cs
<<<<<<< HEAD
// Họ và tên: Vũ Xuân Tuấn
// Mã sinh viên: 23103100035
// Nội dung thực hiện: Thêm Phòng , Khách hàng, Đặt phòng mẫu vào cơ sở dữ liệu khi khởi tạo ứng dụng (DbSeeder.cs)
using QuanLy_15_UNETI15_TI17A4HN.Helpers;
using QuanLy_15_UNETI15_TI17A4HN.Models;

namespace QuanLy_15_UNETI15_TI17A4HN.Data;

public static class DbSeeder
{
    public static void Seed(AppDbContext db)
    {
        if (!db.TaiKhoans.Any())
        {
            db.TaiKhoans.AddRange(
                TaoTaiKhoan("admin1", "Admin@123", "Nguyễn Đình Tuấn", "admin1@khachsan.vn", VaiTroTaiKhoan.Admin),
                TaoTaiKhoan("admin2", "Admin@123", "Trần Quốc Bảo", "admin2@khachsan.vn", VaiTroTaiKhoan.Admin),
                TaoTaiKhoan("nhanvien1", "NhanVien@123", "Lê Thị Hoa", "nv1@khachsan.vn", VaiTroTaiKhoan.NhanVien),
                TaoTaiKhoan("nhanvien2", "NhanVien@123", "Phạm Văn Nam", "nv2@khachsan.vn", VaiTroTaiKhoan.NhanVien),
                TaoTaiKhoan("nhanvien3", "NhanVien@123", "Vũ Thị Lan", "nv3@khachsan.vn", VaiTroTaiKhoan.NhanVien),
                TaoTaiKhoan("khach1", "KhachHang@123", "Hoàng Minh Đức", "khach1@gmail.com", VaiTroTaiKhoan.KhachHang),
                TaoTaiKhoan("khach2", "KhachHang@123", "Đỗ Thu Trang", "khach2@gmail.com", VaiTroTaiKhoan.KhachHang),
                TaoTaiKhoan("khach3", "KhachHang@123", "Bùi Anh Tú", "khach3@gmail.com", VaiTroTaiKhoan.KhachHang),
                TaoTaiKhoan("khach4", "KhachHang@123", "Ngô Mai Linh", "khach4@gmail.com", VaiTroTaiKhoan.KhachHang),
                TaoTaiKhoan("khachkhoa", "KhachHang@123", "Tài Khoản Bị Khóa", "khoa@gmail.com", VaiTroTaiKhoan.KhachHang, false)
            );
        }

        if (!db.LoaiPhongs.Any())
        {
            db.LoaiPhongs.AddRange(
                new LoaiPhong { TenLoai = "Standard Đơn", SoNguoiToiDa = 1, DonGiaNgay = 400_000, MoTa = "Phòng 1 giường đơn, phù hợp khách đi một mình." },
                new LoaiPhong { TenLoai = "Standard Đôi", SoNguoiToiDa = 2, DonGiaNgay = 600_000, MoTa = "Phòng 1 giường đôi hoặc 2 giường đơn." },
                new LoaiPhong { TenLoai = "Deluxe", SoNguoiToiDa = 3, DonGiaNgay = 900_000, MoTa = "Phòng rộng, có ban công và tầm nhìn đẹp." },
                new LoaiPhong { TenLoai = "Family", SoNguoiToiDa = 5, DonGiaNgay = 1_400_000, MoTa = "Phòng gia đình, 2 giường lớn." },
                new LoaiPhong { TenLoai = "Suite", SoNguoiToiDa = 4, DonGiaNgay = 2_000_000, MoTa = "Phòng cao cấp có phòng khách riêng." }
            );
        }

        db.SaveChanges();
        // ── Phòng (15 phòng, nhiều trạng thái) ──
        if (!db.Phongs.Any())
        {
            var lp = db.LoaiPhongs.ToList();
            int std1 = lp.First(l => l.TenLoai == "Standard Đơn").MaLoaiPhong;
            int std2 = lp.First(l => l.TenLoai == "Standard Đôi").MaLoaiPhong;
            int dlx  = lp.First(l => l.TenLoai == "Deluxe").MaLoaiPhong;
            int fam  = lp.First(l => l.TenLoai == "Family").MaLoaiPhong;
            int suit = lp.First(l => l.TenLoai == "Suite").MaLoaiPhong;
            db.Phongs.AddRange(
                new Phong { SoPhong = "101", MaLoaiPhong = std1, Tang = 1, HuongPhong = "Đông", DonGia = 400_000, TrangThai = "TrongRanh" },
                new Phong { SoPhong = "102", MaLoaiPhong = std1, Tang = 1, HuongPhong = "Tây",  DonGia = 400_000, TrangThai = "TrongRanh" },
                new Phong { SoPhong = "103", MaLoaiPhong = std2, Tang = 1, HuongPhong = "Nam",  DonGia = 600_000, TrangThai = "TrongRanh" },
                new Phong { SoPhong = "201", MaLoaiPhong = std2, Tang = 2, HuongPhong = "Đông", DonGia = 600_000, TrangThai = "DangSuDung" },
                new Phong { SoPhong = "202", MaLoaiPhong = dlx,  Tang = 2, HuongPhong = "Nam",  DonGia = 900_000, TrangThai = "TrongRanh" },
                new Phong { SoPhong = "203", MaLoaiPhong = dlx,  Tang = 2, HuongPhong = "Tây",  DonGia = 900_000, TrangThai = "BaoTri", NgayBaoTri = DateTime.Today },
                new Phong { SoPhong = "301", MaLoaiPhong = dlx,  Tang = 3, HuongPhong = "Đông", DonGia = 900_000, TrangThai = "TrongRanh" },
                new Phong { SoPhong = "302", MaLoaiPhong = fam,  Tang = 3, HuongPhong = "Nam",  DonGia = 1_400_000, TrangThai = "TrongRanh" },
                new Phong { SoPhong = "303", MaLoaiPhong = fam,  Tang = 3, HuongPhong = "Tây",  DonGia = 1_400_000, TrangThai = "DangSuDung" },
                new Phong { SoPhong = "401", MaLoaiPhong = fam,  Tang = 4, HuongPhong = "Đông", DonGia = 1_400_000, TrangThai = "TrongRanh" },
                new Phong { SoPhong = "402", MaLoaiPhong = suit, Tang = 4, HuongPhong = "Toàn cảnh", DonGia = 2_000_000, TrangThai = "TrongRanh" },
                new Phong { SoPhong = "403", MaLoaiPhong = suit, Tang = 4, HuongPhong = "Toàn cảnh", DonGia = 2_000_000, TrangThai = "DangSuDung" },
                new Phong { SoPhong = "501", MaLoaiPhong = suit, Tang = 5, HuongPhong = "Toàn cảnh", DonGia = 2_000_000, TrangThai = "TrongRanh" },
                new Phong { SoPhong = "104", MaLoaiPhong = std1, Tang = 1, HuongPhong = "Bắc",  DonGia = 400_000, TrangThai = "KhongKinhDoanh" },
                new Phong { SoPhong = "204", MaLoaiPhong = std2, Tang = 2, HuongPhong = "Bắc",  DonGia = 600_000, TrangThai = "TrongRanh" }
            );
            db.SaveChanges();
        }
        // ── Khách hàng (30 khách) ──
        if (!db.KhachHangs.Any())
        {
            db.KhachHangs.AddRange(
                new KhachHang { HoTen = "Nguyễn Văn An",     GioiTinh = "Nam",  SoDienThoai = "0901111001", Email = "an@gmail.com",     CCCD = "001001000001", QuocTich = "Việt Nam", TrangThai = true },
                new KhachHang { HoTen = "Trần Thị Bình",     GioiTinh = "Nữ",   SoDienThoai = "0901111002", Email = "binh@gmail.com",   CCCD = "001001000002", QuocTich = "Việt Nam", TrangThai = true },
                new KhachHang { HoTen = "Lê Văn Cường",      GioiTinh = "Nam",  SoDienThoai = "0901111003", Email = "cuong@gmail.com",  CCCD = "001001000003", QuocTich = "Việt Nam", TrangThai = true },
                new KhachHang { HoTen = "Phạm Thị Dung",     GioiTinh = "Nữ",   SoDienThoai = "0901111004", Email = "dung@gmail.com",   CCCD = "001001000004", QuocTich = "Việt Nam", TrangThai = true },
                new KhachHang { HoTen = "Hoàng Văn Em",      GioiTinh = "Nam",  SoDienThoai = "0901111005", Email = "em@gmail.com",     CCCD = "001001000005", QuocTich = "Việt Nam", TrangThai = true },
                new KhachHang { HoTen = "Vũ Thị Phương",     GioiTinh = "Nữ",   SoDienThoai = "0901111006", Email = "phuong@gmail.com", CCCD = "001001000006", QuocTich = "Việt Nam", TrangThai = true },
                new KhachHang { HoTen = "Đặng Văn Giang",    GioiTinh = "Nam",  SoDienThoai = "0901111007", Email = "giang@gmail.com",  CCCD = "001001000007", QuocTich = "Việt Nam", TrangThai = true },
                new KhachHang { HoTen = "Bùi Thị Hà",        GioiTinh = "Nữ",   SoDienThoai = "0901111008", Email = "ha@gmail.com",     CCCD = "001001000008", QuocTich = "Việt Nam", TrangThai = true },
                new KhachHang { HoTen = "Ngô Văn Ích",       GioiTinh = "Nam",  SoDienThoai = "0901111009", Email = "ich@gmail.com",    CCCD = "001001000009", QuocTich = "Việt Nam", TrangThai = true },
                new KhachHang { HoTen = "Đinh Thị Kim",      GioiTinh = "Nữ",   SoDienThoai = "0901111010", Email = "kim@gmail.com",    CCCD = "001001000010", QuocTich = "Việt Nam", TrangThai = true },
                new KhachHang { HoTen = "Lý Văn Long",       GioiTinh = "Nam",  SoDienThoai = "0901111011", Email = "long@gmail.com",   CCCD = "001001000011", QuocTich = "Việt Nam", TrangThai = true },
                new KhachHang { HoTen = "Phan Thị Mai",      GioiTinh = "Nữ",   SoDienThoai = "0901111012", Email = "mai@gmail.com",    CCCD = "001001000012", QuocTich = "Việt Nam", TrangThai = true },
                new KhachHang { HoTen = "Trương Văn Nam",    GioiTinh = "Nam",  SoDienThoai = "0901111013", Email = "nam@gmail.com",    CCCD = "001001000013", QuocTich = "Việt Nam", TrangThai = true },
                new KhachHang { HoTen = "Dương Thị Oanh",    GioiTinh = "Nữ",   SoDienThoai = "0901111014", Email = "oanh@gmail.com",   CCCD = "001001000014", QuocTich = "Việt Nam", TrangThai = true },
                new KhachHang { HoTen = "Hồ Văn Phúc",      GioiTinh = "Nam",  SoDienThoai = "0901111015", Email = "phuc@gmail.com",   CCCD = "001001000015", QuocTich = "Việt Nam", TrangThai = true },
                new KhachHang { HoTen = "Tô Thị Quỳnh",     GioiTinh = "Nữ",   SoDienThoai = "0901111016", Email = "quynh@gmail.com",  CCCD = "001001000016", QuocTich = "Việt Nam", TrangThai = true },
                new KhachHang { HoTen = "Cao Văn Rồng",     GioiTinh = "Nam",  SoDienThoai = "0901111017", Email = "rong@gmail.com",   CCCD = "001001000017", QuocTich = "Việt Nam", TrangThai = true },
                new KhachHang { HoTen = "Mai Thị Sen",       GioiTinh = "Nữ",   SoDienThoai = "0901111018", Email = "sen@gmail.com",    CCCD = "001001000018", QuocTich = "Việt Nam", TrangThai = true },
                new KhachHang { HoTen = "Kiều Văn Thắng",   GioiTinh = "Nam",  SoDienThoai = "0901111019", Email = "thang@gmail.com",  CCCD = "001001000019", QuocTich = "Việt Nam", TrangThai = true },
                new KhachHang { HoTen = "Lưu Thị Uyên",     GioiTinh = "Nữ",   SoDienThoai = "0901111020", Email = "uyen@gmail.com",   CCCD = "001001000020", QuocTich = "Việt Nam", TrangThai = true },
                new KhachHang { HoTen = "John Smith",        GioiTinh = "Nam",  SoDienThoai = "0901111021", Email = "john@mail.com",    CCCD = "PASS001",      QuocTich = "Mỹ",       TrangThai = true },
                new KhachHang { HoTen = "Emma Johnson",      GioiTinh = "Nữ",   SoDienThoai = "0901111022", Email = "emma@mail.com",    CCCD = "PASS002",      QuocTich = "Anh",      TrangThai = true },
                new KhachHang { HoTen = "Zhang Wei",         GioiTinh = "Nam",  SoDienThoai = "0901111023", Email = "zhang@mail.com",   CCCD = "PASS003",      QuocTich = "Trung Quốc", TrangThai = true },
                new KhachHang { HoTen = "Yuki Tanaka",       GioiTinh = "Nữ",   SoDienThoai = "0901111024", Email = "yuki@mail.com",    CCCD = "PASS004",      QuocTich = "Nhật Bản", TrangThai = true },
                new KhachHang { HoTen = "Park Jiyeon",       GioiTinh = "Nữ",   SoDienThoai = "0901111025", Email = "park@mail.com",    CCCD = "PASS005",      QuocTich = "Hàn Quốc", TrangThai = true },
                new KhachHang { HoTen = "Nguyễn Thị Vân",   GioiTinh = "Nữ",   SoDienThoai = "0901111026", Email = "van@gmail.com",    CCCD = "001001000026", QuocTich = "Việt Nam", TrangThai = true },
                new KhachHang { HoTen = "Trần Văn Xinh",    GioiTinh = "Nam",  SoDienThoai = "0901111027", Email = "xinh@gmail.com",   CCCD = "001001000027", QuocTich = "Việt Nam", TrangThai = true },
                new KhachHang { HoTen = "Lê Thị Yến",       GioiTinh = "Nữ",   SoDienThoai = "0901111028", Email = "yen@gmail.com",    CCCD = "001001000028", QuocTich = "Việt Nam", TrangThai = true },
                new KhachHang { HoTen = "Phạm Văn Zũng",    GioiTinh = "Nam",  SoDienThoai = "0901111029", Email = "zung@gmail.com",   CCCD = "001001000029", QuocTich = "Việt Nam", TrangThai = true },
                new KhachHang { HoTen = "Hoàng Thị Ánh",    GioiTinh = "Nữ",   SoDienThoai = "0901111030", Email = "anh@gmail.com",    CCCD = "001001000030", QuocTich = "Việt Nam", TrangThai = false }
            );
            db.SaveChanges();
        }
        // ── Đặt phòng mẫu (50 bản ghi, nhiều trạng thái) ──
        if (!db.DatPhongs.Any())
        {
            var phongs = db.Phongs.ToList();
            var khs    = db.KhachHangs.ToList();

            var khList = khs.ToList();
            int KhId(int idx) => khList[idx % khList.Count].MaKhachHang;
            int PhId(string so) => phongs.First(p => p.SoPhong == so).MaPhong;
            var list = new List<DatPhong>();
            // 10 ChoDuyet
            for (int i = 0; i < 10; i++)
                list.Add(new DatPhong { MaKhachHang = KhId(i),    MaPhong = PhId("101"), NgayDat = DateTime.Now.AddDays(-i),      NgayNhan = DateTime.Now.AddDays(i+1),  NgayTraDuKien = DateTime.Now.AddDays(i+3),  SoNguoi=1, TienCoc=200_000, TrangThai = TrangThaiDatPhong.ChoDuyet });
            // 10 DaDuyet
            for (int i = 0; i < 10; i++)
                list.Add(new DatPhong { MaKhachHang = KhId(i+10), MaPhong = PhId("102"), NgayDat = DateTime.Now.AddDays(-i-5),   NgayNhan = DateTime.Now.AddDays(i+1),  NgayTraDuKien = DateTime.Now.AddDays(i+4),  SoNguoi=1, TienCoc=200_000, TrangThai = TrangThaiDatPhong.DaDuyet });
            // 10 DaNhanPhong
            for (int i = 0; i < 10; i++)
                list.Add(new DatPhong { MaKhachHang = KhId(i+5),  MaPhong = PhId("103"), NgayDat = DateTime.Now.AddDays(-i-10),  NgayNhan = DateTime.Now.AddDays(-i),   NgayTraDuKien = DateTime.Now.AddDays(i+2),  SoNguoi=1, TienCoc=200_000, TrangThai = TrangThaiDatPhong.DaNhanPhong, NgayNhanThucTe = DateTime.Now.AddDays(-i) });
            // 10 DaTraPhong
            for (int i = 0; i < 10; i++)
                list.Add(new DatPhong { MaKhachHang = KhId(i+15), MaPhong = PhId("201"), NgayDat = DateTime.Now.AddDays(-i-20), NgayNhan = DateTime.Now.AddDays(-i-10), NgayTraDuKien = DateTime.Now.AddDays(-i-5), SoNguoi=1, TienCoc=200_000, TrangThai = TrangThaiDatPhong.DaTraPhong, NgayNhanThucTe = DateTime.Now.AddDays(-i-10), NgayTraThucTe = DateTime.Now.AddDays(-i-5) });
            // 10 Huy
            for (int i = 0; i < 10; i++)
                list.Add(new DatPhong { MaKhachHang = KhId(i+20), MaPhong = PhId("204"), NgayDat = DateTime.Now.AddDays(-i-3),  NgayNhan = DateTime.Now.AddDays(i+2),  NgayTraDuKien = DateTime.Now.AddDays(i+5),  SoNguoi=1, TienCoc=200_000, TrangThai = TrangThaiDatPhong.Huy, LyDoHuy = "Khách hủy vì lý do cá nhân" });
            db.DatPhongs.AddRange(list);
            db.SaveChanges();
        }
    }

    private static TaiKhoan TaoTaiKhoan(string tenDangNhap, string matKhau, string hoTen,
        string email, string vaiTro, bool trangThai = true) => new()
    {
        TenDangNhap = tenDangNhap,
        MatKhau = MatKhauHelper.BamMatKhau(matKhau),
        HoTen = hoTen,
        Email = email,
        VaiTro = vaiTro,
        TrangThai = trangThai
    };
}
=======
// Họ và tên: Nguyễn Đình Tuấn
// Mã sinh viên: 23103100235
// Nội dung thực hiện: Dữ liệu mẫu tối thiểu cho tài khoản, loại phòng, phòng, khách và giao dịch.
using Microsoft.EntityFrameworkCore;
using QuanLy_15_UNETI15_TI17A4HN.Helpers;
using QuanLy_15_UNETI15_TI17A4HN.Models;
namespace QuanLy_15_UNETI15_TI17A4HN.Data;
=======
// Họ và tên: Lê Văn Thanh
// Mã sinh viên: 23103100200
// Nội dung thực hiện: Module 5 - Dữ liệu mẫu tài khoản (Admin, Nhân viên, Khách hàng) và loại phòng phục vụ kiểm thử.
using QuanLy_15_UNETI15_TI17A4HN.Helpers;
using QuanLy_15_UNETI15_TI17A4HN.Models;

namespace QuanLy_15_UNETI15_TI17A4HN.Data;

>>>>>>> md5:Data/DbSeeder.cs
public static class DbSeeder
{
    public static void Seed(AppDbContext db)
    {
<<<<<<< HEAD:QuanLy_15_UNETI15_TI17A4HN/Data/DbSeeder.cs
        var taiKhoanMau = new (string User,string Pass,string Name,string Email,string Role,bool Active)[]
        {
            ("admin1","Admin@123","Nguyễn Đình Tuấn","admin1@khachsan.vn",VaiTroTaiKhoan.Admin,true),
            ("admin2","Admin@123","Trần Quốc Bảo","admin2@khachsan.vn",VaiTroTaiKhoan.Admin,true),
            ("nhanvien1","NhanVien@123","Lê Thị Hoa","nv1@khachsan.vn",VaiTroTaiKhoan.NhanVien,true),
            ("nhanvien2","NhanVien@123","Phạm Văn Nam","nv2@khachsan.vn",VaiTroTaiKhoan.NhanVien,true),
            ("nhanvien3","NhanVien@123","Vũ Thị Lan","nv3@khachsan.vn",VaiTroTaiKhoan.NhanVien,true),
            ("khach1","KhachHang@123","Hoàng Minh Đức","khach1@gmail.com",VaiTroTaiKhoan.KhachHang,true),
            ("khach2","KhachHang@123","Đỗ Thu Trang","khach2@gmail.com",VaiTroTaiKhoan.KhachHang,true),
            ("khach3","KhachHang@123","Bùi Anh Tú","khach3@gmail.com",VaiTroTaiKhoan.KhachHang,true),
            ("khach4","KhachHang@123","Ngô Mai Linh","khach4@gmail.com",VaiTroTaiKhoan.KhachHang,true),
            ("khachkhoa","KhachHang@123","Tài khoản bị khóa","khoa@gmail.com",VaiTroTaiKhoan.KhachHang,false)
        };
        foreach(var a in taiKhoanMau)
            if(!db.TaiKhoans.Any(x=>x.TenDangNhap==a.User))
                db.TaiKhoans.Add(new TaiKhoan{TenDangNhap=a.User,MatKhau=MatKhauHelper.BamMatKhau(a.Pass),HoTen=a.Name,Email=a.Email,VaiTro=a.Role,TrangThai=a.Active});

        var soTaiKhoanKhach=db.TaiKhoans.Count(x=>x.VaiTro==VaiTroTaiKhoan.KhachHang);
        for(int i=1; soTaiKhoanKhach<30; i++)
        {
            var user=$"khach{i:00}";
            if(!db.TaiKhoans.Any(x=>x.TenDangNhap==user))
            {
                db.TaiKhoans.Add(new TaiKhoan{TenDangNhap=user,MatKhau=MatKhauHelper.BamMatKhau("KhachHang@123"),HoTen=$"Khách hàng {i:00}",Email=$"{user}@gmail.com",VaiTro=VaiTroTaiKhoan.KhachHang,TrangThai=true});
                soTaiKhoanKhach++;
            }
        }

        var loaiMau=new (string Name,int Capacity,decimal Price,string Description)[]
        {
            ("Standard Đơn",1,400000m,"Phòng một giường đơn."),
            ("Standard Đôi",2,600000m,"Phòng tiêu chuẩn giường đôi."),
            ("Deluxe",3,900000m,"Phòng rộng, có ban công."),
            ("Family",5,1400000m,"Phòng gia đình."),
            ("Suite",4,2000000m,"Phòng cao cấp, có phòng khách riêng.")
        };
        foreach(var l in loaiMau)
            if(!db.LoaiPhongs.Any(x=>x.TenLoai==l.Name))
                db.LoaiPhongs.Add(new LoaiPhong{TenLoai=l.Name,SoNguoiToiDa=l.Capacity,DonGiaNgay=l.Price,MoTa=l.Description,TrangThai=true});
        db.SaveChanges();

        var khachTaiKhoan=db.TaiKhoans.Where(x=>x.VaiTro==VaiTroTaiKhoan.KhachHang).OrderBy(x=>x.MaTaiKhoan).Take(30).ToList();
        for(int i=0;i<khachTaiKhoan.Count;i++)
        {
            var tk=khachTaiKhoan[i];
            if(!db.KhachHangs.Any(x=>x.MaTaiKhoan==tk.MaTaiKhoan))
                db.KhachHangs.Add(new KhachHang{MaTaiKhoan=tk.MaTaiKhoan,HoTen=tk.HoTen,Email=tk.Email,CCCD=$"079{i+1:000000000}",SoDienThoai=$"090{i+1:0000000}",NgaySinh=new DateTime(1980+i%20,1+i%12,1+i%27),GioiTinh=i%2==0?"Nam":"Nữ",DiaChi=$"Quận {(i%12)+1}, TP. Hồ Chí Minh",QuocTich="Việt Nam",TrangThai=tk.TrangThai});
        }
        db.SaveChanges();
        var khachs=db.KhachHangs.OrderBy(x=>x.MaKhachHang).Take(30).ToList();
        var loais=db.LoaiPhongs.OrderBy(x=>x.MaLoaiPhong).ToList();
        for(int i=1;i<=15;i++)
        {
            var soPhong=(100+i).ToString();
            if(!db.Phongs.Any(x=>x.SoPhong==soPhong))
            {
                var loai=loais[(i-1)%loais.Count];
                db.Phongs.Add(new Phong{SoPhong=soPhong,MaLoaiPhong=loai.MaLoaiPhong,Tang=(i-1)/5+1,HuongPhong=i%2==0?"Đông":"Tây",TienNghi="Wi-Fi, điều hòa, TV, minibar",DonGia=loai.DonGiaNgay,TrangThai=TrangThaiPhong.Trong});
            }
        }
        var dichVuMau=new (string Name,string Unit,decimal Price)[]
        {
            ("Bữa sáng","suất",120000m),("Giặt ủi","kg",50000m),("Đưa đón sân bay","chuyến",300000m),("Nước uống","chai",20000m),
            ("Spa","lượt",250000m),("Thuê xe","ngày",400000m),("Minibar","lần",100000m),("Ăn tại phòng","suất",180000m)
        };
        foreach(var d in dichVuMau)
            if(!db.DichVus.Any(x=>x.TenDichVu==d.Name))
                db.DichVus.Add(new DichVu{TenDichVu=d.Name,DonViTinh=d.Unit,DonGia=d.Price,TrangThai=true});
        db.SaveChanges();

        var rooms=db.Phongs.Include(x=>x.LoaiPhong).OrderBy(x=>x.MaPhong).ToList();
        var staff=db.TaiKhoans.Where(x=>x.VaiTro==VaiTroTaiKhoan.NhanVien).OrderBy(x=>x.MaTaiKhoan).ToList();
        var today=DateTime.UtcNow.Date;
        for(int i=1;i<=45;i++)
        {
            var tag=$"[DEMO-DAT-{i:000}]";
            if(db.DatPhongs.Any(x=>x.GhiChu!=null&&x.GhiChu.Contains(tag))) continue;
            var room=rooms[(i-1)%rooms.Count];
            DateTime nhan=i<=15?today.AddDays(-45+i*2):i<=18?today.AddDays(-1):i<=33?today.AddDays(3+(i-19)*2):today.AddDays(-i);
            var state=i<=15?TrangThaiDatPhong.HoanThanh:i<=18?TrangThaiDatPhong.DangXuLy:i<=33?TrangThaiDatPhong.ChoXuLy:i<=40?TrangThaiDatPhong.Huy:TrangThaiDatPhong.TuChoi;
            db.DatPhongs.Add(new DatPhong{MaKhachHang=khachs[(i-1)%khachs.Count].MaKhachHang,MaNhanVienTiepNhan=state==TrangThaiDatPhong.ChoXuLy?null:staff[(i-1)%staff.Count].MaTaiKhoan,NgayDat=today.AddDays(-1-i%10),NgayNhan=nhan,NgayTraDuKien=nhan.AddDays(2),SoNguoi=Math.Min(room.LoaiPhong!.SoNguoiToiDa,1+i%3),TienCoc=state==TrangThaiDatPhong.HoanThanh||state==TrangThaiDatPhong.DangXuLy?room.DonGia*0.2m:0,TrangThai=state,GhiChu=$"{tag} Dữ liệu mẫu kiểm thử."});
        }
        db.SaveChanges();

        var sampleBookings=db.DatPhongs.Where(x=>x.GhiChu!=null&&x.GhiChu.Contains("[DEMO-DAT-")).OrderBy(x=>x.MaDatPhong).ToList();
        var services=db.DichVus.OrderBy(x=>x.MaDichVu).ToList();
        for(int i=1;i<=18;i++)
        {
            var tag=$"[DEMO-DAT-{i:000}]";
            var booking=sampleBookings.FirstOrDefault(x=>x.GhiChu!.Contains(tag));
            if(booking==null) continue;
            var room=rooms[(i-1)%rooms.Count];
            if(!db.ChiTietDatPhongs.Any(x=>x.MaDatPhong==booking.MaDatPhong&&x.MaPhong==room.MaPhong))
                db.ChiTietDatPhongs.Add(new ChiTietDatPhong{MaDatPhong=booking.MaDatPhong,MaPhong=room.MaPhong,NgayNhan=booking.NgayNhan,NgayTra=booking.NgayTraDuKien,DonGia=room.DonGia,SoNgay=2,ThanhTien=room.DonGia*2,TrangThai=i<=15?TrangThaiChiTietDatPhong.DaTraPhong:TrangThaiChiTietDatPhong.DangSuDung});
            if(i>15) room.TrangThai=TrangThaiPhong.DangSuDung;
        }
        db.SaveChanges();
        var details=db.ChiTietDatPhongs.OrderBy(x=>x.MaChiTiet).ToList();
        for(int i=db.SuDungDichVus.Count();i<20&&details.Count>0;i++)
        {
            var d=services[i%services.Count];
            var qty=1+i%3;
            db.SuDungDichVus.Add(new SuDungDichVu{MaChiTiet=details[i%details.Count].MaChiTiet,MaDichVu=d.MaDichVu,SoLuong=qty,DonGia=d.DonGia,ThanhTien=d.DonGia*qty,NgaySuDung=details[i%details.Count].NgayNhan.AddDays(1)});
        }
        db.SaveChanges();
    }
}
>>>>>>> model1
=======
        if (!db.TaiKhoans.Any())
        {
            db.TaiKhoans.AddRange(
                TaoTaiKhoan("admin1", "Admin@123", "Lê Văn Thanh", "admin1@khachsan.vn", VaiTroTaiKhoan.Admin),
                TaoTaiKhoan("admin2", "Admin@123", "Trần Quốc Bảo", "admin2@khachsan.vn", VaiTroTaiKhoan.Admin),
                TaoTaiKhoan("nhanvien1", "NhanVien@123", "Lê Thị Hoa", "nv1@khachsan.vn", VaiTroTaiKhoan.NhanVien),
                TaoTaiKhoan("nhanvien2", "NhanVien@123", "Phạm Văn Nam", "nv2@khachsan.vn", VaiTroTaiKhoan.NhanVien),
                TaoTaiKhoan("nhanvien3", "NhanVien@123", "Vũ Thị Lan", "nv3@khachsan.vn", VaiTroTaiKhoan.NhanVien),
                TaoTaiKhoan("khach1", "KhachHang@123", "Hoàng Minh Đức", "khach1@gmail.com", VaiTroTaiKhoan.KhachHang),
                TaoTaiKhoan("khach2", "KhachHang@123", "Đỗ Thu Trang", "khach2@gmail.com", VaiTroTaiKhoan.KhachHang),
                TaoTaiKhoan("khach3", "KhachHang@123", "Bùi Anh Tú", "khach3@gmail.com", VaiTroTaiKhoan.KhachHang),
                TaoTaiKhoan("khach4", "KhachHang@123", "Ngô Mai Linh", "khach4@gmail.com", VaiTroTaiKhoan.KhachHang),
                TaoTaiKhoan("khachkhoa", "KhachHang@123", "Tài Khoản Bị Khóa", "khoa@gmail.com", VaiTroTaiKhoan.KhachHang, false)
            );
        }

        if (!db.LoaiPhongs.Any())
        {
            db.LoaiPhongs.AddRange(
                new LoaiPhong { TenLoai = "Standard Đơn", SoNguoiToiDa = 1, DonGiaNgay = 400_000, MoTa = "Phòng 1 giường đơn, phù hợp khách đi một mình." },
                new LoaiPhong { TenLoai = "Standard Đôi", SoNguoiToiDa = 2, DonGiaNgay = 600_000, MoTa = "Phòng 1 giường đôi hoặc 2 giường đơn." },
                new LoaiPhong { TenLoai = "Deluxe", SoNguoiToiDa = 3, DonGiaNgay = 900_000, MoTa = "Phòng rộng, có ban công và tầm nhìn đẹp." },
                new LoaiPhong { TenLoai = "Family", SoNguoiToiDa = 5, DonGiaNgay = 1_400_000, MoTa = "Phòng gia đình, 2 giường lớn." },
                new LoaiPhong { TenLoai = "Suite", SoNguoiToiDa = 4, DonGiaNgay = 2_000_000, MoTa = "Phòng cao cấp có phòng khách riêng." }
            );
        }

        db.SaveChanges();

        // Dữ liệu giao dịch (phòng, khách hàng, đặt phòng, chi tiết) phục vụ Module 5.
        DuLieuMauGiaoDich.Seed(db);
    }

    private static TaiKhoan TaoTaiKhoan(string tenDangNhap, string matKhau, string hoTen,
        string email, string vaiTro, bool trangThai = true) => new()
    {
        TenDangNhap = tenDangNhap,
        MatKhau = MatKhauHelper.BamMatKhau(matKhau),
        HoTen = hoTen,
        Email = email,
        VaiTro = vaiTro,
        TrangThai = trangThai
    };
}
>>>>>>> md5:Data/DbSeeder.cs
