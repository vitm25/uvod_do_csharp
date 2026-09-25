namespace kamen_nuzky_papir
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 1 = kamen, 2 = nuzky, 3 = papir
            Console.Write("Zadej 1 = kámen, 2 = nůžky, 3 = papír: ");
            string coUzivatelZadal = Console.ReadLine();

            int hrac;
            hrac = Convert.ToInt32(coUzivatelZadal);

            // pocitac si nahodne vybere cislo 1, 2 nebo 3
            Random nahoda = new Random();
            int pocitac;
            pocitac = nahoda.Next(1, 4);

            Console.WriteLine("Počítač zvolil " + pocitac);

            // vyhodnoceni
            if (hrac == pocitac)
            {
                Console.WriteLine("Remíza!");
            }
            else if (hrac == 1 && pocitac == 2)
            {
                Console.WriteLine("Vyhrál jsi! Kámen tupí nůžky.");
            }
            else if (hrac == 2 && pocitac == 3)
            {
                Console.WriteLine("Vyhrál jsi! Nůžky stříhají papír.");
            }
            else if (hrac == 3 && pocitac == 1)
            {
                Console.WriteLine("Vyhrál jsi! Papír zabalí kámen.");
            }
            else
            {
                Console.WriteLine("Prohrál jsi!");
            }
        }
    }
}