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
            //Get file location from argument
            string path = args[0] + ".cav";

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
            for(int i = 0, j = 1; i < cav_num; i++, j+=2){
                caves.Add(new Cave(i+1, all[j], all[j+1]));
            }

            //Caves relationships
            int[] relationships = all.Skip(cav_num*2+1).ToArray();
            



            
        }
    }
}
