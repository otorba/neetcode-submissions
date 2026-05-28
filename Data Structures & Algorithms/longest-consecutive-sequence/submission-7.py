class Solution:
    def longestConsecutive(self, nums: List[int]) -> int:
        

        seen = set()
        for n in nums:
            seen.add(n)

        starts = []
        for n in nums: 
            if n - 1 not in seen:
                starts.append(n)
        
        longest_seq = 0
        for s in starts:
            seq = 1
            last = s
            while last + 1 in seen:
                seq += 1
                last = last + 1
            if seq > longest_seq:
                longest_seq = seq
        
        return longest_seq

            
