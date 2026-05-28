public class Solution {
    public bool IsAnagram(string s, string t) {
        var seen = new Dictionary<char, int>();
        foreach (var c in s) {
            if (seen.ContainsKey(c))
                seen[c] += 1;
            else
                seen[c] = 1;
        }

        foreach (var c in t) {
            if (!seen.ContainsKey(c))
                return false;
            else if (seen[c] > 0) {
                seen[c] -= 1;
                if (seen[c] == 0)
                    seen.Remove(c);
            }
        }

        if (seen.Count > 0)
            return false;
        return true;
    }
}
