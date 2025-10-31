using System;
using System.Collections.Generic;

public static class Arrays
{
    public static double[] MultiplesOf(double startingNumber, int numberOfMultiples)
    {
        // My plan for implementing MultiplesOf:
        // 1. I will create a new array of doubles with the specified number of multiples
        // 2. I will use a for loop to iterate from 0 to numberOfMultiples - 1
        // 3. For each iteration, I will calculate the multiple using: startingNumber * (i + 1)
        //    I use i+1 because I want multiples starting from the number itself
        // 4. I will store each calculated multiple in the array at the current index
        // 5. I will return the completed array
        
        // I create the result array with the required size
        double[] result = new double[numberOfMultiples];
        
        // I fill the array with multiples using a loop
        for (int i = 0; i < numberOfMultiples; i++)
        {
            // I calculate the current multiple: starting number multiplied by (index + 1)
            result[i] = startingNumber * (i + 1);
        }
        
        // I return the completed array of multiples
        return result;
    }
}