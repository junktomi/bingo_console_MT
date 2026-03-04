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

        }
    }
}
