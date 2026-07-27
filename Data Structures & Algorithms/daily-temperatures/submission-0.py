class Solution:
    def dailyTemperatures(self, temperatures: List[int]) -> List[int]:
        stack = []
        result = [0] * len(temperatures)
        for i in range(0, len(temperatures)):
            while stack and temperatures[stack[-1]] < temperatures[i]:
                colderDayIndex = stack.pop()
                result[colderDayIndex] = i - colderDayIndex
            
            stack.append(i)
        
        return result


