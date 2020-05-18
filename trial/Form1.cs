using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace trial
{
    public partial class Form1 : Form
    {
        int[,] mesafe = new int[10, 10];
        int[] buzaklık = new int[10];
        int greddyuzaklik = 0;
        string greddypath = "A";
        int astaruzaklik = 0;
        string astarpath = "A";
        string tavlamapath = "A";
        string tavlamaeniyiyol = "A";
        List<int> uzakliklar = new List<int>();
        int eniyiuzaklik = 0;
        List<string> path = new List<string>();
        double greddyzaman = 0;
        double tavlamazaman = 0;
        double ayildizzaman = 0;
        public Form1()
        {
            InitializeComponent();
        }
        private void doldur() // elle doldurdum matrisleri
        {
            mesafe[0, 0] = int.MaxValue; mesafe[0, 1] = 65; mesafe[0, 2] = 60; mesafe[0, 3] = 50; mesafe[0, 4] = 0; mesafe[0, 5] = 0; mesafe[0, 6] = 0; mesafe[0, 7] = 0; mesafe[0, 8] = 0; mesafe[0, 9] = 0;
            mesafe[1, 0] = 65; mesafe[1, 1] = int.MaxValue; mesafe[1, 2] = 58; mesafe[1, 3] = 0; mesafe[1, 4] = 72; mesafe[1, 5] = 0; mesafe[1, 6] = 0; mesafe[1, 7] = 0; mesafe[1, 8] = 0; mesafe[1, 9] = 0;
            mesafe[2, 0] = 60; mesafe[2, 1] = 58; mesafe[2, 2] = int.MaxValue; mesafe[2, 3] = 0; mesafe[2, 4] = 0; mesafe[2, 5] = 83; mesafe[2, 6] = 131; mesafe[2, 7] = 112; mesafe[2, 8] = 0; mesafe[2, 9] = 0;
            mesafe[3, 0] = 50; mesafe[3, 1] = 0; mesafe[3, 2] = 0; mesafe[3, 3] = int.MaxValue; mesafe[3, 4] = 0; mesafe[3, 5] = 0; mesafe[3, 6] = 0; mesafe[3, 7] = 90; mesafe[3, 8] = 0; mesafe[3, 9] = 0;
            mesafe[4, 0] = 0; mesafe[4, 1] = 72; mesafe[4, 2] = 0; mesafe[4, 3] = 0; mesafe[4, 4] = int.MaxValue; mesafe[4, 5] = 44; mesafe[4, 6] = 0; mesafe[4, 7] = 0; mesafe[4, 8] = 0; mesafe[4, 9] = 0;
            mesafe[5, 0] = 0; mesafe[5, 1] = 0; mesafe[5, 2] = 83; mesafe[5, 3] = 0; mesafe[5, 4] = 44; mesafe[5, 5] = int.MaxValue; mesafe[5, 6] = 55; mesafe[5, 7] = 0; mesafe[5, 8] = 0; mesafe[5, 9] = 159;
            mesafe[6, 0] = 0; mesafe[6, 1] = 0; mesafe[6, 2] = 131; mesafe[6, 3] = 0; mesafe[6, 4] = 0; mesafe[6, 5] = 55; mesafe[6, 6] = int.MaxValue; mesafe[6, 7] = 0; mesafe[6, 8] = 74; mesafe[6, 9] = 71;
            mesafe[7, 0] = 0; mesafe[7, 1] = 0; mesafe[7, 2] = 112; mesafe[7, 3] = 90; mesafe[7, 4] = 0; mesafe[7, 5] = 0; mesafe[7, 6] = 0; mesafe[7, 7] = int.MaxValue; mesafe[7, 8] = 52; mesafe[7, 9] = 0;
            mesafe[8, 0] = 0; mesafe[8, 1] = 0; mesafe[8, 2] = 0; mesafe[8, 3] = 0; mesafe[8, 4] = 0; mesafe[8, 5] = 0; mesafe[8, 6] = 74; mesafe[8, 7] = 52; mesafe[8, 8] = int.MaxValue; mesafe[8, 9] = 71;
            mesafe[9, 0] = 0; mesafe[9, 1] = 0; mesafe[9, 2] = 0; mesafe[9, 3] = 0; mesafe[9, 4] = 0; mesafe[9, 5] = 159; mesafe[9, 6] = 71; mesafe[9, 7] = 0; mesafe[9, 8] = 71; mesafe[9, 9] = int.MaxValue;

            buzaklık[0] = int.MaxValue; buzaklık[1] = 332; buzaklık[2] = 316; buzaklık[3] = 340; buzaklık[4] = 216; buzaklık[5] = 168; buzaklık[6] = 91; buzaklık[7] = 90; buzaklık[8] = 72; buzaklık[9] = 0;

            for (int i = 0; i < mesafe.GetLength(0); i++) //0 yapınca hata oluyordu int max olarak değiştirmek zorunda kaldım
            {
                for (int j = 0; j < mesafe.GetLength(1); j++)
                {
                    if (mesafe[i, j] == 0)
                    {
                        mesafe[i, j] = int.MaxValue;
                    }
                }
            }
        }
        private void greddy()
        {
            System.Diagnostics.Stopwatch zaman = new System.Diagnostics.Stopwatch();
            zaman.Start();
            int i = 0;//başlangıç şehri
            int sehir = 0;//gidilen şehir
            List<int> gidilenyol = new List<int>();//gidilen şehirlere dönmemek için liste
            gidilenyol.Add(0);//başta a gittiği için geri dönmesin diye
            while (sehir != 9)//son şehir b yi 9 olarak eklemiştim
            {
                int min = int.MaxValue;//min değerler üzerinde çalışıyoruz
                for (int j = 0; j < 10; j++)
                {
                    if (mesafe[i, j] != int.MaxValue)//eğer max değer değilse komşuluk vardır
                    {
                        if (min > buzaklık[j] && !gidilenyol.Contains(j))//eğer gidilmemişse o şehre ve if'i sağlıyorsa
                        {
                            min = buzaklık[j];//bu komşu şehre gitmiştir demektir
                            sehir = j;//yeni şehiri atıyorum şehir kısmına
                        }
                    }
                }
                i = sehir;//şu anki şehiri belirtiyorum forun dışında olduğu için şehir diye bir şey tanımlamış oldum
                gidilenyol.Add(sehir);//gidilen şehire o şehri ekliyorum
                greddyuzaklik += buzaklık[i];//gidilen yerin heuristic uzaklığını ekliyorum
                greddypath += " " + sehirBul(sehir);//gidilen path'i ekliyorum
            }
            zaman.Stop();
            greddyzaman = zaman.ElapsedMilliseconds; //milisaniyeyi saniye çevirmek için
            zaman.Reset();

        }//hırslı tepe tırmanma algoritması
        private string sehirBul(int kod)//şehir bulmayı kolaylaştırmak ve path'e eklerken basit olsun diye
        {
            switch (kod)
            {
                case 0: return "A"; break;
                case 1: return "X"; break;
                case 2: return "Y"; break;
                case 3: return "Z"; break;
                case 4: return "K"; break;
                case 5: return "L"; break;
                case 6: return "M"; break;
                case 7: return "N"; break;
                case 8: return "T"; break;
                case 9: return "B"; break;
                default: return " Hata"; break;
            }
            return " ";
        }
        private void aStar()
        {
            System.Diagnostics.Stopwatch zaman = new System.Diagnostics.Stopwatch();
            zaman.Start();
            int i = 0;//başlangıç şehri
            int sehir = 0;//gidilen şehir
            int yol = 0;//a şehri başta 0 cost o yüzden 0 gerçek uzaklık
            List<int> gidilenyol = new List<int>();//gidilen şehirlere dönmemek için liste
            gidilenyol.Add(0);//başta a gittiği için geri dönmesin diye
            while (sehir != 9)//son şehir b yi 9 olarak eklemiştim
            {
                int min = int.MaxValue;//min değerler üzerinde çalışıyoruz
                for (int j = 0; j < 10; j++)
                {

                    if (mesafe[i, j] != int.MaxValue)//eğer max değer değilse komşuluk vardır
                    {
                        if (min > (buzaklık[j] + mesafe[i, j]) && !gidilenyol.Contains(j))//eğer gidilmemişse o şehre ve if'i sağlıyorsa
                        {
                            min = buzaklık[j] + mesafe[i, j];//bu komşu şehre gitmiştir demektir
                            sehir = j;//yeni şehiri atıyorum şehir kısmına
                        }
                    }
                    yol = mesafe[i, sehir];//gidilen şehrin gerçek uzaklığını atıyorum
                }
                i = sehir;//şu anki şehiri belirtiyorum forun dışında olduğu için şehir diye bir şey tanımlamış oldum
                gidilenyol.Add(sehir);//gidilen şehire o şehri ekliyorum
                astaruzaklik += yol;//gidilen yerin heuristic ve gerçek uzaklığını  ekliyorum
                astarpath += " " + sehirBul(sehir);//gidilen path'i ekliyorum
            }
            zaman.Stop();
            ayildizzaman = zaman.ElapsedMilliseconds; //milisaniyeyi saniye çevirmek için
            zaman.Reset();
        }//a star algoritması

        private void tavalamaBenzetimi()// tavlama benzetimi algoritması
        {
            System.Diagnostics.Stopwatch zaman = new System.Diagnostics.Stopwatch();
            zaman.Start();
            randomYol();
            double sicaklik = 100; //başlangic sicakliğini 100 verdim
            Random random = new Random();
            eniyiuzaklik = int.MaxValue; //min üstünde çalışıyoruz o yüzden en yüksek int değeri
            while (sicaklik > 1)// sicaklik 1 den büyük olduğu sürece
            {
                if (uzakliklar[0] < eniyiuzaklik) //eğer yeni bir min değer bulunduysa
                {
                    eniyiuzaklik = uzakliklar[0]; //en iyi uzaklik ataması
                    tavlamaeniyiyol = path[0]; //path ataması
                    path.Clear();//kullanılan tüm path sil
                    uzakliklar.Clear();//tüm uzakligi sil
                    randomYol();//tekrar yol oluştur random
                }
                else if (Math.Exp(-(Convert.ToDouble(uzakliklar[0]) - Convert.ToDouble(eniyiuzaklik)) / Convert.ToDouble(sicaklik)) > random.NextDouble())//eğer olasilik sağlanırsa
                {
                    eniyiuzaklik = uzakliklar[0];//en iyi uzaklik ataması
                    tavlamaeniyiyol = path[0];//path ataması
                    path.Clear();//kullanılan tüm path sil
                    uzakliklar.Clear();//tüm uzakligi sil
                    randomYol();//tekrar yol oluştur random
                }
                else //eğer kabul olmayan bir yol varsa
                {
                    path.Clear(); //kullanılan tüm path sil
                    uzakliklar.Clear();//tüm uzakligi sil
                    randomYol(); //tekrar yol oluştur
                }
                sicaklik *= 0.995;
            }
            zaman.Stop();
            tavlamazaman = zaman.ElapsedMilliseconds; //milisaniyeyi saniye çevirmek için
            zaman.Reset();
        }
        private void randomYol()
        {
            int i = 0;//başlangıç şehri
            Random r = new Random();
            int anlikuzaklik = 0;
            int yol = 0;
            string anlikpath = "A";
            int sehir = 0;//gidilen şehir
            List<int> gidilenyol = new List<int>();//gidilen şehirlere dönmemek için liste
            gidilenyol.Add(0);//başta a gittiği için geri dönmesin diye
            while (sehir != 9)//son şehir b yi 9 olarak eklemiştim
            {
                for (int j = 0; j < 10; j++)
                {
                    if (mesafe[i, j] != int.MaxValue)//eğer max değer değilse komşuluk vardır
                    {
                        if (r.NextDouble() <= 0.6 && !gidilenyol.Contains(j))//eğer gidilmemişse o şehre ve if'i sağlıyorsa
                        {
                            sehir = j;//yeni şehiri atıyorum şehir kısmına
                        }
                    }
                    yol = mesafe[i, sehir];//gidilen şehrin gerçek uzaklığını atıyorum
                }
                if (!gidilenyol.Contains(sehir))
                {
                    i = sehir;//şu anki şehiri belirtiyorum forun dışında olduğu için şehir diye bir şey tanımlamış oldum
                    gidilenyol.Add(sehir);//gidilen şehire o şehri ekliyorum
                    anlikuzaklik += yol;//gidilen yerin heuristic uzaklığını ekliyorum
                    anlikpath += " " + sehirBul(sehir);//gidilen path'i ekliyorum
                }
                else
                {
                    gidilenyol.Clear();
                    gidilenyol.Add(0);
                    i = 0;
                    anlikuzaklik = 0;
                    anlikpath = "A";
                }
            }
            uzakliklar.Add(anlikuzaklik);
            path.Add(anlikpath);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            doldur();
            greddy();
            aStar();
            tavalamaBenzetimi();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string text = "Algoritma Adi                 Hirsli Tepe Tirmanma    Benzetimli Tavlama Ile Tepe Tirmanma     A* Aramasi" + " \n" + "Toplam Calisma Suresi               " + greddyzaman + "                                 " + tavlamazaman + "                                                               " + ayildizzaman + "\n"
    + "Toplam Mesafe                         " + greddyuzaklik + "                    " + eniyiuzaklik + "                                                             " + astaruzaklik + "\n"
    + "Olusturulan Yol                       " + greddypath + "                     "
    + tavlamaeniyiyol + "                                             " + astarpath;
            label1.Text = text;
        }
    }
}
