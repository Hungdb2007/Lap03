ưusing System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Lab03_OOP
{
    // ==========================================
    // BÀI TẬP 1: QUẢN LÝ HÌNH HỌC
    // ==========================================
    public class HinhHoc
    {
        public double DienTich { get; set; }
        public double ChuVi { get; set; }

        public virtual void tinhDienTichChuVi()
        {
        }

        public override string ToString()
        {
            return string.Format("S = {0}; P = {1}", Math.Round(DienTich, 2), Math.Round(ChuVi, 2));
        }
    }

    public class HinhChuNhat : HinhHoc
    {
        private double mChieuDai;
        private double mChieuRong;

        public double ChieuDai
        {
            get => mChieuDai;
            set
            {
                if (value > 0) mChieuDai = value;
                else throw new Exception("Chieu dai phai > 0");
            }
        }

        public double ChieuRong
        {
            get => mChieuRong;
            set
            {
                if (value > 0) mChieuRong = value;
                else throw new Exception("Chieu rong phai > 0");
            }
        }

        public HinhChuNhat(double d = 1, double r = 0.5)
        {
            ChieuDai = d;
            ChieuRong = r;
            tinhDienTichChuVi();
        }

        public override void tinhDienTichChuVi()
        {
            DienTich = ChieuDai * ChieuRong;
            ChuVi = (ChieuDai + ChieuRong) * 2;
        }

        public override string ToString()
        {
            return string.Format("L = {0}, W = {1}; {2}", ChieuDai, ChieuRong, base.ToString());
        }
    }

    public class HinhTron : HinhHoc
    {
        private double mBanKinh;

        public double BanKinh
        {
            get => mBanKinh;
            set
            {
                if (value > 0) mBanKinh = value;
                else throw new Exception("Ban kinh phai > 0");
            }
        }

        public HinhTron(double r = 1.0)
        {
            BanKinh = r;
            tinhDienTichChuVi();
        }

        public override void tinhDienTichChuVi()
        {
            DienTich = Math.PI * BanKinh * BanKinh;
            ChuVi = 2 * Math.PI * BanKinh;
        }

        public override string ToString()
        {
            return string.Format("R = {0}; {1}", BanKinh, base.ToString());
        }
    }

    // ==========================================
    // BÀI TẬP 2: QUẢN LÝ NHÂN VIÊN & CON NGƯỜI
    // ==========================================
    public class Nguoi
    {
        public string HoTen { get; set; }
        public DateTime NgaySinh { get; set; }
        public string DiaChi { get; set; }

        public int Tuoi => DateTime.Now.Year - NgaySinh.Year;

        public Nguoi()
        {
            HoTen = "Chua khai bao";
            NgaySinh = DateTime.Now;
            DiaChi = "Chua khai bao";
        }

        public Nguoi(string hoTen, DateTime ngaySinh, string diaChi)
        {
            HoTen = hoTen;
            NgaySinh = ngaySinh;
            DiaChi = diaChi;
        }

        public virtual void XemThongTin()
        {
            Console.WriteLine($"Ho ten: {HoTen} | Ngay sinh: {NgaySinh:dd/MM/yyyy} | Tuoi: {Tuoi} | Dia chi: {DiaChi}");
        }
    }

    public class SinhVien : Nguoi
    {
        public string MaSV { get; set; }
        public string MaLop { get; set; }
        public string Email { get; set; }
        public string DienThoai { get; set; }

        public SinhVien() : base()
        {
            MaSV = MaLop = Email = DienThoai = "";
        }

        public SinhVien(string hoTen, DateTime ngaySinh, string diaChi, string maSV, string maLop, string email, string dienThoai)
            : base(hoTen, ngaySinh, diaChi)
        {
            MaSV = maSV;
            MaLop = maLop;
            Email = email;
            DienThoai = dienThoai;
        }

        public override void XemThongTin()
        {
            base.XemThongTin();
            Console.WriteLine($"[Sinh Vien] MSSV: {MaSV} | Lop: {MaLop} | Email: {Email} | SĐT: {DienThoai}");
        }
    }

    public class NhanVien : Nguoi
    {
        public string MaNhanVien { get; set; }
        public string Email { get; set; }
        public string DienThoai { get; set; }
        public DateTime NgayLamViec { get; set; }
        public string MaCongTy { get; set; }

        public NhanVien() : base()
        {
            MaNhanVien = Email = DienThoai = MaCongTy = "";
            NgayLamViec = DateTime.Now;
        }

        public NhanVien(string hoTen, DateTime ngaySinh, string diaChi, string maNV, string email, string dienThoai, DateTime ngayLamViec, string maCT)
            : base(hoTen, ngaySinh, diaChi)
        {
            MaNhanVien = maNV;
            Email = email;
            DienThoai = dienThoai;
            NgayLamViec = ngayLamViec;
            MaCongTy = maCT;
        }

        public override void XemThongTin()
        {
            base.XemThongTin();
            Console.WriteLine($"[Nhan Vien] MaNV: {MaNhanVien} | Cong ty: {MaCongTy} | Email: {Email} | SĐT: {DienThoai} | Ngay vao lam: {NgayLamViec:dd/MM/yyyy}");
        }
    }

    // ==========================================
    // BÀI TẬP 3: LỚP ĐA THỨC
    // ==========================================
    public class DaThuc
    {
        private double[] heSo;

        public int Bac => heSo.Length - 1;

        public DaThuc(int bac)
        {
            if (bac < 0) bac = 0;
            heSo = new double[bac + 1];
        }

        public double this[int k]
        {
            get
            {
                if (k >= 0 && k <= Bac) return heSo[k];
                return 0;
            }
            set
            {
                if (k >= 0 && k <= Bac) heSo[k] = value;
            }
        }

        public double TinhGiaTri(double b)
        {
            double res = 0;
            for (int i = 0; i <= Bac; i++)
            {
                res += heSo[i] * Math.Pow(b, i);
            }
            return res;
        }

        public static DaThuc operator +(DaThuc p1, DaThuc p2)
        {
            int maxBac = Math.Max(p1.Bac, p2.Bac);
            DaThuc res = new DaThuc(maxBac);
            for (int i = 0; i <= maxBac; i++)
            {
                res[i] = p1[i] + p2[i];
            }
            return res;
        }

        public static DaThuc operator -(DaThuc p1, DaThuc p2)
        {
            int maxBac = Math.Max(p1.Bac, p2.Bac);
            DaThuc res = new DaThuc(maxBac);
            for (int i = 0; i <= maxBac; i++)
            {
                res[i] = p1[i] - p2[i];
            }
            return res;
        }

        public override string ToString()
        {
            List<string> terms = new List<string>();
            for (int i = Bac; i >= 0; i--)
            {
                if (heSo[i] != 0 || Bac == 0)
                {
                    if (i == 0) terms.Add($"{heSo[i]}");
                    else if (i == 1) terms.Add($"{heSo[i]}x");
                    else terms.Add($"{heSo[i]}x^{i}");
                }
            }
            return terms.Count > 0 ? string.Join(" + ", terms) : "0";
        }
    }

    // ==========================================
    // CHƯƠNG TRÌNH CHÍNH
    // ==========================================
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            while (true)
            {
                Console.Clear();
                Console.WriteLine("==================================================");
                Console.WriteLine("          LAB 03 - LẬP TRÌNH HƯỚNG ĐỐI TƯỢNG       ");
                Console.WriteLine("==================================================");
                Console.WriteLine("1. Bài tập 1: Quản lý Hình học (Đọc/Ghi file)");
                Console.WriteLine("2. Bài tập 2: Quản lý Nhân viên & Con người");
                Console.WriteLine("3. Bài tập 3: Thao tác Lớp Đa thức");
                Console.WriteLine("0. Thoát");
                Console.WriteLine("==================================================");
                Console.Write("Chọn bài tập (0-3): ");

                string choice = Console.ReadLine();
                Console.WriteLine();

                switch (choice)
                {
                    case "1":
                        ThucHanhBai1();
                        break;
                    case "2":
                        ThucHanhBai2();
                        break;
                    case "3":
                        ThucHanhBai3();
                        break;
                    case "0":
                        return;
                    default:
                        Console.WriteLine("Lựa chọn không hợp lệ!");
                        break;
                }

                Console.WriteLine("\nẤn phím bất kỳ để quay lại menu...");
                Console.ReadKey();
            }
        }

        static void ThucHanhBai1()
        {
            Console.WriteLine("--- BÀI TẬP 1: QUẢN LÝ HÌNH HỌC ---");
            string inputFile = "HinhHoc.txt";
            string outputFile = "output.txt";

            // Tạo file HinhHoc.txt mẫu nếu chưa tồn tại
            if (!File.Exists(inputFile))
            {
                string[] sampleLines = new string[]
                {
                    "1\t5.3\t3.2",
                    "2\t9.1",
                    "1\t11\t2",
                    "1\t12.9\t10",
                    "2\t4.5",
                    "2\t3.4",
                    "1\t77\t55"
                };
                File.WriteAllLines(inputFile, sampleLines);
                Console.WriteLine($"Đã tự động tạo file mẫu: {inputFile}");
            }

            List<HinhHoc> dsHinh = new List<HinhHoc>();
            string[] lines = File.ReadAllLines(inputFile);

            foreach (string line in lines)
            {
                if (string.IsNullOrWhiteSpace(line)) continue;
                string[] parts = line.Split('\t', ' ');
                if (parts.Length < 2) continue;

                int loai = int.Parse(parts[0]);
                if (loai == 1 && parts.Length >= 3)
                {
                    double d = double.Parse(parts[1]);
                    double r = double.Parse(parts[2]);
                    dsHinh.Add(new HinhChuNhat(d, r));
                }
                else if (loai == 2)
                {
                    double r = double.Parse(parts[1]);
                    dsHinh.Add(new HinhTron(r));
                }
            }

            double tongS = dsHinh.Sum(h => h.DienTich);
            double tongP = dsHinh.Sum(h => h.ChuVi);

            var hcnMaxS = dsHinh.OfType<HinhChuNhat>().OrderByDescending(h => h.DienTich).FirstOrDefault();
            var htMinP = dsHinh.OfType<HinhTron>().OrderBy(h => h.ChuVi).FirstOrDefault();

            List<string> outLines = new List<string>
            {
                $"So hinh: {dsHinh.Count}",
                $"Tong dien tich: {Math.Round(tongS, 2)}",
                $"Tong chu vi: {Math.Round(tongP, 2)}",
                $"Hinh chu nhat co dien tich lon nhat: {hcnMaxS}",
                $"Hinh tron co chu vi nho nhat: {htMinP}"
            };

            File.WriteAllLines(outputFile, outLines);

            Console.WriteLine("Đã xử lý dữ liệu và ghi ra file output.txt thành công!");
            Console.WriteLine("\n--- NỘI DUNG FILE OUTPUT.TXT ---");
            foreach (string l in outLines)
            {
                Console.WriteLine(l);
            }
        }

        static void ThucHanhBai2()
        {
            Console.WriteLine("--- BÀI TẬP 2: QUẢN LÝ CON NGƯỜI & NHÂN VIÊN ---");

            SinhVien sv = new SinhVien("Nguyễn Văn A", new DateTime(2003, 5, 15), "123 Lê Văn Sỹ, TP.HCM", "5101104001", "T2Ca1", "nva@gmail.com", "0901234567");
            NhanVien nv = new NhanVien("Trần Thị B", new DateTime(1995, 10, 20), "456 Nguyễn Trãi, TP.HCM", "NV001", "ttb@company.com", "0987654321", new DateTime(2020, 1, 15), "CTY_ABC");

            Console.WriteLine("Thông tin Sinh viên:");
            sv.XemThongTin();

            Console.WriteLine("\nThông tin Nhân viên:");
            nv.XemThongTin();
        }

        static void ThucHanhBai3()
        {
            Console.WriteLine("--- BÀI TẬP 3: ĐA THỨC ---");

            // Tạo P1 = 3 + 2x + 1x^2 (Bậc 2)
            DaThuc p1 = new DaThuc(2);
            p1[0] = 3;
            p1[1] = 2;
            p1[2] = 1;

            // Tạo P2 = 1 - 4x + 2x^2 + 5x^3 (Bậc 3)
            DaThuc p2 = new DaThuc(3);
            p2[0] = 1;
            p2[1] = -4;
            p2[2] = 2;
            p2[3] = 5;

            Console.WriteLine($"Đa thức P1(x) = {p1}");
            Console.WriteLine($"Đa thức P2(x) = {p2}");

            DaThuc tong = p1 + p2;
            DaThuc hieu = p1 - p2;

            Console.WriteLine($"\nTổng P1(x) + P2(x) = {tong}");
            Console.WriteLine($"Hiệu P1(x) - P2(x) = {hieu}");

            double x = 2;
            Console.WriteLine($"\nGiá trị P1({x}) = {p1.TinhGiaTri(x)}");
            Console.WriteLine($"Giá trị P2({x}) = {p2.TinhGiaTri(x)}");
        }
    }
}