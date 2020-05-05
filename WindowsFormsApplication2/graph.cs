using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication2
{
    class Vector:IComparable
    {
        public double X,Y,Z;

        public Vector(double x=0, double y=0, double z=0)
        {
            X = x;
            Y = y;
            Z = z;
        }
        public double Distance(Vector v)
        {
            return Math.Sqrt(((v.X - X) * (v.X - X)) + ((v.Y - Y) * (v.Y - Y)) + ((v.Z - Z) * (v.Z - Z)));
        }
        public static Vector operator +(Vector v, Vector u)
        {
            return new Vector(v.X + u.X, v.Y + u.Y, v.Z + u.Z);
        }
        public static Vector operator *(Vector v, double d)
        {
            return new Vector(v.X * d, v.Y * d, v.Z * d);
        }
        public static Vector operator -(Vector v, Vector u)
        {
            return v + (u * -1);
        }

        int IComparable.CompareTo(object obj)
        {
            // let it throw the error if necessary
            Vector v = obj as Vector;
            
            if ((v.X == X) && (v.Y == Y) && (v.Z == Z))
            {
                // if they're the same, assert equality
                return 0;
            }
            // otherwise, Sort order is X,Y,Z ascending (dominant X)
            if (v.X > X) return 1;
            if (v.Y > Y) return 1;
            if (v.Z > Z) return 1;
            return -1;
        }
    }
    class Graph
    {
        /// <summary>
        ///  works by keeping an n x n node map with enumerations for named nodes. 
        /// </summary>
        private Dictionary<string, int> NodeLabels;
        private int[,] NodeLinks;
        private int NextNode = 0;
        private int Count = 0;
        public Graph(int n)
        {
            NodeLinks =  new int[n,n];
            NodeLabels = new Dictionary<string,int>(n);
        }
        public void AddNode(string Name)
        {
            NodeLabels.Add(Name,NextNode);
            NextNode++;
            Count++;
        }
        public void AddLink(string Source, string Destination, int count = 1)
        {
            int s = NodeLabels[Source];
            int d = NodeLabels[Destination];
            NodeLinks[s,d]+=count;
        }
        public void RemoveLink(string Source, string Destination, int count = 1)
        {
            int s = NodeLabels[Source];
            int d = NodeLabels[Destination];
            NodeLinks[s, d] -= count;
        }
        public void RemoveNode(string name)
        {
            /* TODO : 
             * swap nodes b, e in n x n  
             * 
             */
        }
        /// <summary>
        /// Returns true if there exists an edge between n1 and n2 in direction degree
        /// </summary>
        /// <param name="n1">Name of node 1</param>
        /// <param name="n2">Name of node 2</param>
        /// <param name="direction">nature of adjacency: 0=not, 1=one direction, 2=two directions</param>
        /// <returns></returns>
        public bool Adjacent(string n1, string n2, int direction=2)
        {
            
            return false;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="n1"></param>
        /// <param name="n2"></param>
        /// <param name="completeness"></param>
        /// <returns></returns>
        public bool Neighbors(string n1, string n2, int completeness=1)
        {
            return false;
        }
        
    }
    class Graph2D:Graph 
    {
        
        public Dictionary<string, Vector> Location;

        public Graph2D(int size=256)
            : base(size)
        {
            Location = new Dictionary<string, Vector>(size);
        }
         public void AddNode(string Name, Vector location)
        {
            base.AddNode(Name);
            this.Location.Add(Name, location);
        }
    }
    

}
