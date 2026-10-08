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

            while (true)
            { 
                Console.WriteLine("Slovo: " + string.Join (" ", uhodnuto));

                Console.Write("Zadej písmeno: ");
                char pismeno = char.ToUpper(Console.ReadLine()[0]);

                for (int i = 0; i < slovo.Length; i++)
                {
                    if (slovo[i] == pismeno)
                    {
                        uhodnuto[i] = pismeno;
                    }
                }
            }
        }
    }
}
