public class Solution {
    public List<List<string>> GroupStrings(string[] strings) {
        var dict = new Dictionary<string, List<string>>();
        var sb = new StringBuilder();

        foreach (var s in strings) {
            var key = Key(s, sb);
            if (dict.TryGetValue(key, out var group)) {
                group.Add(s);
            } else {
                dict[key] = new List<string>() { s };
            }
        }

        return dict.Values.ToList();
    }

    private string Key(string s, StringBuilder sb) {
        sb.Clear();

        for (var i = 0; i < s.Length - 1; i++) {
            sb.Append($"{(s[i + 1] - s[i] + 26) % 26},");
        }

        return sb.ToString();
    }
}
