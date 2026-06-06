class Solution:
    def removeDuplicates(self, nums: List[int]) -> int:
        l, r = 0, 1
        while r != len(nums):
            if nums[l] == nums[r]:
                nums.pop(r)
                continue
            l += 1
            r += 1
        
        return len(nums)


        