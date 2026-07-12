class Solution:
    def minAvailableDuration(
        self, slots1: List[List[int]], slots2: List[List[int]], duration: int
    ) -> List[int]:
        slots1.sort()
        slots2.sort()
        p1 = p2 = 0
        while p1 < len(slots1) and p2 < len(slots2):
            while p1 < len(slots1) and slots1[p1][1] - slots1[p1][0] < duration:
                p1 += 1
            while p2 < len(slots2) and slots2[p2][1] - slots2[p2][0] < duration:
                p2 += 1

            # both slots are valid here
            # check if they ovverlap
            if p1 < len(slots1) and p2 < len(slots2):
                if (
                    slots2[p2][1] - slots1[p1][0] >= duration
                    and slots1[p1][1] - slots2[p2][0] >= duration
                ):
                    start = max(slots1[p1][0], slots2[p2][0])
                    end = start + duration
                    return [start, end]
                else:
                    if slots2[p2][1] < slots1[p1][1]:
                        p2 += 1
                    else:
                        p1 += 1

        return []
