using System;
using System.Collections.Generic;
using System.Data;
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

namespace DoAnGiuaKy_LTUDQL2_18600109
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            string Email = txtEmail.Text;

            string Password = txtPassword.Password;

            if (Email == null)
            {
                errormessage.Text = "you need enter email";
                return;
            }
            if(Password == null)
            {
                errormessage.Text = "you need enter password";
                return;
            }


            string getEmail, getPassword;

            SqlConnection connection = new SqlConnection("Data Source=TESTPURU;Initial Catalog=Data;User ID=sa;Password=wintellect");

            connection.Open();

            string query = "select * from users where email = '" + Email + "'";

            SqlCommand readCommand = new SqlCommand(query, connection);

            SqlDataReader reader = readCommand.ExecuteReader();

            if (reader != null)
            {
                while (reader.Read())
                {
                    getEmail = reader["Email"].ToString();
                    getPassword = reader["Name"].ToString();

                    if(Password == getPassword)
                    {
                        Netflix netflix = new Netflix();
                        netflix.Show();
                        Close();
                    }
                    else
                    {
                        errormessage.Text = "Wrong Password!";
                    }
         
                }
            }


            connection.Close();
               


        }

        private void ResetPassword_Click(object sender, RoutedEventArgs e)
        {
            string Email = txtEmail.Text;
            string getEmail;

            string Password = txtPassword.Password;

            if (Email == null)
            {
                errormessage.Text = "you need enter email";
                return;
            }
            else
            {

                SqlConnection connection = new SqlConnection("Data Source=TESTPURU;Initial Catalog=Data;User ID=sa;Password=wintellect");

                connection.Open();

                string query = "select * from users where email = '" + Email + "'";

                SqlCommand readCommand = new SqlCommand(query, connection);

                SqlDataReader reader = readCommand.ExecuteReader();

                if (reader != null)
                {
                    while (reader.Read())
                    {
                        getEmail = reader["Email"].ToString();
                      

                        if (getEmail != null)
                        {
                            ResetPassword resetpassword = new ResetPassword();
                            resetpassword.Show();
                            Close();
                        }
                        else
                        {
                            errormessage.Text = "Wrong email!";
                        }

                    }
                }


                connection.Close();

               
            }
           

        }
        private void buttonRegister_Click(object sender, RoutedEventArgs e)
        {
            MainWindow register = new MainWindow();
            register.Show();
            Close();
        }
    }
}
