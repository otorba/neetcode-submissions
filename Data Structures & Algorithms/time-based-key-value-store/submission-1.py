from collections import defaultdict

class TimeMap:

    def __init__(self):
        self._dict: dict[str, list[tuple[str, int]]] = defaultdict(list) # key : List<(value, timestamp)>

    def set(self, key: str, value: str, timestamp: int) -> None:
        self._dict[key].append((value, timestamp))

    def get(self, key: str, timestamp: int) -> str:
        values = self._dict[key]
        index = self._find(timestamp, values)
        
        return '' if index < 0 else values[index][0]
        
    
    def _find(self, timestamp: int, values: list[tuple[str, int]]) -> int:
        l, r = 0, len(values) -1
        while l <= r:
            mid = round((l + r) /2)
            if timestamp > values[mid][1]:
                l = mid + 1
            elif timestamp < values[mid][1]:
                r = mid - 1
            else:
                return mid
        
        return r


        
