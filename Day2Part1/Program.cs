// Author(s): thedrdu
// Date: 05/27/2022

using System;
using System.IO;
using System.Collections.Generic;
using System.Collections;
using System.Linq;

class Day1Part2Solver{
    public static void Main(string[] args){

        int distance = 0, depth = 0;
        string[] command; //stores the command and corresponding value

        using (StreamReader sr = new StreamReader("Day2_input.txt")){
            string? line;
            while((line = sr.ReadLine()) != null){
                command = line.Split(' ');

                switch(command[0]){
                    case "forward":
                        distance += Int32.Parse(command[1]);
                        break;
                    case "down":
                        depth += Int32.Parse(command[1]);
                        break;
                    case "up":
                        depth -= Int32.Parse(command[1]);
                        break;
                }

            }
        }
        Console.WriteLine(distance * depth);
    }
}