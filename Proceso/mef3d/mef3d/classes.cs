using System;
using System.Collections.Generic;
using System.Text;

namespace mef3d
{

    public enum indicators
    {
        NOTHING
    }

    public enum lines
    {
        NOLINE,
        SINGLELINE,
        DOUBLELINE
    }

    public enum modes
    {
        NOMODE,
        INT_FLOAT,
        INT_FLOAT_FLOAT_FLOAT,
        INT_INT_INT_INT_INT
    }

    public enum parameters
    {
        Ei,
        WX,
        WY,
        WZ
    }

    public enum sizes
    {
        NODES,
        ELEMENTS,
        DIRICHLET,
        NEUMANN
    }

    public abstract class Item
    {
        protected int id { get; set; }
        protected float x { get; set; }
        protected float y { get; set; }
        protected float z { get; set; }
        protected int node1 { get; set; }
        protected int node2 { get; set; }
        protected int node3 { get; set; }
        protected int node4 { get; set; }
        protected float value { get; set; }

        public abstract void setValues(int a, float b, float c, float d, int e, int f, int g, int h, float i);
    }

    public class Node : Item
    {
        public override void setValues(int a, float b, float c, float d, int e, int f, int g, int h, float i)
        {
            id = a;
            x = b;
            y = c;
            z = d;
        }
    }

    public class Element : Item
    {
        public override void setValues(int a, float b, float c, float d, int e, int f, int g, int h, float i)
        {
            id = a;
            node1 = e;
            node2 = f;
            node3 = g;
            node4 = h;
        }
    }

    public class Condition : Item
    {
        public override void setValues(int a, float b, float c, float d, int e, int f, int g, int h, float i)
        {
            node1 = e;
            value = i;
        }
    }

    public class Mesh
    {
        public float[] param = new float[4];
        public int[] sizes = new int[4];
        public List<Node> node_list = new List<Node>();
        public List<Element> element_list = new List<Element>();
        public List<int> indices_dirich = new List<int>();
        public List<Condition> dirichlet_list = new List<Condition>();
        public List<Condition> neumann_list = new List<Condition>();

        public void setParameters(float ei, float wx, float wy, float wz)
        {
            param[Convert.ToInt32(parameters.Ei)] = ei;
            param[Convert.ToInt32(parameters.WX)] = wx;
            param[Convert.ToInt32(parameters.WY)] = wy;
            param[Convert.ToInt32(parameters.WZ)] = wz;
        }



    }
}
