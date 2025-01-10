//using System;
//using System.Collections.Generic;
//using System.Data;
//using System.Diagnostics.Metrics;
//using System.Linq;
//using System.Reflection.Metadata;
//using System.Runtime.Intrinsics.X86;
//using System.Text;
//using System.Threading.Tasks;
//namespace HAFTA_4
//{
//    internal class HAFTA_4
//    {
//        static void Main(string[] args)
//        {
//            //1.CEVAP
//            //Console.WriteLine(ucgenalanı());
//            //2.CEVAP
//            //int [] sayilar = {45,66,9,23,87,4};
//            //Console.WriteLine("Dizideki en büyük sayı: " + enbuyuk(sayilar));
//            //3.CEVAP
//            //int sonuc = sayitopla(5,6,7);
//            //Console.WriteLine("3 sayı toplamı " + sonuc);
//            //double sonuc2 = sayitopla(3.4, 5.7);
//            //Console.WriteLine("2 double sayı toplamı " +sonuc2);
//            //4.CEVAP
//            //Console.WriteLine("Bir tam sayı giriniz");
//            //int fib = int.Parse(Console.ReadLine());
//            //Console.WriteLine($"{fib}. fibonacci sayısının karşılığı: {fibonacci(fib)}");

//            //5.CEVAP
//            //double sonuc = ortalama(6.9, 4.8, 8.9);
//            //Console.WriteLine(sonuc);
//            //6.CEVAP
//            //int[] sayilar2 = { 34, 5, 7, 23 };
//            //Console.WriteLine("Dizideki 20 den büyük sayıların toplamı: " + dizitoplamı(sayilar2, 20));
//            //7.CEVAP
//            //Console.WriteLine("Yaşınızı giriniz");
//            //int yas = int.Parse(Console.ReadLine());
//            //Console.WriteLine($"Yaş 18 den {yillarisayma(yas)} yıl büyüktür");
//            //8.CEVAP
//            //string[] liste = ["count","add","string","console"] ;
//            //Console.WriteLine("Listedeki 5 karakterden uzun olan elemanlar");
//            //foreach (var a in bestenbuyuk(liste))
//            //{
//            //    Console.WriteLine(a);
//            //}
//            Console.ReadKey();
//        }
//        // 1. Matematiksel Hesaplama Yapan Parametresiz ve Geriye Değer Döndüren Metot
//        //Soru: Bir metot yazın; bu metot, kullanıcıdan üçgenin taban uzunluğu ve yüksekliğini alıp, üçgenin alanını hesaplayarak geriye döndürsün.
//        //Alanı hesaplamak için Taban * Yükseklik / 2 formülünü kullanın.
//        //İpucu: double türünde dönen bir metot tanımlamalı ve kullanıcıdan alınan değerlerle hesaplama yapmalısınız.
//        static double ucgenalanı()
//        {
//            Console.WriteLine("Üçgen taban uzunluğunu giriniz");
//            double taban = double.Parse(Console.ReadLine());
//            Console.WriteLine("Üçgen yüksekliğini giriniz");
//            double yukseklik = double.Parse(Console.ReadLine());
//            double alan = (taban * yukseklik) / 2;
//            return alan;
//        }
//        //2. Dizideki En Büyük Değeri Bulan Parametreli ve Geriye Değer Döndüren Metot
//        //Soru: int türünde bir dizi parametresi alan ve bu dizideki en büyük değeri bulan bir metot yazın.
//        //İpucu: int dönen bir metot tanımlayıp, foreach döngüsü ile diziyi dolaşarak en büyük değeri bulabilirsiniz.
//        static int enbuyuk(int[] x)
//        {
//            int enb = x[0];
//            foreach (int i in x)
//            {

//                if (i > enb)
//                {
//                    enb = i;
//                }
//            }
//            return enb;
//        }
//        //3. Aşırı Yüklenmiş (Overloaded) Metot ile Farklı Türdeki Verilerin Toplamını Bulma
//        //Soru: Aynı isimle üç farklı CalculateSum metodu yazın.İlk metot iki int sayıyı toplasın, ikinci metot iki double sayıyı toplasın, üçüncü metot ise üç int sayıyı toplasın.
//        //İpucu: Metot isimleri aynı olmalı fakat parametre türleri farklı olmalıdır.
//        static int sayitopla(int a, int b)
//        {
//            return a + b;
//        }
//        static double sayitopla(double a, double b)
//        {
//            return a + b;
//        }
//        static int sayitopla(int a, int b, int c)
//        {
//            return a + b + c;
//        }
//        //4. Recursive Metot ile Fibonacci Dizisi Hesaplama
//        //Soru: Bir sayının Fibonacci dizisindeki karşılığını hesaplayan özyinelemeli(recursive) bir metot yazın.
//        //fibonacci(5) çağrısı, dizideki 5. Fibonacci sayısını döndürmelidir.
//        //İpucu: int dönen ve kendini çağırarak Fibonacci dizisi üreten bir metot yazmalısınız.
//        static int fibonacci(int n)
//        {
//            if (n == 0)
//                return 0;
//            if (n == 1)
//                return 1;
//            return fibonacci(n - 1) + fibonacci(n - 2);
//        }
//        //5. Params ile Sınırsız Sayıda Parametre Alarak Ortalama Hesaplama
//        //Soru: params anahtar kelimesini kullanarak sınırsız sayıda double parametre alabilen
//        //ve bu sayılar arasındaki ortalamayı hesaplayan bir metot yazın.
//        //İpucu: params ile dizi gibi parametre alabilir ve döngü kullanarak ortalamayı hesaplayabilirsiniz.
//        static double ortalama(params double[] x)
//        {
//            double toplam = 0;
//            foreach (double i in x)
//            {
//                toplam = toplam + i;
//            }
//            return toplam / x.Length;
//        }
//        //6. Dizi Elemanlarını Toplayan ve Filtreleme Şartı Ekleyen Metot
//        //Soru: int türünde bir dizi ve bir filtre değeri(int) alan bir metot yazın.
//        //Bu metot, filtre değerinden büyük olan tüm elemanları toplasın ve toplamı döndürsün.
//        //İpucu: int türünde bir metot tanımlayıp foreach döngüsü ile filtreyi uygulayarak toplamı hesaplayabilirsiniz.
//        static int dizitoplamı(int[] a, int b)
//        {
//            int toplam = 0;
//            foreach (int i in a)
//            {
//                if (i > b)
//                    toplam = toplam + i;
//            }
//            return toplam;
//        }
//        //7. Seçmeli (Optional) Parametre ile Belirli Yaştan Sonraki Yılları Sayma
//        //Soru: Bir yaş değeri alan bir metot yazın.Eğer yaş belirtilmezse varsayılan olarak
//        //18 olsun ve metot, verilen yaşın 18’den ne kadar fazla olduğunu döndürsün.
//        //İpucu: int türünde bir metot tanımlayıp varsayılan parametre kullanarak yaşı hesaplayabilirsiniz.
//        static int yillarisayma(int yas)
//        {
//            if (yas >= 18)
//            {
//                return yas - 18;
//            }
//            else if (0 < yas && yas < 18)
//            {
//                return yas - 18;
//            }
//            else
//            {
//                yas = 18;
//                return yas - 18;
//            }
//        }
//        //8. Geriye Koleksiyon Döndüren ve Veriyi Filtreleyen Metot
//        //Soru: string türünde bir dizi alan bir metot yazın.Bu metot, sadece
//        //uzunluğu 5 karakterden büyük olan elemanları içeren bir List<string> döndürsün.
//        //İpucu: List<string> türünde bir metot tanımlayarak döngü ile filtreleme yapabilirsiniz.
//        static List<string> bestenbuyuk(string[] a)
//        {
//            List<string> yeniliste = new List<string>();
//            foreach (string i in a)
//            {
//                if (i.Length > 5)
//                {
//                    yeniliste.Add(i);
//                }
//            }
//            return yeniliste;
//        }
//    }
//}