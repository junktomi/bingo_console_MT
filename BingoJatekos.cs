using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bingo_console_MT
{
    internal class BingoJatekos
    {
        public string Nev { get; set; }
        public string[,] Kartya { get; set; }
        public bool[,] Jeloles { get; set; }

        public BingoJatekos(string nev, string[,] kartya)
        {
            Nev = nev;
            Kartya = kartya;
            Jeloles = new bool[5, 5];

        }
        public void SorsoltSzamotJelol(int szam)
        {
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (Kartya[i, j] != "X" && int.Parse(Kartya[i, j]) == szam)
                    {
                        Jeloles[i, j] = true;
                    }
                }
            }
        }

        public bool BingoEll()
        {
            for (int i = 0; i < 5; i++)
            {
                bool sor = true;
                for (int j = 0; j < 5; j++)
                    if (!Jeloles[i, j]) sor = false;

                if (sor) return true;
            }

            for (int j = 0; j < 5; j++)
            {
                bool oszlop = true;
                for (int i = 0; i < 5; i++)
                    if (!Jeloles[i, j]) oszlop = false;

                if (oszlop) return true;
            }

            bool atlo1 = true;
            bool atlo2 = true;

            for (int i = 0; i < 5; i++)
            {
                if (!Jeloles[i, i]) atlo1 = false;
                if (!Jeloles[i, 4 - i]) atlo2 = false;
            }

            return atlo1 || atlo2;
        }

    }
}
