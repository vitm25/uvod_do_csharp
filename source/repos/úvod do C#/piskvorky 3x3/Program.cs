namespace piskvorky_3x3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Piškvorkyyyyyyyyyyyy");
            string[] pole = { "0", "1", "2", "3", "4", "5", "6", "7", "8" };
            string hrac = "X";
            int tahy = 0;

            while (true)
            {
                //pole
                Console.WriteLine(pole[0] + "|" + pole[1] + "|" + pole[2]);
                Console.WriteLine(pole[3] + "|" + pole[4] + "|" + pole[5]);
                Console.WriteLine(pole[6] + "|" + pole[7] + "|" + pole[8]);

                //tah hrace
                Console.Write("hraje " + hrac + ", zadej číslo políčka: ");
                int cislo = Convert.ToInt32(Console.ReadLine());

                if (cislo < 1 || cislo > 9 || pole[cislo - 1] == "X" || pole[cislo - 1] == "0");
                {
                    Console.WriteLine("tam nejde hrát, zkus to znovu");
                    continue;
                }

                pole[cislo-1] = hrac;
                tahy ++;

                if (Vyhral(pole, hrac));
                {
                    Console.WriteLine("Vyhral " + hrac + "!");
                    break;


                }
            }
        }
    }
}
