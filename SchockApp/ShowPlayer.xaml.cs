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
using System.Windows.Shapes;

namespace SchockApp
{
    /// <summary>
    /// Interaktionslogik für ShowPlayer.xaml
    /// </summary>
    public partial class ShowPlayer : Window
    {
        
        public ShowPlayer()
        {
            InitializeComponent();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            int count = 1;
            foreach (var item in Spieler.spielers.OrderByDescending(x => x.GesamtPunkte).ToList())
            {
                item.Position = count;
                count++;
            }
            liste.ItemsSource = Spieler.spielers.OrderByDescending(x => x.GesamtPunkte).ToList();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            MainWindow mainWindow = new MainWindow(SpielfeldCode.Anzahl3_11, SpielfeldCode.Anzahl4_11, SpielfeldCode.Anzahl5_11);
            this.Close();
            mainWindow.ShowDialog();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            int name;
            string[] player = new string[2];
            int count = 0;
            name = liste.SelectedIndex;
            try
            {
                Spieler.spielers.RemoveAt(name);

            DatenLesenSchreiben.killAllText();
            foreach (var item in Spieler.spielers)
            {
                player[count] = item.Name;
                player[count + 1] = item.Club;
                DatenLesenSchreiben.updateFile();
            }
            }
            catch (Exception)
            {

                MessageBox.Show("Keine Daten vorhanden");
            }
            liste.Items.Refresh();
        }
    }
}
 
