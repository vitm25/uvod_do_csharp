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
            string slovo = slovicka[rnd.Next(slovicka.Length)];

            Console.WriteLine(slovo);
        }
    }
}
