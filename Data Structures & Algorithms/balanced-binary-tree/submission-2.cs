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
        return IsBalancedInner(root);
    }

    private bool IsBalancedInner(TreeNode root) {
        if (root == null)
            return true;

        var leftHeight = Height(root.left);
        var rightHeight = Height(root.right);

        return Math.Abs(leftHeight - rightHeight) <= 1 
        && IsBalancedInner(root.left)
        && IsBalancedInner(root.right);
    }

    private int Height(TreeNode node) {
        if (node == null)
            return 0;

        var leftHeight = Height(node.left);
        var rightHeight = Height(node.right);

        return Math.Max(leftHeight, rightHeight) + 1;
    }
}
