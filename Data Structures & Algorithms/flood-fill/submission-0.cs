public class Solution {
    public int[][] FloodFill(int[][] image, int sr, int sc, int color) {
        var visited = new HashSet<(int, int)>();
        var origPixel = image[sr][sc];
        return Helper(image, visited, sr, sc, origPixel, color);
    }

    private int[][] Helper(int[][] image, HashSet<(int, int)> visited, int r, int c, int origPixel,
                           int color) {
        var raws = image.Length;
        var colms = image[0].Length;

        if (r >= raws || c >= colms || Math.Min(r, c) < 0 || image[r][c] != origPixel ||
            visited.Contains((r, c)))
            return image;

        image[r][c] = color;
        visited.Add((r, c));

        Helper(image, visited, r + 1, c, origPixel, color);
        Helper(image, visited, r - 1, c, origPixel, color);
        Helper(image, visited, r, c + 1, origPixel, color);
        Helper(image, visited, r, c - 1, origPixel, color);

        return image;
    }
}