// Author(s): thedrdu
// Date: 06/07/2022

using System;
using System.IO;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text.RegularExpressions;
public class Board{
    public int[,] tiles = new int[5,5];
    public bool[,] marked = new bool[5,5];
    public Board(int[,] tiles){
        this.tiles = tiles;
    }
    public void mark(int x){
        for(int i = 0; i < 5; i++){
            for(int j = 0; j < 5; j++){
                if(tiles[i,j] == x){
                    marked[i,j] = true;
                }
            }
        }
    }
    public void print(){
        Console.WriteLine();
        for(int i = 0; i < 5; i++){
            for(int j = 0; j < 5; j++){
                Console.Write(tiles[i,j] + " ");
            }
            Console.WriteLine();
        }
        for(int i = 0; i < 5; i++){
            for(int j = 0; j < 5; j++){
                Console.Write(marked[i,j] + " ");
            }
            Console.WriteLine();
        }
    }

    public int sumUnmarked(){
        int sum = 0;
        for(int i = 0; i < 5; i++){
            for(int j = 0; j < 5; j++){
                if(marked[i,j] == false){
                    sum += tiles[i,j];
                }
            }
        }
        return sum;
    }
    public bool checkValid(){
        for(int i = 0; i < 5; i++){ //Check rows
            bool complete = true;
            for(int j = 0; j < 5; j++){
                if(marked[i,j] == false){
                    complete = false;
                }
            }
            if(complete){
                return true;
            }
        }
        for(int i = 0; i < 5; i++){ //Check cols
            bool complete = true;
            for(int j = 0; j < 5; j++){
                if(marked[j,i] == false){
                    complete = false;
                }
            }
            if(complete){
                return true;
            }
        }
        return false;
    }
}
class Day4Part1Solver{

    public static void Main(string[] args){
        string[] guesses;
        List<Board> boards = new List<Board>();
        using (StreamReader sr = new StreamReader("Day4_input.txt")){
            string? line;
            guesses = sr.ReadLine().Split(',');
            // foreach(string s in guesses){
            //     Console.Write(s + " ");
            // }
            while((line = sr.ReadLine()) != null){
                if(line == ""){
                    int[,] tiles = new int[5,5];
                    for(int i = 0; i < 5; i++){ //read in 5 rows
                        line = sr.ReadLine();
                        line = line.Trim();
                        string[] row = Regex.Split(line, @"\s{1,}");
                        // foreach(string s in row){
                        //     Console.Write(s + " / ");
                        // }
                        int[] rowInt = new int[5];
                        int tempIndex = 0;
                        foreach(string s in row){
                            rowInt[tempIndex] = Int32.Parse(s);
                            tempIndex++;
                        }
                        for(int j = 0; j < rowInt.Length; j++){
                            tiles[i,j] = rowInt[j];
                            Console.Write(tiles[i,j] + " / ");
                        }
                        Console.WriteLine();
                    }
                    boards.Add(new Board(tiles));
                }
                Console.WriteLine(boards.Count);
            }
        }
        //Now we have all the boards
        foreach(string s in guesses){
            foreach(Board b in boards){
                b.mark(Int32.Parse(s));
                if(b.checkValid() == true){
                    b.print();
                    Console.WriteLine("Answer: " + Int32.Parse(s) * b.sumUnmarked());
                    return;
                }
            }
        }
    }

}