using System.Collections.Generic;

namespace Hitopia.ModulFungsi
{
    public class BalancedBracket
    {
        public string Input { get; set; }

        public BalancedBracket(string input)
        {
            Input = input;
        }

        public bool IsBalanced
        {
            get
            {
                return AreBracketsBalanced(Input);
            }
        }

        public bool AreBracketsBalanced(string input)
        {
            Stack<char> stack = new Stack<char>();

            foreach (char c in input)
            {
                if (c == '(' || c == '{' || c == '[')
                {
                    stack.Push(c);
                }
                else if (c == ')' || c == '}' || c == ']')
                {
                    if (stack.Count == 0)
                    {
                        return false;
                    }

                    char top = stack.Pop();
                    if (!IsMatchingPair(top, c))
                    {
                        return false;
                    }
                }
            }

            return stack.Count == 0;
        }

        private bool IsMatchingPair(char open, char close)
        {
            return (open == '(' && close == ')') ||
                   (open == '{' && close == '}') ||
                   (open == '[' && close == ']');
        }
    }
}
