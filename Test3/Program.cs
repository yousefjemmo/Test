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
            

            bool MaxPointsIsValid = false;
            int maxpoints = 0;
            while (!MaxPointsIsValid)
            {
                try
                {
                    maxpoints = AskForMaxPoints();  
                    CheckIfNumberOfPointsInRange(maxpoints);
                    MaxPointsIsValid = true;
                }
                catch (ArgumentOutOfRangeException)
                {
                    Console.WriteLine("Only between 2 and 10 points ");
                }
                catch (System.FormatException)
                {
                    Console.WriteLine("You are only allowed to enter numbers");
                }
            }

            string UserChoice = AskWithWhoToPlay();


            while (gameloop)
            {


                if (UserChoice == "A")
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
                }
                else if (UserChoice == "B")
                {
                    var PlayerOne = AskForInputAndCheckIt();
                    

                    Random randomChoice = new Random();
                    int Computer = randomChoice.Next(1, 4);

                    var results = CompareTheAnswersBetweenPlayers(PlayerOne, Computer);

                    Console.WriteLine(results);

                    if (results == Player_Two_Won)
                    {

                        Console.WriteLine($"Player Two Choice: {Computer} \n ");
                        PlayerTwoPoints++;
                    }
                    else if (results == Player_One_Won)
                    {
                        Console.WriteLine($"Player Two Choice: {Computer} \n");
                        PlayerOnePoints++;
                    }
                }

                if (PlayerOnePoints == maxpoints / 2 || PlayerTwoPoints == maxpoints / 2)
                {
                    Console.WriteLine($"Player One has now {PlayerOnePoints}");                    
                    Console.WriteLine($"Player Two has now {PlayerTwoPoints}");                 
                }

                if (PlayerOnePoints == maxpoints || PlayerTwoPoints == maxpoints)
                {
                    gameloop = false;
                    Console.WriteLine($"Player Two has {PlayerTwoPoints} points - Player One has {PlayerOnePoints} points");
                }
            }              

        }

        private static int AskForMaxPoints()
        {
            Console.WriteLine("Please insert the Max points: ");
            int PointsInput = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("");
            return PointsInput;
        } 
        
        public static void CheckIfNumberOfPointsInRange(int input)
        {
            if (input < 2 || input > 10)
            {
                throw new ArgumentOutOfRangeException();
            }
        }

        public static string AskWithWhoToPlay()
        {
            bool IputCheck = false;
            string Input = "";
            Console.WriteLine("With who you want to play?");
            Console.WriteLine("A. Normal Player");
            Console.WriteLine("B. Computer \n");

            while (!IputCheck)
            {
                Input = Console.ReadLine().ToUpper();
                if (Input == "A" || Input == "B")
                {
                    IputCheck = true;
                }
                else
                {
                    Console.WriteLine("Either A or B. Try Again: ");
                }
            }
            return Input;
        }


        private static int AskForInputAndCheckIt()
        {
            Console.WriteLine("\nPlease enter a Number below for your choice and press enter:");

            Console.WriteLine("1.Rock");
            Console.WriteLine("2.Paper");
            Console.WriteLine("3.Scissors \n");

            
            bool IputCheckIsValidForPlayerOne = false;
            int input = 0;
            while (!IputCheckIsValidForPlayerOne)
            {                   
                input = Convert.ToInt32(Console.ReadLine());

                if (input == 1 || input == 2 || input == 3)
                {                    
                    Console.WriteLine($"Player: {input} \n");                    
                    IputCheckIsValidForPlayerOne = true;
                }
                else
                {
                    Console.WriteLine("Either 1 , 2 or 3. Try Again: ");                    
                }                
            }            
            return input;
        }    

        private static string Player_One_Won = "Player One Won!!";
        private static string Player_Two_Won = "Player Two Won!!";             
        private static string Tie = "It's a draw.";

        public static string CompareTheAnswersBetweenPlayers(int PlayerOne, int PlayerTwo)
        {

            switch (PlayerOne)
            {               

                case 1:
                    switch (PlayerTwo)
                    {
                        case 1:
                            return Tie;

                        case 2:
                            return Player_Two_Won;

                        case 3:
                            return Player_One_Won;

                            break;
                    }
                    break;

                case 2:
                    switch (PlayerTwo)
                    {
                        case 1:
                            return Player_One_Won;

                        case 2:
                            return Tie;

                        case 3:
                            return Player_Two_Won;

                            break;
                    }

                    break;

                case 3:
                    switch (PlayerTwo)
                    {
                        case 1:
                            return Player_Two_Won;

                        case 2:
                            return Player_One_Won;

                        case 3:
                            return Tie;

                            break;
                    }
                    break;
            }
            return Tie;
            
        }      

    }
}   