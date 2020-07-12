using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;

namespace Commonwealth
{

    public partial class Form1 : Form
    {
        const int wid = 500;
        const int hei = 500;
        const float ScaleX = (float)wid / 2 / 100000;
        const float ScaleY = -((float)hei / 2 / 100000);

        const int ofsx = 8;
        const int ofsy = 8;

        int maxn=10;
        static readonly Settlement[] settlements = new Settlement[]
            {
                new Settlement {Name="Sunshine Tidings Co-op",X=-82773,Y=40161,Index=0},
                new Settlement {Name="Sanctuary Hills",X=-78806,Y=89795,Index=1},
                new Settlement {Name="Abernathy farm",X=-75425,Y=67256,Index=2},
                new Settlement {Name="Red Rocket truck stop",X=-70335,Y=81410,Index=3},
                new Settlement {Name="Graygarden",X=-49370,Y=18562,Index=4},
                new Settlement {Name="Oberland Station",X=-46016,Y=-5502,Index=5},
                new Settlement {Name="Starlight Drive-in",X=-35804,Y=59701,Index=6},
                new Settlement {Name="Somerville Place",X=-34704,Y=-91140,Index=7},
                new Settlement {Name="Egret Tours Marina",X=-28755,Y=-61535,Index=8},
                new Settlement {Name="Tenpines Bluff",X=-22812,Y=87906,Index=9},
                new Settlement {Name="Hangman's Alley",X=-22545,Y=-17546,Index=10},
                new Settlement {Name="Outpost Zimonja",X=-8415,Y=98515,Index=11},
                new Settlement {Name="Covenant",X=-8152,Y=47109,Index=12},
                new Settlement {Name="Taffington Boathouse",X=4248,Y=47793,Index=13},
                new Settlement {Name="Murkwater construction site",X=5369,Y=-94249,Index=14},
                new Settlement {Name="Jamaica Plain",X=7072,Y=-65928,Index=15},
                new Settlement {Name="Greentop Nursery",X=30375,Y=67357,Index=16},
                new Settlement {Name="County Crossing",X=38529,Y=31164,Index=17},
                new Settlement {Name="Boston Airport",X=48100,Y=-3361,Index=18},
                new Settlement {Name="The Castle",X=48147,Y=-48523,Index=19},
                new Settlement {Name="Finch Farm",X=54432,Y=47353,Index=20},
                new Settlement {Name="The Slog",X=54583,Y=67383,Index=21},
                new Settlement {Name="Warwick Homestead",X=57494,Y=-78533,Index=22},
                new Settlement {Name="Nordhagen Beach",X=63698,Y=2432,Index=23},
                new Settlement {Name="Spectacle Island",X=68299,Y=-55268,Index=24},
                new Settlement {Name="Coastal Cottage",X=70679,Y=88556,Index=25},
                new Settlement {Name="Kingsport Lighthouse",X=87201,Y=58846,Index=26},
                new Settlement {Name="Croup Manor",X=90135,Y=35935,Index=27},
                new Settlement {Name="Bunker Hill",X=18196,Y=12609,Index=28}
            };

        //double[,] dist;

        struct Connection
        {
            public int Source;
            public int Target;
            public double Distance;

            public Connection(int initSource,int initTarget)
                {
                    Source = initSource;
                    Target = initTarget;
                    Distance = Math.Sqrt(Math.Pow(settlements[initSource].X - settlements[initTarget].X, 2) + Math.Pow(settlements[initSource].Y - settlements[initTarget].Y, 2));
            }
        }

       List<Connection> allconnections;
        List<Connection> connections;

        struct Settlement
        {
            public string Name;
            public int X;
            public int Y;
            public int Index;

            public float ScaledX { get { return ofsx + wid / 2 + X * ScaleX; } }
            public float ScaledY { get { return ofsy + hei / 2 + Y * ScaleY; } }
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //InitDistances();
            InitConnections();
            CalculateDistance();
        }

        private void CalculateDistance()
        {
            lblDistance.Text = String.Format("{0:n0}", Math.Round(connections.Sum(x => x.Distance)));
        }

        private void InitConnections()
        {

            allconnections = new List<Connection>();
            for (int i = 0; i < settlements.Length - 1; i++)
            {

                for (int j = i+1; j < settlements.Length; j++)
                {
                    allconnections.Add(new Connection(i, j));
                }
                
            }

            connections = new List<Connection>();
            for (int i = 1; i < settlements.Length; i++)
            {
                connections.Add(new Connection(0, i));
            }
            
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            float x0;
            float y0;

            Graphics g = e.Graphics; //this.CreateGraphics();
            Rectangle r = new Rectangle(ofsx, ofsy, wid + 80, hei + 16);
            Pen p = new Pen(Color.DarkGreen);
            Pen pRed = new Pen(Color.LightGreen);
            Brush b = new SolidBrush(Color.DarkGreen);
            Font f = new Font("Calibri", 8);
            g.FillRectangle(new SolidBrush(Color.Black), r);

            foreach (Connection c in connections)
            {
                g.DrawLine(pRed, settlements[c.Source].ScaledX + 1, settlements[c.Source].ScaledY, settlements[c.Target].ScaledX + 1, settlements[c.Target].ScaledY);
            }

            foreach (Settlement s in settlements)
            {
                x0 = s.ScaledX;
                y0 = s.ScaledY;
                g.DrawEllipse(p, x0 - 2, y0 - 2, 5, 5);
                g.DrawString(s.Name, f, b, x0 + 5, y0 + 5);
            }
            pRed.Dispose();
            p.Dispose();
            b.Dispose();
            f.Dispose();
            g.Dispose();
        }

        private void btnCalc_Click(object sender, EventArgs e)
        {

        }

        private void btnInit_Click(object sender, EventArgs e)
        {
            InitConnections();
            CalculateDistance();
            this.Refresh();
        }

        private void btnBorder_Click(object sender, EventArgs e)
        {
            MakeBorder();
            CalculateDistance();
            this.Refresh();
        }

        private void MakeBorder()
        {
            int west, east, north, south;
            
            connections = new List<Connection>();

            var settlementlist = settlements.ToList();

            Settlement westitem = settlementlist.OrderBy(x => x.X).First();
            
            west = westitem.Index;
            east = (settlementlist.OrderBy(x => x.X).Last()).Index;
            north = (settlementlist.OrderBy(x => x.Y).First()).Index;
            south = (settlementlist.OrderBy(x => x.Y).Last()).Index;

            //connections.Add(new Connection(west, east));
            //connections.Add(new Connection(north, south));

            int x0 = settlements[west].X;
            int y0 = settlements[west].Y;

            settlementlist.Remove(westitem);
            var nextitem = settlementlist.OrderBy(s => (s.Y - y0) / (s.X - x0)).First();
            connections.Add(new Connection(west, nextitem.Index));

            //https://de.wikipedia.org/wiki/Gift-Wrapping-Algorithmus

        }

        private void btnMST_Click(object sender, EventArgs e)
        {
            maxn++;

            connections = new List<Connection>();

            var sortedconnections = allconnections.OrderBy(x => x.Distance).ToList();

            bool[] occupied = new bool[settlements.Length];

            connections.Add(new Connection(sortedconnections[0].Source, sortedconnections[0].Target));
            occupied[sortedconnections[0].Source]=true;
            occupied[sortedconnections[0].Target] = true;

            sortedconnections.Remove(sortedconnections[0]);
            int n = 0;
            foreach (var item in sortedconnections)
            {

                if (!IsSomehowConnected(item.Source, item.Target))
                {
                    connections.Add(new Connection(item.Source, item.Target));
                    occupied[item.Source] = true;
                    occupied[item.Target] = true;
                    //sortedconnections.Remove(item);
                }
                else
                {
                    //sortedconnections.Remove(item);
                }

                //if (AllOccupied(occupied))
                if (AllConnected())
                //maxn+=1;
                //if (n>maxn)
                {
                    break;
                }
            }

            CalculateDistance();
            this.Refresh();
        }

        private bool AllOccupied(bool[] occupied)
        {
            bool z = true;
            for (int i = 0; i < occupied.Length; i++)
            {
                z &= occupied[i];
            }
            return z;
        }

        private bool AllConnected()
        {
            for (int i = 1; i < settlements.Length; i++)
            {
                if (!IsSomehowConnected(0, i)) { return false; }
            }
            return true;
        }

        private bool IsSomehowConnected(int Source,int Target)
        {
            Graph graph = new Graph(settlements.Length);
            
            foreach (var item in connections)
            {
                graph.AddEdge(item.Source, item.Target);
            }
            graph.AddEdge(Source, Target);
            return graph.IsCyclic();
        }

        bool IsConnected(int Source, int Target)
        {
            return connections.Exists(x => (x.Source == Source && x.Target == Target) || (x.Source == Target && x.Target == Source));
        }
    }
}
