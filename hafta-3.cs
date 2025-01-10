using System;
using System.Collections;
using System.Numerics;


//HAFTA-3



//Soru 1 - Foreach Döngüsü ile Liste Elemanlarını Yazdırma


//ArrayList Sayilar = new ArrayList();

//Sayilar.Add(33);
//Sayilar.Add(7);
//Sayilar.Add(45);

//int toplam = 0;

//foreach (int i in Sayilar) {
//    toplam = toplam + i;
//    Console.WriteLine(i);
// }

//Console.WriteLine("Sayıların toplamı: {0}",toplam);





//Soru 2 - Hazır Yöntem Kullanımı 

//Console.WriteLine("Bir cümle giriniz");
//string cumle = Console.ReadLine();

//string[] yenicumle =cumle.Split(" ");

//int kelimesayisi = yenicumle.Count();
//Console.WriteLine("Cümlenizdeki kelime sayısı:{0}",kelimesayisi);





//Soru 3 - ArrayList ile Alfabetik Sıralama 

//ArrayList isimler = new ArrayList();

//Console.WriteLine("5 adet isim giriniz");

//for (int i = 0; i < 5; i++)
//{
//    string x=Console.ReadLine();
//    isimler.Add(x);
//}

//isimler.Sort();
//Console.WriteLine("İsimlerin alfabetik sıralanışı:");
//foreach (string isim in isimler)
//{
//    Console.Write(" " +isim);
//}




//Soru 4 - For Döngüsü ile Fibonacci Serisi 

//Console.WriteLine("Bir sayı giriniz:");
//int sayi=Convert.ToInt32(Console.ReadLine());

//int sayi1 = 0;
//int sayi2=1;
//int toplam = 0;
//Console.Write("{0} {1}",sayi1,sayi2);

////while ile çözüm
//while (toplam < sayi)
//{
//    toplam = sayi1 + sayi2;
//    sayi1 = sayi2;
//    sayi2 = toplam;
//    if (toplam < sayi)
//        console.write(" {0}", toplam);
//}

////for ile çözüm
//for (int i = 0; i < sayi; i = toplam)
//{
//    toplam = sayi1 + sayi2;
//    sayi1 = sayi2;
//    sayi2 = toplam;
//    if (toplam < sayi)
//        Console.Write(" {0}", toplam);

//}





//Soru 5 - While Döngüsü ile Tahmin Oyunu 


//Random rnd = new Random();
//int sayi = rnd.Next(0,100);

//Console.WriteLine("Tahmininizi giriniz");
//int tahmin=Convert.ToInt32(Console.ReadLine());

//while(sayi != tahmin)
//{
//    Console.WriteLine("Tahmininiz yanlış yeni bir sayı giriniz");
//    tahmin = Convert.ToInt32(Console.ReadLine());
//}

//Console.WriteLine("Doğru sayıyı buldunuz.");






//Soru 6 - Do While Döngüsü ile Basit Hesap Makinesi

//int sayi1, sayi2,islem;
//string x;
//Console.WriteLine("Toplama -> 1");
//Console.WriteLine("Çıkarma -> 2");
//Console.WriteLine("Çarpma -> 3");
//Console.WriteLine("Bölme -> 4");

//do
//{
//    Console.Write("1.sayıyı giriniz: ");
//    sayi1 = int.Parse(Console.ReadLine());
//    Console.Write("2.sayıyı giriniz: ");
//    sayi2 = int.Parse(Console.ReadLine());
//    Console.WriteLine("Yapmak istediğiniz işlemin numarasını giriniz:");
//    islem = int.Parse(Console.ReadLine());
//    if (islem == 1)
//    {
//        islem=sayi1 + sayi2;
//        Console.WriteLine("İşlemin sonucu:"+islem);
//    }
//    else if (islem == 2)
//    {
//        islem = sayi1 - sayi2;
//        Console.WriteLine("İşlemin sonucu:" + islem);
//    }
//    else if (islem == 3)
//    {
//        islem = sayi1 * sayi2;
//        Console.WriteLine("İşlemin sonucu:" + islem);
//    }
//    else if (islem == 4)
//    {
//        if (sayi2 != 0)
//        {
//            islem = sayi1 / sayi2;
//            Console.WriteLine("İşlemin sonucu:" + islem);
//        }
//        else
//            Console.WriteLine("Sayıyı sıfıra bölersek tanımsız olur");

//    }
//    else
//        Console.WriteLine("Seçtiğiniz işlem 1 ile 4 arasında olmalı.");

//    Console.WriteLine("Çıkmak istiyorsanız çıkış yaznız:");
//    x = Console.ReadLine();
//}
//while (x != "çıkış");






////Soru 7 - For ve While Döngüsü ile Sayı Toplama Oyunu 
//string x = " ";
//int toplam = 0;
//int i = 0;
//List<int> sayilar = new List<int>();
//while (x != "0")
//{
//    Console.WriteLine("Pozitif tam sayı giriniz: ");
//    int sayi = int.Parse(Console.ReadLine());
//    if (sayi > 0)
//    {
//        sayilar.Add(sayi);
//    }
//    else
//        Console.WriteLine("Girdiğiniz sayı pozitif değil");
//    Console.WriteLine("Sayı girmeye devam etmek istemiyorsanız 0 tuşuna basınız");
//    x = Console.ReadLine();
//}
//int uzunluk = sayilar.Count;
//while (i < uzunluk)
//{
//    toplam = toplam + sayilar[i];
//    i++;
//}

//for (i = 0; i < uzunluk; i++)
//{
//    Console.Write(" " + sayilar[i]);
//}
//Console.WriteLine("Sayıların toplamı:" + toplam);



//Console.ReadKey();