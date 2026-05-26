class Solution:
    def isValidSudoku(self, board: List[List[str]]) -> bool:
        # rows check
        seen = set()
        for raw in board:
            for d in raw:
                if d == '.':
                    continue
                if d in seen:
                    return False
                seen.add(d)
            seen.clear()


        # columns check
        for i in range(len(board)):
            seen.clear()
            for j in range(len(board)):
                if board[j][i] == '.':
                    continue
                if board[j][i] in seen:
                    return False
                seen.add(board[j][i])

        # sub-boxes check
        
        for i in range(0, len(board), 3):
            for j in range(0, len(board), 3):
                seen.clear()
                for r in range(i, i + 3, 1):
                    for c in range(j, j + 3, 1):
                        if board[r][c] == '.':
                            continue
                        if board[r][c] in seen:
                            return False
                        seen.add(board[r][c])
                
        return True
