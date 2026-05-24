class Solution:
    def productExceptSelf(self, nums: List[int]) -> List[int]:
        left = [0] * len(nums)
        right = [0] * len(nums)

        for i in range(len(nums)):
            if i == 0:
                left[i] = 1
            else:
                left[i] = nums[i - 1] * left[i - 1]

        for i in range(len(nums) - 1, -1, -1):
            if i == len(nums) - 1:
                right[i] = 1
            else:
                right[i] = right[i + 1] * nums[i + 1]

        output = [0] * len(nums)
        for i in range(len(nums)):
            output[i] = right[i] * left[i]
        return output
