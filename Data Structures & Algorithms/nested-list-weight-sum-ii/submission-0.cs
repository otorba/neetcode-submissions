/**
 * // This is the interface that allows for creating nested lists.
 * // You should not implement it, or speculate about its implementation
 * public interface INestedInteger {
 *     // @return true if this NestedInteger holds a single integer, rather than a nested list.
 *     bool IsInteger();
 *
 *     // @return the single integer that this NestedInteger holds, if it holds a single integer
 *     // Return null if this NestedInteger holds a nested list
 *     int GetInteger();
 *
 *     // Set this NestedInteger to hold a single integer.
 *     void SetInteger(int value);
 *
 *     // Set this NestedInteger to hold a nested list and adds a nested integer to it.
 *     void Add(INestedInteger ni);
 *
 *     // @return the nested list that this NestedInteger holds, if it holds a nested list
 *     // Return empty list if this NestedInteger holds a single integer
 *     IList<INestedInteger> GetList();
 * }
 */

public class Solution {
    public int DepthSumInverse(IList<INestedInteger> nestedList) {
        var depths = new List<(int, int)>();  // initVal + depth
        var depth = 1;

        foreach (var item in nestedList) {
            CalculateDepths(depths, item, depth);
        }

        var maxDepth = int.MinValue;
        foreach (var item in depths) {
            maxDepth = Math.Max(maxDepth, item.Item2);
        }

        var result = 0;
        foreach (var item in depths) {
            var weith = maxDepth - item.Item2 + 1;
            result += item.Item1 * weith;
        }

        return result;
    }

    private void CalculateDepths(List<(int, int)> depths, INestedInteger item, int depth) {
        if (item.IsInteger()) {
            depths.Add((item.GetInteger(), depth));
            return;
        }

        foreach (var i in item.GetList()) {
            CalculateDepths(depths, i, depth + 1);
        }

        return;
    }
}
