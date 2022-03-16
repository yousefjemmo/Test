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
                var PlayerOne = AskForInput();

                var PlayerTwo = AskForInput();


               var results = Game(PlayerOne, PlayerTwo);



                if (results == Player_Two_Won)
                {
                    Console.WriteLine(Player_Two_Won);
                    PlayerTwoPoints++;
                }
                else if (results == Player_One_Won)
                {
                    Console.WriteLine(Player_One_Won);
                    PlayerOnePoints++;
                }
                else
                {
                    Console.WriteLine(Tie);
                }                 

                if (PlayerOnePoints == 5 || PlayerTwoPoints == 5)
                {
                    gameloop = false;
                    Console.WriteLine($"Player Two has {PlayerTwoPoints} points - Player One has {PlayerOnePoints} points");
                }

            }          

        }

        private static string AskForInput()
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

        public static string Game(string PlayerOne, string PlayerTwo)
        {           
                      
            switch (PlayerOne)
            {               

                case "A":
                    if (PlayerTwo == "A")
                    {                        
                        return Tie;
                    }
                    else if (PlayerTwo == "B")
                    {
                        return Player_Two_Won;                        
                    }
                    else if (PlayerTwo == "C")
                    {
                        return Player_One_Won;
                    }
                    break;

                case "B":
                    if (PlayerTwo == "A")
                    { 
                        return Player_One_Won;
                    }
                    else if (PlayerTwo == "B")
                    {
                        return Tie;
                    }
                    else if (PlayerTwo == "C")
                    {
                        return Player_Two_Won;
                    }
                    break;

                case "C":
                    if (PlayerTwo == "A")
                    { 
                        return Player_Two_Won;
                    }
                    else if (PlayerTwo == "B")
                    {         
                        return Player_One_Won;
                    }
                    else if (PlayerTwo == "C")
                    {                       
                        return Tie;
                    }
                    break;              

            }
            return Tie;
            
        }   

    }
}   