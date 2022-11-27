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

namespace FlowersShopMDK
{
    /// <summary>
    /// Логика взаимодействия для RegestrationWindow.xaml
    /// </summary>
    public partial class RegestrationWindow : Window
    {
        public string? SelectedValue;
        int? RoleCheck = 0;
        SqlConnection sqlConnection =
           new(@"Data Source=DESKTOP-Q9BEC2K;Initial Catalog=kommo;Integrated Security=True");
        SqlCommand sqlCommand;
        public RegestrationWindow()
        {
            InitializeComponent();
        }

        private void CloseWindow(object sender, MouseButtonEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void BackWindow(object sender, MouseButtonEventArgs e)
        {
            Close();
            new AutorisationWindow().Visibility = Visibility.Visible;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AutorisationClass.RegPasswordCheker(LoginTb, PasswordTb, RepeatPasswordTb);
            if (SelectedValue == null)
            {
                MBClass.ErrorMB("Выбирете роль");
            }

            try
            {
                sqlConnection.Open();
                sqlCommand = new SqlCommand("Insert Into dbo.[User] " +
                "(Login, Password, IdRole) Values " +
                $"('{LoginTb.Text}','{PasswordTb.Password}',{RoleCheck})",
                sqlConnection);
                sqlCommand.ExecuteNonQuery();
                MBClass.InfoMB("Пользователь зарегистрирован");
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


        private void RB_Checked(object sender, RoutedEventArgs e)
        {
            
            if (sender is RadioButton item)
            {
                SelectedValue = item.Content.ToString();
            }
            if (SelectedValue == "Флорист")
            {
                RoleCheck = 1;
            }
            else if (SelectedValue == "Администратор")
            {
                RoleCheck = 2;
            }

        }
    }
}
