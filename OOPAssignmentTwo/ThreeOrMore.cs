using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace OOPAssignmentTwo
{
    internal class ThreeOrMore:Game
    {
        static stats stats = new stats();
        //putting dice into an array so i can loop over them
        private Die[] PutDiceIntoArray()
        {
            Die[] dice = new Die[5];
            dice[0] = die1;
            dice[1] = die2;
            dice[2] = die3;
            dice[3] = die4;
            dice[4] = die5;
            return dice;
        }
       //prints out an array 
        private void PrintArray(int[] array)
        {
            foreach (int number in array)
            {
                Console.Write($"{number}, ");
            }
            // creates a space between the output and the next thig printed
            //one is because the printer uses write so the output would otherwise be on the same line
            // the next makes the space between outputs
            Console.WriteLine();
            Console.WriteLine();
        }
        //rolls all the dice and puts the results  into an array
        private int[] rollAll(Die[] dice)
        {
            int[] rolls = new int[5];
            for (int i = 0; i < rolls.Length; i++)
            {
                rolls[i]=dice[i].Roll();
            }
            
            return rolls;
        }
        
        //loop over the rolls gotten from rollAll and counts how many of each type there are.
        // switch statement checks what each roll is and then increments the index of the  dice roll -1
        // when that loop finishes a second loop finds the modal value and how often it occurs
        private int[] findMode(int[] rolls)
        {
            int temp;
            int[] numberOfEach = new int[6];
            
            for(int i = 0; i < rolls.Length; i++)
            {
                temp = rolls[i];
                switch(temp)
                {
                    case 1:
                        numberOfEach[0]++;
                        break;
                    case 2:
                        numberOfEach[1]++;
                        break;
                    case 3:
                        numberOfEach[2]++;
                        break;
                    case 4:
                        numberOfEach[3]++;
                        break;
                    case 5:
                        numberOfEach[4]++;
                        break;
                    case 6:
                        numberOfEach[5]++;
                        break;
                    default:
                        Console.WriteLine($"die{i + 1} is out of range. temp value:{temp}");
                        break;
                }
               
            }
            int mode = 0;
            int timesModeRolled=0;
            
            for (int i = 0; i < numberOfEach.Length; i++)
            {
                
                if (numberOfEach[i] >= numberOfEach[mode])
                {
                    mode = i;
                    timesModeRolled = numberOfEach[i];
                    
                    
                }
            }
            //because of indexing i is one less than the actual mode number
            mode++;
            int[] results = new int[2];
            results[0] = mode;
            results[1] = timesModeRolled;
            return results;
            
        }
        // looks through the rolls to find all non-modal values and rerolls them
        private int[] Reroll(Die[] dice ,int[] rolls,int mode)
        {
            int[] reRolls = new int[6];
            // go over each roll and if they're not the same as the modal value log it
            for (int i = 0; i < rolls.Length; i++)
            {
               
                if (rolls[i] != mode)
                {
                    reRolls[i]++;
                }

            }
            //checks the reroll array for 1s which indicate a die needs rerolling and then rolls it
            for (int i = 0; i < reRolls.Length; i++)
            {
                if (reRolls[i] == 1)
                {
                   rolls[i] = dice[i].Roll();
                }
            }
            return rolls;
        }
        //checks how often the modal value occurs and returns the correct amount of points for it
        private int ScoreChecker(int occurence)
        {
            int score = 0;
            switch (occurence)
            {
                case 1:
                    Console.WriteLine("You didn't roll 3 or more of a kind. No points this turn.");
                    score = 0;
                    break;
                case 2:
                    Console.WriteLine("You didn't roll 3 or more of a kind. No points this turn.");
                    score = 0;
                    break;
                case 3:
                    
                    score = 3;
                    Console.WriteLine($"Adding {score} points");
                    break;
                case 4:
                    score = 6;
                    Console.WriteLine($"Adding {score} points");
                    break;
                case 5:
                    score = 12;
                    Console.WriteLine($"Adding {score} points");
                    break;
                default: 
                    score = 0;
                    Console.WriteLine($"occurence value out of range. occurence value is {occurence}. ");
                    break;
            }
                
            return score;
        }
        // asks the player if they want to reroll non modal values or all dice and recurrs until given a valid input
        private int[] PlayerChoice(int mode,int occurence, int[] rolls, Die[]dice)
        {
            Console.WriteLine($"You rolled {occurence} {mode}s. Type \"1\" to reroll non-{mode} dice or type \"2\" to reroll all dice.");
            string playerChoice = Console.ReadLine();
            switch(playerChoice)
            {
                case "1":
                    rolls =Reroll(dice, rolls, mode);
                    break;
                case "2":
                    rolls = rollAll(dice);
                    break;
                default:
                    Console.WriteLine($"Invalid choice please type \"1\" to reroll non-{mode} dice or type \"2\" to reroll all dice.");
                    rolls = PlayerChoice(mode,occurence,rolls,dice);
                    break;

            }
            return rolls;
        }
        private int PlayerTurn(Die[]dice)
        {
            int score = 0;
            int[] rolls = rollAll(dice);
            PrintArray(rolls);
            int[] modeAndOccurence = findMode(rolls);
            int mode = modeAndOccurence[0];
            int occurence = modeAndOccurence[1];
            if (occurence >= 3)
            {
                score = ScoreChecker(occurence);
            }
            else
            {
               rolls = PlayerChoice(mode,occurence, rolls,dice);
               PrintArray(rolls);
                modeAndOccurence = findMode(rolls);
               mode = modeAndOccurence[0];
               occurence = modeAndOccurence[1];
               score = ScoreChecker(occurence);


            }
            
            return score;
        }
        //same as player turn except the computer just always calls the reroll function
        private int ComputerTurn(Die[] dice)
        {
            int score = 0;
            int[] rolls = rollAll(dice);
            PrintArray(rolls);
            int[] modeAndOccurence = findMode(rolls);
            int mode = modeAndOccurence[0];
            int occurence = modeAndOccurence[1];
            if (occurence >= 3)
            {
                score = ScoreChecker(occurence);
            }
            else
            {
                rolls = Reroll(dice, rolls, mode);
                modeAndOccurence = findMode(rolls);
                mode = modeAndOccurence[0];
                occurence = modeAndOccurence[1];
                score = ScoreChecker(occurence);


            }

            return score;
        }
        public ThreeOrMore()
        {
            PartnerOrComputer();
            Game(false);
        }
        private int Game(bool testing)
        {
            int winningScore = 20;
           
            Die[] dice = PutDiceIntoArray();
            while (_player1Score < winningScore && _player2Score < winningScore)
            {
                
                
                if (testing)
                {
                    _player1Score += ComputerTurn(dice);
                }
                else
                {
                    PrintInColours($"{_player1Name} ", ConsoleColor.DarkBlue);
                    Console.WriteLine("it is your turn");
                    Console.ReadKey();
                    _player1Score += PlayerTurn(dice);
                }
                
                if (_multiplayerChoice == "1")
                {
                    PrintInColours($"{_player2Name} ", ConsoleColor.DarkGreen);
                    Console.WriteLine("it is your turn");
                    _player2Score += PlayerTurn(dice);
                }
                else
                {
                    Console.Write("It is the ");
                    PrintInColours("computer's", ConsoleColor.DarkRed);
                    Console.WriteLine("turn");
                    _player2Score += ComputerTurn(dice);
                }
                DisplayScore(3);
            }
            if (_player1Score > _player2Score)
            {
                stats.ThreeOrMoreHighScore = _player1Score;
                PrintInColours($"{_player1Name}", ConsoleColor.DarkBlue);
                Console.WriteLine(" wins!");
                return _player1Score;
            }
            else if (_player1Score < _player2Score)
            {
                stats.ThreeOrMoreHighScore = _player2Score;
                PrintInColours($"{_player2Name}", ConsoleColor.DarkGreen);
                Console.WriteLine($" wins!");
                return Player2Score;
            }
            else
            {
                stats.ThreeOrMoreHighScore = _player1Score;
                Console.WriteLine("Draw!");
                return Player1Score;
            }
        }
        public ThreeOrMore(string testing)
        {
            Console.WriteLine($"Created a test game for three or more");
           int numOfTests = 0;
            while( numOfTests < 1000 )
            {
                //checking the score checker returns the correct values
                int testScore = ScoreChecker(3);
                Debug.Assert(testScore == 3);
                testScore = ScoreChecker(4);
                Debug.Assert(testScore == 6);
                testScore = ScoreChecker(5);
                Debug.Assert(testScore == 12);
                // testing if the game returns a value larger than 20 when it ends
                Debug.Assert(Game(true) >= 20);
                numOfTests++;
            }
    
           
            Console.WriteLine("testing for ThreeOrMore complete");
        }

    }
}
