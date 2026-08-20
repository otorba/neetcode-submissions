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
    public List<int> InorderTraversal(TreeNode root) {
        var output = new List<int>();
        Travers(root, output);
        return output;
    }

    private void Travers(TreeNode node, List<int> output) {
        if (node == null)
            return;

        Travers(node.left, output);
        output.Add(node.val);
        Travers(node.right, output);
    }
}