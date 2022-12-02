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
                List<int> int_current_relationships = new List<int>();

                for (int p = 0; p/cav_num < cav_num; p+=cav_num){
                    int temp = relationships[i+p];

                    if(temp != 0){
                        current_relationships.Add(new Cave((p/cav_num)+1, all[(((p+cav_num)/cav_num)*2)-1], all[((p+cav_num)/cav_num)*2]));
                        int_current_relationships.Add((p / cav_num)+1);
                    }
                }
                //Create the cave with unknown (high) distance
                caves.Add(new Cave(i+1, all[j], all[j+1], 0, current_relationships, int_current_relationships));
            }

            //Starting and ending node
            startCave = caves[0];
            endCave = caves[caves.Count - 1];
            
            List<Cave> solution = new List<Cave>();



            //Main search loop
            while(success == false){

                //set urrent cave
                Cave current_cave;

                if(toVisit.Count == 0)
                    current_cave = startCave;
                else
                    current_cave = toVisit.Pop();

                if(current_cave == endCave)
                    success = true;

                //Add cave to visited list
                visited.Add(current_cave);

                //Calculate distances of neighbours
                foreach (Cave cave in current_cave.Relationsips){

                    //Distance between two relative nodes + distance from current node to beginning
                    caves[cave.Id-1].Distance = CalcDistance(caves[cave.Id-1], current_cave) + current_cave.Distance;

                    //Want to visit if it's not been visited and it's not already planned to be visited
                    if (!visited.Contains(caves[cave.Id - 1]))
                    {
                        if(!toVisit.Contains(caves[cave.Id - 1]))
                        {

                        }
                        //Add to want t visit list
                        toVisit.Push(caves[cave.Id - 1]);
                    }
                        
                        
                    //Console.WriteLine("Considering: " + caves[cave.Id - 1].Id + " Distance: " + caves[cave.Id - 1].Distance);
                }
                
                //Sort stack
                SortStack(toVisit);


                /*
                List<Cave> temp = new List<Cave>();
                foreach (Cave x in toVisit)
                {
                    temp = toVisit.ToList();
                }
                foreach (Cave x in temp)
                {
                    Console.Write(x.Id + ",");
                }
                Console.Write("\n");*/
            }

            //Console.WriteLine("Distance: " + caves[caves.Count-1].Id + " " + caves[caves.Count - 1].Distance);

            solution = visited;

            solution.Reverse();
            foreach (Cave i in solution) {
                i.Distance = 0;
                Console.Write(i.Id + ", "); 
            }

            

            for (int i = 0; i < solution.Count; i++)
            {
                if (solution[i].Id == 1) break;
                while (!solution[i+1].Int_relationships.Contains(solution[i].Id))
                {
                    solution.Remove(solution[i + 1]);
                }
            }

            Console.WriteLine("New: ");
            foreach (Cave i in solution) { Console.Write(i.Id + ", "); }



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
