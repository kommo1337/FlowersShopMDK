using FlowersShopMDK.ClassFolder;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Formats.Asn1;
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

namespace FlowersShopMDK.WindowFolder.AdminFolder
{
    /// <summary>
    /// Логика взаимодействия для AdminWindow.xaml
    /// </summary>
    public partial class AdminWindow : Window
    {
        SqlConnection sqlConnection = new SqlConnection(@"Data Source=DESKTOP-Q9BEC2K;Initial Catalog=kommo;Integrated Security=True");
        DgClass Dg;
        public AdminWindow()
        {
            InitializeComponent();
            Dg = new DgClass(ListUserDg);
        }

        private void Image_Close(object sender, MouseButtonEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Image_MouseDown(object sender, MouseButtonEventArgs e)
        {
            new AutorisationWindow().Show();
            Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Dg.LoadDG("SELECT * From dbo.[User]");
        }
        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void ListUserDg_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (ListUserDg.SelectedItem==null)
            {
                MBClass.ErrorMB("Выбирите строчку");
            }
            else
            {
                try
                {
                    VariableClass.UserId = Dg.SelectId();
                    new EditUserWindow().Show();
                    Close();
                }
                catch (Exception ex)
                {

                    MBClass.ErrorMB(ex);
                }
            }
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            new AddUserWindow().Show();
            Close();
        }

        private void SearchTb_TextChanged(object sender, TextChangedEventArgs e)
        {
           Dg.LoadDG("Select * From dbo.[User] " +
                $"Where Login Like '%{SearchTb.Text}%'");
        }
    }
}
