using System;

namespace hafta13_odev
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BinarySearchTree bst = new BinarySearchTree();
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\n -- BST Algoritması Programı -- ");
                Console.ResetColor();
                Console.WriteLine("23 kişi örneği için - 0");
                Console.WriteLine("Kişi eklemek için - 1");
                Console.WriteLine("Ağacı yazdırmak için - 2");
                Console.Write("Seçenek: ");
                int chs = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine();
                if (chs == 0)
                {
                    bst.InsertNode(new Person("Sadi Enis", "Güçlüer", 12345678909));
                    bst.InsertNode(new Person("Yavuz", "Hakim", 12345678909));
                    bst.InsertNode(new Person("Mustafa", "Özlü", 12345678909));
                    bst.InsertNode(new Person("Murat", "Taşyürek", 12345678909));
                    bst.InsertNode(new Person("Canan", "Güçlüer", 12345678909));
                    bst.InsertNode(new Person("Kerime", "Şanlı", 12345678909));
                    bst.InsertNode(new Person("Cişarp", "Datnet", 12345678909));
                    bst.InsertNode(new Person("Hamdi", "Tuncer", 12345678909));
                    bst.InsertNode(new Person("Sait", "Güçlüer", 12345678909));
                    bst.InsertNode(new Person("Neriman", "Yavaş", 12345678909));
                    bst.InsertNode(new Person("Halil", "Çökertme", 12345678909));
                    bst.InsertNode(new Person("Christopher", "Judge", 12345678909));
                    bst.InsertNode(new Person("Hedio", "Kojima", 12345678909));
                    bst.InsertNode(new Person("Jale", "Şanlı", 12345678909));
                    bst.InsertNode(new Person("John", "Marton", 12345678909));
                    bst.InsertNode(new Person("Galip", "Galip", 12345678909));
                    bst.InsertNode(new Person("Bahri", "Kitapçı", 12345678909));
                    bst.InsertNode(new Person("Bekir", "Elmalı", 12345678909));
                    bst.InsertNode(new Person("Binary", "Search", 12345678909));
                    bst.InsertNode(new Person("Nesne", "Tabanlı", 12345678909));
                    bst.InsertNode(new Person("Bilgisayar", "Mühendisliği", 12345678909));
                    bst.InsertNode(new Person("Serdar", "Güçlüer", 12345678909));
                    bst.InsertNode(new Person("Ahmet", "Taşyürek", 12345678909));
                }
                else if (chs == 1)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Ağaca eklenecek kişinin; ");
                    Console.Write("Adı: ");
                    string name = Console.ReadLine();
                    Console.Write("Soyadı: ");
                    string surname = Console.ReadLine();
                    ulong tc = 0;
                    bool count;
                    do
                    {
                        try
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write("Kimlik numrası: ");
                            tc = Convert.ToUInt64(Console.ReadLine());
                            if (tc.ToString().Length != 11)
                                throw new Exception();
                            count = false;
                        }
                        catch (Exception)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Hatalı girdi yaptınız. Yeniden giriniz.");
                            Console.ResetColor();
                            count = true;
                        }
                    } while (count);
                    bst.InsertNode(new Person(name, surname, tc));
                    Console.ResetColor();
                }
                else if (chs == 2)
                    bst.PrintTree();
                else
                    return;

                Console.Write("Hehangi bir tuş bas.");
                Console.ReadKey();
                Console.Clear();
            }
        }
    }
    public class Person
    {
        public string Name;
        public string Surname;
        private ulong tc;
        public string TC
        {
            get // ! Kişi tc'si privite'dır ancak maskeli şekilde erişim olabilir.
            {
                char[] arrTC = tc.ToString().ToCharArray();
                for (int i = 0;  i < arrTC.Length; i++)
                    if (i != 9 && i != 10)
                        arrTC[i] = '*';
                string maskedTC = new string(arrTC);
                return maskedTC;
            }
        }
        public Person(string _name, string _surname, ulong _tc) // Bu ctor dışında tc değişikliği ya da erişimi yok
        {
            Name = _name;
            Surname = _surname;
            tc = _tc;
        }
        public override string ToString() { return $"İsmi: {Name} Soyismi: {Surname} TC: {TC}"; } // Kişi bilgilerini yazdırmak için ToString override ettim.
    }
}
