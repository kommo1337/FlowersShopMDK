using FlowersShopMDK.ClassFolder;
using FlowersShopMDK.WindowFolder.AdminFolder;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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

namespace FlowersShopMDK.WindowFolder.FloristFolder
{
    /// <summary>
    /// Логика взаимодействия для FloristWindow.xaml
    /// </summary>
    public partial class FloristWindow : Window
    {
        SqlConnection sqlConnection = new SqlConnection(@"Data Source=DESKTOP-Q9BEC2K;Initial Catalog=kommo;Integrated Security=True");
        DgClass Dg;
        public FloristWindow()
        {
            InitializeComponent();
            Dg = new DgClass(ListFlowerDg);
        }

        private void Image_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Image_MouseLeftButtonDown_1(object sender, MouseButtonEventArgs e)
        {
            new AutorisationWindow().Show();
            Close();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Dg.LoadDG("SELECT * From dbo.[Flowers]");
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            Dg.LoadDG("Select * From dbo.[Flowers] " +
                $"Where Name Like '%{SearchTb.Text}%'");
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            new AddFlowerWindow().Show();
            Close();
        }

        private void ListFlowerDg_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (ListFlowerDg.SelectedItem == null)
            {
                MBClass.ErrorMB("Выбирите строчку");
            }
            else
            {
                try
                {
                    VariableClass.FlowersId = Dg.SelectId();
                    new EditFlowerWindow().Show();
                    Close();
                }
                catch (Exception ex)
                {

                    MBClass.ErrorMB(ex);
                }
            }
        }
    }
}
