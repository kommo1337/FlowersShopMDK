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

namespace FlowersShopMDK.WindowFolder.AdminFolder
{
    /// <summary>
    /// Логика взаимодействия для EditUserWindow.xaml
    /// </summary>
    public partial class EditUserWindow : Window
    {
        SqlConnection sqlConnection = new SqlConnection(@"Data Source=DESKTOP-Q9BEC2K;Initial Catalog=kommo;Integrated Security=True");
        SqlCommand SqlCommand;
        public EditUserWindow()
        {
            InitializeComponent();
        }

        private void Image_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Image_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            new AdminWindow().Show();
            Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int Role = 0;

            if (RoleCB.SelectedIndex==0)
                Role = 1;
            else if(RoleCB.SelectedIndex == 0)
                Role=2;
            else
            Role = 3;
            
            if (RoleCB.SelectedIndex == -1)
            {
                MBClass.ErrorMB("Не выбрана роль");
                RoleCB.Focus();
            }
            else
            {
                try
                {
                    sqlConnection.Open();
                    SqlCommand =
                        new SqlCommand("Update " +
                        "dbo.[User] " +
                        $"Set Login ='{LoginTb.Text}'," +
                        $"Password='{PasswordTb.Text}'," +
                        $"IdRole='{Role}' " +
                        $"Where UserId='{VariableClass.UserId}'",
                        sqlConnection);
                    SqlCommand.ExecuteNonQuery();
                    MBClass.InfoMB($"Данные пользователя " +
                        $"успешно отредактированы");
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

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }
    }
}
