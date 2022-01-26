using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Win32;

namespace SchockApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        public MainWindow(int T1,int T2,int T3)
        {
            t1 = T1;
            t2 = T2;
            t3 = T3;
            InitializeComponent();
        }
           public int t1 = 0;
           public int t2 = 10;
           public int t3 = 0;


        private void save_Click(object sender, RoutedEventArgs e)
        {
            String[] player = new string[2];
            if (playerName.Text != "" && playersClub.Text != "")
            {
                player[0] = playerName.Text;
                player[1] = playersClub.Text;
                Spieler spieler = new Spieler(player[0], player[1], "0", "0", "0", "0", "0","0","0","0");
                DatenLesenSchreiben datenLesenSchreiben = new DatenLesenSchreiben();
                datenLesenSchreiben.CreateFile(player);
                playerName.Text = null;
                playersClub.Text = null;
                MessageBox.Show("Spieler/in " + player[0] + " vom " + player[1] + " wurde hinzugefügt");
            }
            else MessageBox.Show("Eingabe unvollständig");
        }

        private void Main_load(object sender, RoutedEventArgs e)
        {
            SpielfeldCode.tischeAktuallisieren(t1, t2, t3);
            amountTable3.Text = t1.ToString();
            amountTable4.Text = t2.ToString();
            amountTable5.Text = t3.ToString();

        }

        private void showPlayers_Click(object sender, RoutedEventArgs e)
        {
            SpielfeldCode.tischeAktuallisieren(t1, t2, t3);
            ShowPlayer showPlayer = new ShowPlayer();
            this.Close();
            showPlayer.ShowDialog();
        }

        private void loadOldSession_Click(object sender, RoutedEventArgs e)
        {
            // Hier wird die spielerListe geleert und neu beschrieben
            //Hier wird ein Textdokument ausgewählt und in ein 2d array gespeichert
            string txt = "";
            string[,] player = new string[100, 10];
            string[] updatePlayer = new string[500];
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                txt = openFileDialog.FileName;
                player = DatenLesenSchreiben.readFile(txt);
            }
            if(txt != string.Empty)
            {
                Spieler.spielers.Clear();

                string name = "";
                string club = "";
                string punkte = "";
                string R1 = "";
                string R2 = "";
                string R3 = "";
                string R4 = "";
                string Viertel = "";
                string Halb = "";
                string Finale = "";
                int count = 1;
                // Hier wird das array player auseinander genommen
                // der zeichenzusatz spielername und club entfernt 
                // und dem Konstruktor spieler übergeben um spieler 
                // zu erzeugen
                foreach (string item in player)
                {
                    updatePlayer[count - 1] = item;
                    if (item == null)
                    {
                        break;
                    }
                    else if (item.StartsWith("Spielername:"))
                    {
                        name = item;
                        name = name.Remove(0, 12);
                    }

                    else if (item.StartsWith("Club:"))
                    {
                        club = item;
                        club = club.Remove(0, 5);
                    }
                    else if (item.StartsWith("Punkte:"))
                    {
                        punkte = item;
                        punkte = punkte.Remove(0, 7);
                    }
                    else if (item.StartsWith("Punkte erste Runde:"))
                    {
                        R1 = item;
                        R1 = R1.Remove(0, 19);
                    }
                    else if (item.StartsWith("Punkte zweite Runde:"))
                    {
                        R2 = item;
                        R2 = R2.Remove(0, 20);
                    }
                    else if (item.StartsWith("Punkte dritte Runde:"))
                    {
                        R3 = item;
                        R3 = R3.Remove(0, 20);
                    }
                    else if (item.StartsWith("Punkte vierte Runde:"))
                    {
                        R4 = item;
                        R4 = R4.Remove(0, 20);
                    }
                    else if (item.StartsWith("Punkte Viertelfinale:"))
                    {
                        Viertel = item;
                        Viertel = Viertel.Remove(0, 21);
                    }
                    else if (item.StartsWith("Punkte Halbfinale:"))
                    {
                        Halb = item;
                        Halb = Halb.Remove(0, 18);
                    }
                    else if (item.StartsWith("Punkte Finale:"))
                    {
                        Finale = item;
                        Finale = Finale.Remove(0, 14);
                    }
                    if (count % 10 == 0)
                    {
                        Spieler spieler = new Spieler(name, club, punkte, R1, R2, R3, R4,Viertel,Halb,Finale);
                    }
                        count++;
                }
            }
            if(txt != string.Empty) 
            { 
                DatenLesenSchreiben.updateFile();
                MessageBox.Show("Daten wieder hergestellt");
            }
            else
            {
                MessageBox.Show("Keine neuen Daten ausgewählt");
            }
        }

        private void showTable_Click(object sender, RoutedEventArgs e)
        {
            Board board = new Board();
            this.Close();
            board.ShowDialog();
            
        }

        private void changeOption_Click(object sender, RoutedEventArgs e)
        {
            t1 = Int32.Parse(amountTable3.Text);
            t2 = Int32.Parse(amountTable4.Text);
            t3 = Int32.Parse(amountTable5.Text);
            if (t1 + t2 + t3 > 10)
            {
                MessageBox.Show("Maximale Tischanzahl von 10 überschritten");
            }
            else SpielfeldCode.tischeAktuallisieren(t1,t2,t3);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
        public void exeptionInfo()
        {
            MessageBox.Show("Keine Datei vorhanden");
        }
    }
}
