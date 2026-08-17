public class Solution {
    public string KthDistinct(string[] arr, int k) {
        var freq = new Dictionary<string, int>();
        for (var i = 0; i < arr.Length; i++) {
            if (freq.ContainsKey(arr[i])) {
                freq[arr[i]] += 1;
            } else {
                freq[arr[i]] = 1;
            }
        }

        var kth = 0;
        for (var i = 0; i < arr.Length; i++) {
            if (freq[arr[i]] == 1) {
                kth += 1;
                if (kth == k) {
                    return arr[i];
                }
            }
        }

        return "";
    }
}