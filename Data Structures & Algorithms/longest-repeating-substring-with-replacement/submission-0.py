class Solution:
    def characterReplacement(self, s: str, k: int) -> int:
        l = logest_length = 0
        freq = {}
        for r in range(len(s)):
            to_add = s[r]
            if to_add in freq:
                freq[to_add] += 1
            else:
                freq[to_add] = 1

            # we have [l,r] here

            # window size (r - l + 1) - the most frequant number <= k
            max_freq_key = max(freq, key=lambda c: freq[c]) # O(1)
            max_freq = freq[max_freq_key]
            while r - l + 1 - max_freq > k:
                to_remove = s[l]
                freq[to_remove] -= 1
                l += 1

            # valid window
            logest_length = max(logest_length, r - l + 1)

        return logest_length


sol = Solution()
s = "XYYX"
k = 2
# assert sol.characterReplacement(s, k) == 4
