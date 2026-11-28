public class LogSystem {
    private List<(int Id, long Timestamp)> _timestamps = new();

    public LogSystem() {}

    public void Put(int id, string timestamp) {
        _timestamps.Add((id, Convert(timestamp)));
        _timestamps.Sort((a, b) => a.Timestamp.CompareTo(b.Timestamp));
    }

    public List<int> Retrieve(string start, string end, string granularity) {
        var startN = Convert(start, granularity, '0');
        var endN = Convert(end, granularity, '9');

        var from = FindFirstGreaterOrEqual(startN);
        var to = FindLastLessOrEqual(endN);
        if (from == null || to == null)
            return new();

        var result = new List<int>();
        for (var i = from.Value; i <= to.Value; i++) result.Add(_timestamps[i].Id);
        return result;
    }

    private int? FindLastLessOrEqual(long target) {
        var left = 0;
        var right = _timestamps.Count - 1;
        int? candidate = null;
        while (left <= right) {
            var mid = (right + left) / 2;
            if (_timestamps[mid].Timestamp > target)
                right = mid - 1;
            else if (_timestamps[mid].Timestamp <= target) {
                left = mid + 1;
                candidate = mid;
            }
        }

        return candidate;
    }

    private int? FindFirstGreaterOrEqual(long target) {
        var left = 0;
        var right = _timestamps.Count - 1;
        int? candidate = null;
        while (left <= right) {
            var mid = (right + left) / 2;
            if (_timestamps[mid].Timestamp >= target) {
                right = mid - 1;
                candidate = mid;
            } else if (_timestamps[mid].Timestamp < target) {
                left = mid + 1;
            }
        }

        return candidate;
    }

    private long Convert(string timestamp) {
        var trim = timestamp.Replace(":", string.Empty);
        return long.Parse(trim);
    }

    private long Convert(string timestamp, string granularity, char defaultVal) {
        var digits = 14;
        var digitsPreserved = -1;
        switch (granularity) {
            case "Year": {
                digitsPreserved = 4;
                break;
            }
            case "Month": {
                digitsPreserved = 6;
                break;
            }
            case "Day": {
                digitsPreserved = 8;
                break;
            }
            case "Hour": {
                digitsPreserved = 10;
                break;
            }
            case "Minute": {
                digitsPreserved = 12;
                break;
            }
            case "Second": {
                return Convert(timestamp);
            }
            default: {
                return Convert(timestamp);
            }
        }

        var trim = timestamp.Replace(":", string.Empty);
        var preserved = trim[..digitsPreserved];
        trim = preserved.PadRight(digits, defaultVal);
        return long.Parse(trim);
    }
}

/**
 * Your LogSystem object will be instantiated and called as such:
 * LogSystem obj = new LogSystem();
 * obj.Put(id, timestamp);
 * List<int> param_2 = obj.Retrieve(start, end, granularity);
 */
