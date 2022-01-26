using System;

namespace Vinlotteri
{
     class Program
    {
        public readonly static DeltagerApi DeltagerApi = new DeltagerApi();
        public static IList<int>?LoddListe;
        static void Main(string[] args)
        {
            try
            {
                LoddListe = Enumerable.Range(1, 100).ToList();
                Home();
            }
            catch (Exception)
            {
                Console.WriteLine("Noe gikk galt:(,prøv igjen");
                Thread.Sleep(1000);
                Home();
            }

        }

        private static void Home()
        {
            Console.Clear();
            Console.WriteLine("----Velkommen til Vinlotteri----");

            if (LoddListe.Count > 0)
            {
                int antallTegn = 0;
                foreach (var l in LoddListe)
                {
                    antallTegn++;

                    Console.Write($"{l} , ");

                    if (antallTegn == 10)
                    {
                        Console.WriteLine();
                        antallTegn = 0;
                    }
                }

                Console.WriteLine("\n\nTrykk på k for å registrere kjøp\n");

                var valg = Console.ReadLine();

                if (valg.ToLower() == "k")
                {
                    Registrering();
                }
                else
                {
                    Home();
                }
            }
           
        }

        private static void Registrering()
        {
            Console.Clear();

            Console.WriteLine("Skriv in deltager navn");
            var navn  = Console.ReadLine();

            Console.WriteLine($"\nHvor mange lodd har {navn} kjøpt ?");
            var antall= int.Parse(Console.ReadLine());

            var kjoptLodd = new List<Lodd>();    
            for (int i = 0; i < antall; i++)
            {
                Console.WriteLine($"\nSkriv in {i+1}.lodd");

                var nummer = int.Parse(Console.ReadLine());

                kjoptLodd.Add(new Lodd(nummer));

                //fjerner kjøpte lodd fra listen
                LoddListe.Remove(nummer);

            }

            var deltager = new Deltager
            {
                Navn = navn,
                Lodd = kjoptLodd
            };

            DeltagerApi.AddDeltager(deltager) ;

            Console.WriteLine("\nRegistreing vellykket, trykk h for å gå tilbake");
            Console.ReadLine();

            Home();
        }
    }
}