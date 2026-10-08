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

            while (true)
            { 
                Console.WriteLine("Slovo: " + string.Join (" ", uhodnuto));
                Console.WriteLine("Chyby: " + chyby + "/" + maxChyb);

                Console.Write("Zadej písmeno: ");
                char pismeno = char.ToUpper(Console.ReadLine()[0]);

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
                    Console.WriteLine("Prohrál jsi! Slovo bylo:" + slovo);
                    
                    break;
                }
            }
        }
    }
}
