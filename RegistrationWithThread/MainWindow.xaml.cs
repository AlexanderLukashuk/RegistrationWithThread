using RegistrationWithThread.Data;
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
        private readonly ApplicationContext context;
        private static object lockObject = new object();
        public MainWindow()
        {
            InitializeComponent();

            context = new ApplicationContext();
        }

        private void registerButtonClick(object sender, RoutedEventArgs e)
        {
            var login = loginTextBox.Text;
            var email = emailTextBox.Text;
            var phone = phoneTextBox.Text;
            var password = passwordTextBox.Password.ToString();
            var repeatPassword = repeatPasswordTextBox.Password.ToString();
            int phoneNumber;
            bool isPhoneNumber = int.TryParse(phoneTextBox.Text, out phoneNumber);

            if (login.Length > 0 && email.Length > 0 && phone.Length > 0 && password.Length > 0 && repeatPassword.Length > 0 && isPhoneNumber)
            {

                if (password == repeatPassword)
                {
                    lock (lockObject)
                    {
                        User user = new User(login, email, phone, password);
                        context.Users.Add(user);
                        context.SaveChanges();

                    }
                    MessageBox.Show("Вы успешно зарегистрировались");
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

        private void WindowClosing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            context.Dispose();
        }
    }
}
