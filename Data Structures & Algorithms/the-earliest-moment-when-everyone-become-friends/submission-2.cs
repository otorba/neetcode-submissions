public class Solution {
    public int EarliestAcq(int[][] logs, int n) {
        // sort logs by a timestamp first
        Array.Sort(logs, (x, b) => x[0].CompareTo(b[0]));

        // Person: 0 1 2 3 4 5
        // Parent: 0 0 1 2 4 5

        var parents = new int[n];
        for (var i = 0; i < n; i++) parents[i] = i;

        var mergesCount = 0;
        foreach (var log in logs) {
            var a = log[1];
            var b = log[2];

            var pA = Find(a, parents);
            var pB = Find(b, parents);
            if (pA != pB) {
                parents[pB] = pA;
                mergesCount++;
            }

            if (mergesCount == n - 1)
                return log[0];
        }

        return -1;
    }

    private int Find(int person, int[] parents) {
        if (person == parents[person])
            return person;

        var parent = Find(parents[person], parents);
        parents[person] = parent;
        return parent;
    }
}
