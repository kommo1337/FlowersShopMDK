using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Data.SqlClient;

namespace FlowersShopMDK.ClassFolder
{
    internal class AutorisationClass
    {
        public static void PasswordCheker(TextBox LoginBox, PasswordBox PsbBox)
        {
            if (string.IsNullOrWhiteSpace(LoginBox.Text) || string.IsNullOrWhiteSpace(PsbBox.Password))
            {
                MBClass.ErrorMB("Заполните все поля");
            }
        }
        public static void RegPasswordCheker(TextBox LoginBox, PasswordBox PsbBox, PasswordBox PsbBoxRepeat)
        {
            string pass = PsbBox.Password;
            string zagl = "QWERTYUIOPASDFGHJKLZXCVBNM";
            string mal = "qwertyuiopasdfghjklzxcvbnm";
            string cif = "123457890";
            string znak = "!@#$%^&*()_+";
            if (string.IsNullOrWhiteSpace(LoginBox.Text))
            {
                MBClass.ErrorMB("Некоректный логин");
                LoginBox.Focus();
            }
            else if (string.IsNullOrWhiteSpace(PsbBox.Password))
            {
                MBClass.ErrorMB("Некоректный пароль");
                PsbBox.Focus();
            }
            else if (zagl.IndexOfAny(pass.ToCharArray()) == -1)
            {
                MBClass.ErrorMB("Пароль должен содержать заглавную букву");
                PsbBox.Focus();
            }
            else if (mal.IndexOfAny(pass.ToCharArray()) == -1)
            {
                MBClass.ErrorMB("Пароль должен содержать маленькую букву");
                PsbBox.Focus();
            }
            else if (cif.IndexOfAny(pass.ToCharArray()) == -1)
            {
                MBClass.ErrorMB("Пароль должен содержать цифру");
                PsbBox.Focus();
            }
            else if (znak.IndexOfAny(pass.ToCharArray()) == -1)
            {
                MBClass.ErrorMB("Пароль должен содержать " +
                    "один из этих знаков " + znak);
                PsbBox.Focus();
            }
            else if (string.IsNullOrWhiteSpace(PsbBoxRepeat.Password))
            {
                MBClass.ErrorMB("Некоректный повтор пароля");
                PsbBoxRepeat.Focus();
            }
            else if (PsbBoxRepeat.Password != PsbBox.Password)
            {
                MBClass.ErrorMB("Пароли не совпадают");
                PsbBoxRepeat.Focus();
                PsbBox.Focus();
            }
        }
    }
}
