class Solution:
    def numOfSubarrays(self, arr: List[int], k: int, threshold: int) -> int:
        l = number = cur = 0

        for r in range(len(arr)):
            cur += arr[r]
            while r - l + 1 > k:
                cur -= arr[l]
                l += 1

            if r - l + 1 == k and cur // k >= threshold:
                number += 1

        return number
