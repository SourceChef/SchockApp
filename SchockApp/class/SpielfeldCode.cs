using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchockApp
{
    class SpielfeldCode 
    {
        static int Anzahl3 = 0;
        static int Anzahl4 = 0;
        static int Anzahl5 = 0;
        static int gesamtTische = 0;
        static int Anzahl3_1 = 0;
        static int Anzahl4_1 = 0;
        static int Anzahl5_1 = 0;
        static bool shuffelR1 = false;
        static bool shuffelR2 = false;
        static bool shuffelR3 = false;
        static bool shuffelR4 = false;
        static bool shuffelVf = false;
        static bool shuffelHf = false;
        static bool shuffelF = false;

        public static int Anzahl31 { get => Anzahl3; set => Anzahl3 = value; }
        public static int Anzahl41 { get => Anzahl4; set => Anzahl4 = value; }
        public static int Anzahl51 { get => Anzahl5; set => Anzahl5 = value; }
        public static int GesamtTische { get => gesamtTische; set => gesamtTische = value; }
        public static int Anzahl3_11 { get => Anzahl3_1; set => Anzahl3_1 = value; }
        public static int Anzahl4_11 { get => Anzahl4_1; set => Anzahl4_1 = value; }
        public static int Anzahl5_11 { get => Anzahl5_1; set => Anzahl5_1 = value; }
        public static bool ShuffelR1 { get => shuffelR1; set => shuffelR1 = value; }
        public static bool ShuffelR2 { get => shuffelR2; set => shuffelR2 = value; }
        public static bool ShuffelR3 { get => shuffelR3; set => shuffelR3 = value; }
        public static bool ShuffelR4 { get => shuffelR4; set => shuffelR4 = value; }
        public static bool ShuffelVf { get => shuffelVf; set => shuffelVf = value; }
        public static bool ShuffelHf { get => shuffelHf; set => shuffelHf = value; }
        public static bool ShuffelF { get => shuffelF; set => shuffelF = value; }

        public static void tischeAktuallisieren(int t1,int t2,int t3)
        {
            Anzahl31 = t1;
            Anzahl41 = t2;
            Anzahl51 = t3;
            Anzahl3_11 = t1;
            Anzahl4_11 = t2;
            Anzahl5_11 = t3;
            GesamtTische = t1 + t2 + t3;
            if(Spieler.ViertelFinale == true)
            {
                Anzahl31 = 0;
                Anzahl41 = 4;
                Anzahl51 = 0;
                GesamtTische = Anzahl31 + Anzahl41 + Anzahl51;
            }
            if (Spieler.HalbFinale == true)
            {
                Anzahl31 = 0;
                Anzahl41 = 2;
                Anzahl51 = 0;
                GesamtTische = Anzahl31 + Anzahl41 + Anzahl51;
            }
            if (Spieler.FinalFinale == true)
            {
                Anzahl31 = 0;
                Anzahl41 = 1;
                Anzahl51 = 0;
                GesamtTische = Anzahl31 + Anzahl41 + Anzahl51;
            }
        }

        
    }
}
//Letzer stand rundenPunkte müssen ins array aufgenommen werden
