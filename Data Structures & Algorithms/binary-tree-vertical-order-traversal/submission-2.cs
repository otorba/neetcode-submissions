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
    public List<List<int>> VerticalOrder(TreeNode root) {
        if (root == null) 
            return new();
        var queue = new Queue<(TreeNode, int)>();  // node + shift
        queue.Enqueue((root, 0));
        var dict = new Dictionary<int, List<int>>();  // shift -> List of node vals

        while (queue.Count > 0) {
            var nodesCount = queue.Count;
            for (var i = 0; i < nodesCount; i++) {
                var (node, shift) = queue.Dequeue();
                if (!dict.TryGetValue(shift, out var group)) {
                    dict[shift] = new List<int>() { node.val };
                } else {
                    group.Add(node.val);
                }

                if (node.left != null)
                    queue.Enqueue((node.left, shift - 1));
                if (node.right != null)
                    queue.Enqueue((node.right, shift + 1));
            }
        }

        var output = new List<List<int>>();
        foreach (var key in dict.Keys.OrderBy(x => x)) {
            output.Add(dict[key]);
        }
        return output;
    }
}