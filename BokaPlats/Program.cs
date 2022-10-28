namespace BokaPlats
{
    internal class Program
    {

        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("\nVälkommen till SJ-bokning! \n");
            Console.WriteLine("Vad vill du göra: ");
            Console.WriteLine("\u2022 Boka, skriv \"B\", på samma rad följt av ett platsnummer.");
            Console.WriteLine("\u2022 Avboka, skriv \"A\" på samma rad följt av ett platsnummer. ");
            Console.WriteLine("\u2022 Skriva ut det sena\"S\"ste bokade biljetterna, skriv \"S\"");
            Console.WriteLine("\u2022 Avsluta, skriv \"Q\"");


            Console.ReadLine();

        }
    }
}