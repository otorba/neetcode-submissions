public class Solution {
    public List<int> FindClosestElements(int[] arr, int k, int x) {
        var l = 0;
        var r = 0;

        var min = int.MaxValue;
        var currentSum = 0;
        var lO = 0;
        var rO = 0;

        while (r < arr.Length) {
            currentSum += Math.Abs(arr[r] - x); // 1 2 3
            while (r - l + 1 > k) {
                currentSum -= Math.Abs(arr[l] - x);
                l++;
            }

            if (r - l + 1 == k) {
                if (currentSum < min) {
                    min = currentSum;
                    lO = l;
                    rO = r;
                }
            }

            r++;
        }

        var output = new List<int>(arr.Length);

        for (var i = lO; i <= rO; i++) {
            output.Add(arr[i]);
        }

        return output;
    }
}