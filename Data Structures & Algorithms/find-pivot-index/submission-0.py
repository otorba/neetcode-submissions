class Solution:
    def pivotIndex(self, nums: List[int]) -> int:
        # [1] left = 0 right = 29
        # [7] left = 1 right = 20
        # [3] left = 8 right = 17
        # [6] left = 11 right 11

        left = []
        total = 0
        for n in nums:
            left.append(total)
            total += n
        
        total = 0
        right = [0] * len(nums)
        for i in range(len(nums) - 1, -1, -1):
            right[i] = total
            total += nums[i]
        
        for i in range(len(nums)):
            if right[i] == left[i]:
                return i;
        
        return -1
            




