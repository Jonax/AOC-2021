namespace Advent_of_Code_2021
{
    public class Day10
    {
        private static readonly Dictionary<string, int> _corruptionScoring = new()
        {
            { ")", 3 },
            { "]", 57 },
            { "}", 1197 },
            { ">", 25137 },
        };

        private static readonly Dictionary<char, ulong> _incompleteScoring = new()
        {
            { '(', 1 },
            { '[', 2 },
            { '{', 3 },
            { '<', 4 },
        };

        public static (int corruption, ulong incomplete) Execute(string line)
        {
            Stack<char> stack = new ();

            int corruption = 0;
            ulong incomplete = 0;

            try
            {
                foreach (char c in line)
                {
                    switch (c)
                    {
                        case '(':
                        case '[':
                        case '{':
                        case '<':
                            stack.Push(c);
                            break;

                        case ')':
                            if (stack.Peek() != '(')
                            {
                                throw new Exception(")");
                            }

                            stack.Pop();
                            break;

                        case ']':
                            if (stack.Peek() != '[')
                            {
                                throw new Exception("]");
                            }

                            stack.Pop();
                            break;

                        case '}':
                            if (stack.Peek() != '{')
                            {
                                throw new Exception("}");
                            }

                            stack.Pop();
                            break;

                        case '>':
                            if (stack.Peek() != '<')
                            {
                                throw new Exception(">");
                            }

                            stack.Pop();
                            break;
                    }
                }

                while (stack.TryPop(out char result))
                {
                    incomplete = (incomplete * 5) + _incompleteScoring[result];
                }
            }
            catch (Exception e)
            {
                corruption += _corruptionScoring[e.Message];
            }

            return (corruption, incomplete);
        }
    }
}