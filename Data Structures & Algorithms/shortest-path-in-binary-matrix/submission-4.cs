public class Solution {
    public int ShortestPathBinaryMatrix(int[][] grid) {
        var n = grid.Length;
        if (grid[0][0] == 1 || grid[n - 1][n - 1] == 1)
            return -1;

        var queue = new Queue<(int, int)>();
        queue.Enqueue((0, 0));
        var seen = new HashSet<(int, int)>();
        var length = 0;
        var directions = new(int, int)[] {
            (0, -1),   // left
            (-1, 0),   // up
            (0, 1),    // right
            (1, 0),    // down
            (-1, -1),  // top-left
            (-1, 1),   // top-right
            (1, -1),   // bottom-left
            (1, 1),    // bottom-right
        };

        while (queue.Count > 0) {
            var queueLength = queue.Count;
            for (var i = 0; i < queueLength; i++) {
                var (r, c) = queue.Dequeue();

                if ((r, c) == (n - 1, n - 1)) {
                    return ++length;
                }

                foreach (var drc in directions) {
                    var (dr, dc) = drc;
                    var nr = r + dr;
                    var nc = c + dc;

                    if (nc >= n || nr >= n || nc < 0 || nr < 0 || grid[nr][nc] == 1 ||
                        seen.Contains((nr, nc)))
                        continue;

                    queue.Enqueue((nr, nc));
                    seen.Add((nr, nc));
                }
            }
            if (queue.Count > 0)
                length++;
        }

        return -1;
    }
}