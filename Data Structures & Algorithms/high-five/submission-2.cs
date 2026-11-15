public class Solution {
    public int[][] HighFive(int[][] items) {
        var dict = new Dictionary<int, PriorityQueue<int, int>>();
        var capacity = 5;
        foreach (var item in items) {
            var id = item[0];
            var score = item[1];
            if (dict.TryGetValue(id, out var scores)) {
                if (scores.Count < capacity)
                    scores.Enqueue(score, score);
                else
                    scores.EnqueueDequeue(score, score);
            } else {
                var q = new PriorityQueue<int, int>();
                q.Enqueue(score, score);
                dict[id] = q;
            }
        }

        var result = new int [dict.Keys.Count][];
        var i = 0;
        foreach (var id in dict.Keys.OrderBy(id => id)) {
            var scores = dict[id];

            var sum = 0;
            while (scores.Count > 0) sum += scores.Dequeue();
            var avg = sum / capacity;

            result[i] = new int[] { id, avg };
            i++;
        }

        return result;
    }
}
