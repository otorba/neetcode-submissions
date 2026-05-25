class Solution:
    def productExceptSelf(self, nums: List[int]) -> List[int]:
        output = [0] * len(nums)
        for i in range(len(nums) - 1, -1, -1):
            if i == len(nums) - 1:
                output[i] = 1
            else:
                output[i] = output[i + 1] * nums[i + 1]
        
        acc_left = 1
        for i in range(len(nums)):
            if i == 0:
                continue
                
            output[i] = output[i] * nums[i - 1] * acc_left
            acc_left = acc_left * nums[i - 1]
        return output
