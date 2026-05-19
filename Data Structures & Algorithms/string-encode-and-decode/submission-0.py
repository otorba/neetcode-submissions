class Solution:
    def encode(self, strs: List[str]) -> str:
        result = ""
        for string in strs:
            result += f"{len(string)}#{string}"

        return result

    def decode(self, s: str) -> List[str]:
        result = []
        count_to_skip = ""
        indexes = 0
        start_skipping = False
        string_to_add = ""

        for c in s:
            if c.isdigit() and start_skipping == False:
                count_to_skip += c
            elif c == "#" and start_skipping == False:
                start_skipping = True
                indexes = int(count_to_skip)
            elif start_skipping and indexes > 0:
                string_to_add += c
                indexes -= 1
            if start_skipping and indexes == 0:
                result.append(string_to_add)
                start_skipping = False
                string_to_add = ""
                count_to_skip = ""

        return result
