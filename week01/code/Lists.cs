using System;
using System.Collections.Generic;

public static class Lists
{
    public static void RotateListRight(List<int> data, int amount)
    {
        // My plan for implementing RotateListRight:
        // 1. I will calculate the split point: data.Count - amount
        //    This gives me the index where the rotation occurs
        // 2. I will get the right portion of the list (the part that moves to the front)
        //    This is from split point to the end of the list
        // 3. I will get the left portion of the list (the part that moves to the back)
        //    This is from beginning to split point
        // 4. I will clear the original list to prepare for reconstruction
        // 5. I will add the right portion first (this becomes the new beginning)
        // 6. I will add the left portion after (this becomes the new end)
        
        // I calculate where to split the list for rotation
        int splitIndex = data.Count - amount;
        
        // I extract the right portion that will move to the front
        List<int> rightPortion = data.GetRange(splitIndex, amount);
        
        // I extract the left portion that will move to the back
        List<int> leftPortion = data.GetRange(0, splitIndex);
        
        // I clear the original list to rebuild it in rotated order
        data.Clear();
        
        // I add the right portion first (the part that was at the end)
        data.AddRange(rightPortion);
        
        // I add the left portion after (the part that was at the beginning)
        data.AddRange(leftPortion);
        
        // Now the list is successfully rotated to the right by the specified amount
    }
}