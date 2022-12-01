using System;
using System.Collections.Generic;

namespace Caverns_Routing_Application
{
    class Cave
    {
        //Identifier, coordinates, distance and connected caves
        private int id;
        private int xCoordinate;
        private int yCoordinate;
        private double distance;
        private List<Cave> relationships = new List<Cave>();

        public Cave(int id, int xCoordinate, int yCoordinate, double distance, List<Cave> relationships){
            this.id = id;
            this.xCoordinate = xCoordinate;
            this.yCoordinate = yCoordinate;
            this.distance = distance;
            this.relationships = relationships;
        }

        public Cave(int id, int x, int y, List<Cave> relationships){
            this.id = id;
            this.xCoordinate = x;
            this.yCoordinate = y;
            this.relationships = relationships;
        }

        public Cave(int id, int x, int y){
            this.id = id;
            this.xCoordinate = x;
            this.yCoordinate = y;
        }

        public int Id {set{id = value;} get{return id;}}
        public int XCoordinate {set{xCoordinate = value;} get{return xCoordinate;}}
        public int YCoordinate {set{yCoordinate = value;} get{return yCoordinate;}}
        public double Distance {set{distance = value;} get{return distance;}}
        public List<Cave> Relationsips {set{relationships = value;} get{return relationships;}}


        public String toString(){
            return "Cave " + id + ": (" + "x: " + xCoordinate + " y: " + yCoordinate + ")";
        }
    }
}
