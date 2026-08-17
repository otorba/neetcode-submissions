from collections import defaultdict


class Solution:
    def subarraySum(self, nums: List[int], k: int) -> int:
        result = 0
        prefix = [0] * len(nums)
        sum = 0
        freq = defaultdict(int)
        freq[0] = 1
        for i in range(len(nums)):
            sum += nums[i]
            prefix[i] = sum

            result += freq[prefix[i] - k]

            freq[prefix[i]] += 1

        return result
