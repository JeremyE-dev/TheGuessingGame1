using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessingGame
{
    class Program
    {
        static void Main(string[] args)
        {
            int theAnswer = 0;
            int playerGuess;
            string playerInput;
            string name;
            int attempts = 0;
            int upperRange = 0;
            string mode;
            int number;

            Random r = new Random();
            

           
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("What is your name? ");
            name = Console.ReadLine();
           
            
            
            while(true)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("Please select 1 for Easy mode (1-5) , 2 for Normal mode (1-20) or 3 for Hard mode (1-50)");
                mode = Console.ReadLine();

                if (int.TryParse(mode, out number))
                {
                    if (number < 1 && number > 3)
                    {
                        Console.WriteLine("That was not a valid entry, please try again");
                        continue;
                    }

                    else
                    {
                        break;
                    }

                }

                else
                {
                    Console.WriteLine("That was not a valid entry, please try again");
                    continue;
                }
            }

            switch(number)
            {
                case 1: 
                    theAnswer = r.Next(1, 6);
                    upperRange = 5;
                    break;
                case 2:
                    theAnswer = r.Next(1, 21);
                    upperRange = 20;
                    break;
                case 3:
                    theAnswer = r.Next(1, 51);
                    upperRange = 50;
                    break;

            }
            
            do
            {
                // get player input
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("{0} Enter your guess (1-{1}): ", name, upperRange);
                playerInput = Console.ReadLine();

                //3. Q to quit
                if(playerInput.Equals("Q") || playerInput.Equals("q"))
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("Thank you for playing, Goodbye");
                    return;
                }

                //attempt to convert the string to a number
                if (int.TryParse(playerInput, out playerGuess))
                {
                    //2. error message if number out of range
                    if(playerGuess <= 0 || playerGuess >= upperRange + 1)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("That number was not between 1 and {0}, please try again", upperRange);
                        continue;
                    }
                    
                    
                    
                    if (playerGuess == theAnswer)
                    {
                        attempts++;

                        if (attempts == 1)
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine($"{theAnswer} was the number.  You Win {name}! You guessed it on the first attempt Congratulations!, Game Over");
                            break;
                        }

                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine($"{theAnswer} was the number.  You Win {name}! You guessed in {attempts} attempts,  Game Over");
                            break;
                        }
                    }
                    
                    else
                    {
                        if (playerGuess > theAnswer)
                        {
                            attempts++;
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine($"Your guess was too High {name}!");
                        }
                        else
                        {
                            attempts++;
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine($"Your guess was too low {name}!");
                        }
                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"That wasn't a number {name}!");
                }

            } while (true);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"Press any key to quit {name}.");
            Console.ReadKey();
        }
    }
}
