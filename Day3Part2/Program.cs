// Author(s): thedrdu
// Date: 06/07/2022

using System;
using System.IO;
using System.Collections.Generic;
using System.Collections;
using System.Linq;

class Day3Part2Solver{
    public static int[] occurrences = new int[12]; //NOTE: This length is hardcoded.

    public static void Main(string[] args){

        int totalInputs = 0;
        HashSet<string> oxygenNumbers = new HashSet<string>();
        Queue<string> oxygenDelete = new Queue<string>();
        Queue<string> c02Delete = new Queue<string>();
        string oxygenRating = string.Empty, c02Rating = string.Empty;

        using (StreamReader sr = new StreamReader("Day3_input.txt")){
            string? line;
            while((line = sr.ReadLine()) != null){
                oxygenNumbers.Add(line);
                for(int i = 0; i < line.Length; i++){
                    if(line[i] == '1'){
                        occurrences[i] += 1;
                    }
                }
                totalInputs++;
            }
        }
        HashSet<string> c02Numbers = new HashSet<string>(oxygenNumbers);
        /*
        By dividing occurrences[i] by totalInputs, we can see if 0 or 1 is more common(threshold is totalInputs/2)
        */
        for(int i = 0; i < 12; i++){
            populateOccurrences(oxygenNumbers);
            if(occurrences[i]*2 >= oxygenNumbers.Count){ //1 majority
                foreach(string s in oxygenNumbers){
                    if(s[i] == '0'){
                        oxygenDelete.Enqueue(s);
                    }
                }
            }
            else{ //0 majority
                foreach(string s in oxygenNumbers){
                    if(s[i] == '1'){
                        oxygenDelete.Enqueue(s);
                    }
                }
            }
            while(oxygenDelete.Count > 0){
                if(oxygenNumbers.Count == 1){
                    goto Next;
                }
                oxygenNumbers.Remove(oxygenDelete.Dequeue());
            }
        }
        Next:

        for(int i = 0; i < 12; i++){
            populateOccurrences(c02Numbers);
            if(occurrences[i]*2 >= c02Numbers.Count){ //0 minority
                foreach(string s in c02Numbers){
                    if(s[i] == '1'){
                        c02Delete.Enqueue(s);
                    }
                }
            }
            else{ //1 minority
                foreach(string s in c02Numbers){
                    if(s[i] == '0'){
                        c02Delete.Enqueue(s);
                    }
                }
            }
            while(c02Delete.Count > 0){
                if(c02Numbers.Count == 1){
                    goto Final;
                }
                c02Numbers.Remove(c02Delete.Dequeue());
            }
        }

        Final:
        foreach(string s in oxygenNumbers){
            oxygenRating = s;
        }
        foreach(string s in c02Numbers){
            c02Rating = s;
        }

        Console.WriteLine(Convert.ToInt32(oxygenRating, 2) * Convert.ToInt32(c02Rating, 2));
        Console.WriteLine();

    }

    public static void populateOccurrences(HashSet<string> remaining){
        for(int i = 0; i < 12; i++){
            occurrences[i] = 0;
            foreach(string s in remaining){
                if(s[i] == '1'){
                    occurrences[i]++;
                }
            }
        }
    }
}