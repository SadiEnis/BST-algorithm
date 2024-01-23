using System;

namespace hafta13_odev
{
    public class TreeNode
    {
        public Person data;
        public TreeNode rightNode;
        public TreeNode leftNode;

        public TreeNode(Person _data)
        {
            data = _data;
            rightNode = null;
            leftNode = null; // Node'ların başlangıçta çocukları boştur.
        }
    }
    public class BinarySearchTree
    {
        public TreeNode root;

        // Disegn Pattern'ler Binary Search Tree gibi spesifik konulara çözüm aramaz.
        // Daha genel sorunlara çözüm olurlar. Özel sorunlar için genellikle design pattern geliştirilmez.
        // Ama bir pattern oluşturulacak olsaydı bu "node'ları recursive olarak dolaşan bir metot" olurdu.
        // Bizim node'ları sıra sıra dolaşıp null değil ise karşılaştırıp devam etmemizi sağlayan recursive bir metot dolaşma ve ekleme sorununa çözüm olacaktır.

        public void InsertNode(Person data)
        { // Bu metot kullanıcının kullanacağı sadece veriyi parametre olarak girdiği metottur.
          // İçinde aynı metodun recursive çalışan 
            root = InsertNode(root, data);
        }
        private TreeNode InsertNode(TreeNode _root, Person _data)
        {
            if (_root == null) // Ağaç boşsa yeni düğüm oluşturur.
                return new TreeNode(_data);
            /***Aşağıda kullanılan string.Compare() karşılaştırma yapar.***\
             * Geri dönüş değeri sıfır ise parametre aldığı iki string değer aynıdır.
             * Geri dönüş değeri negatif ise ilk parametre ikinci parametreden alfabetik olarak küçüktür.
             * Geri dönüş değeri pozitif ise ilk paramtere ikinci paremeterden alfabetik olarak büyüktür.
            */

            // Soyadına göre sıralama 
            if (string.Compare(_data.Surname, _root.data.Surname) < 0)
                _root.leftNode = InsertNode(_root.leftNode, _data); // Verinin soyadı küçük ise sola ilerler.
            else if (string.Compare(_data.Surname, root.data.Surname) > 0)
                _root.rightNode = InsertNode(_root.rightNode, _data); // Verinin soyadı büyük ise sağa ilerler.
            else // Eşit ise ada göre sıralama
            {
                if (string.Compare(_data.Name, _root.data.Name) < 0)
                    _root.leftNode = InsertNode(_root.leftNode, _data); // Verinin adı küçük ise sola ilerler
                else
                    _root.rightNode = InsertNode(_root.rightNode, _data);
            }
            return _root; // Bu koşullara uygun şekilde sıra sıra uygun eklenecek node'a geldiğinde..
                          // .. _root değişkenine atama yapar sonunda onu return eder. 
        }

        // Yine üstteki InsertNode için bahsettiğim gibi node'ları tek tek dolaşması ve bunları yazması bir sorun olarak kabul edersek..
        // Aşağıdaki yöntem onun için bir pattern olarak nispeten kabul edilebilir.
        // Ağaç sistemi genel bir sorun olmadığı için klasikleşmiş 24 pattern içinde çözümü yoktur(bence!! - ki aradım bulamadım da)
        public void PrintTree()
        { // Bu metotu kullarak program içinde çıktı alınacak.
            PrintTree(root, 0); // İçinde recursive aşırı yüklemesi çalışıyor.
        } // Dikey eksende çıktı almak yerine yatay bir şekilde ağacı yazdırmak neden olmasın ki. 
          // Aşağıdaki metot yatay eksende ağacın node'larını yazdırır.
          // Her düzeyde level değişkeni ile bağlı olarak boşluk bırakır böylece ağaç görüntüsü elde eder.
        private void PrintTree(TreeNode node, int level)
        {
            if (node != null)
            {
                PrintTree(node.rightNode, level + 1); // Sağ alt ağacı yazdırır. En alt sağ ağaca kadar iner ve çıktıyı vermeye oradan başlar.
                Console.WriteLine($"{new string(' ', level * 4)}{node.data.ToString()}"); // Mevcut düğümü yazdırır. Sonraki düğüme geeçer.
                                                                                          // Her alt ağaçtakı root da bir üst katmana çıkıldığında yazdırılmış olur.
                PrintTree(node.leftNode, level + 1); // Sol alt ağacı yazdırır. En alt sol ağaca kadar iner ve çıktı vermeye başlar. Sıra sıra çıktı vererek sonuca ulaşır.
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"{new string(' ', level * 4)}null"); // Boş olan node'lar için null çıktısı alacağım. Böylece daha düzenli görünüm sağlayacak.
                Console.ResetColor();
            }
        }
    }
}
