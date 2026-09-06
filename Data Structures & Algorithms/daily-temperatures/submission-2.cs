public class Solution {
    public int[] DailyTemperatures(int[] temperatures) {
        var output = new int[temperatures.Length];
        var stack = new Stack<int>();

        for (var i = 0; i < temperatures.Length; i++) {
            while (stack.Count > 0 && temperatures[i] > temperatures[stack.Peek()]) {
                var day = stack.Pop();
                output[day] = i - day;
            }

            stack.Push(i);
        }

        return output;
    }
}
