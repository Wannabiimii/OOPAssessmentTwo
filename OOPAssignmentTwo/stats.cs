using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPAssignmentTwo
{
    internal class stats
    {
        private static int threeOrMoreHighScore = 0;
        private static int sevensOutHighScore = 0;
        public int ThreeOrMoreHighScore
        {
             get{return threeOrMoreHighScore;}
            set
            {
                if (value > threeOrMoreHighScore)
                {
                    threeOrMoreHighScore = value;
                }
            }
        }
        public int SevensOutHighScore
        {
            get
            {
                return sevensOutHighScore;
            }
            set
            {
                if (value > sevensOutHighScore)
                {
                    sevensOutHighScore = value;
                }
            }
        }

        private static int sevensOutTimesPlayed = 0;
        private static int threeOrMoreTimesPlayed = 0;
        
        public void IncrementAStat(int selection)
        {
            switch(selection)
            {
                
                case 3:
                    threeOrMoreTimesPlayed++;
                    break;
                case 7:
                    sevensOutTimesPlayed++;
                    break;
            }
        }

        public void displayStats()
        {
            if (threeOrMoreTimesPlayed == 0 && sevensOutTimesPlayed == 0)
            {
                Console.WriteLine("You haven't played anything yet!");
            }
            else
            {
                Console.WriteLine($"You have played three or more {threeOrMoreTimesPlayed} times");
                Console.WriteLine($"Your highest score in three or more is:{threeOrMoreHighScore}");
                Console.WriteLine($"You have played Sevens Out {sevensOutTimesPlayed} times");
                Console.WriteLine($"Your highest score in Sevens Out is:{sevensOutHighScore}");
            }
            
            
        }
    }
}
