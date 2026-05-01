class Solution:
    def twoSum(self, nums: List[int], target: int) -> List[int]:
        prevValue = {} # value : index
        for i, n in enumerate(nums):
            diff = target - n;
            if diff in prevValue:
                return [prevValue[diff], i]
            prevValue[n] = i
        return []
        