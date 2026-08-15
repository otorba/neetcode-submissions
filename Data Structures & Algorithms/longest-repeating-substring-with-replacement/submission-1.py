from collections import defaultdict
class Solution:
    def characterReplacement(self, s: str, k: int) -> int:
        l = r = 0
        longest = 0
        f = defaultdict(int)
        # window is valid when window size r-l+1 - the most freq element <= k
        while r < len(s):
            f[s[r]] += 1

            while len(f) > 0 and (r - l + 1) - max(f.values()) > k:
                f[s[l]] -= 1
                l += 1

            # valid window is here
            longest = max(longest, r - l + 1)

            r += 1  # for the next iter

        return longest
