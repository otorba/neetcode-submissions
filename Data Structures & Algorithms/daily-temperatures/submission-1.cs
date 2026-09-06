public class Solution {
    private class Day {
        public readonly int Tempeature;
        public readonly int Index;

        public Day(int temp, int index) {
            Tempeature = temp;
            Index = index;
        }
    }
    public int[] DailyTemperatures(int[] temperatures) {
        var output = new int[temperatures.Length];
        var days = new Stack<Day>();

        for (var i = 0; i < temperatures.Length; i++) {
            var currentTemp = temperatures[i];
            while (days.Count > 0 && currentTemp > days.Peek().Tempeature) {
                var day = days.Pop();
                output[day.Index] = i - day.Index;
            }

            days.Push(new Day(currentTemp, i));
        }

        return output;
    }
}
