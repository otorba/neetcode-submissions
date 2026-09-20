/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int val=0, ListNode next=null) {
 *         this.val = val;
 *         this.next = next;
 *     }
 * }
 */
public class Solution {
    public int PairSum(ListNode head) {
        var toProcess = new Stack<int>();

        var fast = head;
        var slow = head;

        while (fast != null) {
            toProcess.Push(slow.val);

            slow = slow.next;
            fast = fast.next.next;
        }

        var max = int.MinValue;

        while (toProcess.Count > 0) {
            var left = toProcess.Pop();
            var right = slow.val;

            max = Math.Max(left + right, max);

            slow = slow.next;
        }

        return max;
    }
}