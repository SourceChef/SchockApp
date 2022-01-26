using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace SchockApp
{
    class DatenLesenSchreiben
    {
        public static string ultimatePath = "";
        public void CreateFile(string[] data)
        {
            string path = "C:\\Users\\"+Environment.UserName+"\\Desktop\\SchockTurnier";
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            if (!File.Exists(path+"\\SchockTurnier.txt"))
            {
                using (File.Create(path + "\\SchockTurnier.txt")) ;
                ultimatePath = path + "\\SchockTurnier.txt";
                writeFile(data);
            }
            else
            {
                ultimatePath = path + "\\SchockTurnier.txt";
                writeFile(data);
            }
        }
        public static void writeFile(string[] data)
        {
            try
            {
            using (StreamWriter writer = new StreamWriter(ultimatePath,true))
            {
                //Hier wird die eingabe des Spielernamen und des Clubs in eine Textdatei gespeichert
                for (int i = 0; i < data.Length; i++)
                {
                        if (i == 0 || i % 2 == 0)
                        {
                            writer.WriteLine("Spielername:" + data[i]);
                        }
                        else
                        {
                            writer.WriteLine("Club:" + data[i]);
                            writer.WriteLine("Punkte:0");
                            writer.WriteLine("Punkte erste Runde:0");
                            writer.WriteLine("Punkte zweite Runde:0");
                            writer.WriteLine("Punkte dritte Runde:0");
                            writer.WriteLine("Punkte vierte Runde:0");
                            writer.WriteLine("Punkte Viertelfinale:0");
                            writer.WriteLine("Punkte Halbfinale:0");
                            writer.WriteLine("Punkte Finale:0");
                        }
                }
                writer.Flush();
            }

            }
            catch (Exception e)
            {

                throw;
            }

        }
        // Funktion zum löschen des Textes
        public static void killAllText()
        {
            File.WriteAllText("C:\\Users\\"+Environment.UserName+"\\Desktop\\SchockTurnier\\SchockTurnier.txt", String.Empty);
        }

        // Textfile wird neu geschrieben
        public static void updateFile()
        {
            killAllText();
            try
            {
                using (StreamWriter writer = new StreamWriter("C:\\Users\\"+Environment.UserName+"\\Desktop\\SchockTurnier\\SchockTurnier.txt", true))
                {
                    //Hier wird die eingabe des Spielernamen und des Clubs in eine Textdatei gespeichert
                    foreach (var item in Spieler.spielers)
                    {
                        writer.WriteLine("Spielername:" + item.Name);
                        writer.WriteLine("Club:" + item.Club);
                        writer.WriteLine("Punkte:" + item.Punkte);
                        writer.WriteLine("Punkte erste Runde:" + item.PunkteR1);
                        writer.WriteLine("Punkte zweite Runde:" + item.PunkteR2);
                        writer.WriteLine("Punkte dritte Runde:" + item.PunkteR3);
                        writer.WriteLine("Punkte vierte Runde:" + item.PunkteR4);
                        writer.WriteLine("Punkte Viertelfinale:" + item.ViertelF);
                        writer.WriteLine("Punkte Halbfinale:" + item.HalbF);
                        writer.WriteLine("Punkte Finale:" + item.Finale1);
                        writer.Flush();
                    }
                }

            }
            catch (Exception e)
            {

                MainWindow mainwindow = new MainWindow() ;
                mainwindow.exeptionInfo();
            }

        }
        // Hier wird eine Textdatei ausgelesen und in ein 2d Array gespeichert
        public static string[,] readFile(string path)
        {
            string[,] player = new string[100, 10];
            int counter = 0;
            var lines = File.ReadLines(path);
            foreach (var line in lines)
            {
                if (line.StartsWith("Spielername:"))
                {
                    player[counter, 0] = line;
                }

                else if(line.StartsWith("Club:"))
                {
                    player[counter, 1] = line;
                }
                else if(line.StartsWith("Punkte:")) 
                {
                    player[counter, 2] = line;
                }
                else if (line.StartsWith("Punkte erste Runde:"))
                {
                    player[counter, 3] = line;
                }
                else if (line.StartsWith("Punkte zweite Runde:"))
                {
                    player[counter, 4] = line;
                }
                else if (line.StartsWith("Punkte dritte Runde:"))
                {
                    player[counter, 5] = line;
                }
                else if (line.StartsWith("Punkte vierte Runde:"))
                {
                    player[counter, 6] = line;
                }
                else if (line.StartsWith("Punkte Viertelfinale:"))
                {
                    player[counter, 7] = line;
                }
                else if (line.StartsWith("Punkte Halbfinale:"))
                {
                    player[counter, 8] = line;
                }
                else if (line.StartsWith("Punkte Finale:"))
                {
                    player[counter, 9] = line;
                    counter++;
                }
            }
            return player;
        }
    }
}
