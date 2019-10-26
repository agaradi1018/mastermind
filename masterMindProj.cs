using System;
using System.Collections.Generic;
using System.Linq;

namespace MasterMind
{
    internal class MasterMindProj
    {
        public Dictionary<int, int> freq = new Dictionary<int, int>();
        int numPrint = 0;
        char[] answer = new char[4];
        string guess = "";
        bool correntAns = false;

        public MasterMindProj()
        {
            Console.WriteLine("Let's play Mastermind! - You have to guess a 4 digit secret number where each digit is beween 1 & 6.");
            Console.WriteLine("'+' -> correct digit, correct position\n'-' -> correct digit, wrong position\n'x' -> wrong number. You have 10 attempts, GOOD LUCK!");

            int[] secret = generateSecretNumber();

            for (int i = 1; i <=10; i++)
            {
                answer = new char[4];
				
                Console.WriteLine("\nAttempt # " + i + ", Enter you guess - ");
                guess = Console.ReadLine();

                validateInput(guess);

                compare(secret , guess);

                if (correntAns)
                {
                    Console.WriteLine("You got the correct answer!! Congratulations, the secret number was " + numPrint + "!");
                    Console.ReadLine();
                    return;
                }
                else
                {
                    Console.WriteLine("Result : ");

                    foreach (char c in answer)
                        Console.Write(c + "|");
                }
            }
            Console.WriteLine("You've run out of turns, the secret number was " + numPrint + ". Better luck next time..");
            Console.ReadLine();
        }

        private void validateInput(string guess)
        {
            try
            {
                if (!System.Text.RegularExpressions.Regex.IsMatch(guess, "^[1-6]{4}$"))
                {
                    Console.WriteLine("Please enter a 4 digit number. Each digit shoud be an integer between 1 and 6. ");
                    string correctedInput = Console.ReadLine();
                }
                else
                    return;
            }
            catch(Exception ex)
            {
                throw new System.ArgumentException("Error in validating input : " + ex.Message);
            }
        }

        private void compare(int[] secret, string guess)
        {
            int digit;
            int matchCounter = 0;

            try
            {
                for (int i = 0; i < secret.Length; i++)
                {
                    digit = Convert.ToInt32(Char.GetNumericValue(guess[i]));

                    if (freq.ContainsKey(digit))
                    {
                        if (digit == secret[i])
                        {
                            answer[i] = '+';
                            matchCounter++;
                        }
                    }
                }

                if (matchCounter == 4)
                {
                    correntAns = true;
                    return;
                }

                for (int i = 0; i < secret.Length; i++)
                {
                    if (answer[i] != '+')
                    {
                        digit = Convert.ToInt32(Char.GetNumericValue(guess[i]));

                        if (freq.ContainsKey(digit))
                        {
                            answer[i] = '-';
                        }
                        else
                        {
                            answer[i] = 'x';
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                throw new System.ArgumentException("Error in compare method : " + ex.Message);
            }
        }

        private int[] generateSecretNumber()
        {
            Random r = new Random();
            int num;
            int freqCounter;
            int[] secret = new int[4];

            try
            {
                for(int i=0;i<4;i++)
                {
                    num = r.Next(1, 7);
                    secret[i] = num;
                    numPrint = numPrint * 10 + num;

                    if (freq.ContainsKey(num))
                    {
                        freqCounter = freq[num];
                        freq[num] = freqCounter + 1;
                    }
                    else
                    {
                        freq.Add(num, 1);
                    }
                }
            }
            catch(Exception ex)
            {
                throw new System.ArgumentException("Error in generating secret number : " + ex.Message);
            }
            return secret;
        }
    }
}