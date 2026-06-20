class Solution:
    def minSubArrayLen(self, target: int, nums: List[int]) -> int:
        l = current = 0
        min_sum = float("inf")

        for r in range(len(nums)):
            current += nums[r]
            while current >= target:
                min_sum = min(min_sum, r - l + 1)
                current -= nums[l]
                l += 1
                
        return 0 if min_sum == float("inf") else int(min_sum)
