class Solution:
    def carFleet(self, target: int, position: List[int], speed: List[int]) -> int:
        times = []
        for i in range(len(position)):
            time = (target - position[i]) / speed[i]
            times.append(time)
        cars = sorted(zip(position, times), reverse=True)
        stack = []
        for c in cars:
            if not stack:
                stack.append(c[1])
            elif c[1] > stack[-1]:
                stack.append(c[1])

        return len(stack)


# 4,3 1,4 0,10 7,3
