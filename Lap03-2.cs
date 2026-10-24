using System;

namespace DuongTron
{
    // ==========================================
    // LỚP ĐIỂM (Oxy)
    // ==========================================
    class Diem
    {
        private int x;
        private int y;

        public int X
        {
            get { return x; }
            set { x = value; }
        }

        public int Y
        {
            get { return y; }
            set { y = value; }
        }

        public Diem()
        {
            x = 0;
            y = 0;
        }

        public Diem(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public Diem(Diem p)
        {
            this.x = p.x;
            this.y = p.y;
        }

        public double KhoangCach(Diem b)
        {
            int dx = this.x - b.x;
            int dy = this.y - b.y;
            return Math.Sqrt(dx * dx + dy * dy);
        }

        public override string ToString()
        {
            return "(" + x + ", " + y + ")";
        }
    }

    // ==========================================
    // LỚP ĐƯỜNG TRÒN
    // ==========================================
    class DuongTron
    {
        private Diem tam;
        private int banKinh;

        public Diem Tam
        {
            get { return tam; }
            set { tam = value; }
        }

        public int BanKinh
        {
            get { return banKinh; }
            set { banKinh = value; }
        }

        // Khởi tạo mặc định
        public DuongTron()
        {
            tam = new Diem();
            banKinh = 0;
        }

        // Khởi tạo có tham số
        public DuongTron(Diem t, int r)
        {
            tam = new Diem(t);
            banKinh = r;
        }

        // Khởi tạo sao chép
        public DuongTron(DuongTron dt)
        {
            tam = new Diem(dt.Tam);
            banKinh = dt.BanKinh;
        }

        public double ChuVi()
        {
            return 2 * Math.PI * banKinh;
        }

        public double DienTich()
        {
            return Math.PI * banKinh * banKinh;
        }

        public void Xuat()
        {
            Console.WriteLine("Tâm: " + tam.ToString() + ", Bán kính: " + banKinh);
        }

        // Kiểm tra vị trí tương đối của một điểm với đường tròn
        public string ViTriTuongDoi(Diem p)
        {
            double d = tam.KhoangCach(p);
            if (d < banKinh) return "Điểm nằm TRONG đường tròn";
            if (d == banKinh) return "Điểm nằm TRÊN đường tròn";
            return "Điểm nằm NGOÀI đường tròn";
        }

        // Kiểm tra vị trí tương đối giữa hai đường tròn
        public string ViTriTuongDoi(DuongTron dt2)
        {
            double d = tam.KhoangCach(dt2.Tam);
            int r1 = banKinh;
            int r2 = dt2.BanKinh;

            if (d == 0 && r1 == r2) return "Hai đường tròn TRÙNG NHAU";
            if (d == 0 && r1 != r2) return "Hai đường tròn ĐỒNG TÂM";
            if (d == r1 + r2) return "Hai đường tròn TIẾP XÚC NGOÀI";
            if (d == Math.Abs(r1 - r2)) return "Hai đường tròn TIẾP XÚC TRONG";
            if (d > Math.Abs(r1 - r2) && d < r1 + r2) return "Hai đường tròn CẮT NHAU";
            if (d > r1 + r2) return "Hai đường tròn Ở NGOÀI NHAU";
            return "Một đường tròn BAO BỌC đường tròn kia";
        }
    }

    // ==========================================
    // CHƯƠNG TRÌNH CHÍNH (PROGRAM)
    // ==========================================
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.WriteLine("==================================================");
            Console.WriteLine("          THỬ NGHIỆM LỚP ĐƯỜNG TRÒN (EXTRA)       ");
            Console.WriteLine("==================================================");

            // Khởi tạo các đường tròn
            DuongTron dt1 = new DuongTron();
            Console.Write("Đường tròn 1 (Mặc định): ");
            dt1.Xuat();

            Diem I2 = new Diem(3, 4);
            DuongTron dt2 = new DuongTron(I2, 5);
            Console.Write("Đường tròn 2: ");
            dt2.Xuat();

            Console.WriteLine("Chu vi DT2: " + Math.Round(dt2.ChuVi(), 2));
            Console.WriteLine("Diện tích DT2: " + Math.Round(dt2.DienTich(), 2));

            // Kiểm tra vị trí điểm với đường tròn
            Diem P1 = new Diem(3, 7);
            Diem P2 = new Diem(10, 10);
            Console.WriteLine($"\nKiểm tra điểm P1{P1} với DT2: {dt2.ViTriTuongDoi(P1)}");
            Console.WriteLine($"Kiểm tra điểm P2{P2} với DT2: {dt2.ViTriTuongDoi(P2)}");

            // Kiểm tra vị trí tương đối giữa 2 đường tròn
            Diem I3 = new Diem(6, 8);
            DuongTron dt3 = new DuongTron(I3, 3);
            Console.Write("\nĐường tròn 3: ");
            dt3.Xuat();

            Console.WriteLine($"Vị trí tương đối giữa DT2 và DT3: {dt2.ViTriTuongDoi(dt3)}");

            Console.WriteLine("\nẤn phím bất kỳ để kết thúc...");
            Console.ReadKey();
        }
    }
}