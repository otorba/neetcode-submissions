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
        return IsBalancedInner(root).isBalanced;
    }

    private (int height, bool isBalanced) IsBalancedInner(TreeNode node){
        // simplest case
        if (node == null)
            return (0, true);
        
        var left = IsBalancedInner(node.left);
        var right = IsBalancedInner(node.right);

        var height = Math.Max(left.height, right.height) + 1;
        var isLocalBalanced = Math.Abs(left.height - right.height) <= 1;
        var isBalanced = isLocalBalanced && left.isBalanced && right.isBalanced;
        return (height, isBalanced);
    }
}
