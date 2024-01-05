using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BT5
{
    class CD
    {
        private int macd;
        private string tuacd;
        private string casi;
        private int sobaihat;
        private int dongia;
        public CD()
        {
        }
        public CD(int macd)
        {
            this.macd = macd;
        }
        public CD(int macd, string tuacd, string casi, int sobaihat, int dongia)
        {
            this.macd = macd;
            this.tuacd = tuacd;
            this.casi = casi;
            this.sobaihat = sobaihat;
            this.dongia = dongia;
        }
        public int MaCD
        {
            set { this.macd = value; }
            get { return macd; }
        }
        public string TuaCD
        {
            set { this.tuacd = value; }
            get { return tuacd; }
        }
        public string CaSi
        {
            set { this.casi = value; }
            get { return casi; }
        }
        public int SoBaiHat
        {
            set { this.sobaihat = value; }
            get { return sobaihat; }
        }
        public int DonGia
        {
            set { this.dongia = value; }
            get { return dongia; }
        }
        public string ToString()
        {
            return string.Format("{0, 10} {1,30} {2,30} {3,10} {4, 15:#,##0}", macd,
            tuacd, casi, sobaihat, dongia);
        }
    }
    class QuanLyCD
    {
        private CD[] ds;
        private int n;
        public QuanLyCD()
        {
            ds = new CD[100];
            n = 0;
        }
        public QuanLyCD(int sophantu)
        {
            ds = new CD[sophantu];
            n = 0;
        }
        public void ThemCD(CD cd)
        {
            if (n >= ds.Length)
            {
                Console.WriteLine("Danh sach da day.");
            }
            else
            {
                if (!kiemTraTrungCD(cd.MaCD))
                    ds[n++] = cd;
                else
                {
                    Console.WriteLine("Trung ma CD");
                }
            }
        }
        private bool kiemTraTrungCD(int macd)
        {
            for (int i = 0; i < n; i++)
            {
                if (ds[i].MaCD == macd)
                {
                    return true;
                }
            }
            return false;
        }
        public double tinhGiaTB()
        {
            int tonggia = 0;
            for (int i = 0; i < n; i++)
            {
                tonggia += ds[i].DonGia;
            }
            return (double)tonggia / n;
        }
        public void Xuat()
        {
            Console.WriteLine("{0, 10} {1,30} {2,30} {3,10} {4, 15}",
            "MaCD", "Tua CD", "Ca si", "So bai hat", "Gia thanh");
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine(ds[i].ToString());
            }
        }
        public void SapXepGiamTheoGiaThanh()
        {
            CD tam;
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = i + 1; j < n; j++)
                {
                    if (ds[i].DonGia < ds[j].DonGia)
                    {
                        tam = ds[i];
                        ds[i] = ds[j];
                        ds[j] = tam;
                    }
                }
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            menu();
        }
        static void menu()
        {
            QuanLyCD quanlyCD = new QuanLyCD();
            int chon = 0;
            do
            {
                Console.WriteLine("**********Chuong trinh quan ly CD*********");
                Console.WriteLine("1. Them CD");
                Console.WriteLine("2. Tinh gia thanh trung binh");
                Console.WriteLine("3. Sap xep CD giam dan them gia thanh");
                Console.WriteLine("4. Sap xep CD tang dan theo tua CD");
                Console.WriteLine("5. Xuat toan bo CD");
                Console.WriteLine("0. Thoat chuong trinh.");
                Console.WriteLine("-----------------------------------------");
                Console.Write("Moi Nhap:");
                chon = int.Parse(Console.ReadLine());
                switch (chon)
                {
                    case 1:
                        CD cd = new CD();
                        Console.Write("Nhap Ma cd:");
                        cd.MaCD = int.Parse(Console.ReadLine());
                        Console.Write("Nhap Tua CD:");
                        cd.TuaCD = Console.ReadLine();
                        Console.Write("Nhap Ca Si:");
                        cd.CaSi = Console.ReadLine();
                        Console.Write("Nhap So Bai Hat:");
                        cd.SoBaiHat = int.Parse(Console.ReadLine());
                        Console.Write("Nhap Gia Thanh:");
                        cd.DonGia = int.Parse(Console.ReadLine());
                        quanlyCD.ThemCD(cd);
                        break;
                    case 2:
                        double kq = quanlyCD.tinhGiaTB();
                        Console.WriteLine("Gia thanh trung binh : {0:#,##0.00}", kq);
                        break;
                    case 3:
                        quanlyCD.SapXepGiamTheoGiaThanh();
                        Console.WriteLine("Da sap them theo gia thanh giam dan");
                        break;
                    case 4:
                        break;
                    case 5:
                        quanlyCD.Xuat();
                        break;
                    case 0:
                        Console.WriteLine("--------------------------------------------");
                        Console.WriteLine("--------Ban Da Ket Thuc Chuong Trinh--------");
                        Console.WriteLine("--------------------------------------------");
                        Console.ReadLine();
                        break;
                }
            } while (chon != 0);
        }
    }
}