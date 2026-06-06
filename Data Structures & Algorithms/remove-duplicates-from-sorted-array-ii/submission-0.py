class Solution:
    def removeDuplicates(self, nums: List[int]) -> int:
        # we can use two pointers here:
        #    1. L points to the last element of the scope.
        #       - In this scope we have unique elements appeared at most twice
        #    2. R behavies like a scout to find the next unique or dublicate unique number
        #       - When we find such a number, we move L to the right and replace nums[L] with the nums[R]
        #       - We should have a counter for the unique numbers
        #         that will be used as a condition to have at least two dublicated.
        L, R = 0, 1
        while R != len(nums):
            if nums[L] == nums[R] and L > 0 and nums[L] == nums[L - 1]:  # at most two
                R += 1
            else:
                L += 1
                nums[L] = nums[R]
                R += 1

        return L + 1
