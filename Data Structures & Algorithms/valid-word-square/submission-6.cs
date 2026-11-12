public class Solution {
    public bool ValidWordSquare(IList<string> words) {
        for (var r = 0; r < words.Count; r++) {
            for (var c = 0; c < words[r].Length; c++) {
                if (c >= words.Count || words[c].Length < r + 1)
                    return false;

                if (words[r][c] != words[c][r])
                    return false;
            }
        }

        return true;
    }

    // ball
    // asee
    // let
    // lep
}
