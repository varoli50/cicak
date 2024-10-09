using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    enum Szine { Zold,Rozsaszin,Feher,Lila, Fekete}
    enum Neme { Fiú,Lány}
    class Cica
    {
        public int ID { get; set; }
        public string Neve { get; set; }

        public Szine Szine { get; set; }
        public DateTime SzuletsiDatum { get; set; }
        public Neme Neme { get; set; }
        public int Suly { get; set; }
        public int Kor => DateTime.Now.Year - SzuletsiDatum.Year;

        public override string ToString()
        {
            return $"{ID,-5} {Neve,-15} {Szine,-10} {SzuletsiDatum.ToString("yyy.MM.dd"),-15} {Neme,-10} {Suly,-5} {Kor,-5}";
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<Cica> cicak = new List<Cica>()
            {
                new Cica()
                {
                    ID=1,
                    Neme=Neme.Fiú,
                    Neve="Megatron",
                    Suly=10,
                    Szine=Szine.Fekete,
                    SzuletsiDatum= new DateTime(2018,08,13),
                },
                new Cica()
                {
                    ID=2,
                    Neme=Neme.Fiú,
                    Neve="Kanci",
                    Suly=15,
                    Szine=Szine.Feher,
                    SzuletsiDatum= new DateTime(2004,04,10),
                },
                new Cica()
                {
                    ID=3,
                    Neme=Neme.Lány,
                    Neve="Erzsi",
                    Suly=5,
                    Szine=Szine.Rozsaszin,
                    SzuletsiDatum= new DateTime(2015,11,29),
                },
                new Cica()
                {
                    ID=4,
                    Neme=Neme.Lány,
                    Neve="Peti",
                    Suly=2,
                    Szine=Szine.Lila,
                    SzuletsiDatum= new DateTime(2024,01,01),
                },
                new Cica()
                {
                    ID=5,
                    Neme=Neme.Fiú,
                    Neve="Macsek",
                    Suly=6,
                    Szine=Szine.Zold,
                    SzuletsiDatum= new DateTime(2010,10,10),
                },

            };
            Cica elsoCica = cicak.First();
            Console.WriteLine(elsoCica);
            Cica utolsoCica = cicak.Last();
            Console.WriteLine(utolsoCica);

            int osszSzuly = cicak.Sum(x => x.Suly);
            Console.WriteLine($"Össz súly: {osszSzuly} kg");

            double atlagKor = cicak.Average(x => x.Kor);
            Console.WriteLine($"Átlag életkor: {atlagKor:0.00}");

            int db = cicak.Count(x => x.Neme == Neme.Lány);
            Console.WriteLine($" lány cicák: {db}");

            int girhes = cicak.Min(x => x.Suly);
            Console.WriteLine($"Legvíznább: {girhes}");

            cicak.Where(x => x.Kor > 3)
                .ToList()
                .ForEach(x => Console.WriteLine(x.Neve));

            cicak.Where(x => x.Szine== Szine.Fekete)
                .ToList()
                .ForEach(x => Console.WriteLine(x.Neve));

            Console.ReadKey();
        }
    }
}
