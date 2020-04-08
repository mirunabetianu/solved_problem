using System;

namespace Problem.input
{
    public class FileReader
    {
        public readonly int[] Array;
        public FileReader(string path)
        {
            //reading from the file
            var fileContent = System.IO.File.ReadAllText(path);

            //remove the braces
            var myArray = fileContent.Substring(1, fileContent.Length -2);

            //remove the commas 
            var arraySplit = myArray.Split(',');

            //transform the array of strings into an array of integers
            var arrayToInt = new int[arraySplit.Length];

            var i = 0;
            foreach(var s in arraySplit)
            {
                arrayToInt[i] = int.Parse(s);
                i++;
            }
            
            
            Array = arrayToInt;
        }
        
    }
}