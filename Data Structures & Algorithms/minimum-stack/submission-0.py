class MinStack:

    def __init__(self):
        self._main: list[int] = []
        self._min: list[int] = []
        

    def push(self, val: int) -> None:
        self._main.append(val)
        new_min = min(val, self._min[-1])if self._min else val
        self._min.append(new_min)
        

    def pop(self) -> None:
        self._main.pop()
        self._min.pop()
        
        

    def top(self) -> int:
        return self._main[-1]
        

    def getMin(self) -> int:
        return self._min[-1]
        
