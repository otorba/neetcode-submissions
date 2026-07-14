class Solution:
    def evalRPN(self, tokens: List[str]) -> int:
        stack = []
        for t in tokens:
            if not t in {"+", "-", "*", "/"}:
                stack.append(int(t))
                continue

            second = stack.pop()
            first = stack.pop() 
            if t == '+':
                stack.append(first + second)
            elif t == '-':
                stack.append(first - second)
            elif t == '*':
                stack.append(first * second)
            elif t == '/':
                stack.append(int(first / second))
        
        return stack[0]

    
