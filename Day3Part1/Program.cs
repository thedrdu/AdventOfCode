// Author(s): thedrdu
// Date: 05/27/2022

using System;
using System.IO;
using System.Collections.Generic;
using System.Collections;
using System.Linq;

class Day3Part1Solver{
    public static void Main(string[] args){

        int totalInputs = 0;
        int[] occurrences = new int[12]; //NOTE: This length is hardcoded.

        using (StreamReader sr = new StreamReader("Day3_input.txt")){
            string? line;
            while((line = sr.ReadLine()) != null){
                for(int i = 0; i < line.Length; i++){
                    if(line[i] == '1'){
                        occurrences[i] += 1;
                    }
                }
                totalInputs++;
            }
        }
        /*
        By dividing occurrences[i] by totalInputs, we can see if 0 or 1 is more common(threshold is totalInputs/2)
        */
        string gamma = "", epsilon = "";
        foreach(int i in occurrences){
            if(i >= totalInputs/2){ //1 majority
                gamma += "1";
                epsilon += "0";
            }
            else{
                gamma += "0";
                epsilon += "1";
            }
        }
        int gammaInt = Convert.ToInt32(gamma, 2);
        int epsilonInt = Convert.ToInt32(epsilon, 2);

        Console.WriteLine(gammaInt * epsilonInt);
    }
}