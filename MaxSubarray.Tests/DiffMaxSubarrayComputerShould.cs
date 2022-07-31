using System.Collections.Generic;
using System.Linq;
using Xunit;

public class DiffMaxSubarrayComputerShould
{
    [Fact]
    public void ComputeMaxSubarray()
    {
        int[] sampleInput = { 1, -1, 1, -1, 1, -1, 1, -1, -3, 4, 5, -2, 10, 1, -5, 1, -1 };

        int[] output = new DiffMaxSubarrayComputer().Compute(sampleInput);

        int[] sampleInputMaxSubarray = { 4, 5, -2, 10, 1 };
        Xunit.Assert.Equal(sampleInputMaxSubarray, output);
    }

    [Fact]
    public void ComputeMaxSubarray2()
    {
        int[] sampleInput = { 1, -1, 1, -1, 1, -1, 1, -1, -3, 4, 5, -2, 10, 1, -1, 1, -1 };

        int[] output = new DiffMaxSubarrayComputer().Compute(sampleInput);

        int[] sampleInputMaxSubarray = { 4, 5, -2, 10, 1, -1, 1 };
        Xunit.Assert.Equal(sampleInputMaxSubarray, output);
    }
}