class Solution:
    def findMaxConsecutiveOnes(self, nums: List[int]) -> int:
        l = cur = 0
        k = 1
        max_num = float('-inf')
        for r in range(len(nums)):
            if nums[r] != 1:
                cur += 1
            # here nums[l, r]
            while cur > k:
                if nums[l] != 1:
                    cur -= 1
                l += 1
            
            # here is the valid window
            max_num = max(max_num, r - l + 1)
        
        return  0 if max_num == float('-inf') else int(max_num)
            
            

