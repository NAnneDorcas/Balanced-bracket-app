namespace BalancedBracketService
{
    public interface IBracketChecker
    {
        bool Validate(string input);
    }

    public class BracketChecker : IBracketChecker
    {
        public bool Validate(string input)

        {
            if (string.IsNullOrEmpty(input))
                return false; // Empty or null strings are false now
            var brackets = new HashSet<char> { '(', ')', '[', ']', '{', '}' };

            // Return false if any character is not a bracket
            if (input.Any(c => !brackets.Contains(c)))
                return false;
            if (string.IsNullOrEmpty(input)) return true;

            var stack = new Stack<char>();
            var pairs = new Dictionary<char, char> {
                {')', '('},
                {'}', '{'},
                {']', '['}
            };

            foreach (var ch in input)
            {
                if (pairs.Values.Contains(ch))
                {
                    stack.Push(ch);
                }
                else if (pairs.Keys.Contains(ch))
                {
                    if (stack.Count == 0 || stack.Pop() != pairs[ch])
                        return false;
                }
            }

            return stack.Count == 0;
        }
        public bool[] ValidateMultiple(string[] inputs)
        {
            if (inputs == null || inputs.Length == 0)
                return new bool[0];
            return inputs.Select(Validate).ToArray();
        }
    }

}
