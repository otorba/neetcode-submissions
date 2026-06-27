from collections import defaultdict


class Solution:
    def minWindow(self, s: str, t: str) -> str:
        l = 0
        min_win = float("inf")
        min_r = -1
        min_l = 0
        origin = defaultdict(int)

        for c in t:
            origin[c] += 1
        need = len(origin)
        have = 0

        window = defaultdict(int)
        for r in range(len(s)):
            window[s[r]] += 1
            if window[s[r]] == origin[s[r]]:
                have += 1
            # window_view = s[l, r] here

            while have == need:
                # here the window is valid
                cur_win_len = r - l + 1
                if cur_win_len < min_win:
                    min_win = cur_win_len
                    min_r = r
                    min_l = l

                window[s[l]] -= 1
                if window[s[l]] < origin[s[l]]:
                    have -= 1
                l += 1

        res_str = ""
        for i in range(min_l, min_r + 1):
            res_str += s[i]
        return res_str
