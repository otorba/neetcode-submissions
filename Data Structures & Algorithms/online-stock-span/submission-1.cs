public class StockSpanner {
    private class PriceInfo {
        public readonly int Price;
        public int Count;

        public PriceInfo(int price) {
            Price = price;
            Count = 1;
        }
    }

    private readonly Stack<PriceInfo> _history = new();

    public StockSpanner() {}

    public int Next(int price) {
        var newPrice = new PriceInfo(price);

        while (_history.Count > 0 && _history.Peek().Price <= newPrice.Price) {
            var prevPrice = _history.Pop();
            newPrice.Count += prevPrice.Count;
        }

        _history.Push(newPrice);

        return newPrice.Count;
    }
}

/**
 * Your StockSpanner object will be instantiated and called as such:
 * StockSpanner obj = new StockSpanner();
 * int param_1 = obj.Next(price);
 */