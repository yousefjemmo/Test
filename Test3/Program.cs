using System;

namespace Rockpaperscissors
{
    class Program
    {
        static void Main(string[] args)
        {
            bool gameloop = true;
            int PlayerOnePoints = 0;
            int PlayerTwoPoints = 0;

            while (gameloop)
            {
                var PlayerOne = AskForInputAndCheckIt();
                var PlayerTwo = AskForInputAndCheckIt();


                var results = CompareTheAnswersBetweenPlayers(PlayerOne, PlayerTwo);

                Console.WriteLine(results);

                if (results == Player_Two_Won)
                {                    
                    PlayerTwoPoints++;
                }
                else if (results == Player_One_Won)
                {                    
                    PlayerOnePoints++;
                }
               
                if (PlayerOnePoints == 5 || PlayerTwoPoints == 5)
                {
                    gameloop = false;
                    Console.WriteLine($"Player Two has {PlayerTwoPoints} points - Player One has {PlayerOnePoints} points");
                }

            }          

        }

        private static string AskForInputAndCheckIt()
        {
            Console.WriteLine("\nPlease enter a Letter below for your choice and press enter:");

            Console.WriteLine("A.Rock");
            Console.WriteLine("B.Paper");
            Console.WriteLine("C.Scissors \n");

            
            bool IputCheckIsValidForPlayerOne = false;
            string input = "";
            while (!IputCheckIsValidForPlayerOne)
            {                   
                input = Console.ReadLine().ToUpper();

                if (input == "A" || input == "B" || input == "C")
                {                    
                    Console.WriteLine($"Player: {input} \n");                    
                    IputCheckIsValidForPlayerOne = true;
                }
                else
                {
                    Console.WriteLine("Either A , B or C. Try Again: ");                    
                }                
            }            
            return input;

        }

        private static string Player_One_Won = "Player One Won!!";
        private static string Player_Two_Won = "Player Two Won!!";
        private static string Tie = "It's a draw.";

        public static string CompareTheAnswersBetweenPlayers(string PlayerOne, string PlayerTwo)
        {           
                      
            switch (PlayerOne)
            {               

                case "A":
                    switch (PlayerTwo)
                    {
                        case "A":
                            return Tie;

                        case "B":
                            return Player_Two_Won;

                        case "C":
                            return Player_One_Won;

                            break;
                    }                 
                    break;

                case "B":
                    switch (PlayerTwo)
                    {
                        case "A":
                            return Player_One_Won;

                        case "B":
                            return Tie;

                        case "C":
                            return Player_Two_Won;

                            break;
                    }
                    break;

                case "C":
                    switch (PlayerTwo)
                    {
                        case "A":
                            return Player_Two_Won;

                        case "B":
                            return Player_One_Won;

                        case "C":
                            return Tie;

                            break;
                    }
                    break;

            }
            return Tie;
            
        }   

    }
}   