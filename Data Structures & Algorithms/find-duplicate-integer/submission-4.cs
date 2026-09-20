public class Solution {
    public int FindDuplicate(int[] nums) {
        if (nums.Length == 1)
            return nums[0];

        var fast = 0;
        var slow = 0;

        while (true) {
            slow = nums[slow];        // 1 3 2 4
            fast = nums[nums[fast]];  // 3 4 4 4

            if (slow == fast)
                break;
        }

        slow = 0;
        while (true) {
            slow = nums[slow];
            fast = nums[fast];

            if (slow == fast)
                break;
        }

        return fast;
    }
}
