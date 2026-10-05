public class Solution {
    public List<List<int>> SubsetsWithDup(int[] nums) {
        Array.Sort(nums);

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

        // find all combinations including the current nums[i]
        curSet.Add(nums[i]);
        Helper(i + 1, nums, curSet, subSets);

        // find all combinations exclusing the current nums[i] starting from the next unique nums[i]
        curSet.RemoveAt(curSet.Count - 1);
        while (i + 1 < nums.Length && nums[i] == nums[i + 1]) i++;
        Helper(i + 1, nums, curSet, subSets);
    }
}
