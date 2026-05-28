public class Solution {
    public bool IsAnagram(string s, string t) {
        var counts = new int[26];
        foreach (var c in s) {
            counts[c - 'a'] += 1;
        }

        foreach (var c in t) {
            counts[c - 'a'] -= 1;
        }

        return counts.All(x => x == 0);
    }
}
