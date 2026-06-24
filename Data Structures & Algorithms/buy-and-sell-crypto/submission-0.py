class Solution:
    def maxProfit(self, prices: List[int]) -> int:
        lowest_price = float('inf')
        max_profit = 0
        for p in prices:
            lowest_price = min(lowest_price, p)
            max_profit = max(max_profit, p - lowest_price)
        
        return max_profit