using FlowersShopMDK.ClassFolder;
using FlowersShopMDK.WindowFolder.FloristFolder;
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

namespace FlowersShopMDK.WindowFolder.ManagerFolder
{
    /// <summary>
    /// Логика взаимодействия для ManagerWindow.xaml
    /// </summary>
    public partial class ManagerWindow : Window
    {
        SqlConnection sqlConnection = new SqlConnection(@"Data Source=DESKTOP-Q9BEC2K;Initial Catalog=kommo;Integrated Security=True");
        DgClass Dg;
        public ManagerWindow()
        {
            InitializeComponent();
            Dg = new DgClass(ListProviderDg);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Dg.LoadDG("SELECT * From dbo.[Provider]");
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

        private void ListProviderDg_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (ListProviderDg.SelectedItem == null)
            {
                MBClass.ErrorMB("Выбирите строчку");
            }
            else
            {
                try
                {
                    VariableClass.ProviderId = Dg.SelectId();
                    new EditFlowerWindow().Show();
                    Close();
                }
                catch (Exception ex)
                {

                    MBClass.ErrorMB(ex);
                }
            }
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            Dg.LoadDG("Select * From dbo.[Provider] " +
                      $"Where Name Like '%{SearchTb.Text}%'");
        }
    }
}
