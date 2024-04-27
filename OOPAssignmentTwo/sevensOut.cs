using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace OOPAssignmentTwo
{
    internal class SevensOut:Game
    {
        private int firstRoll;
        private int secondRoll;
        static stats stats = new stats();
        
        private int RollAndSum()
        {
             firstRoll = die1.Roll();
             secondRoll = die2.Roll();
            int sum = firstRoll + secondRoll;
            
            return sum;
        }
        private int Turn(bool testing)
        {
            int turnScore = 0;
            bool rolledSeven = false;
            while (!rolledSeven)
            {
                int result = RollAndSum();
                if (testing)
                {
                    result = 7;
                }
                if (result == 7)
                {
                    Console.WriteLine("rolled 7! Turn over.");
                    rolledSeven = true;
                }
                else if (die1.DiceValue == die2.DiceValue)
                {
                    Console.WriteLine($"Double {die1.DiceValue}s! Adding {2*die1.DiceValue} points to score.");
                    turnScore += 2 * result;
                }
                else
                {
                    Console.WriteLine($"Rolled {result}! Adding {result} points to score");
                    turnScore += result;
                }
            }
            return turnScore;
           
        }

        private void Game()
        {
            PrintInColours($"{_player1Name}", ConsoleColor.DarkBlue);
            Console.WriteLine(" it is your turn! Press ENTER to play!");
            Console.ReadLine();
            _player1Score += Turn(false);
            DisplayScore(1);
            if (_multiplayerChoice == "1")
            {
                PrintInColours($"{_player2Name}", ConsoleColor.DarkGreen);
                Console.WriteLine($" it is your turn! Press ENTER to play!");
                Console.ReadLine();
            }
            else
            {
                Console.Write("It is the");
                PrintInColours(" computer's", ConsoleColor.DarkRed);
                Console.WriteLine(" turn!");
            }
            _player2Score += Turn(false);
            DisplayScore(2);
            if (_player1Score > _player2Score)
            {
                PrintInColours($"{_player1Name}", ConsoleColor.DarkBlue);
                Console.WriteLine(" wins!");
                stats.SevensOutHighScore = _player1Score;

            }
            else if (_player2Score > _player1Score)
            {
                if (_multiplayerChoice == "1")
                {
                    PrintInColours($"{_player2Name}", ConsoleColor.DarkGreen);
                    Console.WriteLine($" wins!");
                    stats.SevensOutHighScore = _player2Score;
                }
                else
                {
                    PrintInColours($"{_player2Name}", ConsoleColor.DarkRed);
                    Console.WriteLine($" wins! {_player2Score}");
                    stats.SevensOutHighScore = _player2Score;
                }
            }
            else
            {
                Console.WriteLine("Draw!");
            }
        }
        public SevensOut()
        {
            //Check if the player is going against the computer or another person and get the name of those playing
            PartnerOrComputer();
            // method that plays through the game
            Game();
           
           
        }
        public SevensOut(string testing)
        {
            Console.WriteLine("created a test game of sevens out");
            int numOfTests = 0;
            while (numOfTests < 1000)
            {
                //testing that roll and sum returns the correct value
                int sum = RollAndSum();
                
                Debug.Assert(sum == firstRoll + secondRoll);

                // when turn is called with true it forces the reulst variable to be 7.
                // If turn returns 0 then the game ended immediately due to rolling 7.  
                int checkForSeven = Turn(true);
                Debug.Assert(checkForSeven == 0);
                numOfTests++;
            }
           
            Console.WriteLine("sevensOut testing complete");
        }
    }
}
