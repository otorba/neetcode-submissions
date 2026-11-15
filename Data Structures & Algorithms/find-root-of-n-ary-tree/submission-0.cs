/*
// Definition for a Node.
public class Node {
    public int val;
    public List<Node> children;

    public Node() {
        children = new List<Node>();
    }

    public Node(int _val) {
        val = _val;
        children = new List<Node>();
    }

    public Node(int _val, List<Node> _children) {
        val = _val;
        children = _children;
    }
}
*/

public class Solution {
    public Node FindRoot(List<Node> tree) {
        var sum = 0;

        foreach (var node in tree) {
            sum += node.val;
            foreach (var child in node.children) sum -= child.val;
        }

        Node root = null;
        foreach (var node in tree) {
            if (node.val == sum)
                root = node;
        }

        return root;
    }
}
