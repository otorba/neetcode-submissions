/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
 *         this.val = val;
 *         this.left = left;
 *         this.right = right;
 *     }
 * }
 */

public class Solution {
    public int KthSmallest(TreeNode root, int k) {
        var kref = k;
        return Traverse(root, ref kref);
    }

    private int Traverse(TreeNode root, ref int k) {
        if (root == null)
            return -1;

        var left = Traverse(root.left, ref k);
        if (left > -1)
            return left;
        k--;
        if (k == 0)
            return root.val;
        var right = Traverse(root.right, ref k);
        if (right > -1)
            return right;

        return -1;
    }
}
