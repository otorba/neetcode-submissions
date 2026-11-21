public class Solution {
    public int EarliestAcq(int[][] logs, int n) {
        // sort logs by a timestamp first
        Array.Sort(logs, (x, b) => x[0].CompareTo(b[0]));

        var groups = new int[n];  // an index is a friend number
        var nextGroupId = 1;
        foreach (var log in logs) {
            var a = log[1];
            var b = log[2];
            if (groups[a] == 0 && groups[b] == 0) {
                groups[a] = nextGroupId;
                groups[b] = nextGroupId;
                nextGroupId++;
            } else if (groups[a] != 0 && groups[b] == 0) {
                groups[b] = groups[a];
            } else if (groups[a] != 0 && groups[b] != 0) {
                var groupB = groups[b];
                var groupA = groups[a];
                for (var f = 0; f < n; f++) {
                    if (groups[f] == groupB)
                        groups[f] = groupA;
                }
            } else if (groups[a] == 0 && groups[b] != 0) {
                groups[a] = groups[b];
            }

            var groupACount = 0;
            for (var f = 0; f < n; f++) {
                if (groups[f] == groups[a])
                    groupACount++;
            }
            if (groupACount == n)
                return log[0];
        }

        return -1;
    }
}
