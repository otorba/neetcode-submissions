public class StockSpanner {
    private readonly Stack<int> _history = new();
    private readonly Stack<int> _temp = new();

    public StockSpanner() {}

    public int Next(int price) {
        var count = 0;
        _history.Push(price);
        while (_history.Count > 0 && _history.Peek() <= price) {
            var prevPrice = _history.Pop();
            count++;
            _temp.Push(prevPrice);
        }

        while (_temp.Count > 0) {
            _history.Push(_temp.Pop());
        }

        return count;
    }
}

/**
 * Your StockSpanner object will be instantiated and called as such:
 * StockSpanner obj = new StockSpanner();
 * int param_1 = obj.Next(price);
 */