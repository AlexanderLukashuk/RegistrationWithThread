using RegistrationWithThread.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace RegistrationWithThread.Models
{
    public class User
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Login { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }

        public User(string login, string email, string phone, string password)
        {
            Login = login;
            Email = email;
            Phone = phone;
            Password = password;
        }

        public void AddUserToDB(object obj)
        {
            ApplicationContext context = (ApplicationContext)obj;
            context.Users.Add(this);
            context.SaveChanges();
        }
    }
}
