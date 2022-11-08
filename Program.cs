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
            //string path = args[0] + ".cav";
            string path  = @"C:\Users\matti\OneDrive\Napier\S3 - Artificial Intelligence\Caverns Routing Application\input1.cav";

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
                List <int> current_relationships = new List<int>();
                for(int p = 0; p/7 < cav_num; p+=cav_num){
                    current_relationships.Add(relationships[i+p]);
                    
                    /*
                    int temp = relationships[i+p];
                    if(temp != 0)
                        current_relationships.Add(relationships[i+p]);*/
                    
                }
                caves.Add(new Cave(i+1, all[j], all[j+1], current_relationships));
            }

            //Caves visited
            List <Cave> visited = new List<Cave>();

            //Starting and ending node
            Cave start = caves[0];
            Cave end = caves[caves.Count-1];
            
            bool success = false;

            for(int p = 0; p < caves.Count; p++){
                    //Console.WriteLine("Cave " + caves[p].Id);
                    Console.WriteLine(" Rel: " + caves[p].Relationsips[3]);
            }

            /*
            while(success == false){

                Cave current_cave = start;
                visited.Add(current_cave);

                
                
                


            }*/



            
        }
    }
}
