using System;
using System.Collections.Generic;
using System.IO;

namespace Caverns_Routing_Application
{
    class Program
    {
        static void Main(string[] args)
        {
            //Get file location from argument
            string path = args[0] + ".cav";

            //Check if file exists
            if(File.Exists(path)){
                Console.WriteLine("File does not exist");
                System.Environment.Exit(0);
            }
            
            //Extract info from file
            String[] all = File.ReadAllText(path).Split(',');

            int cav_num = Int32.Parse(all[0]);
            List<Cave> caves = new List<Cave>();

            
        }
    }
}
