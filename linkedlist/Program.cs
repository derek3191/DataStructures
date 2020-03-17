using System;
using System.Collections.Generic;

namespace linkedlist
{
    class Cell{
        public int CurrentValue;
        public List<int> PreviousValues = new List<int>();

        public Cell(int value){
            if(PreviousValues.Count != 0){
                PreviousValues.Add(CurrentValue);
                CurrentValue = value;
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            int[] states = { 1,0,0,0,0,1,0,0};
            int days = 0;

            var output = cellCompete(states, days);
            Console.WriteLine(output);
        }

        public static int[] cellCompete(int[] states, int days){
            int[] dummy = {0,1};
            
            LinkedList<Cell> houses = new LinkedList<Cell>();
            foreach(var state in states){
                Cell cell = new Cell(state);
                houses.AddLast(cell);
            }           

            Console.WriteLine(houses.First.Value.CurrentValue);
            return dummy;
        }
    }
}
