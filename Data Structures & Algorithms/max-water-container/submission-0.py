class Solution:
    def maxArea(self, heights: List[int]) -> int:
        l = 0
        r = len(heights) - 1
        max_area = float("-inf")
        while l < r:
            area = min(heights[l], heights[r]) * (r - l)
            max_area = max(max_area, area)
            if heights[l] < heights[r]:
                l += 1
            else:
                r -= 1
        
        return 0 if max_area  == float('-inf') else int(max_area)
