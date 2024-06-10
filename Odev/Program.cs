namespace Odev
{
    class Program
    {
        static List<KiralikEv> kiralikEvler = new List<KiralikEv>();
        static List<SatilikEv> satilikEvler = new List<SatilikEv>();

        static void Main(string[] args)
        {
            Console.WriteLine("**** Emlakçı Uygulamasına Hoşgeldiniz ****\n");
            while (true)
            { 
                MenuGetir();
            }
        }

        public static void MenuGetir()
        {

            Console.WriteLine("1. Kiralık Ev Giriş\n2. Satılık Ev Giriş\n3. Kayıtlı Ev Bilgileri Getir\n4. Çıkış\n**** LÜTFEN SEÇİM YAPINIZ ****");
            byte menuSecim = byte.Parse(Console.ReadLine());

            switch (menuSecim)
            {
                case 1:
                    EvBilgiGiris<KiralikEv>();
                    break;
                case 2:
                    EvBilgiGiris<SatilikEv>();
                    break;
                case 3:
                    KayitliEvBilgileriGoster();
                    break;
                case 4:
                    Console.WriteLine("Program Kapatılıyor...");
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Hatalı Seçim Yaptınız !!!");
                    break;
            }
        }

        public static void EvBilgiGiris<T>() where T : Ev, new()
        {
            var ev = new T();

            Console.WriteLine("Lütfen Semt Bilgisi Giriniz : ");
            ev.Semt = Console.ReadLine();

            Console.WriteLine("Lütfen Kat Numarasını Giriniz : ");
            ev.KatNo = int.Parse(Console.ReadLine());

            Console.WriteLine("Lütfen Oda Sayısını Giriniz : ");
            ev.OdaSayisi = int.Parse(Console.ReadLine());

            Console.WriteLine("Lütfen Alan Bilgisini Giriniz : ");
            ev.Alan = double.Parse(Console.ReadLine());

            if (ev is KiralikEv kiralikEv)
            {
                Console.WriteLine("Lütfen Kira Bedelini Giriniz : ");
                kiralikEv.KiraFiyati = double.Parse(Console.ReadLine());

                Console.WriteLine("Lütfen Depozito Bedelini Giriniz : ");
                kiralikEv.Depozito = double.Parse(Console.ReadLine());

                kiralikEvler.Add(kiralikEv);
                DosyayaYaz(kiralikEv.ToString(), "kiralik_evler.txt");
            }
            else if (ev is SatilikEv satilikEv)
            {
                Console.WriteLine("Lütfen Satış Bedelini Giriniz : ");
                satilikEv.SatisFiyati = double.Parse(Console.ReadLine());

                satilikEvler.Add(satilikEv);
                DosyayaYaz(satilikEv.ToString(), "satilik_evler.txt");
            }

            Console.WriteLine("Ev girişi başarılı! Devam etmek istiyor musunuz? (E/H)");
            string cevap = Console.ReadLine();
            if (cevap.ToUpper() == "E")
            {
                EvBilgiGiris<T>();
            }
            else
            {
                MenuGetir();
            }
        }

        public static void KayitliEvBilgileriGoster()
        {
            Console.WriteLine("Kiralık Evler:");
            Console.WriteLine(File.ReadAllText("kiralik_evler.txt"));

            Console.WriteLine("\nSatılık Evler:");
            Console.WriteLine(File.ReadAllText("satilik_evler.txt"));
        }

        public static void DosyayaYaz(string veri, string dosyaYolu)
        {
            using (StreamWriter sw = new StreamWriter(dosyaYolu, true))
            {
                sw.WriteLine(veri);
            }
        }
    }
}
