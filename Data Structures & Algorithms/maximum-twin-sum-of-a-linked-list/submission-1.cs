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
        var fast = head;
        var slow = head;

        ListNode prevBackward = null;
        ListNode slowNext = null;

        while (fast != null) {
            var nextSlow = slow.next;
            var nextFast = fast.next.next;
            
            slow.next = prevBackward;
            prevBackward = slow;

            slow = nextSlow;
            fast = nextFast;
        }

        var max = int.MinValue;

        while (slow != null) {
            var left = prevBackward.val;
            var right = slow.val;

            max = Math.Max(left + right, max);

            slow = slow.next;
            prevBackward = prevBackward.next;
        }

        return max;
    }
}