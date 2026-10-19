public class Solution {
    public bool CheckInclusion(string s1, string s2) {
        if (s2.Contains(s1))
            return true;

        var f = BuildView(s1);
        var s = new int[26];

        var l = 0;
        var r = 0;

        while (r != s2.Length) {
            s[s2[r] - 'a'] += 1;

            while (r - l + 1 > s1.Length) {
                s[s2[l] - 'a'] -= 1;
                l++;
            }

            if (r - l + 1 == s1.Length) {
                if (Equal(f, s))
                    return true;
            }

            r++;
        }

        return false;
    }

    private int[] BuildView(string s) {
        var view = new int[26];
        foreach (var c in s) {
            view[c - 'a'] += 1;
        }
        return view;
    }

    private bool Equal(int[] f, int[] s) {
        for (var i = 0; i < f.Length; i++) {
            if (f[i] != s[i])
                return false;
        }
        return true;
    }
}
