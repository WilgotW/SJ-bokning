using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BokaPlats
{
    internal class Biljett
    {

        public string location1 { get; set; }
        public string location2 { get; set; }
        string time { get; set; }
        public int seat { get; set; }
        public bool smokerSeat { get; set; }

        public Biljett(string location1, string location2, int seat, bool smokerSeat)
        {
            this.location1 = location1;
            this.location2 = location2;
            this.seat = seat;
            this.smokerSeat = smokerSeat;
        }
        public void printOut()
        {
            

            string smoker;
            
            if (smokerSeat)
            {
                smoker = "RÖKARE";
            }
            else
            {
                smoker = "ICKE RÖKARE";
            }

            string biljett = $"\n PLATSBILJETT \n {location1}-{location2} \n Plats: {seat} \n som: {smoker}";
            lines();
            Console.WriteLine(biljett);
            lines();
            void lines()
            {
                for (int i = 0; i < biljett.Length; i++)
                {
                    Console.Write("-");
                }
            }
            Console.WriteLine();
            
        }
    }
}
