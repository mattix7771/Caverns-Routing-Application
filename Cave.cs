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
        private List<int> relationships = new List<int>();

        public Cave(int id, int x, int y, List<int> rel){
            this.id = id;
            this.x = x;
            this.y = y;
            this.relationships = rel;
        }

        public int Id {set{id = value;} get{return id;}}
        public int X {set{x = value;} get{return x;}}
        public int Y {set{y = value;} get{return y;}}
        public List<int> Relationsips {set{relationships = value;} get{return relationships;}}
    }
}
