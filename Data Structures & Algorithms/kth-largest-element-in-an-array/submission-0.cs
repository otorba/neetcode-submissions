public class Solution {
    public int FindKthLargest(int[] nums, int k) {
        var heap = new PriorityQueue<int, int>(Comparer<int>.Create((a, b) => b.CompareTo(a)));
        foreach (var n in nums) {
            heap.Enqueue(n, n);
        }

        var output = 0;

        for (var i = 0; i < k; i++) {
            output = heap.Dequeue();
        }

        return output;
    }
}
