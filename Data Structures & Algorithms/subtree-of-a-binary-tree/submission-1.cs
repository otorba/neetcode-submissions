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
    public bool IsSubtree(TreeNode root, TreeNode subRoot) {
        if (root == null)
            return false;

        return IsSameTree(root, subRoot) || IsSubtree(root.left, subRoot) ||
               IsSubtree(root.right, subRoot);
    }

    private bool IsSameTree(TreeNode first, TreeNode second) {
        if (first == null && second == null)
            return true;
        else if (first == null && second != null)
            return false;
        else if (first != null && second == null)
            return false;
        else if (first.val != second.val)
            return false;

        return IsSameTree(first.left, second.left) && IsSameTree(first.right, second.right);
    }
}
