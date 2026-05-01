class Solution:
    firstDict = {}
    secondDict = {}

    def groupAnagrams(self, strs: List[str]) -> List[List[str]]:
        result = []

        for val in strs:
            if len(result) == 0:
                result.append([val])
                continue
            added = False
            for group in result:
                if self.isAnagram(group[0], val):
                    group.append(val)
                    added = True
                    break
            if not added:
                result.append([val])

        return result

    def isAnagram(self, first: str, second: str) -> bool:
        if len(first) != len(second):
            return False
        for c in first:
            self.firstDict[c] = 1 + self.firstDict.get(c, 0)
        for c in second:
            self.secondDict[c] = 1 + self.secondDict.get(c, 0)

        isAnagram = self.firstDict == self.secondDict
        self.firstDict.clear()
        self.secondDict.clear()
        return isAnagram
