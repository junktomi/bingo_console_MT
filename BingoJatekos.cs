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
    }
}
