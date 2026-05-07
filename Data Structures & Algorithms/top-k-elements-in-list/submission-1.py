class Solution:
    def topKFrequent(self, nums: List[int], k: int) -> List[int]:
        freq = collections.Counter(nums)
        result = heapq.nlargest(k, freq.keys(), key=freq.get)
        return result

        