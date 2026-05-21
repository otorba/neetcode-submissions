class Solution:
    def encode(self, strs: List[str]) -> str:
        result = ""
        for string in strs:
            result += f"{len(string)}#{string}"

        return result

    # 5#hello5#world
    def decode(self, s: str) -> List[str]:
        result = []
        i = 0  # position
        while i < len(s):
            j = s.find("#", i)  # 1
            number_of_digits = int(s[i:j])  # 5
            string = s[j + 1 : number_of_digits + j + 1]  # [2:7]
            result.append(string)
            i = j + 1 + number_of_digits

        return result
