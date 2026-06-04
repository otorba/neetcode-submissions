class NumMatrix:
    def __init__(self, matrix: List[List[int]]):
        prefixMatrixSum = []
        for r in range(len(matrix)):
            prefixRawSum = []
            total = 0
            for c in range(len(matrix[r])):
                prefixRawSum.append(total)
                total += matrix[r][c]
            prefixMatrixSum.append(prefixRawSum)

        self._prefixMatrixSum = prefixMatrixSum
        self._matrix = matrix

    def sumRegion(self, row1: int, col1: int, row2: int, col2: int) -> int:
        # green
        # 6 is [1, 1] left right
        # 0 is [2, 2]

        # blue
        # 3 is [1, 2] left right
        # 5 is [2, 4] lower right

        total = 0
        for r in range(row1, row2 + 1):
            right = self._prefixMatrixSum[r][col2] + self._matrix[r][col2]
            left = self._prefixMatrixSum[r][col1]
            total += right - left

        return total


# Your NumMatrix object will be instantiated and called as such:
# obj = NumMatrix(matrix)
# param_1 = obj.sumRegion(row1,col1,row2,col2)
