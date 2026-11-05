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
    public int CountUnivalSubtrees(TreeNode root) {
        int count = 0;
        IsUniValueTree(root, ref count);
        return count;
    }

    private bool IsUniValueTree(TreeNode node, ref int count) {
        if (node == null)
            return true;

        // First, visit BOTH subtrees.
        bool leftIsUni = IsUniValueTree(node.left, ref count);
        bool rightIsUni = IsUniValueTree(node.right, ref count);

        // Then, check the immediate children.
        bool leftMatches = node.left == null || node.left.val == node.val;
        bool rightMatches = node.right == null || node.right.val == node.val;

        var isCurrentUni = leftIsUni && rightIsUni && leftMatches && rightMatches;
        if (isCurrentUni)
            count++;
        return isCurrentUni;
    }
}
