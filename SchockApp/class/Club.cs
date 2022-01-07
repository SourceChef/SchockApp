using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchockApp
{
    class Club
    {
        static readonly List<Club> clubs = new List<Club>();
        string club;
        string punkte;
        string gesamtPunkte;

        internal static List<Club> Clubs => clubs;

        public string Club1 { get => club; set => club = value; }
        public string Punkte { get => punkte; set => punkte = value; }
        public string GesamtPunkte { get => gesamtPunkte; set => gesamtPunkte = value; }

        public void sortClubs()
        {
            int count = 0;
            for (int i = 0; i < Spieler.spielers.Count; i++)
            {
                foreach (var item in Spieler.spielers)
                {
                    if (item.Club != Spieler.spielers[count].Club)
                    {

                    }
                }
            }
        }
    }
}
