﻿using System;
using System.Linq;
using System.Windows;

namespace SchockApp
{
    /// <summary>
    /// Interaktionslogik für ShowPlayer.xaml
    /// </summary>
    public partial class ShowPlayer2 : Window
    {
        
        public ShowPlayer2()
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

            this.Close();

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
 