class Solution:
    def search(self, nums: List[int], target: int) -> int:
        l, r = 0, len(nums) - 1
        while l <= r:
            m = round((l + r) / 2)
            if target < nums[m]:
                r = m - 1
            elif target > nums[m]:
                l = m + 1
            else:
                return m
        return -1

s = Solution()
assert s.search([1,2,3,4,5], target=5) is 4 # happy path
assert s.search([1,2,3,4,5], target=7) is -1 # negative path
assert s.search([], target=7) is -1 # degenerative path