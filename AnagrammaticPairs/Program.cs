using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;

class Solution
{

    // Complete the sherlockAndAnagrams function below.
    static int sherlockAndAnagrams(string s)
    {
        int stringLength = s.Length;
        int anagramCount = 0;
        //Loop through lengths of substrings from 1 to strinLength
        for(int subLength = 1; subLength < stringLength; subLength++)
        {

            //Loop through each index of the string and get the substring
            for(int charIndex = 0; charIndex < stringLength - subLength; charIndex++)
            {
                //Build this substring
                string subString = s.Substring(charIndex, subLength);

                //Check with all other substrings of this length to the right of us (left already checked)
                for(int compareCharIndex = charIndex + 1; compareCharIndex <= stringLength - subLength; compareCharIndex++)
                {
                    string compareSubString = s.Substring(compareCharIndex, subLength);
                    if (CheckAnagram(subString, compareSubString))
                    {
                        anagramCount++;
                    }
                }
            }
        }
        return anagramCount;

    }

    static bool CheckAnagram(string item1, string item2)
    {
        int[] differenceArray = new int[26];

        foreach(char char1 in item1)
        {
            differenceArray[char1 - 'a']++;
        }
        foreach(char char2 in item2)
        {
            differenceArray[char2 - 'a']--;
        }
        return differenceArray.All(d => d == 0);

    }



    static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int q = Convert.ToInt32(Console.ReadLine());

        for (int qItr = 0; qItr < q; qItr++)
        {
            string s = Console.ReadLine();

            int result = sherlockAndAnagrams(s);

            textWriter.WriteLine(result);
        }

        textWriter.Flush();
        textWriter.Close();
    }
}
