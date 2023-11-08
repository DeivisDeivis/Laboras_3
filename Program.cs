using Microsoft.SqlServer.Server;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboras_PO4
{
    /// <summary>
    /// Klasė kopijavimo aparato duomenims saugoti
    /// </summary>
    class Aparatas
    {
        private string gamintojas; //Kopijavimo aparato gamintojo kintamasis
        private string modelis; //Kopijavimo aparato modelio kintamasis
        private string formatas; //Maksimalaus popieriaus formato kintamasis
        private int sparta; //Kopijavimo spartos kintamasis
        private int puslapioLaikas; //Pirmojo puslapio išspausdinimo laiko kintamasis
        private int talpa;//Standartinės popieriaus kasetės talpos kintamasis
        /// <summary>
        /// Konstruktorius su parametrais
        /// </summary>
        /// <param name="gamintojas">kopijavimo aparato gamintojas</param>
        /// <param name="modelis">kopijavimo aparato modelis</param>
        /// <param name="formatas">maksimalaus popieriaus formatas</param>
        /// <param name="sparta">kopijavimo sparta</param>
        /// <param name="puslapioLaikas">pirmojo puslapio išspausdinimo laikas</param>
        /// <param name="talpa">standartinės popieriaus kasetės talpa</param>
        public Aparatas(string gamintojas, string modelis, string formatas, int sparta, int puslapioLaikas, int talpa)
        {
            this.gamintojas = gamintojas;
            this.modelis = modelis;
            this.formatas = formatas;
            this.sparta = sparta;
            this.puslapioLaikas = puslapioLaikas;
            this.talpa = talpa;
        }
        /// <summary>
        /// Grąžina popieriaus kasetės talpos dydį
        /// </summary>
        /// <returns>kasetės talpa</returns>
        public int ImtiTalpą() { return this.talpa; }
        /// <summary>
        /// Grąžina kopijavimo spartą
        /// </summary>
        /// <returns>kopijavimo sparta</returns>
        public int ImtiSpartą() { return this.sparta; }
        /// <summary>
        /// Grąžina kopijavimo aparato gamintoją
        /// </summary>
        /// <returns>kopijavimo aparato gamintojas</returns>
        public string ImtiGamintoją() { return this.gamintojas; }
        /// <summary>
        /// Užklotas metodas ToString()
        /// </summary>
        /// <returns>grąžina eilutę (string), kurioje yra sukaupta informacija apie objektą (kintamųjų reikšmes)</returns>
        public override string ToString()
        {
            string eilute;
            eilute = string.Format(" | {0,14} | {1,19} | {2,12} | {3,14:d} | {4,21:d} | {5,17:d} | ",
            gamintojas, modelis, formatas, sparta, puslapioLaikas, talpa);
            return eilute;
        }
        /// <summary>
        /// Užklotas metodas GetHashCode()
        /// </summary>
        ///<returns>grąžina objekto Hash kodo reikšmę</returns>
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        /// <summary>
        /// Užklotas metodas Equals(), kuris palygina du objektus
        /// </summary>
        /// <param name="obj">kopijuoklio objektas</param>
        /// <returns>gražina true, jei objektai lygus</returns>
        /// <returns>gražina fase, jei objektai nelygūs</returns>
        public virtual bool Equals(Aparatas obj)
        {
            if (this.gamintojas == obj.gamintojas)
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// Užklotas metodas >=()
        /// </summary>
        /// <param name="st1">vieno iš sąrašo lyginamo kopijuoklio objektas</param>
        /// <param name="st2">kito iš sąrašo lyginamo kopijuoklio objektas</param>
        /// <returns>grąžina dviejų elementų palyginimą</returns>
        public static bool operator >=(Aparatas st1, Aparatas st2)
        {
            int g = String.Compare(st1.gamintojas, st2.gamintojas, StringComparison.CurrentCulture);
            return st1.ImtiSpartą() > st2.ImtiSpartą() || st1.ImtiSpartą() == st2.ImtiSpartą() && g < 0;
        }
        /// <summary>
        /// Užklotas metodas <=()
        /// </summary>
        /// <param name="st1">vieno iš sąrašo lyginamo kopijuoklio objektas</param>
        /// <param name="st2">kito iš sąrašo lyginamo kopijuoklio objektas</param>
        /// <returns>grąžina dviejų elementų palyginimą</returns>
        public static bool operator <=(Aparatas st1, Aparatas st2)
        {
            int g = String.Compare(st1.gamintojas, st2.gamintojas, StringComparison.CurrentCulture);
            return st1.ImtiSpartą() < st2.ImtiSpartą() || st1.ImtiSpartą() == st2.ImtiSpartą() && g > 0; ;
        }
    }
    /// <summary>
    /// Koteinerinė klasė
    /// </summary>
    class Kopijuokliai
    {
        const int Cn = 100; //Masyvo dydžio kintamasis
        private Aparatas[] aparatai; //Kopijavimo aparatų duomenys
        private int kiekis; //Kopijavimo aparatų skaičius
        /// <summary>
        /// Užklotas konstruktorius be parametrų
        /// </summary>
        public Kopijuokliai()
        {
            kiekis = 0;
            aparatai = new Aparatas[Cn];
        }
        /// <summary>
        /// Užklotas konstruktorius su parametrais
        /// </summary>
        /// <param name="aparatai">kopijavimo aparatų duomenys</param>
        /// <param name="kiekis">kopijavimo aparatų skaičius</param>
        public Kopijuokliai(Aparatas[] aparatai, int kiekis)
        {
            this.aparatai = aparatai;
            this.kiekis = kiekis;
        }
        /// <summary>
        /// Grąžina nurodyto indekso kopijavimo aparato objektą
        /// </summary>
        /// <param name="i">kopijavimo aparato indeksas</param>
        /// <returns>nurodyto indekso kopijavimo aparato objektas</returns>
        public Aparatas Imti(int i) { return aparatai[i]; }
        /// <summary>
        /// Grąžina kopijavimo aparatų (kopijuoklių) skaičių
        /// </summary>
        /// <returns>kopijavimo aparatų skaičių</returns>
        public int ImtiKiekį() { return kiekis; }
        /// <summary>
        /// Padeda į kopijuoklių objektų masyvą naują aparatą ir masyvo dydį padidina vienetu
        /// </summary>
        /// <param name="b">kopijuoklio obejektas</param>
        public void Dėti(Aparatas b) { aparatai[kiekis++] = b; }
        /// <summary>
        /// Metodas surasti didžiausią popieriaus talpą turintį kopijuoklį
        /// </summary>
        /// <returns>didžiausią popieriaus talpą turintis kopijuoklis</returns>
        public Aparatas MaxTalpa()
        {
            Aparatas max = this.Imti(0);
            for (int i = 1; i < this.ImtiKiekį(); i++)
            {
                if (this.Imti(i).ImtiTalpą() > max.ImtiTalpą())
                {
                    max = this.Imti(i);
                }
            }
            return max;
        }
        /// <summary>
        /// Metodas surasti kelis didžiausią popieriaus talpą turinčius kopijuoklus
        /// </summary>
        /// <returns>keli didžiausią popieriaus talpą turintys kopijuokliai</returns>
        public Kopijuokliai DidziausiaTalpa()
        {
            Kopijuokliai didTalpa = new Kopijuokliai();
            Aparatas max = this.MaxTalpa();
            for (int i = 0; i < this.ImtiKiekį(); i++)
            {
                if (this.Imti(i).ImtiTalpą() == max.ImtiTalpą())
                {
                    didTalpa.Dėti(this.Imti(i));
                }
            }
            return didTalpa;
        }
        /// <summary>
        /// Metodas, leidžiantis atrinkti nurodyta sparta kopijuojančius aparatus
        /// </summary>
        /// <param name="kopijuokliai">kopijuoklių saugomi duomenys</param>
        /// <param name="xp">kopijuoklio kopijavimo spartos intervalo pradžios kintamasis</param>
        /// <param name="xh">kopijuoklio kopijavimo spartos intervalo pabaigos kintamasis</param>
        /// <returns>naujai atrinktų kopijuoklių aparatai</returns>
        public Kopijuokliai Formuoti(Kopijuokliai kopijuokliai, int xp, int xh)
        {
            Kopijuokliai atrinkti = new Kopijuokliai();
            for (int i = 0; i < kopijuokliai.ImtiKiekį(); i++)
            {
                Aparatas apar = kopijuokliai.Imti(i);
                if (apar.ImtiSpartą() >= xp && apar.ImtiSpartą() <= xh)
                {
                    atrinkti.Dėti(apar);
                }
            }
            return atrinkti;
        }
        /// <summary>
        /// Metodas, suskaičiuojantis kopijuoklio gamintojo gaminamų modelių kiekį
        /// </summary>
        /// <param name="talpos">pagal didžiausią popieriaus talpą išrinktas kopijuoklio objektas</param>
        /// <param name="visasSarasas">visų pradinio sąrašo kopijuoklių objektas</param>
        /// <returns>kopijuoklio gamintojo gaminamų modelių kiekis</returns>
        public string ModeliuKiekis(Kopijuokliai talpos, Kopijuokliai visasSarasas)
        {
            string aparatuKiekis = "";
            for (int i = 0; i < talpos.ImtiKiekį(); i++)
            {
                int kiekis = 0;
                for (int j = 0; j < visasSarasas.ImtiKiekį(); j++)
                {
                    if (talpos.Imti(i).Equals(visasSarasas.Imti(j)))
                    {
                        kiekis++;
                    }
                }
                aparatuKiekis = String.Format("Gamintojas {0,3} turi {1,2:d} modelį/(ius).\n", talpos.Imti(i).ImtiGamintoją(), kiekis);
            }
            return aparatuKiekis;
        }
        /// <summary>
        /// Metodas, kuris surikiuoja naują kopijuoklių sąrašą pagal nurodytą spartą mažėjimo tvarka
        /// </summary>
        public void RikiuotiPagalSpartMaz()
        {
            for (int i = 0; i < this.kiekis; i++)
            {
                Aparatas min = this.aparatai[i];
                int im = i;
                for (int j = i + 1; j < this.kiekis; j++)
                {
                    if (this.aparatai[j] >= min)
                    {
                        min = this.aparatai[j];
                        im = j;
                    }
                }
                this.aparatai[im] = this.aparatai[i];
                this.aparatai[i] = min;
            }
        }
    }
    /// <summary>
    /// Klasė pagrindinei programai vykdyti ir kitiems skaičiavimio veiksmams atlikti
    /// </summary>
    internal class Program
    {
        const string CFd = "..\\..\\Kopijuokliai.txt"; //Duomenų failo kintamasis
        const string CFrez = "..\\..\\Rezultatai.txt"; //Rezultatų failo kintamasis
        static void Main(string[] args)
        {
            int xp;
            int xh;
            Console.InputEncoding = System.Text.Encoding.GetEncoding(1257);
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Kopijuokliai kopijuokliai = new Kopijuokliai();
            Kopijuokliai didziausiosTalpos; //Didžiausią popieriaus talpą turinčių kopijuoklių objektas
            Kopijuokliai atrinkti;

            Skaityti(ref kopijuokliai, CFd);

            if (File.Exists(CFrez))
                File.Delete(CFrez);

            Spausdinti(CFrez, kopijuokliai, "Skaitmeninių kopijavimo aparatų techninės charakteristikos: ");

            using (var fr = File.AppendText(CFrez))
            {
                fr.WriteLine("\nRezultatai:");
            }

            didziausiosTalpos = kopijuokliai.DidziausiaTalpa();
            Spausdinti(CFrez, didziausiosTalpos, "\n1. Kopijuoklio/(-ių) su didžiausia talpa informacija: ");

            using (var fr = File.AppendText(CFrez))
            {
                fr.WriteLine("\n2. Pastarojo aparato gamintojo gaminamų modelių kiekis: \n{0}", kopijuokliai.ModeliuKiekis(didziausiosTalpos, kopijuokliai));
            }

            Console.Write("Nurodykite kopijuoklio kopijavimo spartos intervalo pradžią (cpm): ");
            xp = int.Parse(Console.ReadLine());

            Console.Write("Nurodykite kopijuoklio kopijavimo spartos intervalo pabaigą (cpm): ");
            xh = int.Parse(Console.ReadLine());

            atrinkti = kopijuokliai.Formuoti(kopijuokliai, xp, xh);
            Spausdinti(CFrez, atrinkti, "3. Atrinktų kopijuoklių su nurodyta sparta informacija:");

            atrinkti.RikiuotiPagalSpartMaz();
            Spausdinti(CFrez, atrinkti, "\n4. Skaitmeninių kopijavimo aparatų sąrašas, surikiuotas pagal spartą mažėjimo tvarka: ");
        }
        /// <summary>
        /// Duomenų failo nuskaitymo metodas
        /// </summary>
        /// <param name="kopijuokliai">kopijuoklių saugomi duomenys</param>
        /// <param name="fv">failo vardas, kuris nurodomas konstanta CFd</param>
        static void Skaityti(ref Kopijuokliai kopijuokliai, string fv)
        {
            string gamintojas, modelis, formatas;
            int sparta, talpa, puslapioLaikas;
            string line;
            using (StreamReader reader = new StreamReader(fv))
            {
                kopijuokliai = new Kopijuokliai();
                while ((line = reader.ReadLine()) != null)
                {
                    string[] parts = line.Split(';');
                    gamintojas = parts[0].Trim();
                    modelis = parts[1].Trim();
                    formatas = parts[2].Trim();
                    sparta = int.Parse(parts[3].Trim());
                    puslapioLaikas = int.Parse(parts[4].Trim());
                    talpa = int.Parse(parts[5].Trim());
                    Aparatas apar = new Aparatas(gamintojas, modelis, formatas, sparta, puslapioLaikas, talpa);
                    kopijuokliai.Dėti(apar);
                }
            }
        }
        /// <summary>
        /// Duomenų failo spausdinimo metodas
        /// </summary>
        /// <param name="fv">failo vardas, kuris nurodomas konstanta CFd</param>
        /// <param name="kopijuokliai">kopijuoklių saugomi duomenys</param>
        /// <param name="antraste">failo antraštė</param>
        static void Spausdinti(string fv, Kopijuokliai kopijuokliai, string antraste)
        {
            string virsus =
            ""
            + " -------------------------------------------------------------------------------------------------------------------- \r\n"
            + " |   Gamintojas   |       Modelis       | Max. popier. |   Kopijavimo   |     Pirm. puslap.     | Standart. popier. | \r\n"
            + " |                |                     |   formatas   |  sparta (cpm)  |  išspausdinimo laikas |   kasetės talpa   | \r\n"
            + " --------------------------------------------------------------------------------------------------------------------";
            using (var fr = File.AppendText(fv))
            {
                fr.WriteLine(antraste);
                fr.WriteLine(virsus);
                for (int i = 0; i < kopijuokliai.ImtiKiekį(); i++)
                    fr.WriteLine(kopijuokliai.Imti(i).ToString());
                fr.WriteLine(" -------------------------------------------------------------------------------------------------------------------- ");
            }
        }
    }
}

