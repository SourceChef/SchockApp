using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchockApp
{
    class SpielfeldCode 
    {
        public static int Anzahl3 = 0;
        public static int Anzahl4 = 0;
        public static int Anzahl5 = 0;
        public static int gesamtTische = 0;
        public static int Anzahl3_1 = 0;
        public static int Anzahl4_1 = 0;
        public static int Anzahl5_1 = 0;
        public static bool shuffelR1 = false;
        public static bool shuffelR2 = false;
        public static bool shuffelR3 = false;
        public static bool shuffelR4 = false;
        public static bool shuffelVf = false;
        public static bool shuffelHf = false;
        public static bool shuffelF = false;
        public static void tischeAktuallisieren(int t1,int t2,int t3)
        {
            Anzahl3 = t1;
            Anzahl4 = t2;
            Anzahl5 = t3;
            Anzahl3_1 = t1;
            Anzahl4_1 = t2;
            Anzahl5_1 = t3;
            gesamtTische = t1 + t2 + t3;
            if(Spieler.viertelFinale == true)
            {
                Anzahl3 = 0;
                Anzahl4 = 4;
                Anzahl5 = 0;
                gesamtTische = Anzahl3 + Anzahl4 + Anzahl5;
            }
            if (Spieler.halbFinale == true)
            {
                Anzahl3 = 0;
                Anzahl4 = 2;
                Anzahl5 = 0;
                gesamtTische = Anzahl3 + Anzahl4 + Anzahl5;
            }
            if (Spieler.finalFinale == true)
            {
                Anzahl3 = 0;
                Anzahl4 = 1;
                Anzahl5 = 0;
                gesamtTische = Anzahl3 + Anzahl4 + Anzahl5;
            }
        }

        
    }
}
//Letzer stand rundenPunkte müssen ins array aufgenommen werden
