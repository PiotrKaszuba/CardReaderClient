using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
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

namespace CardReaderClient
{
    /// <summary>
    /// Interaction logic for StartLesson.xaml
    /// </summary>
    public partial class StartLesson : Page
    {
        private CardReaderDB mDB;
        private prowadzacy prowadzacy;
        private przedmiot_info przedmiot;
        private SolidColorBrush white;
        private SolidColorBrush green;
        private DataGridRow lastclick = null;
        private IEnumerable<przedmiot_coll> przedmiot_cols;
        public StartLesson(CardReaderDB mDB, prowadzacy prowadzacy)
        {
            InitializeComponent();
            this.mDB = mDB;
            this.prowadzacy = prowadzacy;
            white = new SolidColorBrush(Colors.White);
            green = new SolidColorBrush(Colors.Green);
            przedmiot_cols = new List<przedmiot_coll>();
        }
        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {

            refresh();
        }
        public void refresh()
        {
            
            przedmiot_cols = (from x in mDB.przedmiot where x.prow_id == prowadzacy.id_prow select new przedmiot_coll{ przedmiot_info = new przedmiot_info { nazwa = x.nazwa, dzien = x.dzien, godzina = x.godzina, sala = x.sala }, przed_id = x.id_przed, prow_id = x.prow_id }).ToList();
            dataGrid.ItemsSource = (from x in przedmiot_cols select x.przedmiot_info);
        }

        private void RowDoubleClick(object sender, MouseButtonEventArgs e)
        {
            DataGridRow rowContainer = (DataGridRow)sender;
            przedmiot = (przedmiot_info)rowContainer.Item;

           
            if(lastclick!= null)
            {
                lastclick.Background = white;
            }
            rowContainer.Background = green;
            lastclick = rowContainer;
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            
            try {
                int id_przed = (from x in przedmiot_cols where x.przedmiot_info.Equals(przedmiot) select x.przed_id).First();
                mDB.zajecia.Add(new zajecia { nazwa = textBox.Text, typ_zaj = id_przed, data = DateTime.Now });

            if (mDB.SaveChanges() == 1)
                MessageBox.Show("Pomyślnie dodano zajęcia.");
            else
                MessageBox.Show("Wystąpił błąd i nie dodano zajęć");
        }
            catch (DbUpdateException ex)
            {
                MessageBox.Show("Błąd bazy danych - nie wykonano operacji.");
                mDB = new CardReaderDB();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
