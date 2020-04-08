using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem.utils
{
    public class SplitArrayMethods 
    {
        public readonly bool IsPossibleToSplit;
        
        public SplitArrayMethods(int[] array)
        {
            IsPossibleToSplit = SplitArraySameAverage(array);
        }
        
        //checking the condition
        private static bool IsPossible (int sum, int n, int m)
        {
            var possible = false;
            
            for (var i = 1; i <= m; ++i)
                if (sum * i % n == 0) possible = true;
            
            return possible;
        }

        private static bool SplitArraySameAverage(IReadOnlyCollection<int> array)
        {
            var n = array.Count;
            var sum = array.Sum();
            var m = n / 2;

            //first step
            if (!IsPossible(sum, n, m)) return false;
            
            //second step
            //initialize the table
            var map = new HashSet<int>[m + 1];
            
            for (var i = 0; i <= m; ++i) 
                map[i] = new HashSet<int>();
            
            //initialization of the first row
            //the sum of the partitions with 0 elements is 0
            map[0].Add(0);
            
            //populate the table
            foreach (var num in array) 
            {
                for (var i = m; i > 0; --i) 
                {
                    //loop through all the elements in the previous rows  
                    foreach (var prev in map[i - 1]) 
                    {
                        //add the current number to the current elements and insert it into the current row
                        map[i].Add(prev + num);
                    }
                }
            }
            
            //check the condition 
            //if true, we look to see if  we can found the value in the table
            //if both are true, then we return true, the splitting can be done successfully
            for (var i = 1; i <= m; ++i)
                if (sum * i % n == 0 && map[i].Contains(sum * i / n)) return true;
            
            return false;
        }
        
    }
}