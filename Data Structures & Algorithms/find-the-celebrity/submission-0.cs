/* The Knows API is defined in the parent class Relation.
      bool Knows(int a, int b); */

public class Solution : Relation {
    public int FindCelebrity(int n) {
        var candidate = 0;

        for (var i = 1; i < n; i++) {
            if (Knows(candidate, i))
                candidate = i;  // candidate knows about i, then it isn't a candidate
        }

        for (var i = 0; i < n; i++) {
            if (candidate == i)
                continue;

            if (Knows(candidate, i) || !Knows(i, candidate))
                return -1;
        }

        return candidate;
    }
}
