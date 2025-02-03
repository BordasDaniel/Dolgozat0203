using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;

namespace Dolgozat0203
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static List<Meres> meresek = new();
        static HashSet<string> valogatottMeresek = new();
        static List<string> lekertMeresek = new();

        public MainWindow()
        {
            InitializeComponent();
            string allomany = "meresek.csv";
            Feltolt(allomany);
            Valogatas();

            cbxDatumok.ItemsSource = valogatottMeresek;
            lbxLista.ItemsSource = lekertMeresek;
        }



        static void Feltolt(string allomany)
        {
           try
           {
                using (StreamReader olvas = new(allomany))
                {
                    olvas.ReadLine();
                    string sor = olvas.ReadLine();

                    while ((sor = olvas.ReadLine()) != null)
                    {
                        meresek.Add(new(sor));
                    }
                }

                MessageBox.Show("Sikeres beolvasás!");

            } catch(Exception ex)
            {
                MessageBox.Show("Sikertelen beolvasás!");
            }

        }

        static void Valogatas()
        {
            foreach(Meres meres in meresek)
            {
                valogatottMeresek.Add($"{meres.Datum.ToShortDateString()}");
            }
        }

        private void cbxDatumok_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbxDatumok.SelectedItem != null)
            {
                lekertMeresek.Clear();
               

                foreach (Meres meres in meresek)
                {
                    if (meres.Datum.ToShortDateString() == cbxDatumok.SelectedItem.ToString())
                    {
                        lekertMeresek.Add(meres.ToString());
                    }
                }
                lbxLista.Items.Refresh();



            }
        }

        private void lbxLista_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lbxLista.SelectedItem != null)
            {
                int index = 0;
                while (index  < lbxLista.Items.Count && meresek[index].ToString() != lbxLista.SelectedItem.ToString())
                {
                    index++;
                }
                MessageBox.Show(meresek[index].Minosites());

            }
        }
    }
}