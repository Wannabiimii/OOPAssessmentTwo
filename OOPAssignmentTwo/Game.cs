using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;

namespace OOPAssignmentTwo
{
    internal class Game
    {
        static stats stats = new stats();
        //STUFF TO BE INHERITED
        public void PrintInColours(string toBePrinted, ConsoleColor color)
        {
            
            Console.ForegroundColor = color;
            Console.Write(toBePrinted);
            Console.ForegroundColor = ConsoleColor.White;
        }
        //DICE
        
       protected Die die1 = new Die();
       protected Die die2 = new Die();
       protected Die die3 = new Die();
       protected Die die4 = new Die();
       protected Die die5 = new Die();
      
        //SCORING
        //Scores for the games
       protected  int _player1Score = 0;
       protected  int _player2Score = 0;
       public int Player1Score {get{return _player1Score;}set{_player1Score = value;}}
       public int Player2Score {get{return _player2Score;}set{_player2Score = value;}}
       //a method to display the score of player 1 and or 2 depending on which argument the method is called with
       public void DisplayScore(int player)
        {
            switch (player)
            {
                case 1:
                    PrintInColours($"{_player1Name}", ConsoleColor.DarkBlue);
                    Console.WriteLine($"'s score:{_player1Score}");
                    break;
                case 2:
                    if (_multiplayerChoice == "1")
                    {
                        PrintInColours($"{_player2Name}", ConsoleColor.DarkGreen);
                        Console.WriteLine($"'s score: {_player2Score}");
                    }
                    else
                    {
                        PrintInColours($"{_player2Name}", ConsoleColor.DarkRed);
                        Console.WriteLine($"'s score: {_player2Score}");
                    }
                    break;
                default:
                    PrintInColours($"{_player1Name}", ConsoleColor.DarkBlue);
                    Console.WriteLine($"'s score:{_player1Score}");
                    if (_multiplayerChoice == "1")
                    {
                        PrintInColours($"{_player2Name}", ConsoleColor.DarkGreen);
                        Console.WriteLine($"'s score: {_player2Score}");
                    }
                    else
                    {
                        PrintInColours($"{_player2Name}", ConsoleColor.DarkRed);
                        Console.WriteLine($"'s score: {_player2Score}");
                    }
                    break;
            }
        }
       //PLAYERS
       //a method to be inherited by the two game classes used to choose whether you play against the computer or pplay multiplayer
       protected string _multiplayerChoice;
       protected string _player1Name;
       protected string _player2Name;
       protected void PartnerOrComputer()
       {
            Console.WriteLine("What's your name?");
            _player1Name = Console.ReadLine();
            Console.Write("Hello ");
            PrintInColours($"{_player1Name}", ConsoleColor.DarkBlue);
            Console.WriteLine(" play against a person or the computer?");
            Console.WriteLine("Type \"1\" to play with another person or type anything to play against a computer)");
           _multiplayerChoice = Console.ReadLine();
            if (_multiplayerChoice == "1")
            {
                Console.WriteLine("Who are you playing with");
                _player2Name = Console.ReadLine();
                Console.Write("Hello ");
                PrintInColours($"{_player2Name}", ConsoleColor.DarkGreen);
                Console.WriteLine();
            }
            else
            {
                Console.Write("Playing against a ");
                PrintInColours("computer", ConsoleColor.DarkRed);
                Console.WriteLine();
                _player2Name = "Computer";
            }
       }


        
        //PROGRAM STUFF
        // menu method allow the user to choose what they want to do in the program
        static void Menu()
        {
            Console.WriteLine("What would you like to do?");
            Console.WriteLine($"type \"1\" to play sevens out");
            Console.WriteLine($"type \"2\" to play three or more");
            Console.WriteLine($"type \"3\" to view statistics");
            Console.WriteLine($"type \"4\" to start testing");
            string userChoice = Console.ReadLine();

            switch (userChoice)
            {
                case "1":
                    stats.IncrementAStat(7);
                    SevensOut sevensOut = new SevensOut();
                    break;
                case "2":
                    stats.IncrementAStat(3);
                    ThreeOrMore threeOrMore = new ThreeOrMore();
                    break;
                case "3":
                    stats.displayStats();
                    break;
                case "4":
                    
                    Test test = new Test();
                    break;
                default:
                    Console.WriteLine("invalid choice");
                    Menu();
                    break;
            }



        }
        static bool Continue()
        {
            bool playing = true;
            bool validAnswer = false;
            while (!validAnswer)
            {
                Console.WriteLine("continue? type \"1\" for yes type \"2\" for no");
                string response = Console.ReadLine();

                switch (response)
                {
                    case "1":
                        Console.WriteLine("Have fun!");
                        validAnswer = true;
                        break;
                    case "2":
                        Console.WriteLine("Goodbye!");
                        validAnswer = true;
                        playing = false;
                        break;
                    default:
                        Console.WriteLine("invalid choice");
                        break;
                }
            }
            return playing;
        }
    
        static void Main(string[] args)
        {
            bool playing = true;
            while (playing)
            {
                Menu();
                playing = Continue();
               
            }
            
            Console.ReadKey();
        }
    }
}
