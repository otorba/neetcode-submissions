class Solution:
    def lengthOfLongestSubstring(self, s: str) -> int:
        length = max_length = 0
        seen = set()
        for L in range(0, len(s)):
            for R in range(L, len(s)):
                if s[R] in seen:
                    if length > max_length:
                        max_length = length
                    L += 1
                    seen.clear()
                    length = 0
                    break
                else:
                    seen.add(s[R])
                    length += 1

        if length > max_length:
            max_length = length
        return max_length
