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
    public int LongestConsecutive(TreeNode root) {
        var longest = int.MinValue;
        Helper(root, ref longest);
        return longest;
    }

    private (int, int) Helper(TreeNode node, ref int longest) {
        if (node == null)
            return (0, 0);

        var (curInc, curDec) = (0, 0);
        var (leftInc, leftDec) = Helper(node.left, ref longest);
        var (rightInc, rightDec) = Helper(node.right, ref longest);

        if (node.left != null && node.val - node.left.val == 1)
            curDec = Math.Max(curDec, leftDec);
        if (node.right != null && node.val - node.right.val == 1)
            curDec = Math.Max(curDec, rightDec);

        if (node.left != null && node.left.val - node.val == 1)
            curInc = Math.Max(curInc, leftInc);
        if (node.right != null && node.right.val - node.val == 1)
            curInc = Math.Max(curInc, rightInc);

        curInc++;
        curDec++;
        longest = Math.Max(longest, curDec + curInc - 1);

        return (curInc, curDec);
    }
}
