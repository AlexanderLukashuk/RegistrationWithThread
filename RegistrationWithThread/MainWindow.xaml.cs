using RegistrationWithThread.Models;
using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace RegistrationWithThread
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void registerButtonClick(object sender, RoutedEventArgs e)
        {
            var login = loginTextBox.Text;
            var email = emailTextBox.Text;
            var phone = phoneTextBox.Text;
            var password = passwordTextBox.Password.ToString();
            var repeatPassword = repeatPasswordTextBox.Password.ToString();

            if (login.Length > 0 && email.Length > 0 && phone.Length > 0 && password.Length > 0 && repeatPassword.Length > 0)
            {

                if (password == repeatPassword)
                {
                    MessageBox.Show("Вы успешно зарегистрировались");
                    User user = new User(login, email, phone, password);
                }
                else
                {
                    MessageBox.Show("Пароли не совпадают");
                }
            }
            else
            {
                MessageBox.Show("Неверная форма заполнения");
            }
        }
    }
}
