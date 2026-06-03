class NumArray:
    def __init__(self, nums: List[int]):
        preSum = []
        total = 0
        for n in nums:
            total += n
            preSum.append(total)

        self._prefixSum = preSum

    def sumRange(self, left: int, right: int) -> int:
        preRight = self._prefixSum[right]
        preLeft = self._prefixSum[left - 1] if left > 0 else 0
        return preRight - preLeft


# Your NumArray object will be instantiated and called as such:
# obj = NumArray(nums)
# param_1 = obj.sumRange(left,right)
