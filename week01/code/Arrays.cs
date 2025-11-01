using System;
using System.Collections.Generic;

public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.  For 
    /// example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}.  Assume that length is a positive
    /// integer greater than 0.
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns>
    public static double[] MultiplesOf(double number, int length)
    {
        // My implementation plan:
        // 1. Create a new array of doubles with the specified length
        // 2. Use a for loop to iterate from 0 to length - 1
        // 3. For each index i, calculate the multiple as: number * (i + 1)
        // 4. Store each calculated multiple in the array
        // 5. Return the completed array
        
        double[] result = new double[length];
        
        for (int i = 0; i < length; i++)
        {
            result[i] = number * (i + 1);
        }
        
        return result;
    }

    /// <summary>
    /// Rotate the 'data' to the right by the 'amount'.  For example, if the data is 
    /// List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9} and an amount is 3 then the list after the function runs should be 
    /// List<int>{7, 8, 9, 1, 2, 3, 4, 5, 6}.  The value of amount will be in the range of 1 to data.Count, inclusive.
    ///
    /// Because a list is dynamic, this function will modify the existing data list rather than returning a new list.
    /// </summary>
    public static void RotateListRight(List<int> data, int amount)
    {
        // My implementation plan:
        // 1. Calculate the split index: data.Count - amount
        // 2. Get the right portion of the list (from split index to end)
        // 3. Get the left portion of the list (from start to split index)
        // 4. Clear the original list
        // 5. Add the right portion first, then the left portion
        
        int splitIndex = data.Count - amount;
        List<int> rightPortion = data.GetRange(splitIndex, amount);
        List<int> leftPortion = data.GetRange(0, splitIndex);
        
        data.Clear();
        data.AddRange(rightPortion);
        data.AddRange(leftPortion);
    }
}