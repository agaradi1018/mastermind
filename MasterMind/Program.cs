using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterMind
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] answer;
            string guess = "";
            bool result;

            MasterMindProj master = new MasterMindProj();
            string secret = master.generateSecretNumber();

            Console.WriteLine("Let's play Mastermind! - You have to guess a 4 digit secret number where each digit is beween 1 & 6.");
            Console.WriteLine("'+' -> correct digit, correct position\n'-' -> correct digit, wrong position\n' '(blank) -> wrong number. You have 10 attempts, GOOD LUCK!");

            for (int i = 1; i <= 10; i++)
            {
                result = true;
                Console.WriteLine("\nAttempt # " + i + ", Enter you guess - ");
                guess = Console.ReadLine();
                while (!master.validateInput(guess))
                {
                    Console.WriteLine("Please enter a 4 digit number. Each digit shoud be an integer between 1 and 6. ");
                    guess = Console.ReadLine();
                }

                answer = master.compare(secret, guess);

                foreach(char c in answer)
                {
                    if (c != '+')
                    {
                        result = false;
                        break;
                    }
                }

                if (result)
                {
                    Console.WriteLine("You got the correct answer!! Congratulations, the secret number was " + secret + "!");
                    Console.ReadLine();
                    return;
                }
                else
                {
                    Console.Write("Result : ");
                    foreach (char c in answer)
                        Console.Write(c + "|");
                }
            }
            Console.WriteLine("You've run out of turns, the secret number was " + secret + ". Better luck next time..");
            Console.ReadLine();
        }
    }
}
