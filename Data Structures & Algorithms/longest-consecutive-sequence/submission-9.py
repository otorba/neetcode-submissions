class Solution:
    def longestConsecutive(self, nums: List[int]) -> int:
        seen = set(nums)

        longest = 0
        for n in seen:
            if n - 1 not in seen:
                seq = 1
                last = n
                while last + 1 in seen:
                    seq += 1
                    last = last + 1
                if seq > longest:
                    longest = seq

        return longest
