using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Card
{
    class Karta
    {
        public string Suit { get; }
        public string Rank { get; }

        public Karta(string suit, string rank)
        {
            Suit = suit;
            Rank = rank;
        }

        public int GetValue()
        {
            // Определение значения карты (по рангу)
            switch (Rank)
            {
                case "6":
                    return 6;
                case "7":
                    return 7;
                case "8":
                    return 8;
                case "9":
                    return 9;
                case "10":
                    return 10;
                case "Валет":
                    return 11;
                case "Дама":
                    return 12;
                case "Король":
                    return 13;
                case "Туз":
                    return 14;
                default:
                    return 0;
            }
        }

        public override string ToString()
        {
            return $"{Rank} {Suit}";
        }
    }
}
