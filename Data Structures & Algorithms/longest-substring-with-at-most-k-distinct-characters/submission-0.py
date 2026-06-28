from collections import defaultdict


class Solution:
    def lengthOfLongestSubstringKDistinct(self, s: str, k: int) -> int:
        l = 0
        longest = float("-inf")
        d = defaultdict(int)
        for r in range(len(s)):
            d[s[r]] += 1
            while len(d) > k:
                d[s[l]] -= 1
                if d[s[l]] == 0:
                    d.pop(s[l])
                l += 1

            # valid window here
            longest = max(longest, r - l + 1)

        return 0 if longest == float("-inf") else int(longest)
