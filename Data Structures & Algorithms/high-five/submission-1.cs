public class Solution {
    public int[][] HighFive(int[][] items) {
        var dict = new Dictionary<int, List<int>>();
        foreach (var item in items) {
            var id = item[0];
            var score = item[1];
            if (dict.TryGetValue(id, out var scores)) {
                scores.Add(score);
            } else {
                dict[id] = new List<int>() { score };
            }
        }

        var result = new int [dict.Keys.Count][];
        var i = 0;
        foreach (var id in dict.Keys.OrderBy(id => id)) {
            var scores = dict[id];

            var sum = 0;
            foreach (var s in scores.OrderByDescending(s => s).Take(5)) sum += s;
            var avg = sum / 5;

            result[i] = new int[] { id, avg };
            i++;
        }

        return result;
    }
}
