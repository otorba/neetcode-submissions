class Solution:
    def groupAnagrams(self, strs: List[str]) -> List[List[str]]:
        groups = {}  # tuple-key : List[str]
        for string in strs:
            key = self.transform(string)
            if key in groups:
                groups[key].append(string)
            else:
                groups[key] = [string]

        result = []
        for k, v in groups.items():
            result.append(v)
        return result

    def transform(self, string: str) -> tuple[int, ...]:
        key = [0] * 26
        for c in string:
            index = ord(c) - ord("a")
            key[index] += 1
        return tuple(key)
