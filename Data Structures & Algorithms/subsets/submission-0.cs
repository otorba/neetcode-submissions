public class Solution {
    public List<List<int>> Subsets(int[] nums) {
        var curSet = new List<int>();
        var subSets = new List<List<int>>();

        Helper(0, nums, curSet, subSets);

        return subSets;
    }

    private void Helper(int i, int[] nums, List<int> curSet, List<List<int>> subSets) {
        // base case
        if (i >= nums.Length) {
            subSets.Add(new List<int>(curSet));
            return;
        }

        // find all combination including current nums[i]
        curSet.Add(nums[i]);
        Helper(i + 1, nums, curSet, subSets);

        // find all combination excluding current nums[i]
        curSet.RemoveAt(curSet.Count - 1);
        Helper(i + 1, nums, curSet, subSets);
    }
}
