public class Solution {
    public int[] TopKFrequent(int[] nums, int k) {
        var numberByFrequance = new Dictionary<int, int>();
        foreach (var n in nums) {
            if (numberByFrequance.ContainsKey(n)) {
                numberByFrequance[n] += 1;
            } else {
                numberByFrequance[n] = 1;
            }
        }

        return numberByFrequance.Select(kvp => (kvp.Key, kvp.Value))
            .OrderByDescending(x => x.Value)
            .Select(x => x.Key)
            .Take(k)
            .ToArray();
    }
}
