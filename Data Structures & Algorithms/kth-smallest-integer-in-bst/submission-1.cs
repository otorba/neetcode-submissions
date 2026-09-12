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
        var kth = k;
        return Traverse(root, ref kth).Value;
    }

    private int? Traverse(TreeNode node, ref int k) {
        if (node == null)
            return null;
        
        var val = Traverse(node.left, ref k);
        if (val != null)
            return val;

        k--;
        if (k == 0)
            return node.val;

        val = Traverse(node.right, ref k);
        if (val != null)
            return val;
        
        return null;
    }
}
