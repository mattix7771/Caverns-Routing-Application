using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caverns_Routing_Application
{
    class Cave
    {
        //Identifier, coordinates
        private int id;
        private int x;
        private int y;
        private List<Cave> relationships = new List<Cave>();
        private List<double> distances = new List<double>();

        public Cave(int id, int x, int y, List<Cave> rel){
            this.id = id;
            this.x = x;
            this.y = y;
            this.relationships = rel;
        }

        public Cave(int id, int x, int y){
            this.id = id;
            this.x = x;
            this.y = y;
        }

        public int Id {set{id = value;} get{return id;}}
        public int X {set{x = value;} get{return x;}}
        public int Y {set{y = value;} get{return y;}}
        public List<Cave> Relationsips {set{relationships = value;} get{return relationships;}}
        public List<double> Distances {set{distances = value;} get{return distances;}}


        public String toString(){
            return "Cave " + id + ": (" + "x: " + x + " y: " + y + ")";
        }
    }
}
