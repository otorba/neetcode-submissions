/*
// Definition for a Node.
public class Node {
    public int val;
    public IList<Node> neighbors;

    public Node() {
        val = 0;
        neighbors = new List<Node>();
    }

    public Node(int _val) {
        val = _val;
        neighbors = new List<Node>();
    }

    public Node(int _val, List<Node> _neighbors) {
        val = _val;
        neighbors = _neighbors;
    }
}
*/

public class Solution {
    public Node CloneGraph(Node node) {
        if (node == null)
            return null;

        var clone = new Node(node.val);
        var clones = new Dictionary<Node, Node>();
        clones[node] = clone;

        var queue = new Queue<Node>();
        queue.Enqueue(node);

        while (queue.Count > 0) {
            var queueLength = queue.Count;
            for (var i = 0; i < queueLength; i++) {
                var nodeToClone = queue.Dequeue();

                foreach (var n in nodeToClone.neighbors) {
                    Node neighborClone = null;
                    if (!clones.TryGetValue(n, out neighborClone)) {
                        neighborClone = new Node(n.val);
                        clones[n] = neighborClone;

                        queue.Enqueue(n);
                    }

                    clones[nodeToClone].neighbors.Add(neighborClone);
                }
            }
        }

        return clones[node];
    }
}
