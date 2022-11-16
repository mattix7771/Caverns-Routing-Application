using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Caverns_Routing_Application
{
    class Program
    {
        static void Main(string[] args)
        {
            //args[0] = @"C:\Users\matti\OneDrive\Napier\S3 - Artificial Intelligence\Caverns Routing Application\input1";
            //Get file location from argument
           // string path = args[0] + ".cav";
            string path  = @"C:\Users\matti\OneDrive\Napier\S3 - Artificial Intelligence\Caverns Routing Application\input1.cav";

            Console.WriteLine(path);
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

            //Add info to Cave objects
            for(int i = 0, j = 1; i < cav_num; i++, j+=2){
                List <Cave> current_relationships = new List<Cave>();

                for(int p = 0; p/7 < cav_num; p+=cav_num){
                    int temp = relationships[i+p];

                    if(temp != 0)
                        current_relationships.Add(new Cave((p/7)+1, all[(((p+7)/7)*2)-1], all[((p+7)/7)*2]));
                    

                }
                caves.Add(new Cave(i+1, all[j], all[j+1], current_relationships));
            }

            //Determine distances between caves
            foreach(Cave cave in caves){
                foreach(Cave rel in cave.Relationsips){
                    cave.Distances.Add(Distance(rel, cave));
                }
            }

            //Caves visited
            List <Cave> visited = new List<Cave>();

            //Caves to visit
            Stack<Cave> toVisit = new Stack<Cave>();

            //Starting and ending node
            Cave start = caves[0];
            Cave end = caves[caves.Count-1];
            
            bool success = false;

            

            
            //while(success == false){

                Cave current_cave = caves[3];
                List<Cave> current_rel = new List<Cave>();
                visited.Add(current_cave);

                foreach(Cave cave in current_cave.Relationsips){

                   //TODO  Put back current_rel.Add();

                    // double max_value = current_cave.Distances.Max();
                    // int index = current_cave.Distances.IndexOf(max_value);
                    // toVisit.Push(current_cave.Relationsips[index]);

                    //add distance attribute to cave object and that equals the nodes distance from the starting node               }


                
            //}

            Console.WriteLine(toVisit.Pop().Id);
            Console.WriteLine(toVisit.Pop().Id);
            Console.WriteLine(toVisit.Pop().Id);
            Console.WriteLine(toVisit.Pop().Id);



            
        }

        public static double Distance(Cave x, Cave y){
            double distance = Math.Sqrt( Math.Pow(y.X - x.X, 2) + Math.Pow(y.Y - x.Y, 2) );
            return distance;
        }
    }
}
