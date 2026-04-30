public class Solution {
    public bool IsAnagram(string s, string t) {
        var dict = new Dictionary<char, int>();
        foreach (var c in s)
            if (!dict.TryAdd(c, 1))
                dict[c] += 1;

        foreach (var c in t) {
            if (!dict.TryGetValue(c, out var value))
                return false;

            if (value == 0)
                return false;

            dict[c]--;

            if (dict[c] == 0)
                dict.Remove(c);
        }

        if (dict.Count == 0)
            return true;

        return false;
    }
}
