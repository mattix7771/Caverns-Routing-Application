using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Caverns_Routing_Application
{
    class Program
    {
        //Start and end node
        static Cave startCave;
        static Cave endCave;

        //Caves visited
        static List<Cave> visited = new List<Cave>();

        //Caves to visit/ Priority queue
        static Stack<Cave> toVisit = new Stack<Cave>();

        //End node reached
        static bool success = false;

        static void Main(string[] args)
        {
            //Get file location from argument
            
            //string path = args[0] + ".cav";
            string path  = @"C:\Users\matti\OneDrive\Napier\S3 - Artificial Intelligence\Caverns-Routing-Application\generated30-1.cav";

            //Check if file exists
            if(!File.Exists(path)){
                Console.WriteLine("File does not exist");
                System.Environment.Exit(0);
            }
            
            //Extract info from file
            int[] all = Array.ConvertAll(File.ReadAllText(path).Split(','), int.Parse);

            //Number of caves in system
            int cav_num = all[0];

            //Extraction of caves coordinates
            List<Cave> caves = new List<Cave>();
            //Caves relationships
            int[] relationships = all.Skip(cav_num*2+1).ToArray();

            //Add info and create Cave objects
            for(int i = 0, j = 1; i < cav_num; i++, j+=2){
                List <Cave> current_relationships = new List<Cave>();

                for(int p = 0; p/cav_num < cav_num; p+=cav_num){
                    int temp = relationships[i+p];

                    if(temp != 0){
                        current_relationships.Add(new Cave((p/cav_num)+1, all[(((p+cav_num)/cav_num)*2)-1], all[((p+cav_num)/cav_num)*2]));
                    }
                }
                //Create the cave with unknown (high) distance
                caves.Add(new Cave(i+1, all[j], all[j+1], 0, current_relationships));
            }

            //Starting and ending node
            startCave = caves[0];
            endCave = caves[caves.Count - 1];
            
            List<int> solution = new List<int>();



            //Main search loop
            while(success == false){

                //set urrent cave
                Cave current_cave;

                if(toVisit.Count == 0)
                    current_cave = startCave;
                else
                    current_cave = toVisit.Pop();

                Console.WriteLine("Looking at: " + current_cave.Id);
                /*while(solution.Count > 0 && !current_cave.Relationsips.Contains(new Cave())){
                    solution.Remove(solution.Last());
                }   //1,2         7
                solution.Add(current_cave.Id);*/

                if(current_cave == endCave)
                    success = true;

                //Add cave to visited list
                visited.Add(current_cave);

                //Console.Write("Considering: ");
                //Calculate distances of neighbours
                foreach (Cave cave in current_cave.Relationsips){

                    caves[cave.Id-1].Distance = CalcDistance(caves[cave.Id-1], current_cave) + current_cave.Distance;
                    if(!visited.Contains(caves[cave.Id-1]))
                        toVisit.Push(caves[cave.Id-1]);
                    Console.WriteLine("Considering: " + caves[cave.Id - 1].Id + " Distance: " + caves[cave.Id - 1].Distance);
                }
                
                //Sort stack
                SortStack(toVisit);
            }



            

            
        }

        //Eucledean distance calculator
        public static double CalcDistance(Cave x, Cave y){
            double distance = Math.Sqrt( Math.Pow(y.XCoordinate - x.XCoordinate, 2) + Math.Pow(y.YCoordinate - x.YCoordinate, 2) );
            return distance;
        }

        //Method to order the stack by distances
        public static void SortStack(Stack<Cave> stack){

            //Check that there is more than 1 item in stack
            if(stack.Count <= 0) return;

            Stack<Cave> temp_stack = new Stack<Cave>();

            //Loop for all items in stack
            while(stack.Count > 0){

                Cave value = stack.Pop();
                double distance = value.Distance;

                //Return items to input stack if not in order
                while(temp_stack.Count > 0 && temp_stack.Peek().Distance < distance){
                    stack.Push(temp_stack.Pop());
                }
                //Add item to temporary stack
                temp_stack.Push(value);
            }

            //Equate temporary and original stacks
            toVisit = temp_stack;
        }
    }
}
