public class Solution {
    public bool hasDuplicate(int[] nums) {
        var set = new HashSet<int>();
        foreach(var i in nums){
            if (!set.Add(i))
                return true;
        }
        return false;
    }
}