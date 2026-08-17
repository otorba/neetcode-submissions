public class Solution {
    public int[] ProductExceptSelf(int[] nums) {
        var prefixProduct = new int[nums.Length];
        var postfixProduct = new int[nums.Length];

        var product = 1;
        for (var i = 0; i < nums.Length; i++) {
            prefixProduct[i] = product;  // ommit current i intentionally
            product *= nums[i];
        }

        product = 1;
        for (var i = nums.Length - 1; i >= 0; i--) {
            postfixProduct[i] = product;
            product *= nums[i];
        }

        var output = new int[nums.Length];
        for (var i = 0; i < nums.Length; i++) {
            output[i] = postfixProduct[i] * prefixProduct[i];
        }

        return output;
    }
}
