public class Solution {
    public int LastStoneWeight(int[] stones) {
        var heap = new PriorityQueue<int, int>(Comparer<int>.Create((a, b) => b.CompareTo(a)));
        foreach (var stone in stones) {
            heap.Enqueue(stone, stone);
        }

        while (heap.Count > 1) {
            var x = heap.Dequeue();
            var y = heap.Dequeue();

            if (x < y) {
                y = y - x;
                heap.Enqueue(y, y);
            } else if (x > y) {
                x = x - y;
                heap.Enqueue(x, x);
            }
        }

        if (heap.Count == 0)
            return 0;
        else
            return heap.Dequeue();
    }
}
