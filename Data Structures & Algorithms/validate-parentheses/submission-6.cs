public class Solution {
    public bool IsValid(string s) {
        var stack = new Stack<char>();
        foreach (var c in s) {
            if (stack.TryPeek(out var peek)) {
                if ((c == '}' && peek == '{') || (c == ']' && peek == '[') ||
                    (c == ')' && peek == '('))
                    stack.Pop();
                else
                    stack.Push(c);
            } else
                stack.Push(c);
        }

        return stack.Count == 0;
    }
}
