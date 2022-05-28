// Author(s): thedrdu
// Date: 05/27/2022

using System;
using System.IO;
using System.Collections.Generic;
using System.Collections;

class Day1Solver{
    
    public static void Main(string[] args){
        int count = 0;
        using (StreamReader sr = new StreamReader("Day1_input.txt")){
            string? line;
            int? previous = Int32.Parse(sr.ReadLine());
            while((line = sr.ReadLine()) != null)
            {
                int lineInt = Int32.Parse(line); 
                if(lineInt > previous){
                    count++;
                }
                previous = lineInt;
            }
        }
        Console.WriteLine(count);

    }
}