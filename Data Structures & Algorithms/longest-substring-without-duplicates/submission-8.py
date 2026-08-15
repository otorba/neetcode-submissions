class Solution:
    def lengthOfLongestSubstring(self, s: str) -> int:
        seen = set()
        longest = 0
        l = r = 0
        while r < len(s):
            while s[r] in seen:
                seen.remove(s[l])
                l += 1

            longest = max(longest, r - l + 1)
            
            seen.add(s[r])
            r += 1


        return longest
