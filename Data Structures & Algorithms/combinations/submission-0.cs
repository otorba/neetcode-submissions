public class Solution {
    public List<List<int>> Combine(int n, int k) {
        var nums = Enumerable.Range(1, n).ToArray();
        var combinations = new List<List<int>>();
        var cur = new List<int>();

        Helper(0, k, nums, cur, combinations);

        return combinations;
    }

    private void Helper(int i, int k, int[] nums, List<int> cur, List<List<int>> combinations) {
        // base case
        if (i >= nums.Length) {
            if (cur.Count == k)
                combinations.Add(new List<int>(cur));
            return;
        }

        cur.Add(nums[i]);
        Helper(i + 1, k, nums, cur, combinations);
        cur.RemoveAt(cur.Count - 1);

        Helper(i + 1, k, nums, cur, combinations);
    }
}