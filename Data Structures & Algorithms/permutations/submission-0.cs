public class Solution {
    public List<List<int>> Permute(int[] nums) {
        var perms = new List<List<int>>() { new() };
        List<List<int>> nextPerms = null;

        foreach (var num in nums) {
            nextPerms = new();
            foreach (var perm in perms) {
                foreach (var i in Enumerable.Range(0, perm.Count + 1)) {
                    var newPerm = new List<int>(perm);
                    newPerm.Insert(i, num);
                    nextPerms.Add(newPerm);
                }
            }

            perms = nextPerms;
        }

        return perms;
    }
}
