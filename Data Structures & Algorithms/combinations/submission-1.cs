public class Solution {
    public List<List<int>> Combine(int n, int k) {
        var combinations = new List<List<int>>();
        var cur = new List<int>();

        Helper(0, n, k, cur, combinations);

        return combinations;
    }

    private void Helper(int i, int n, int k, List<int> cur, List<List<int>> combinations) {
        // base case
        if (i >= n) {
            if (cur.Count == k)
                combinations.Add(new List<int>(cur));
            return;
        }

        cur.Add(i + 1);
        Helper(i + 1, n, k, cur, combinations);
        cur.RemoveAt(cur.Count - 1);

        Helper(i + 1, n, k, cur, combinations);
    }
}