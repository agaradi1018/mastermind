using System;
using System.Collections.Generic;
using System.Text;

namespace MasterMind
{
    public class MasterMindProj
    {
        public List<string> freq;
        
        public MasterMindProj(){}
         
        public string generateSecretNumber()
        {
            freq = new List<string>();
            Random r = new Random();
            string num = "";
            StringBuilder secret = new StringBuilder();

            try
            {
                for (int i = 0; i < 4; i++)
                {
                    num = (r.Next(1, 7)).ToString();
                    secret.Append(num);
                    if (!freq.Contains(num))
                        freq.Add(num);
                }
            }
            catch (Exception ex)
            {
                throw new System.ArgumentException("Error in denerating sevret number : " + ex.Message);
            }

            return secret.ToString();
        }

        public bool validateInput(string guess)
        {
            try
            {
                if (!System.Text.RegularExpressions.Regex.IsMatch(guess, "^[1-6]{4}$"))
                {
                    return false;
                }
            }
            catch(Exception ex)
            {
                throw new System.ArgumentException("Error in validating input : " + ex.Message);
            }
            return true;
        }

        public char[] compare(string secret, string guess)
        {
            string num;
            int matchCounter = 0;
            char[] answer = new char[4];

            try
            {
                for (int i = 0; i < secret.Length; i++)
                {
                    num = guess[i].ToString();

                    if (freq.Contains(num))
                    {
                        if (num == secret[i].ToString())
                        {
                            answer[i] = '+';
                            matchCounter++;
                        }
                    }
                }

                if (matchCounter == 4)
                {
                    return answer;
                }

                for (int i = 0; i < secret.Length; i++)
                {
                    if (answer[i] != '+')
                    {
                        num = guess[i].ToString();

                        if (freq.Contains(num))
                        {
                            answer[i] = '-';
                        }
                        else
                        {
                            answer[i] = ' ';
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new System.ArgumentException("Error in compare method : " + ex.Message);
            }
            return answer;
        }
    }
}