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
    /// Interaktionslogik für Board.xaml
    /// </summary>
    public partial class Board : Window
    {
        List<TextBlock> textblockList = new List<TextBlock>();
        List<TextBox> textBoxeList = new List<TextBox>();
        public Board()
        {
            InitializeComponent();
        }
        public string runde = "1";
        public int T3 = SpielfeldCode.Anzahl31;
        public int T4 = SpielfeldCode.Anzahl41;
        public int T5 = SpielfeldCode.Anzahl51;
        public int gesamtT = SpielfeldCode.GesamtTische;
        public bool firstTime = true;
        private int spielfeldCodeCheck()
        {
            #region PlayersPerTable
            //Anzahl der Spieler pro Tisch
            int z = 0;
            if (T3 >= 1)
            {
                z = 3;
                if(firstTime == false)T3--;
            }
            else if(T4>=1)
            {
                z = 4;
                if (firstTime == false) T4--;
            }
            else if (T5 >= 1)
            {
                z = 5;
                if (firstTime == false) T5--;
            }
            if(gesamtT == 0)
            {
                return 0;
            }
            if (firstTime == false) gesamtT--;
            firstTime = false;
            return z;
            #endregion
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            #region RundenCheck
            // Hier wird die aktuelle Spielrunde festgelegt
            int zaehler1 = 0;
            int zaehler2 = 0;
            int zaehler3 = 0;
            int zaehler4 = 0;
            int zaehlerVf = 0;
            int zaehlerHf = 0;
            int zaehlerFi = 0;
            int tisch3Zahl = SpielfeldCode.Anzahl31;
            int tisch4Zahl = SpielfeldCode.Anzahl41;
            int tisch5Zahl = SpielfeldCode.Anzahl51;
            foreach (var item in Spieler.spielers)
            {
                if (item.PunkteR1 != "0")
                {
                    zaehler1++;
                }
                if (item.PunkteR2 != "0")
                {
                    zaehler2++;
                }
                if (item.PunkteR3 != "0")
                {
                    zaehler3++;
                }
                if (item.PunkteR4 != "0")
                {
                    zaehler4++;
                }
            }
            foreach (var item in Spieler.spielerFinale)
            {
                if (item.ViertelF != "0")
                {
                    zaehlerVf++;
                }
                if (item.HalbF != "0")
                {
                    zaehlerHf++;
                }
                if (item.Finale1 != "0")
                {
                    zaehlerFi++;
                }
            }
            //Wenn eine neue runde beginnt, also alle Punkte der Vorrunde eingetragen bzw alle Punkte der neuen Runde auf 0 stehen wird die Spielerliste neu gemischt
            if(zaehler1 == 0 || zaehler1 < Spieler.spielers.Count)
            {
               if (zaehler1 == 0) runde = "1";
                if (zaehler1 == 0 && SpielfeldCode.ShuffelR1 == false)
                {
                    MyExtensions.Shuffle(Spieler.spielers);
                    SpielfeldCode.ShuffelR1 = true;
                }
            }
            else if (zaehler2 == 0 || zaehler2 < Spieler.spielers.Count)
            {
                runde = "2";
                if(zaehler2==0 && SpielfeldCode.ShuffelR2 == false)MyExtensions.Shuffle(Spieler.spielers); SpielfeldCode.ShuffelR2 = true;
            }
            else if (zaehler3 == 0 || zaehler3 < Spieler.spielers.Count)
            {
                runde = "3";
                if (zaehler3 == 0 && SpielfeldCode.ShuffelR3 == false) MyExtensions.Shuffle(Spieler.spielers); SpielfeldCode.ShuffelR3 = true;
            }
            else if (zaehler4 == 0 || zaehler4 < Spieler.spielers.Count)
            {
                runde = "4";
                if (zaehler4 == 0 && SpielfeldCode.ShuffelR4 == false) MyExtensions.Shuffle(Spieler.spielers); SpielfeldCode.ShuffelR4 = true;
            }
            else if (zaehlerVf == 0 || zaehlerVf < Spieler.spielerFinale.Count)
            {
                runde = "Viertelfinale";
                if (zaehlerVf == 0 && SpielfeldCode.ShuffelVf == false) MyExtensions.Shuffle(Spieler.spielerFinale); SpielfeldCode.ShuffelVf = true;
                Spieler.ViertelFinale = true;
                SpielfeldCode.tischeAktuallisieren(SpielfeldCode.Anzahl31,SpielfeldCode.Anzahl41,SpielfeldCode.Anzahl51);
                Spieler.elemination();
            }
            else if (zaehlerHf == 0 || zaehlerHf < Spieler.spielerFinale.Count)
            {
                runde = "Halbfinale";
                if (zaehlerHf == 0 && SpielfeldCode.ShuffelHf == false) MyExtensions.Shuffle(Spieler.spielerFinale); SpielfeldCode.ShuffelHf = true;
                Spieler.HalbFinale = true;
                SpielfeldCode.tischeAktuallisieren(SpielfeldCode.Anzahl31, SpielfeldCode.Anzahl41, SpielfeldCode.Anzahl51);
                Spieler.eleminationHf();
            }
            else if (zaehlerFi == 0 || zaehlerFi < Spieler.spielerFinale.Count)
            {
                runde = "Finale";
                if (zaehlerFi == 0 && SpielfeldCode.ShuffelF == false) MyExtensions.Shuffle(Spieler.spielerFinale); SpielfeldCode.ShuffelF = true;
                Spieler.FinalFinale = true;
                SpielfeldCode.tischeAktuallisieren(SpielfeldCode.Anzahl31, SpielfeldCode.Anzahl41, SpielfeldCode.Anzahl51);
                Spieler.eleminationFi();
            }
            #endregion

            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            SizeToContent = SizeToContent.WidthAndHeight;

            #region Colums and rows
            // Define the Columns
            ColumnDefinition colDef1 = new ColumnDefinition();
            ColumnDefinition colDef2 = new ColumnDefinition();
            ColumnDefinition colDef3 = new ColumnDefinition();
            ColumnDefinition colDef4 = new ColumnDefinition();
            ColumnDefinition colDef5 = new ColumnDefinition();
            ColumnDefinition colDef6 = new ColumnDefinition();
            ColumnDefinition colDef7 = new ColumnDefinition();
            ColumnDefinition colDef8 = new ColumnDefinition();
            ColumnDefinition colDef9 = new ColumnDefinition();
            ColumnDefinition colDef10 = new ColumnDefinition();
                ColumnDefinition colDef11 = new ColumnDefinition();
                ColumnDefinition colDef12 = new ColumnDefinition();
                ColumnDefinition colDef13 = new ColumnDefinition();
                ColumnDefinition colDef14 = new ColumnDefinition();
                ColumnDefinition colDef15 = new ColumnDefinition();
                ColumnDefinition colDef16 = new ColumnDefinition();
                ColumnDefinition colDef17 = new ColumnDefinition();
                ColumnDefinition colDef18 = new ColumnDefinition();
                ColumnDefinition colDef19 = new ColumnDefinition();
                ColumnDefinition colDef20 = new ColumnDefinition();
            colDef1.MinWidth = 20;
            colDef2.MinWidth = 100;
            colDef3.MinWidth = 100;
            colDef4.MinWidth = 50;
            colDef5.MinWidth = 5;
            colDef6.MinWidth = 100;
            colDef7.MinWidth = 100;
            colDef8.MinWidth = 50;
            colDef9.MinWidth = 5;
            colDef10.MinWidth = 100;
                colDef11.MinWidth = 100;
                colDef12.MinWidth = 50;
                colDef13.MinWidth = 5;
                colDef14.MinWidth = 100;
                colDef15.MinWidth = 100;
                colDef16.MinWidth = 50;
                colDef17.MinWidth = 5;
                colDef18.MinWidth = 100;
                colDef19.MinWidth = 100;
                colDef20.MaxWidth = 50;
            if (Spieler.ViertelFinale == true)
            {
                colDef11.MinWidth = 1;
                colDef12.MinWidth = 1;
                colDef13.MinWidth = 1;
                colDef14.MinWidth = 1;
                colDef11.MaxWidth = 1;
                colDef12.MaxWidth = 1;
                colDef13.MaxWidth = 1;
                colDef14.MaxWidth = 1;
                colDef15.MinWidth = 1;
                colDef16.MinWidth = 1;
                colDef17.MinWidth = 1;
                colDef18.MinWidth = 1;
                colDef19.MinWidth = 1;
                colDef20.MinWidth = 1;
                colDef15.MaxWidth = 1;
                colDef16.MaxWidth = 1;
                colDef17.MaxWidth = 1;
                colDef18.MaxWidth = 1;
                colDef19.MaxWidth = 1;
                colDef20.MaxWidth = 1;
            }
            test.ColumnDefinitions.Add(colDef1);
            test.ColumnDefinitions.Add(colDef2);
            test.ColumnDefinitions.Add(colDef3);
            test.ColumnDefinitions.Add(colDef4);
            test.ColumnDefinitions.Add(colDef5);
            test.ColumnDefinitions.Add(colDef6);
            test.ColumnDefinitions.Add(colDef7);
            test.ColumnDefinitions.Add(colDef8);
            test.ColumnDefinitions.Add(colDef9);
            test.ColumnDefinitions.Add(colDef10);
                test.ColumnDefinitions.Add(colDef11);
                test.ColumnDefinitions.Add(colDef12);
                test.ColumnDefinitions.Add(colDef13);
                test.ColumnDefinitions.Add(colDef14);
                test.ColumnDefinitions.Add(colDef15);
                test.ColumnDefinitions.Add(colDef16);
                test.ColumnDefinitions.Add(colDef17);
                test.ColumnDefinitions.Add(colDef18);
                test.ColumnDefinitions.Add(colDef19);
                test.ColumnDefinitions.Add(colDef20);

            // Define the Rows
            RowDefinition rowDef1 = new RowDefinition();
            RowDefinition rowDef2 = new RowDefinition();
            RowDefinition rowDef3 = new RowDefinition();
            RowDefinition rowDef4 = new RowDefinition();
            RowDefinition rowDef5 = new RowDefinition();
            RowDefinition rowDef6 = new RowDefinition();
            RowDefinition rowDef7 = new RowDefinition();
            RowDefinition rowDef8 = new RowDefinition();
            RowDefinition rowDef9 = new RowDefinition();
            RowDefinition rowDef10 = new RowDefinition();
            RowDefinition rowDef11 = new RowDefinition();
            RowDefinition rowDef12 = new RowDefinition();
            RowDefinition rowDef13 = new RowDefinition();
            RowDefinition rowDef14 = new RowDefinition();
            RowDefinition rowDef15 = new RowDefinition();
            RowDefinition rowDef16 = new RowDefinition();
            rowDef1.MinHeight = 40;
            rowDef2.MinHeight = 40;
            rowDef3.MinHeight = 20;
            rowDef4.MinHeight = 20;
            rowDef5.MinHeight = 20;
            rowDef6.MinHeight = 20;
            rowDef7.MinHeight = 20;
            rowDef8.MinHeight = 40;
            rowDef9.MinHeight = 20;
            rowDef10.MinHeight = 20;
            rowDef11.MinHeight = 20;
            rowDef12.MinHeight = 20;
            rowDef13.MinHeight = 20;
            rowDef14.MinHeight = 20;
            rowDef15.MinHeight = 40;
            rowDef16.MinHeight = 40;
            rowDef16.MaxHeight = 40;
            rowDef15.MaxHeight = 5;

            test.RowDefinitions.Add(rowDef1);
            test.RowDefinitions.Add(rowDef2);
            test.RowDefinitions.Add(rowDef3);
            test.RowDefinitions.Add(rowDef4);
            test.RowDefinitions.Add(rowDef5);
            test.RowDefinitions.Add(rowDef6);
            test.RowDefinitions.Add(rowDef7);
            test.RowDefinitions.Add(rowDef8);
            test.RowDefinitions.Add(rowDef9);
            test.RowDefinitions.Add(rowDef10);
            test.RowDefinitions.Add(rowDef11);
            test.RowDefinitions.Add(rowDef12);
            test.RowDefinitions.Add(rowDef13);
            test.RowDefinitions.Add(rowDef14);
            test.RowDefinitions.Add(rowDef15);
            test.RowDefinitions.Add(rowDef16);
            #endregion
            int rowImageTable = 2;
            int colImageTable = 1;
            int rowSpanImageTable = 6;
            int rowLabelTable = 1;
            int colLabelTable = 1;
            int rowLabelPlayer = 1;
            int colLabelPlayer = 2;
            int rowLabelPunkte = 1;
            int colLabelPunkte = 3;
            int tischNummer = 1;

            Label titel = new Label();
            titel.Content = "Spielrunde: " + runde;
            titel.FontSize = 40;
            titel.FontWeight = FontWeights.Bold;
            Grid.SetRow(titel, 0);
            Grid.SetColumn(titel, 9);
            Grid.SetColumnSpan(titel, 11);
            if (Spieler.ViertelFinale == true)
            {
                Grid.SetColumn(titel, 1);
                Grid.SetColumnSpan(titel, 6);
            }
            test.Children.Add(titel);
            int z = spielfeldCodeCheck();
            #region tableimage and labels
            for (int i = 1; i <= (SpielfeldCode.GesamtTische); i++)
            {
                    if (i % 2 != 0)
                    {
                        //Hinzufügen eines Tischpic + Label und Boxen
                        Image imageTable1 = new Image();
                        BitmapImage bi3 = new BitmapImage();
                        bi3.BeginInit();
                        bi3.UriSource = new Uri("Tisch.png", UriKind.Relative);
                        bi3.EndInit();
                        imageTable1.Source = bi3;
                        imageTable1.HorizontalAlignment = 0;
                        imageTable1.Margin = new Thickness(0, -10, 0, 0);

                        Grid.SetColumn(imageTable1, colImageTable);
                        Grid.SetRow(imageTable1, rowImageTable);
                        Grid.SetRowSpan(imageTable1, rowSpanImageTable);

                        // LabelTisch1
                        Label labelTisch1 = new Label();
                        labelTisch1.Content = "Tisch" + tischNummer;
                        labelTisch1.HorizontalAlignment = 0;
                        labelTisch1.VerticalAlignment = VerticalAlignment.Center;
                        labelTisch1.FontSize = 24;
                        labelTisch1.FontWeight = FontWeights.Bold;

                        Grid.SetRow(labelTisch1, rowLabelTable);
                        Grid.SetColumn(labelTisch1, colLabelTable);

                        //LabeSpieler
                        Label labelSpieler = new Label();
                        labelSpieler.Content = "Spieler";
                        labelSpieler.HorizontalAlignment = 0;
                        labelSpieler.Height = 27;
                        labelSpieler.Width = 50;
                        labelSpieler.VerticalAlignment = VerticalAlignment.Bottom;
                        labelSpieler.FontSize = 12;
                        labelSpieler.FontWeight = FontWeights.Bold;
                        Grid.SetRow(labelSpieler, rowLabelPlayer);
                        Grid.SetColumn(labelSpieler, colLabelPlayer);

                        //LabeSpieler
                        Label labelPunkte = new Label();
                        labelPunkte.Content = "Punkte";
                        labelPunkte.HorizontalAlignment = 0;
                        labelPunkte.Height = 27;
                        labelPunkte.Width = 50;
                        labelPunkte.VerticalAlignment = VerticalAlignment.Bottom;
                        labelPunkte.FontSize = 12;
                        labelPunkte.FontWeight = FontWeights.Bold;
                        Grid.SetRow(labelPunkte, rowLabelPunkte);
                        Grid.SetColumn(labelPunkte, colLabelPunkte);

                        test.Children.Add(labelPunkte);
                        test.Children.Add(labelSpieler);
                        test.Children.Add(imageTable1);
                        test.Children.Add(labelTisch1);

                        rowImageTable = 2 + 7;
                        rowSpanImageTable = 5 + 7;
                        rowLabelTable = 1 + 7;
                        rowLabelPlayer = 1 + 7;
                        rowLabelPunkte = 1 + 7;
                    }
                    else
                    {



                        Image imageTable2 = new Image();
                        BitmapImage bi4 = new BitmapImage();
                        bi4.BeginInit();
                        bi4.UriSource = new Uri("Tisch.png", UriKind.Relative);
                        bi4.EndInit();
                        imageTable2.Source = bi4;
                        imageTable2.HorizontalAlignment = 0;
                        imageTable2.Margin = new Thickness(0, -50, 0, 0);

                        Grid.SetColumn(imageTable2, colImageTable);
                        Grid.SetRow(imageTable2, rowImageTable);
                        Grid.SetRowSpan(imageTable2, rowSpanImageTable);
                        tischNummer = tischNummer + 1;
                        // LabelTisch1
                        Label labelTisch2 = new Label();
                        labelTisch2.Content = "Tisch" + tischNummer;
                        labelTisch2.HorizontalAlignment = 0;
                        labelTisch2.VerticalAlignment = VerticalAlignment.Center;
                        labelTisch2.FontSize = 24;
                        labelTisch2.FontWeight = FontWeights.Bold;

                        Grid.SetRow(labelTisch2, rowLabelTable);
                        Grid.SetColumn(labelTisch2, colLabelTable);

                        //LabeSpieler
                        Label labelSpieler2 = new Label();
                        labelSpieler2.Content = "Spieler";
                        labelSpieler2.HorizontalAlignment = 0;
                        labelSpieler2.Height = 27;
                        labelSpieler2.Width = 50;
                        labelSpieler2.VerticalAlignment = VerticalAlignment.Bottom;
                        labelSpieler2.FontSize = 12;
                        labelSpieler2.FontWeight = FontWeights.Bold;
                        Grid.SetRow(labelSpieler2, rowLabelPlayer);
                        Grid.SetColumn(labelSpieler2, colLabelPlayer);

                        //LabeSpieler
                        Label labelPunkte2 = new Label();
                        labelPunkte2.Content = "Punkte";
                        labelPunkte2.HorizontalAlignment = 0;
                        labelPunkte2.Height = 27;
                        labelPunkte2.Width = 50;
                        labelPunkte2.VerticalAlignment = VerticalAlignment.Bottom;
                        labelPunkte2.FontSize = 12;
                        labelPunkte2.FontWeight = FontWeights.Bold;
                        Grid.SetRow(labelPunkte2, rowLabelPunkte);
                        Grid.SetColumn(labelPunkte2, colLabelPunkte);

                        test.Children.Add(labelPunkte2);
                        test.Children.Add(labelSpieler2);
                        test.Children.Add(imageTable2);
                        test.Children.Add(labelTisch2);

                        rowImageTable = 2;
                        colImageTable = colImageTable + 4;
                        rowSpanImageTable = 6;
                        rowLabelTable = 1;
                        colLabelTable = colLabelTable + 4;
                        rowLabelPlayer = 1;
                        colLabelPlayer = colLabelPlayer + 4;
                        rowLabelPunkte = 1;
                        colLabelPunkte = colLabelPunkte + 4;

                        tischNummer = tischNummer + 1;
                    }
            }
            #endregion

            #region textboxes and textblocks

            //Hinzufügen Textblock
            int y = 0;
            z = spielfeldCodeCheck();           
            int rowTextbox = 2;
            int colTextbox = 3;
            int rowBorder = 2;
            int colBorder = 2;
            for (int i = 1; i <= SpielfeldCode.GesamtTische; i++)
            {
                if (z != 0){
                    for (int j = 0; j < z; j++)
                    {

                        TextBlock textBlock = new TextBlock();
                        TextBox textBox = new TextBox();

                        Border border = new Border();
                        border.BorderThickness = new Thickness(2);
                        border.BorderBrush = Brushes.Black;
                        border.Margin = new Thickness(0, 5, 20, 0);
                        border.Width = 80;
                        border.Height = 20;
                        border.Child = textBlock;
                        Grid.SetRow(border, rowBorder);
                        Grid.SetColumn(border, colBorder);

                        test.Children.Add(border);
                        textblockList.Add(textBlock);


                        Border border1 = new Border();
                        border1.BorderThickness = new Thickness(2);
                        border1.Margin = new Thickness(0, 5, 5, 0);
                        border1.BorderBrush = Brushes.Black;
                        border1.Width = 40;
                        border1.Height = 20;
                        border1.Child = textBox;
                        textBoxeList.Add(textBox);                   
                        Grid.SetRow(border1, rowTextbox);
                        Grid.SetColumn(border1, colTextbox);

                        test.Children.Add(border1);

                        rowTextbox++;
                        rowBorder++;
                    }
                    if (i % 2 != 0) 
                    {
                        rowTextbox = 9;
                        rowBorder = 9;
                    }
                    else
                    {
                        rowBorder = 2;
                        rowTextbox = 2;
                        colTextbox = colTextbox + 4;
                        colBorder = colBorder + 4;
                    }
                    z = spielfeldCodeCheck();
                }
                SizeToContent = SizeToContent.WidthAndHeight;
            }
            listFiller();
            Button button1 = new Button();
            Button button2 = new Button();
            Button button3 = new Button();
            Button button4 = new Button();

            button1.Content = "Zurück ohne speichern";
            button1.Width = 130;
            button1.Height = 30;
            button1.Margin = new Thickness(5);
            button1.Click += backButton;
            button1.HorizontalAlignment = HorizontalAlignment.Left;
            Grid.SetRow(button1, 16);
            Grid.SetColumn(button1, 2);
            Grid.SetColumnSpan(button1, 3);
            if(Spieler.ViertelFinale == true)
            {
                Grid.SetColumn(button1, 8);
                Grid.SetColumnSpan(button1, 8);
                Grid.SetRow(button1, 3);
            }

            test.Children.Add(button1);

            button2.Content = "Speichern";
            button2.Width = 130;
            button2.Height = 30;
            button2.Margin = new Thickness(5);
            button2.HorizontalAlignment = HorizontalAlignment.Left;
            button2.Click += saveButton;
            Grid.SetRow(button2, 16);
            Grid.SetColumn(button2, 4);
            Grid.SetColumnSpan(button2, 5);
            if (Spieler.ViertelFinale == true)
            {
                Grid.SetColumn(button2, 8);
                Grid.SetColumnSpan(button2, 8);
                Grid.SetRow(button2, 4);
            }

            test.Children.Add(button2);
            button3.Content = "Runde Beenden";
            button3.Width = 130;
            button3.Height = 30;
            button3.Margin = new Thickness(5);
            button3.HorizontalAlignment = HorizontalAlignment.Left;
            button3.Click += endButton;
            Grid.SetRow(button3, 16);
            Grid.SetColumn(button3, 8);
            Grid.SetColumnSpan(button3, 9);
            if (Spieler.ViertelFinale == true)
            {
                Grid.SetColumn(button3, 8);
                Grid.SetColumnSpan(button3, 8);
                Grid.SetRow(button3, 10);
            }

            test.Children.Add(button3);
            button4.Content = "Punktestand anzeigen";
            button4.Width = 130;
            button4.Height = 30;
            button4.Margin = new Thickness(5);
            button4.HorizontalAlignment = HorizontalAlignment.Left;
            button4.Click += showPlayerWindow;
            Grid.SetRow(button4, 16);
            Grid.SetColumn(button4, 11);
            Grid.SetColumnSpan(button4, 12);
            if (Spieler.ViertelFinale == true)
            {
                Grid.SetColumn(button4, 8);
                Grid.SetColumnSpan(button4, 8);
                Grid.SetRow(button4, 11);
            }

            test.Children.Add(button4);
            SpielfeldCode.Anzahl31 = tisch3Zahl;
            SpielfeldCode.Anzahl41 = tisch4Zahl;
            SpielfeldCode.Anzahl51 = tisch5Zahl;
            foreach (var item in textBoxeList)
            {
                item.SelectAll();
            }
        }
            #endregion

        private void listFiller()
    {
        int cout = 0;

            //// Hier wird die SpielerListe durchgemischt
            //if (Spieler.runde1 == false)
            //{
            //    MyExtensions.Shuffle(Spieler.spielers);
            //    Spieler.runde1 = true;
            //}
            //// Hier geschieht die Shuffelfreigabe für das nächste Feld
            //Spieler.runde2 = false;
            // Hier werden die TextBlocks mit vorhandenen Namen gespeichert. Sind keine weiteren vorhanden wird N/A eingetragen
            Spieler.elemination();
            foreach (var item in textblockList)
        {
            for (int i = 0; i < 1; i++)
            {
                if (Spieler.ViertelFinale == false)
                {

                    if (Spieler.spielers.Count <= cout)
                    {
                        item.Text = "N/A";
                    }
                    else
                    {
                        item.Text = Spieler.spielers[cout].Name;
                    }
                }
                else
                {
                    if (Spieler.spielerFinale.Count <= cout)
                    {
                        item.Text = "N/A";
                    }
                    else
                    {
                        item.Text = Spieler.spielerFinale[cout].Name;
                    }
                }
            }
            cout++;
        }
        cout = 0;
        // Hier werden die Punkte falls schon vorhanden in die Tabelle eingetragen
        foreach (var item in textBoxeList)
        {
            for (int i = 0; i < 1; i++)
            {
                if (Spieler.spielers.Count <= cout)
                {
                    item.Text = "0";
                }
                else
                {
                    if(runde.StartsWith("1"))
                    item.Text = Spieler.spielers[cout].PunkteR1;
                    else if (runde.StartsWith("2"))
                    item.Text = Spieler.spielers[cout].PunkteR2;
                    else if (runde.StartsWith("3"))
                    item.Text = Spieler.spielers[cout].PunkteR3;
                    else if (runde.StartsWith("4"))
                    item.Text = Spieler.spielers[cout].PunkteR4;
                    else if (runde.StartsWith("Viertelfinale"))
                    item.Text = Spieler.spielers[cout].ViertelF;
                    else if (runde.StartsWith("Halbfinale"))
                    item.Text = Spieler.spielers[cout].HalbF;
                    else if (runde.StartsWith("Finale"))
                    item.Text = Spieler.spielers[cout].Finale1;
                    }
            }
            cout++;
        }
    }
        private void backButton(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow(SpielfeldCode.Anzahl3_11, SpielfeldCode.Anzahl4_11, SpielfeldCode.Anzahl5_11);
            this.Close();
            mainWindow.ShowDialog();
        }

        private void saveButton(object sender, RoutedEventArgs e)
        {
            int cout = 0;
            int punkte;
            int a;
            foreach (var item in textBoxeList)
            {
                if (cout < Spieler.spielers.Count)
                {

                    if (item.Text != "" && Spieler.spielers.Count >= cout && Spieler.spielers[cout].Name != "N/A" && Int32.TryParse(item.Text,out a) ==true)
                    {
                        if(runde =="1")
                        {
                            if (Int32.Parse(Spieler.spielers[cout].PunkteR1) == 0)
                            {
                                Spieler.spielers[cout].PunkteR1 = item.Text;
                                punkte = Int32.Parse(Spieler.spielers[cout].PunkteR1) + Int32.Parse(Spieler.spielers[cout].Punkte);
                                Spieler.spielers[cout].Punkte = punkte.ToString();
                            }
                        }
                        else if (runde == "2")
                        {
                            if (Int32.Parse(Spieler.spielers[cout].PunkteR2) == 0)
                            {
                                Spieler.spielers[cout].PunkteR2 = item.Text;
                                punkte = Int32.Parse(Spieler.spielers[cout].PunkteR2) + Int32.Parse(Spieler.spielers[cout].Punkte);
                                Spieler.spielers[cout].Punkte = punkte.ToString();
                            }
                        }
                        else if (runde == "3")
                        {
                            if (Int32.Parse(Spieler.spielers[cout].PunkteR3) == 0)
                            {
                                Spieler.spielers[cout].PunkteR3 = item.Text;
                                punkte = Int32.Parse(Spieler.spielers[cout].PunkteR3) + Int32.Parse(Spieler.spielers[cout].Punkte);
                                Spieler.spielers[cout].Punkte = punkte.ToString();
                            }
                        }
                        else if (runde == "4")
                        {
                            if (Int32.Parse(Spieler.spielers[cout].PunkteR4) == 0)
                            {
                                Spieler.spielers[cout].PunkteR4 = item.Text;
                                punkte = Int32.Parse(Spieler.spielers[cout].PunkteR4) + Int32.Parse(Spieler.spielers[cout].Punkte);
                                Spieler.spielers[cout].Punkte = punkte.ToString();
                            }
                        }
                        else if (runde.StartsWith("Viertelfinale"))
                        {
                            if (Int32.Parse(Spieler.spielerFinale[cout].ViertelF) == 0)
                            {
                                Spieler.spielerFinale[cout].ViertelF = item.Text;
                                punkte = Int32.Parse(Spieler.spielerFinale[cout].ViertelF) + Int32.Parse(Spieler.spielerFinale[cout].Punkte);
                                Spieler.spielerFinale[cout].Punkte = punkte.ToString();
                            }
                        }
                        else if (runde.StartsWith("Halbfinale"))
                        {
                            if (Int32.Parse(Spieler.spielerFinale[cout].HalbF) == 0)
                            {
                                Spieler.spielerFinale[cout].HalbF = item.Text;
                                punkte = Int32.Parse(Spieler.spielerFinale[cout].HalbF) + Int32.Parse(Spieler.spielerFinale[cout].Punkte);
                                Spieler.spielerFinale[cout].Punkte = punkte.ToString();
                            }
                        }
                        else if (runde.StartsWith("Finale"))
                        {
                            if (Int32.Parse(Spieler.spielerFinale[cout].Finale1) == 0)
                            {
                                Spieler.spielerFinale[cout].Finale1 = item.Text;
                                punkte = Int32.Parse(Spieler.spielerFinale[cout].Finale1) + Int32.Parse(Spieler.spielerFinale[cout].Punkte);
                                Spieler.spielerFinale[cout].Punkte = punkte.ToString();
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Ein Spieler wurde fehlerhaft eingetragen");
                        break;
                    }
                    cout++;
                }
            }
            DatenLesenSchreiben.updateFile();
        }

        private void endButton(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Alle Spieler eingetragen?", "Runde wirklich beenden?", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                int cout = 0;
                int a;
                bool check = true;
                foreach (var item in textblockList)
                {
                    if (item.Text != "N/A" && (textBoxeList[cout].Text == "" || textBoxeList[cout].Text == "0"|| Int32.TryParse(textBoxeList[cout].Text, out a) == false))
                    {
                        MessageBox.Show("Nicht alle Punkte wurden korrekt verteilt");
                        check = false;
                        break;
                    }
                    cout++;
                }
                if(check == true)
                {
                        saveButton(sender, e);
                        MainWindow mainWindow = new MainWindow(SpielfeldCode.Anzahl3_11,SpielfeldCode.Anzahl4_11,SpielfeldCode.Anzahl5_11);
                        this.Close();
                        mainWindow.ShowDialog();

                }

            }
        }
        private void showPlayerWindow(object sender, RoutedEventArgs e)
        {
            ShowPlayer2 showPlayer = new ShowPlayer2();
            showPlayer.ShowDialog();
        }
    }
}
