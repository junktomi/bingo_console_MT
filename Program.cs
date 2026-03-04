namespace bingo_console_MT
{
    using System;
    using System.Collections.Generic;
    using System.IO;

    internal class Program
    {
        static void Main(string[] args)
        {
            List<BingoJatekos> jatekosok = new List<BingoJatekos>();

            string[] fajlnevek = File.ReadAllLines("nevek.text");

            foreach (string fajl in fajlnevek)
            {
                string nev = Path.GetFileNameWithoutExtension(fajl);
                string[] sorok = File.ReadAllLines(fajl);

                string[,] kartya = new string[5, 5];

                for (int i = 0; i < 5; i++)
                {
                    string[] elemek = sorok[i].Split(';');
                    for (int j = 0; j < 5; j++)
                    {
                        kartya[i, j] = elemek[j];
                    }
                }

                jatekosok.Add(new BingoJatekos(nev, kartya));
            }

            Console.WriteLine("4. feladat");
            Console.WriteLine($"Játékosok száma: {jatekosok.Count}");

            Random rnd = new Random();
            List<int> huzott = new List<int>();

            int sorszam = 1;
            bool vanBingo = false;

            while (!vanBingo)
            {
                int szam;
                do
                {
                    szam = rnd.Next(1, 76);
                } while (huzott.Contains(szam));

                huzott.Add(szam);

                Console.WriteLine($"{sorszam}. húzás: {szam}");
                sorszam++;

                foreach (var j in jatekosok)
                {
                    j.SorsoltSzamotJelol(szam);
                    if (j.BingoEll())
                        vanBingo = true;
                }
            }

            Console.WriteLine("8. feladat");

            foreach (var j in jatekosok)
            {
                if (j.BingoEll())
                {
                    Console.WriteLine($"Nyertes: {j.Nev}");

                    for (int i = 0; i < 5; i++)
                    {
                        for (int k = 0; k < 5; k++)
                        {
                            if (j.Jeloles[i, k])
                                Console.Write($"{j.Kartya[i, k],4}");
                            else
                                Console.Write($"{"0",4}");
                        }
                        Console.WriteLine();
                    }
                }
            }
        }
    }
}
