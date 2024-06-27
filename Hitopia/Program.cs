using Hitopia.ModulFungsi;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Hitopia
{
    class Program
    {
        static void Main(string[] args)
        {
            bool IsExit = false;
            while (!IsExit)
            {
                Console.WriteLine("-----Menu-------");
                Console.WriteLine("1. String Weight");
                Console.WriteLine("2. Balanced Bracket");
                Console.WriteLine("3. Largest Palindrome");
                Console.WriteLine("4. Exit");
                Console.Write("Select: ");
                int menu = Convert.ToInt32(Console.ReadLine());
                switch (menu)
                {
                    case 1:
                        SoalSatu();
                        break;
                    case 2:
                        SoalDua();
                        break;
                    case 3:
                        SoalTiga();
                        break;
                    default:
                        IsExit = true;
                        break;
                } //end switch
            } //end while

            Console.WriteLine("Press any key to exit application..");
            Console.ReadKey();
        }

        private static void SoalTiga()
        {
            Console.Write("Input String: ");
            string input = Console.ReadLine();
            Console.Write("Input K: ");
            int k = Convert.ToInt32(Console.ReadLine());
            LargestPalindrome largestPalindrome = new LargestPalindrome(input, k);
            largestPalindrome.GenerateResult();
            Console.WriteLine("Result: " + largestPalindrome.PalindromResult);
        }
        private static void SoalDua()
        {
            Console.Write("Input: ");
            string input = Console.ReadLine();
            BalancedBracket balancedBracket = new BalancedBracket(input);
            if (!string.IsNullOrWhiteSpace(input))
            {
                Console.WriteLine("Result: " + (balancedBracket.IsBalanced ? "Yes" : "No"));
            }
            else
            {
                Console.WriteLine("Invalid input, input can't be blank");
            }
        }

        private static void SoalSatu()
        {
            Console.Write("Input: ");
            string input = Console.ReadLine();
            Console.Write("Input Array Query in numeric (separated by comma): ");
            string arrqry = Console.ReadLine();

            StringWeight objsw = new StringWeight(input, arrqry);
            objsw.GenerateResult();

            if (objsw.IsValid)
            {
                Console.WriteLine(string.Join(",", objsw.ArrQueryResult));
            }
            else
            {
                Console.WriteLine(string.Join(",", objsw.ListInvalid));
            }
        }
    }
}
