class Solution:
    def topKFrequent(self, nums: List[int], k: int) -> List[int]:
        countsByNumber = {} 
        for i in nums:
            if i in countsByNumber:
                countsByNumber[i] += 1
            else:
                countsByNumber[i] = 1
        
        sortedValues = sorted(countsByNumber.values())[-k:]
        listToReturn = []
        
        for key,val in countsByNumber.items():
            if val in sortedValues:
                listToReturn.append(key)
        
        return listToReturn
        