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
    public ListNode DeleteNodes(ListNode head, int m, int n) {
        var next = head;
        ListNode f = null;
        var toSkip = m;
        var toRemove = n;

        while (next != null) {
            if (toSkip == 0) {
                if (toRemove > 0) {
                    f.next = next.next;
                    toRemove--;
                }
                if (toRemove == 0) {
                    toSkip = m;
                    toRemove = n;
                    f = null;
                }
            } else {
                toSkip--;
            }

            if (toSkip == 0 && f == null)
                f = next;

            next = next.next;
        }

        return head;
    }
}
