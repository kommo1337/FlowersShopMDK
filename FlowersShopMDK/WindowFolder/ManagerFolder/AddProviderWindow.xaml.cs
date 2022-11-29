using FlowersShopMDK.ClassFolder;
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
    /// Логика взаимодействия для AddProviderWindow.xaml
    /// </summary>
    public partial class AddProviderWindow : Window
    {
        SqlConnection sqlConnection = new SqlConnection(@"Data Source=DESKTOP-Q9BEC2K;Initial Catalog=kommo;Integrated Security=True");
        SqlCommand SqlCommand;
        public AddProviderWindow()
        {
            InitializeComponent();
        }

        private void Image_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Image_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            new ManagerWindow().Show();
            Close();
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                sqlConnection.Open();
                SqlCommand =
                    new SqlCommand("Insert Into " +
                    "dbo.[Provider] (Name, NameProvider, SurnameProvider, TherdNameProvider, Phone)" +
                    $"Values ('{TitleTb.Text}'," +
                    $"'{NameTb.Text}'," +
                    $"'{SureNameTb.Text}'," +
                    $"'{TherdNameTb.Text}'," +
                    $"'{Phone.Text}')", sqlConnection);
                SqlCommand.ExecuteNonQuery();
                MBClass.InfoMB($"Поставщик добавлен");
            }
            catch (Exception ex)
            {

                MBClass.ErrorMB(ex);
            }
            finally
            {
                sqlConnection.Close();
            }
        }
    }
}
