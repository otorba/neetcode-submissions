public class Solution {
    public int MinimumRecolors(string blocks, int k) {
        var l = 0;
        var r = 0;
        var min = int.MaxValue;
        var occupiedNumber = 0;
        while (r < blocks.Length) {
            while (r - l + 1 > k) {
                if (blocks[l] == 'W')
                    occupiedNumber--;
                l++;
            }
            if (blocks[r] == 'W')
                occupiedNumber++;

            if (r - l + 1 == k)
                min = Math.Min(min, occupiedNumber);

            r++;
        }

        return min;
    }
}