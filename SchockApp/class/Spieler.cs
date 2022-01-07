using System;
using System.Collections.Generic;
using System.Linq;

namespace SchockApp
{
    class Spieler
    {
        public static readonly List<Spieler> spielers = new List<Spieler>();
        public static readonly List<Spieler> helperList = new List<Spieler>();
        public static List<Spieler> spielerFinale = new List<Spieler>();
        public static bool runde1 = false;
        public static bool runde2 = false;
        public static bool runde3 = false;
        public static bool runde4 = false;
        public static bool halbFinale = false;
        public static bool viertelFinale = false;
        public static bool finalFinale = false;
        string name;
        string club;
        string punkte;
        string punkteR1 = "0";
        string punkteR2 = "0";
        string punkteR3 = "0";
        string punkteR4 = "0";
        string viertelF;
        string halbF;
        string Finale;
        int gesamtPunkte;
        int position;

        public string Name { get => name; set => name = value; }
        public string Club { get => club; set => club = value; }
        public string Punkte { get => punkte; set => punkte = value; }
        public string PunkteR1 { get => punkteR1; set => punkteR1 = value; }
        public string PunkteR2 { get => punkteR2; set => punkteR2 = value; }
        public string PunkteR3 { get => punkteR3; set => punkteR3 = value; }
        public string PunkteR4 { get => punkteR4; set => punkteR4 = value; }
        public string ViertelF { get => viertelF; set => viertelF = value; }
        public string HalbF { get => halbF; set => halbF = value; }
        public string Finale1 { get => Finale; set => Finale = value; }
        public int GesamtPunkte { get => gesamtPunkte; set => gesamtPunkte = value; }
        public int Position { get => position; set => position = value; }

        public Spieler(string name,string club,string punkte, string R1,string R2,string R3,string R4,string Viertel,string Halb,string Fin)
        {
            int gesamtPunkte;
            Name = name;
            Club = club;
            gesamtPunkte =Int32.Parse(R1)+ Int32.Parse(R2) + Int32.Parse(R3) + Int32.Parse(R4) + Int32.Parse(Viertel) + Int32.Parse(Halb) + Int32.Parse(Fin);
            Punkte = gesamtPunkte.ToString();
            spielers.Add(this);
            PunkteR1 = R1;
            PunkteR2 = R2;
            PunkteR3 = R3;
            PunkteR4 = R4;
            ViertelF = Viertel;
            HalbF = Halb;
            Finale1 = Fin;
            GesamtPunkte = gesamtPunkte;
        }
        public Spieler()
        {
        }
        public void addPlayer()
        {
            spielers.Add(this);
        }
        public static void elemination()
        {
            helperList.Clear();
            helperList.AddRange(spielers);
            int indexcount = helperList.Count - 16;            
            spielerFinale = helperList.OrderByDescending(x => x.GesamtPunkte).ToList();
            if (spielerFinale.Count > 16)
            {
                spielerFinale.RemoveRange(16, indexcount);
            }
        }
        public static void eleminationHf()
        {
            helperList.Clear();
            helperList.AddRange(spielerFinale);
            int indexcount = helperList.Count - 8;
            spielerFinale = helperList.OrderByDescending(x => x.GesamtPunkte).ToList();
            if (spielerFinale.Count > 8)
            {
                spielerFinale.RemoveRange(8, indexcount);
            }
        }
        public static void eleminationFi()
        {
            helperList.Clear();
            helperList.AddRange(spielerFinale);
            int indexcount = helperList.Count - 4;
            spielerFinale = helperList.OrderByDescending(x => x.GesamtPunkte).ToList();
            if (spielerFinale.Count > 4)
            {
                spielerFinale.RemoveRange(4, indexcount);
            }
        }
    }
}
