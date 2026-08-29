public class Solution {
    private class Point {
        public readonly int X;
        public readonly int Y;
        public Point(int x, int y) {
            X = x;
            Y = y;
        }
    }
    public int[][] KClosest(int[][] points, int k) {
        var heap = new PriorityQueue<Point, int>();
        foreach (var point in points) {
            var p = new Point(point[0], point[1]);
            var priority = p.X * p.X + p.Y * p.Y;
            heap.Enqueue(p, priority);
        }

        var output = new int [k][];
        for (var i = 0; i < k; i++) {
            var p = heap.Dequeue();
            output[i] = new int[] { p.X, p.Y };
        }

        return output;
    }
}
