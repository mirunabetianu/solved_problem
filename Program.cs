using System;
using Problem.input;
using Problem.utils;

namespace Problem
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            //read the array from a file
            var fileReader = new FileReader("../../../input/array.txt");
            
            //check if the input meets the requirements of the problem
            var splitArrayMethods = new SplitArrayMethods(fileReader.Array);
            
            //output the result
            Console.Write(splitArrayMethods.IsPossibleToSplit);
        }
    }
}