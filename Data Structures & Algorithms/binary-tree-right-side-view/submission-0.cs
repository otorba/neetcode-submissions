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
    public List<int> RightSideView(TreeNode root) {
        var output = new List<int>();
        var queue = new Queue<TreeNode>();

        if (root != null)
            queue.Enqueue(root);

        while (queue.Count > 0) {
            var currentLevelLength = queue.Count;
            var currentNodePos = 0;
            for (int i = 0; i < currentLevelLength; i++) {
                var node = queue.Dequeue();

                if (currentLevelLength > 1) {
                    if (currentNodePos == currentLevelLength - 1)
                        output.Add(node.val);
                    else
                        currentNodePos++;
                } else
                    output.Add(node.val);

                if (node.left != null)
                    queue.Enqueue(node.left);
                if (node.right != null)
                    queue.Enqueue(node.right);
            }
        }

        return output;
    }
}
