class Solution:
    def pivotIndex(self, nums: List[int]) -> int:
        # leftSum + nums[i] + rightSum = total
        # rightSum = total - leftSum - nums[i]
        
        total = 0
        for n in nums:
            total += n
        
        leftSum = 0
        for i, n in enumerate(nums):
            rightSum = total - leftSum - n
            if leftSum == rightSum:
                return i
            leftSum += n
        

        return -1

        