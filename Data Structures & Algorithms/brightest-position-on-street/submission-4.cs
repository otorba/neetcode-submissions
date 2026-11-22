public class Solution {
    public int BrightestPosition(int[][] lights) {
        Array.Sort(lights, (x, y) => (x[0] - x[1]).CompareTo(y[0] - y[1]));

        var (p, maxBrighness) = (0, int.MinValue);
        var heap = new PriorityQueue<int, int>();

        foreach (var light in lights) {
            var pos = light[0];
            var range = light[1];
            var (left, right) = (pos - range, pos + range);

            while (heap.Count > 0 && heap.Peek() < left) heap.Dequeue();

            heap.Enqueue(right, right);

            if (heap.Count > maxBrighness) {
                p = left;
                maxBrighness = heap.Count;
            }
        }

        return p;
    }
}
