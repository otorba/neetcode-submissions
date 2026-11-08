public class Solution {
    public void islandsAndTreasure(int[][] grid) {
        var rows = grid.Length;
        var columns = grid[0].Length;
        var inf = 2147483647;
        var queue = new Queue<(int, int)>();

        // add chest cells
        for (var r = 0; r < rows; r++) {
            for (var c = 0; c < columns; c++) {
                if (grid[r][c] == 0)
                    queue.Enqueue((r, c));
            }
        }

        var directions = new List<(int, int)>(4) {
            (1, 0),   // up
            (-1, 0),  // down
            (0, -1),  // left
            (0, 1)    // right
        };

        var distance = 1;
        while (queue.Count > 0) {
            var queueCount = queue.Count;
            for (var i = 0; i < queueCount; i++) {
                var (r, c) = queue.Dequeue();

                foreach (var direction in directions) {
                    var (dr, dc) = direction;
                    var (nr, nc) = (r + dr, c + dc);
                    if (nr >= rows || nc >= columns || nr < 0 || nc < 0)
                        continue;

                    if (grid[nr][nc] == inf) {
                        grid[nr][nc] = distance;
                        queue.Enqueue((nr, nc));
                    }
                }
            }
            distance++;
        }
    }
}
