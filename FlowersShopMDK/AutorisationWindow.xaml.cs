using FlowersShopMDK.ClassFolder;
using FlowersShopMDK.WindowFolder.AdminFolder;
using FlowersShopMDK.WindowFolder.FloristFolder;
using FlowersShopMDK.WindowFolder.ManagerFolder;
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
    /// Логика взаимодействия для AutorisationWindow.xaml
    /// </summary>
    public partial class AutorisationWindow : Window
    {
        SqlConnection sqlConnection =
        new(@"Data Source=DESKTOP-Q9BEC2K;Initial Catalog=kommo;Integrated Security=True");
        SqlCommand SqlCommand;
        SqlDataReader dataReader;

        public AutorisationWindow()
        {
            InitializeComponent();
        }


        private void DragWindow(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void Image_MouseDown(object sender, MouseButtonEventArgs e)
        {
           Application.Current.Shutdown();
        }

        private void Regestration(object sender, MouseButtonEventArgs e)
        {
            new RegestrationWindow().Show();
            Visibility = Visibility.Hidden;
        }

        private void Autorisation(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(LoginTb.Text))
            {
                MBClass.ErrorMB("Некоректный логин");
                LoginTb.Focus();
            }
            else if (string.IsNullOrWhiteSpace(PaswordBSB.Password))
            {
                MBClass.ErrorMB("Некоректный пароль");
                PaswordBSB.Focus();
            }
            else
            {

                try
                {
                    sqlConnection.Open();
                    SqlCommand = new SqlCommand("Select * From dbo.[User]" +
                        $"Where Login = '{LoginTb.Text}'", sqlConnection);
                    dataReader = SqlCommand.ExecuteReader();
                    dataReader.Read();
                    if (dataReader[2].ToString() != PaswordBSB.Password)
                    {
                        MBClass.ErrorMB("Введеный пароль не коректен");
                        PaswordBSB.Focus();
                    }
                    else
                    {
                        switch (dataReader[3].ToString())
                        {
                            case "1":
                                new FloristWindow().Show();
                                Close();
                                break;
                            case "2":
                                new AdminWindow().Show();
                                Close();
                                break;
                            case "3":
                                new ManagerWindow().Show();
                                Close();
                                break;
                        }
                    }

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
}
