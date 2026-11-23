public class Solution {
    // time: O(n log n)
    // space: O(1)
    public int CountElements(int[] arr) {
        if (arr.Length == 1)
            return 0;

        Array.Sort(arr);
        // arr=[1,5,6,9,4,2,2,0]
        // arr=[0,1,2,2,4,5,6,9]

        var prev = arr[0];
        var counter = 0;
        var dublicates = 1;
        for (var i = 1; i < arr.Length; i++) {
            var cur = arr[i];
            if (prev == cur)
                dublicates++;
            else if (prev + 1 == cur) {
                counter += dublicates;
                dublicates = 1;
            } else
                dublicates = 1;

            prev = cur;
        }

        return counter;
    }
}
