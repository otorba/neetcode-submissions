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
    public bool IsBalanced(TreeNode root) {
        if (root == null)
            return true;

        if (Math.Abs(Hight(root.left) - Hight(root.right)) > 1)
            return false;

        return IsBalanced(root.left) && IsBalanced(root.right);
    }

    private int Hight(TreeNode node) {
        if (node == null)
            return 0;

        var left = Hight(node.left);
        var right = Hight(node.right);

        return Math.Max(left, right) + 1;
    }
}
