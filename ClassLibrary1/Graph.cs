using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GraphLibrary
{
    
    public abstract class Graph 
    {
        private int NextVertextId;
        private int NextEdgeId;
        public KeyValuePair<string, Vertex> V;
        public KeyValuePair<string, Vertex> E;
        public Graph()
        {
            V = new KeyValuePair<string, Vertex>();
            E = new KeyValuePair<string, Vertex>();
        }
        public Vertex AddVertex( Vertex V ) 
        {
            
           
           
        }
        public Edge AddEdge(string head , string tail)
        {
            Edge Retval = null; 
            if (!V.Key.Contains(a)) |(!V.Key.Contains(b)) {
                return null;
            }
            return Retval;
        }
        public Edge AddEdge(Vertex head , Vertex tail)
        {
            Edge Retval = null; 
            if (!V.Key.Contains(a)) || (!V.Key.Contains(a)));
            return Retval;
        }
    }

    // Vertext class - Abstract root. 
    public virtual class Vertex
    {
        public string name;
        public int Direction = 0;
        public int Color = 0;
        public float Weight = 0;
    }

    public virtual class Edge  
    {
        public string name;
        private Vertex v1=null;
        private Vertex v2 = null;
        public int Direction=0;
        public int Color=0;
        public float Weight=0;

    }
}
