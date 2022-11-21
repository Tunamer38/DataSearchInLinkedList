using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedListDataSearch
{
    class Program
    {
        static block first = null;
        static block last = null;

        public static void Main()
        {
            Random rnd = new Random();
            block list = null;
            Console.WriteLine("Linked List Dizin Sayısını Giriniz: ");
            int len = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < len; i++)
            {
                int deger = rnd.Next(1, 250);
                list = Atama(list, deger, i, len);
            }
            block t = first;
            Console.WriteLine("<<<<<<<<<<<<<<<<<>>>>>>>>>>>>>>>>");
            while (t != null)
            {
                Console.Write(t.data + "\t");
                t = t.next;
            }
            Console.WriteLine();
            Console.WriteLine("<<<<<<<<<<<<<<>>>>>>>>>>>>>>");
            Console.WriteLine("Kontrol edeceğiniz veriyi giriniz:  ");
            int aranan = Convert.ToInt32(Console.ReadLine());
            bool kontrol = Search(list, aranan, len);
            if (kontrol == true) Console.WriteLine("Aranan değer listede mevcuttur...");
            else Console.WriteLine("Aranan değer listede mevcut DEĞİLDİR:..");
            Console.ReadKey();
        }
        public static block Atama(block temp, int veri, int sayac, int length)
        {
            temp = new block();
            temp.data = veri;
            temp.next = null;
            temp.prev = last;
            if (first == null) first = temp;
            else last.next = temp;
            last = temp;

            if (sayac == length - 1)
            {
                block A = first;
                block B = first;
                while (A != null)
                {
                    while (B != null)
                    {
                        if (A.data <= B.data)
                        {
                            int tmp = B.data;
                            B.data = A.data;
                            A.data = tmp;
                        }
                        B = B.next;
                    }
                    A = A.next;
                    B = first;
                }
                temp = A;
            }
            return temp;
        }
        public static bool Search(block s1, int ara, int capacity)
        {
            int x = capacity / 10;//35 kabulüyle x=3;
            int y = capacity % 10; // y=5

            int veri;
            bool sonuc = false;
            block sc = first;
            if (sonuc == false)
            {
                for (int i = 0; i < x; i++)
                {
                    for (int j = 0; j < 10; j++) sc = sc.next;
                    veri = sc.data;
                    if (ara == veri) return true;
                    else if (ara < veri)
                    {
                        while (ara <= veri)
                        {
                            if (sc.data == ara) return true;
                            else
                            {
                                sc = sc.prev;
                                veri = sc.data;
                            }
                        }
                        return false;
                    }
                }

                if (y > 0)
                {
                    for (int k = 0; k < y; k++)
                    {
                        if (ara == sc.data) return true;
                        sc = sc.next;
                    }
                    return false;
                }
            }
            return sonuc;
        }
    }

    class block
    {
        public int data;
        public block next, prev;
    }
}
