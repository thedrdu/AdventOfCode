// Author(s): thedrdu
// Date: 05/27/2022

using System;
using System.IO;
using System.Collections.Generic;
using System.Collections;
using System.Linq; // <-- New import

class Day1Part2Solver{
    
    public static void Main(string[] args){
        /*
        Idea: Queue implementation to track triplets
        */

        Queue<int> triplet = new Queue<int>();
        int count = 0, prevValue = 0;

        using (StreamReader sr = new StreamReader("Day1_input.txt")){
            string? line;

            //The first 3 numbers have no previous sum, so we will just add them to the queue to start.
            for(int i = 0; i < 3; i++){
                triplet.Enqueue(Int32.Parse(sr.ReadLine()));
            }

            while((line = sr.ReadLine()) != null){
                int lineInt = Int32.Parse(line); 

                /*
                At this point, the queue has 3 values, so we are going to store this as a "previous" value, 
                then dequeue in preparation for the next triplet.
                */
                prevValue = triplet.Sum();
                triplet.Dequeue();

                triplet.Enqueue(lineInt);
                if(triplet.Sum() > prevValue){
                    count++;
                }
            }
        }
        Console.WriteLine(count);
    }
}