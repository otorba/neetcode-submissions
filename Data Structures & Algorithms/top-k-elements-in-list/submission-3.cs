public class Solution {
    public int[] TopKFrequent(int[] nums, int k) {
        var numberByFrequance = new Dictionary<int, int>();
        foreach (var n in nums) {
            if (numberByFrequance.ContainsKey(n)) {
                numberByFrequance[n] += 1;
            } else {
                numberByFrequance[n] = 1;
            }
        }

        var pq = new PriorityQueue<int, int>();  // element : frequency
        foreach (var kvp in numberByFrequance) {
            pq.Enqueue(kvp.Key, kvp.Value);
            if (pq.Count > k)
                pq.Dequeue();
        }

        var output = new int[pq.Count];  // k
        var index = 0;
        while (pq.TryDequeue(out var element, out var _)) {
            output[index++] = element;
        }

        return output;
    }
}
