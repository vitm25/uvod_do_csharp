using System.Diagnostics;

namespace piskvorky_3x3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Piškvorkyyyyyyyyyyyy");
            string[] pole = { " ", " ", " ", " ", " ", " ", " ", " ", " " };
            string hrac = "X";
            int tahy = 0;

            while (true)
            {
                //pole
                Console.WriteLine(pole[0] + "|" + pole[1] + "|" + pole[2]);
                Console.WriteLine("-----");
                Console.WriteLine(pole[3] + "|" + pole[4] + "|" + pole[5]);
                Console.WriteLine("-----");
                Console.WriteLine(pole[6] + "|" + pole[7] + "|" + pole[8]);

                //tah hrace
                Console.Write("hraje " + hrac + ", zadej číslo políčka: ");
                int cislo = Convert.ToInt32(Console.ReadLine());

                if (cislo < 1 || cislo > 9 || pole[cislo - 1] == "X" || pole[cislo - 1] == "0")
                {
                    Console.WriteLine("tam nejde hrát, zkus to znovu");
                    continue;
                }

                pole[cislo-1] = hrac;
                tahy ++;

                if (Vyhral(pole, hrac))
                {
                    Console.WriteLine("Vyhral " + hrac + "!");
                    break;
                }
                if (tahy == 9)
                {
                    Console.WriteLine("Remíza!");
                    break;
                }

                if (hrac == "X")
                {
                    hrac = "O";
                }
                else
                {
                    hrac = "X";
                }
                
            }
        }

        static bool Vyhral(string[] p, string h)
        {
            if (p[0] == h && p[1] == h && p[2] == h) return true; // řádek
            if (p[3] == h && p[4] == h && p[5] == h) return true;
            if (p[6] == h && p[7] == h && p[8] == h) return true;
            if (p[0] == h && p[3] == h && p[6] == h) return true; // sloupec
            if (p[1] == h && p[4] == h && p[7] == h) return true;
            if (p[2] == h && p[5] == h && p[8] == h) return true;
            if (p[0] == h && p[4] == h && p[8] == h) return true; // diagonál
            if (p[2] == h && p[4] == h && p[6] == h) return true;
            return false;
        }
    }
}
