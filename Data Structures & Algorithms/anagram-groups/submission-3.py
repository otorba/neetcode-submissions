class Solution:
    def groupAnagrams(self, strs: List[str]) -> List[List[str]]:
        groups = defaultdict(list)  # tuple-key : List[str]
        for string in strs:
            key = self.transform(string)
            groups[key].append(string)

        return list(groups.values())

    def transform(self, string: str) -> tuple[int, ...]:
        key = [0] * 26
        for c in string:
            index = ord(c) - ord("a")
            key[index] += 1
        return tuple(key)
