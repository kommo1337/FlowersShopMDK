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

namespace FlowersShopMDK.WindowFolder.FloristFolder
{
    /// <summary>
    /// Логика взаимодействия для AddFlowerWindow.xaml
    /// </summary>
    public partial class AddFlowerWindow : Window
    {
        SqlConnection sqlConnection = new SqlConnection(@"Data Source=DESKTOP-Q9BEC2K;Initial Catalog=kommo;Integrated Security=True");
        SqlCommand SqlCommand;
        public AddFlowerWindow()
        {
            InitializeComponent();
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void Image_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Image_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            new FloristWindow().Show();
            Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

                try
                {
                    sqlConnection.Open();
                    SqlCommand =
                        new SqlCommand("Insert Into " +
                        "dbo.[Flowers] (Name, Price, Provider, Amount)" +
                        $"Values ('{NameTb.Text}'," +
                        $"'{PriceTb.Text}'," +
                        $"'{ProviderTb.Text}',"+
                        $"'{AmountTb.Text}')", sqlConnection);
                    SqlCommand.ExecuteNonQuery();
                    MBClass.InfoMB($"Цветок добавлен");
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
