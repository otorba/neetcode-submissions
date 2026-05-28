public class Solution {
    public bool IsAnagram(string s, string t) {
        var first = new Dictionary<char, int>();
        foreach (var c in s) {
            if (first.ContainsKey(c))
                first[c] += 1;
            else
                first[c] = 1;
        }

        var second = new Dictionary<char, int>();
        foreach (var c in t) {
            if (second.ContainsKey(c))
                second[c] += 1;
            else
                second[c] = 1;
        }
        if (first.Count != second.Count)
            return false;

        foreach (var kvp in first) {
            var key = kvp.Key;
            var value = kvp.Value;
            if (second.ContainsKey(key) && second[key] == value)
                continue;
            else
                return false;
        }

        return true;
    }
}
