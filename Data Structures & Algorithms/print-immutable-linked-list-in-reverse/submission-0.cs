/**
 * // This is the ImmutableListNode's API interface.
 * // You should not implement it, or speculate about its implementation.
 * public interface IImmutableListNode {
 *     public void PrintValue(); // print the value of this node.
 *     public IImmutableListNode GetNext(); // return the next node.
 * }
 */
public class Solution {
    public void PrintLinkedListInReverse(IImmutableListNode head) {
        Helper(head);
        head.PrintValue();
    }

    private void Helper(IImmutableListNode node) {
        if (node == null)
            return;

        node = node.GetNext();
        Helper(node);

        if (node != null)
            node.PrintValue();
    }
}
