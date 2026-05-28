class Solution:
    def longestConsecutive(self, nums: List[int]) -> int:
        if len(nums) == 0:
            return 0
        elif len(nums) == 1:
            return 1

        seen = set()
        seq = set()
        for n in nums:
            seen.add(n)
            if n - 1 in seen:
                seq.add(n-1)
                seq.add(n)
            if n + 1 in seen:
                seq.add(n+1)
                seq.add(n)
        
        if len(seq) == 0:
            return 1
        return len(seq)