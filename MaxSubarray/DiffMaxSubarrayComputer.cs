using System.Linq;

public class DiffMaxSubarrayComputer : IMaxSubarrayComputer
{
    public int[] Compute(int[] input)
    {
        int[] movingSum = ComputeMovingSum(input);
        (int[] reverseMovingMaxSum, int[] reverseMovingMaxSumOriginIdx) = ComputeReverseMovingMaxSum(movingSum);
        (int maxRangeStartIdx, int maxRangeEndIdx) maxRangeIdxes = ComputeMaxRangeIdxes(movingSum, reverseMovingMaxSum, reverseMovingMaxSumOriginIdx);
        return input.Skip(maxRangeIdxes.maxRangeStartIdx).Take(maxRangeIdxes.maxRangeEndIdx - maxRangeIdxes.maxRangeStartIdx + 1).ToArray();
    }

    private int[] ComputeMovingSum(int[] input)
    {
        int[] movingSum = new int[input.Length];
        movingSum[0] = input[0];
        for(int idx = 1; idx < input.Length; idx++)
        {
            movingSum[idx] = input[idx] + movingSum[idx - 1];
        }

        var s1 = string.Join(',', movingSum);
        Console.WriteLine($"ComputeMovingSum movingSum: {s1}");
        return movingSum;
    }

    private (int[] reverseMovingMaxSum, int[] reverseMovingMaxSumOriginIdx) ComputeReverseMovingMaxSum(int[] movingSum)
    {
        int[] reverseMovingMaxSum = new int[movingSum.Length];
        int[] reverseMovingMaxSumOriginIdx = new int[movingSum.Length];
        int currentReverseMovingMaxSum = movingSum[movingSum.Length - 1];
        int currentReverseMovingMaxSumOriginIdx = movingSum.Length - 1;
        for (int idx = movingSum.Length - 1; idx >= 0; idx--)
        {
            if (currentReverseMovingMaxSum < movingSum[idx])
            {
                currentReverseMovingMaxSum = movingSum[idx];
                currentReverseMovingMaxSumOriginIdx = idx;
            }
            reverseMovingMaxSum[idx] = currentReverseMovingMaxSum;
            reverseMovingMaxSumOriginIdx[idx] = currentReverseMovingMaxSumOriginIdx;
        }

        var s1 = string.Join(',', reverseMovingMaxSum);
        Console.WriteLine($"ComputeReverseMovingMaxSum reverseMovingMaxSum: {s1}");
        var s2 = string.Join(',', reverseMovingMaxSumOriginIdx);
        Console.WriteLine($"ComputeReverseMovingMaxSum reverseMovingMaxSumOriginIdx: ${s2}");
        return (reverseMovingMaxSum, reverseMovingMaxSumOriginIdx);
    }

    private (int, int) ComputeMaxRangeIdxes(int[] movingSum, int[] reverseMovingMaxSum, int[] reverseMovingMaxSumOriginIdx)
    {
        int maxRange = 0;
        int maxRangeStartIdx = 0;
        int maxRangeEndIdx = 0;
        for (int idx = 0; idx < movingSum.Length - 1; idx++)
        {
            int prevSum = idx > 0 ? movingSum[idx - 1] : 0;
            int curRange = reverseMovingMaxSum[idx] - prevSum;
            if (curRange > maxRange)
            {
                maxRange = curRange;
                maxRangeStartIdx = idx;
                maxRangeEndIdx = reverseMovingMaxSumOriginIdx[idx];
            }
        }

        Console.WriteLine($"ComputeMaxRangeIdxes {maxRangeStartIdx}, {maxRangeEndIdx}");
        return (maxRangeStartIdx, maxRangeEndIdx);
    }
}