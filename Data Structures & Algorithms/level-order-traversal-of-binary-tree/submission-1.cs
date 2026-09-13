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
    public List<List<int>> LevelOrder(TreeNode root) {
        var output = new List<List<int>>();
        if (root == null)
            return output;
        
        var queue = new Queue<TreeNode>();
        queue.Enqueue(root);
        while (queue.Count > 0) {
            var levelSize = queue.Count;
            var levelList = new List<int>(levelSize);

            for (var i = 0; i < levelSize; i++) {
                var node = queue.Dequeue();
                levelList.Add(node.val);

                if (node.left != null) 
                    queue.Enqueue(node.left);
                if (node.right != null)
                    queue.Enqueue(node.right);
            }

            output.Add(levelList);
        }

        return output;        
    }
}
