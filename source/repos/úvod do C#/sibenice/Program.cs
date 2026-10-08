namespace sibenice
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("šibenice");

            // slova
            string[] slovicka = File.ReadAllLines("slovnik.txt");
            
            Random rnd = new Random();
            string slovo = "";
            while (slovo == "")
            {
                slovo = slovicka[rnd.Next(slovicka.Length)];
            }

            char[] uhodnuto = new char[slovicka.Length];
            for (int i = 0; i < slovo.Length; i++)
            {
                if (slovo[i] == ' ')
                {
                    uhodnuto[i] = ' ';
                }
                else
                {
                    uhodnuto[i] = '_';
                }
            }

            int chyby = 0;
            int maxChyb = 6;
            string pouzite = "";

            while (true)
            {
                Obrazek(chyby);
                Console.WriteLine("Slovo: " + string.Join (" ", uhodnuto));
                Console.WriteLine("Chyby: " + chyby + "/" + maxChyb);

                Console.WriteLine("Použitá písmena: " + pouzite);
                Console.Write("Zadej písmeno: ");
                string vstup = Console.ReadLine().ToUpper();

                //kontrola, že je to jedno písmeno
                if (vstup.Length != 1 || !char.IsLetter(vstup[0]))
                {
                    Console.WriteLine("Zadej jedno písmeno, zkus to znovu");
                    continue;
                }

                char pismeno = vstup[0];

                //kontrola, jestli už písmeno nebylo
                if (pouzite.Contains(pismeno))
                {
                    Console.WriteLine("Tohle písmeno už jsi zkoušel");
                    continue;
                }

                pouzite += pismeno + " ";

                if (slovo.Contains(pismeno))
                {
                    for (int i = 0; i < slovo.Length; i++)
                    {
                        if (slovo[i] == pismeno)
                        {
                            uhodnuto[i] = pismeno;
                        }
                    }
                    Console.WriteLine("Spravně :)");
                }
                else
                {
                    chyby++;
                    Console.WriteLine("Špatně :(");
                }

                if (new string(uhodnuto) == slovo)
                {
                    Console.WriteLine("Vyhral jsi! Slovo bylo: " + slovo);

                    break;        
                }

                if (chyby == maxChyb)
                {
                    Obrazek(chyby);
                    Console.WriteLine("Prohrál jsi! Slovo bylo:" + slovo);
                    
                    break;
                }
            }
        }

        static void Obrazek(int chyby)
        {
            string hlava = " ";
            string telo = " ";
            string levaRuka = " ";
            string pravaRuka = " ";
            string levaNoha = " ";
            string pravaNoha = " ";

            if (chyby >= 1) hlava = "O";
            if (chyby >= 2) telo = "|";
            if (chyby >= 3) levaRuka = "/";
            if (chyby >= 4) pravaRuka = "\\";
            if (chyby >= 5) levaNoha = "/";
            if (chyby >= 6) pravaNoha = "\\";

            Console.WriteLine("  +---+");
            Console.WriteLine("  |   |");
            Console.WriteLine("  " + hlava + "   |");
            Console.WriteLine(" " + levaRuka + telo + pravaRuka + "  |");
            Console.WriteLine(" " + levaNoha + " " + pravaNoha + "  |");
            Console.WriteLine("      |");
            Console.WriteLine("=========");
        }
    }
}
