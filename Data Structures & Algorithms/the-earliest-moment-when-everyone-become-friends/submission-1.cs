public class Solution {
    public int EarliestAcq(int[][] logs, int n) {
        // sort logs by a timestamp first
        Array.Sort(logs, (x, b) => x[0].CompareTo(b[0]));

        var groups = new int[n];  // an index is a friend number
        var nextGroupId = 1;
        var mergesCount = 0;
        foreach (var log in logs) {
            var a = log[1];
            var b = log[2];
            if (groups[a] == 0 && groups[b] == 0) {
                nextGroupId++;
                groups[a] = nextGroupId;
                groups[b] = nextGroupId;
                mergesCount++;
            } else if (groups[a] != 0 && groups[b] == 0) {
                groups[b] = groups[a];
                mergesCount++;
            } else if (groups[a] != 0 && groups[b] != 0 && groups[a] != groups[b]) {
                var groupB = groups[b];
                var groupA = groups[a];
                for (var f = 0; f < n; f++) {
                    if (groups[f] == groupB)
                        groups[f] = groupA;
                }
                mergesCount++;
            } else if (groups[a] == 0 && groups[b] != 0) {
                groups[a] = groups[b];
                mergesCount++;
            }

            if (mergesCount == n - 1)
                return log[0];
        }

        return -1;
    }
}
