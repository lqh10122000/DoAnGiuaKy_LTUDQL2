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
    /// Interaction logic for ResetPassword.xaml
    /// </summary>
    public partial class ResetPassword : Window
    {
        public ResetPassword()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            Login login = new Login();
            login.Show();
            Close();
        }
        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
        private void Resetpassword_Click(object sender, RoutedEventArgs e)
        {
            string email = txtRPEmail.Text;
            string password = textPassword.Text;
            string confirmPassword = textConfirmPassword.Text;
            if(email == null)
            {
                errormess.Text = "you need enter email!";
                return;
            }
            if (password == null)
            {
                errormess.Text = "you need enter password!";
                return;

            }
            if (confirmPassword == null)
            {
                errormess.Text = "you need enter confirmPassword!";
                return;

            }
            if (password != confirmPassword)
            {
                errormess.Text = "confirmPassword don't match password !";
                return;

            }
            SqlConnection con = new SqlConnection("Data Source=TESTPURU;Initial Catalog=Data;User ID=sa;Password=wintellect");
            con.Open();
            SqlCommand cmd = new SqlCommand("update users set password = '"+ password +"' where email ='"+ email + "'", con);
            cmd.CommandType = CommandType.Text;
            cmd.ExecuteNonQuery();
            con.Close();



            Login login = new Login();
            login.Show();
            Close();


        }
    }
}
