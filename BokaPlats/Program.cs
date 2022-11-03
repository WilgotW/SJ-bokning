using System;
using System.Formats.Asn1;

namespace BokaPlats
{
    internal class Program
    {
        static List<Biljett> biljetter = new List<Biljett>();
        static List<string> destinationer = new List<string>();
        
        static void Main(string[] args)
        {
            addDestinations("Stockholm", "Göteborg", "Malmö", "Lund", "Uppsala", "Helsingborg", "Kristianstad", "Gävle", "Borås", "Norrköping");

            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("\nVälkommen till SJ-bokning! \n");
            
            Menu();

        }
        static void addDestinations(params string[] list)
        {
            for (int i = 0; i < list.Length; i++)
            {
                destinationer.Add(list[i]);
            }
        }
        static void printTrainCanvas()
        {
            for (int i = 0; i < biljetter.Count; i++)
            {
                Console.WriteLine(biljetter[i].seat);
            }
            Console.WriteLine("\n      -*Platser*-      ");
            Console.WriteLine("\n           \"X\"      ");
            Console.WriteLine("     märkerar redan      ");
            Console.WriteLine("     bokade platser      ");
            Console.WriteLine("\n______ICKE RÖKARE______");
            printSection(false, 0, 16);
            Console.WriteLine("\n_________RÖKARE________");
            printSection(true, 16, 32);
        }
        static void printSection(bool smoker, int n, int u)
        {
            Console.Write("|");
            int num = 0;
        
            for (int i = n; i < u; i++)
            {
                int temp = i + 1;


                string seatNum = temp.ToString();
                for (int y = 0; y < biljetter.Count; y++)
                {
                    if (smoker)
                    {
                        if (biljetter[y].seat == temp && biljetter[y].smokerSeat)
                        {
                            if (i.ToString().Length == 2)
                            {
                                seatNum = "X ";
                            }
                            else
                            {
                                seatNum = "X";
                            }
                  
                        }
                    }
                    else
                    {
                        if (biljetter[y].seat == temp && biljetter[y].smokerSeat == false)
                        {
                            if (i.ToString().Length == 2)
                            {
                                seatNum = "X ";
                            }
                            else
                            {
                                seatNum = "X";
                            }
                        }
                    }
                }

                if (num < 4)
                {
                    num++;
                    if (i.ToString().Length == 2)
                    {
                        Console.Write($"{seatNum},  ");
                        if (temp == 16)
                        {
                            Console.Write("|");
                        }
                    }
                    else
                    {
                        Console.Write($" {seatNum},  ");
                    }

                }
                else if (num >= 3)
                {
                    num = 1;
                    if (i.ToString().Length == 2)
                    {
                        Console.Write($"|\n| {seatNum},  ");
                    }
                    else
                    {
                        Console.Write($" |\n| {seatNum},  ");
                    }
                }
            }
            Console.WriteLine("\n-----------------------");
        }
        static void Menu()
        {
            List<int> p = new List<int>();
            for (int i = 0; i < 32; i++)
            {
                p.Add(i);
            }

            string answer;
            Console.WriteLine("Vad vill du göra: ");
            Console.WriteLine("\u2022 Boka, skriv \"B\", på samma rad följt av ett platsnummer. (1 - 32) plattser ");
            Console.WriteLine("\u2022 Avboka, skriv \"A\" på samma rad följt av ett platsnummer. (1 - 32) plattser ");
            Console.WriteLine("\u2022 Ändra biljett, skriv \"C\" på samma rad följt av ett platsnummer. (1 - 32) plattser ");
            Console.WriteLine("\u2022 Skriva ut det senaste bokade biljetterna, skriv \"S\"");
            Console.WriteLine("\u2022 Avsluta, skriv \"Q\"");

            try
            {
                answer = Console.ReadLine().ToLower();               
                char firstLetter = answer[0];
                string otherLetters = answer.Substring(1);
                if(firstLetter == 'b')
                {
                    int nummer = int.Parse(otherLetters);
                    if(nummer > 32 || nummer < 1)
                    {
                        Console.WriteLine("Denna plats finns inte. Endast platser mellan (1 - 32)");
                        Console.WriteLine("Går tillbaka till meny...");
                        System.Threading.Thread.Sleep(5000);
                        Console.Clear();
                        Menu();
                    }
                    foreach(Biljett biljett in biljetter)
                    {
                        p.RemoveAt(biljett.seat);
                        if(nummer == biljett.seat)
                        {
                            Console.WriteLine("Denna plats är redan bokad" );
                            Console.WriteLine("Platser som inte är bokade: ");
                            for (int i = 0; i < p.Count; i++)
                            {
                                if(i == biljett.seat)
                                {
                                    Console.Write("");
                                }
                                else
                                {
                                    Console.Write($"{i}, ");
                                }
                            }
                            Console.WriteLine();
                            Console.WriteLine("Går tillbaka till meny...");
                            System.Threading.Thread.Sleep(5000);
                            Console.Clear();
                            Menu();
                        }
                    }
                    boka(nummer);
                }
                if(firstLetter == 'a')
                {
                    int nummer = int.Parse(otherLetters);
                    avboka(nummer);
                }
                if(firstLetter == 'c')
                {
                    int nummer = int.Parse(otherLetters);
                    avboka(nummer);

                    Console.WriteLine("skriv");
                    Console.ReadLine();

                    int n = int.Parse(otherLetters);
                    if (n > 32 || n < 1)
                    {
                        Console.WriteLine("Denna plats finns inte. Endast platser mellan (1 - 32)");
                        Console.WriteLine("Går tillbaka till meny...");
                        System.Threading.Thread.Sleep(5000);
                        Console.Clear();
                        Menu();
                    }
                    foreach (Biljett biljett in biljetter)
                    {
                        p.RemoveAt(biljett.seat);
                        if (n == biljett.seat)
                        {
                            Console.WriteLine("Denna plats är redan bokad");
                            Console.WriteLine("Platser som inte är bokade: ");
                            for (int i = 0; i < p.Count; i++)
                            {
                                if (i == biljett.seat)
                                {
                                    Console.Write("");
                                }
                                else
                                {
                                    Console.Write($"{i}, ");
                                }
                            }
                            Console.WriteLine();
                            Console.WriteLine("Går tillbaka till meny...");
                            System.Threading.Thread.Sleep(5000);
                            Console.Clear();
                            Menu();
                        }
                    }
                    boka(n);

                }
                if(firstLetter == 's')
                {
                    Console.Clear();
                    printTrainCanvas();

                    if(biljetter.Count > 0)
                    {
                        Console.WriteLine("\n______Bokade Biljetter______\n");
                        for (int i = 0; i < biljetter.Count; i++)
                        {
                            biljetter[i].printOut();
                        }
                    }
                    
                    Console.WriteLine("Skriv valfri bokstav för att gå tillbaka till menyn: ");
                    Console.ReadLine();
                    Console.Clear();
                    Menu();
                }
                if(firstLetter == 'q')
                {
                    Console.Clear();
                    Console.WriteLine("Programm Avslutas");
                    System.Threading.Thread.Sleep(2000);
                    System.Environment.Exit(1);
                }
            }
            catch(Exception e)
            {
                Console.WriteLine($"Error: {e.Message}");
                Console.WriteLine("Går tillbaka till menyn...");
                System.Threading.Thread.Sleep(2000);
                Console.Clear();
                Menu();
            }
        }

        static int destinationIndexCheck()
        {
            int num = 0;
            try
            {
                num = int.Parse(Console.ReadLine());
                return num-1;
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error: {e.Message}");
                Console.WriteLine("Går tillbaka till menyn...");
                System.Threading.Thread.Sleep(2000);
                Console.Clear();
                Menu();
            }
            if (num > destinationer.Count || num < 0)
            {
                Console.WriteLine("ogiltigt nummer");
                Console.WriteLine("Går tillbaka till menyn...");
                System.Threading.Thread.Sleep(2000);
                Console.Clear();
                Menu();
            }
            return 0;
            
        }
        static void boka(int platsnummer)
        {
            Console.Clear();
            Console.WriteLine("___Tillgängliga destinationer___");
            for (int i = 0; i < destinationer.Count; i++)
            {
                Console.WriteLine($"{i+1}• {destinationer[i]}");
            }
            Console.WriteLine("--------------------------------");
            Console.WriteLine("Vart åker du ifrån:");

            int a;

            a = destinationIndexCheck();
            string location1 = destinationer[a];
            Console.WriteLine(destinationer[a]);
            
            Console.WriteLine("Vart vill du åka:");
            a = destinationIndexCheck();
            string location2 = destinationer[a];
            Console.WriteLine(destinationer[a]);

            int seat = platsnummer;
            Console.WriteLine("Tänker du att röka på resan (y/n): ");

            bool smokerSeat;
            string answer = Console.ReadLine().ToLower();
            if (answer == "y")
            {
                smokerSeat = true;
                answer = "RÖKARE";
            }
            else if (answer == "n")
            {
                smokerSeat = false;
                answer = "ICKE RÖKARE";
            }
            else
            {
                Console.WriteLine($"{answer} is an invalid input, setting smoker as false");
                smokerSeat = false;
            }
            
            biljetter.Add(new Biljett(location1, location2, seat, smokerSeat));

            Console.WriteLine($"Bokar plats {seat} som {answer}");
            Console.WriteLine("Går tillbaka till meny...");
            System.Threading.Thread.Sleep(2000);
            Console.Clear();
            Menu();
        }

        static void avboka(int platsnummer)
        {
            foreach(Biljett biljett in biljetter)
            {
                if(biljett.seat == platsnummer)
                {
                    string answer;
                    Console.WriteLine($"är du säker att du vill avboka resa från {biljett.location1} till {biljett.location2}? (y/n)");
                    try
                    {
                        answer = Console.ReadLine();
                        if(answer == "y")
                        {
                            Console.WriteLine($"Tar bort biljett med platsnummer {platsnummer}");
                            System.Threading.Thread.Sleep(4000);
                            biljetter.Remove(biljett);
                            Console.Clear();
                            Menu();
                        }else
                        {
                            Console.WriteLine("Avbokning avbryts, går tillbaka till menyn...");
                            System.Threading.Thread.Sleep(4000);
                            Console.Clear();
                            Menu();
                        }
                    }catch(Exception e)
                    {
                        Console.WriteLine($"Error: {e.Message}");
                        Console.WriteLine("Avbokning avbryts, går tillbaka till menyn...");
                        System.Threading.Thread.Sleep(4000);
                        Console.Clear();
                        Menu();
                    }
                    
                    
                }
            }
        }
    }
}