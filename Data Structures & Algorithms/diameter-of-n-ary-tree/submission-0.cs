/*
// Definition for a Node.
public class Node {
    public int val;
    public IList<Node> children;

    public Node() {}

    public Node(int _val) {
        val = _val;
    }

    public Node(int _val, IList<Node> _children) {
        val = _val;
        children = _children;
    }
}
*/

public class Solution {
    public int Diameter(Node root) {
        var longestPath = int.MinValue;
        Helper(root, ref longestPath);
        return longestPath;
    }

    private int Helper(Node node, ref int longestPath) {
        if (node == null)
            return 0;

        var heap = new PriorityQueue<int, int>();  // distance
        foreach (var child in node.children) {
            var distance = Helper(child, ref longestPath);
            if (heap.Count < 2)
                heap.Enqueue(distance, distance);
            else
                heap.EnqueueDequeue(distance, distance);
        }

        var longestChild = 0;
        var localLongestPath = 0;
        while (heap.TryDequeue(out var path, out _)) {
            longestChild = Math.Max(longestChild, path);
            localLongestPath += path;
        }
        longestPath = Math.Max(longestPath, localLongestPath);
        return longestChild + 1;
    }
}
