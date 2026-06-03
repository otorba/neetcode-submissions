class NumArray:
    def __init__(self, nums: List[int]):
        prefixSum = [0] * len(nums)
        for i, n in enumerate(nums):
            if i == 0:
                prefixSum[i] = n
            else:
                prefixSum[i] = n + prefixSum[i - 1]

        self._prefixSum = prefixSum

    def sumRange(self, left: int, right: int) -> int:
        if left == 0:
            return self._prefixSum[right]
        return self._prefixSum[right] - self._prefixSum[left - 1]


# Your NumArray object will be instantiated and called as such:
# obj = NumArray(nums)
# param_1 = obj.sumRange(left,right)
