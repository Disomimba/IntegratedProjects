namespace Project_1
{
    internal class Program
    {
        
        static void Main(string[] args)
        {
            Console.Write("WELCOME\n\nEnter your Username : ");
            string ign = Console.ReadLine();
            player(ign);
        }

        static void player(String ign)
        {
            Console.WriteLine("\n\nWelcome to Mekus Mekus Game " + ign);

            Console.WriteLine("\n[1]Start\n[2]Rules & Mechanics");

            Console.Write("\nI will select no. ");
            int playerChoice = Convert.ToInt16(Console.ReadLine());

            if (playerChoice == 1)
            {

                Game(ign);

            }
            else if (playerChoice == 2)
            {
                Console.Write("\nRules & Mechanics\n1 - In this game, you'll be given shuffled words to arrange." +
                    "\n2 - Answer must be Capitalize." +
                    "\n3 - Answer shouldn't contains spaces." +
                    "\n4 - You only have 3 lives.\n");

                Console.WriteLine("\nPress any key to go back");
                Console.ReadKey();
                player(ign);
            }
            else
            {
                Console.WriteLine("\n\nInvalid Choice, Please Select again.\n\n");
                player(ign);
            }
        }
        static void Game(String ign)
        {
            int lives = 3;
            int score = 0;

            Console.WriteLine("\n" + ign + " your lives " + lives);

            string[] wordsEasy = { "Y E E S", "N S P I", "S A C H", "C E H S S", "W E R I S", "H A L K C" };
            string[] answersOfEasy = { "EYES", "SPIN", "CASH", "CHESS", "WIRES", "CHALK" };
            int i = 0;

            while (i < wordsEasy.Length && lives > 0)
            {
                Console.WriteLine("Arrange the letters\n" + wordsEasy[i]);
                string ans = Console.ReadLine();
                if (ans == answersOfEasy[i])
                {
                    Console.WriteLine("\nCORRECT!\n");
                    score++;
                }
                else
                {
                    lives--;
                    Console.WriteLine("\nINCORRECT!");
                    Console.WriteLine("\nYour current lives is " + lives + "\n");

                    if (lives == 0)
                    {
                        Console.WriteLine("GAME OVER");
                    }
                }
                i++;
            }
            Console.WriteLine("Your Score is : " + score);
            Console.WriteLine("\n\nDo you want to try again?\n\n[1] Yes\n[Any no.]No");
            Console.Write("\nI will select no. ");
            int playAgain = Convert.ToInt16(Console.ReadLine());
            
            if (playAgain == 1)
            {
                Game(ign);
            }
            else
            {
                Console.Write("Thank You for playing");
                
            }

        }
    }
}