public class Solution {
    public List<List<string>> GroupAnagrams(string[] strs) {
        // dict -> array char [26] : List<string>
        var groups = new Dictionary<string, List<string>>();
        foreach (var str in strs) {
            var key = Key(str);
            if (groups.ContainsKey(key)) {
                groups[key].Add(str);
            } else {
                groups[key] = new() { str };
            }
        }

        var output = new List<List<string>>();
        foreach (var kvp in groups) {
            var values = kvp.Value;
            output.Add(values);
        }

        return output;
    }

    private static string Key(string s) {
        char[] chars = s.ToCharArray();
        Array.Sort(chars);
        return new string(chars);
    }
}
