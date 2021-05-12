using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace DoAnGiuaKy_LTUDQL2_18600109
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

        public void Reset()
        {
            textBoxFirstName.Text = "";
            textBoxLastName.Text = "";
            textBoxEmail.Text = "";
            textBoxAddress.Text = "";
            passwordBox1.Password = "";
            passwordBoxConfirm.Password = "";
        }

        private void Submit_Click(object sender, RoutedEventArgs e)
        {

            if (textBoxEmail.Text.Length == 0)
            {
                errormessage.Text = "Enter an email.";
                textBoxEmail.Focus();
            }
            else if (!Regex.IsMatch(textBoxEmail.Text, @"^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$"))
            {
                errormessage.Text = "Enter a valid email.";
                textBoxEmail.Select(0, textBoxEmail.Text.Length);
                textBoxEmail.Focus();
            }
            else
            {
                string firstname = textBoxFirstName.Text;
                string lastname = textBoxLastName.Text;
                string email = textBoxEmail.Text;
                string password = passwordBox1.Password;
                if (passwordBox1.Password.Length == 0)
                {
                    errormessage.Text = "Enter password.";
                    passwordBox1.Focus();
                }
                else if (passwordBoxConfirm.Password.Length == 0)
                {
                    errormessage.Text = "Enter Confirm password.";
                    passwordBoxConfirm.Focus();
                }
                else if (passwordBox1.Password != passwordBoxConfirm.Password)
                {
                    errormessage.Text = "Confirm password must be same as password.";
                    passwordBoxConfirm.Focus();
                }
                else
                {
                    errormessage.Text = "";
                    string address = textBoxAddress.Text;
                    SqlConnection con = new SqlConnection("Data Source=TESTPURU;Initial Catalog=Data;User ID=sa;Password=wintellect");
                    con.Open();
                    SqlCommand cmd = new SqlCommand("Insert into Registration (FirstName,LastName,Email,Password,Address) values('" + firstname + "','" + lastname + "','" + email + "','" + password + "','" + address + "')", con);
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                    con.Close();
                    errormessage.Text = "You have Registered successfully.";
                    Reset();
                }
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Application curApp = Application.Current;
            Window mainWindow = curApp.MainWindow;
            this.Left = mainWindow.Left + (mainWindow.Width - this.ActualWidth) / 2;
            this.Top = mainWindow.Top + (mainWindow.Height - this.ActualHeight) / 2;
        }



        private void button3_Click(object sender, RoutedEventArgs e)
        {
            Netflix netflix = new Netflix();
            netflix.Show();
            Close();
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            Reset();
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            Login login = new Login();
            login.Show();
            Close();
        }
    }
}



//namespace Login_WPF
//{
//    /// <summary>  
//    /// Interaction logic for Registration.xaml  
//    /// </summary>  
//    public partial class Registration : Window
//    {
//        public Registration()
//        {
//            InitializeComponent();
//        }
//        private void Login_Click(object sender, RoutedEventArgs e)
//        {
//            Login login = new Login();
//            login.Show();
//            Close();
//        }
//        private void button2_Click(object sender, RoutedEventArgs e)
//        {
//            Reset();
//        }
//        public void Reset()
//        {
//            textBoxFirstName.Text = "";
//            textBoxLastName.Text = "";
//            textBoxEmail.Text = "";
//            textBoxAddress.Text = "";
//            passwordBox1.Password = "";
//            passwordBoxConfirm.Password = "";
//        }
//        private void button3_Click(object sender, RoutedEventArgs e)
//        {
//            Close();
//        }
//        private void Submit_Click(object sender, RoutedEventArgs e)
//        {
//            if (textBoxEmail.Text.Length == 0)
//            {
//                errormessage.Text = "Enter an email.";
//                textBoxEmail.Focus();
//            }
//            else if (!Regex.IsMatch(textBoxEmail.Text, @"^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$"))
//            {
//                errormessage.Text = "Enter a valid email.";
//                textBoxEmail.Select(0, textBoxEmail.Text.Length);
//                textBoxEmail.Focus();
//            }
//            else
//            {
//                string firstname = textBoxFirstName.Text;
//                string lastname = textBoxLastName.Text;
//                string email = textBoxEmail.Text;
//                string password = passwordBox1.Password;
//                if (passwordBox1.Password.Length == 0)
//                {
//                    errormessage.Text = "Enter password.";
//                    passwordBox1.Focus();
//                }
//                else if (passwordBoxConfirm.Password.Length == 0)
//                {
//                    errormessage.Text = "Enter Confirm password.";
//                    passwordBoxConfirm.Focus();
//                }
//                else if (passwordBox1.Password != passwordBoxConfirm.Password)
//                {
//                    errormessage.Text = "Confirm password must be same as password.";
//                    passwordBoxConfirm.Focus();
//                }
//                else
//                {
//                    errormessage.Text = "";
//                    string address = textBoxAddress.Text;
//                    SqlConnection con = new SqlConnection("Data Source=TESTPURU;Initial Catalog=Data;User ID=sa;Password=wintellect");
//                    con.Open();
//                    SqlCommand cmd = new SqlCommand("Insert into Registration (FirstName,LastName,Email,Password,Address) values('" + firstname + "','" + lastname + "','" + email + "','" + password + "','" + address + "')", con);
//                    cmd.CommandType = CommandType.Text;
//                    cmd.ExecuteNonQuery();
//                    con.Close();
//                    errormessage.Text = "You have Registered successfully.";
//                    Reset();
//                }
//            }
//        }
//    }
//}








//<Window x:Class="Login_WPF.Login"        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"  
//        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"  
//        Title="Login" Height="350" Width="525">  
   // <Grid>  
   //     <TextBlock Height = "23" HorizontalAlignment="Left" Margin="10,10,0,0" Name="LoginHeading" Text="Login:" VerticalAlignment="Top" FontSize="17" FontStretch="ExtraCondensed"/>  
   //     <TextBlock Height = "50" HorizontalAlignment="Left" Margin="24,48,0,0" Name="textBlockHeading" VerticalAlignment="Top" FontSize="12" FontStyle="Italic" Padding="5">  
   //         Note: Please login here to view the features of this site.If you are new on this site then <LineBreak /><!--line break-->  

   //        please click on
   //       <!--textblock as a Hyperlink.-->
   //         <TextBlock>  
   //              <Hyperlink Click = "buttonRegister_Click" FontSize= "14" FontStyle= "Normal" > Register </ Hyperlink >

   //        </ TextBlock >

   //        < !--end textblock as a hyperlink-->  

   //        button
   //    </TextBlock>
   //     <TextBlock Height = "23" HorizontalAlignment= "Left" Margin= "66,120,0,0" Name= "textBlock1" Text= "Email" VerticalAlignment= "Top" Width= "67" />

   //    < TextBlock Height= "23" HorizontalAlignment= "Left" Margin= "58,168,0,0" Name= "textBlock2" Text= "Password" VerticalAlignment= "Top" Width= "77" />

   //    < TextBox Height= "23" HorizontalAlignment= "Left" Margin= "118,115,0,0" Name= "textBoxEmail" VerticalAlignment= "Top" Width= "247" />

   //    < PasswordBox Height= "23" HorizontalAlignment= "Left" Margin= "118,168,0,0" Name= "passwordBox1" VerticalAlignment= "Top" Width= "247" />

   //    < Button Content= "Login" Height= "23" HorizontalAlignment= "Left" Margin= "118,211,0,0" Name= "button1" VerticalAlignment= "Top" Width= "104" Click= "button1_Click" />

   //    < TextBlock Height= "23" HorizontalAlignment= "Left" x:Name = "errormessage" VerticalAlignment= "Top" Width= "247" Margin= "118,253,0,0"  OpacityMask= "Crimson" Foreground= "#FFE5572C" />

   //</ Grid >
//</ Window >





//namespace Login_WPF
//{
//    /// <summary>  
//    /// Interaction logic for MainWindow.xaml  
//    /// </summary>   
//    public partial class Login : Window
//    {
//        public Login()
//        {
//            InitializeComponent();
//        }
//        Registration registration = new Registration();
//        Welcome welcome = new Welcome();
//        private void button1_Click(object sender, RoutedEventArgs e)
//        {
//            if (textBoxEmail.Text.Length == 0)
//            {
//                errormessage.Text = "Enter an email.";
//                textBoxEmail.Focus();
//            }
//            else if (!Regex.IsMatch(textBoxEmail.Text, @"^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$"))
//            {
//                errormessage.Text = "Enter a valid email.";
//                textBoxEmail.Select(0, textBoxEmail.Text.Length);
//                textBoxEmail.Focus();
//            }
//            else
//            {
//                string email = textBoxEmail.Text;
//                string password = passwordBox1.Password;
//                SqlConnection con = new SqlConnection("Data Source=TESTPURU;Initial Catalog=Data;User ID=sa;Password=wintellect");
//                con.Open();
//                SqlCommand cmd = new SqlCommand("Select * from Registration where Email='" + email + "'  and password='" + password + "'", con);
//                cmd.CommandType = CommandType.Text;
//                SqlDataAdapter adapter = new SqlDataAdapter();
//                adapter.SelectCommand = cmd;
//                DataSet dataSet = new DataSet();
//                adapter.Fill(dataSet);
//                if (dataSet.Tables[0].Rows.Count > 0)
//                {
//                    string username = dataSet.Tables[0].Rows[0]["FirstName"].ToString() + " " + dataSet.Tables[0].Rows[0]["LastName"].ToString();
//                    welcome.TextBlockName.Text = username;//Sending value from one form to another form.  
//                    welcome.Show();
//                    Close();
//                }
//                else
//                {
//                    errormessage.Text = "Sorry! Please enter existing emailid/password.";
//                }
//                con.Close();
//            }
//        }
//        private void buttonRegister_Click(object sender, RoutedEventArgs e)
//        {
//            registration.Show();
//            Close();
//        }
//    }
//}

