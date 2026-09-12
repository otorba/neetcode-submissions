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
        return Traverse(root, ref k).Value;
    }

    private int? Traverse(TreeNode node, ref int k) {
        if (node == null)
            return null;
        
        var found = Traverse(node.left, ref k);
        if (found != null)
            return found;

        k--;
        if (k == 0)
            return node.val;

        found = Traverse(node.right, ref k);
        if (found != null)
            return found;
        
        return null;
    }
}
