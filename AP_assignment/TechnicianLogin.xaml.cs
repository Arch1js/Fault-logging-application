using System.Windows;
using System.Windows.Input;
using MahApps.Metro.Controls;
using System.Data.OleDb;


namespace Fault_Logger
{
    public partial class TechnicianLogin
    {
        dataBaseConnection database = new dataBaseConnection();
        encryptPassword encrypt = new encryptPassword();

        public TechnicianLogin()
        {
            InitializeComponent();
            txtUsername.Focus();
        }
        private void userLogin()
        {
            string username = txtUsername.Text;
            string password = txtPassword.Password;

            if (username != "" && password != "")
            {
                var enteredPassword = encrypt.sha256_hash(password);

                try
                {
                    string sql = "SELECT username, technicianID, password FROM technicians WHERE username= @username AND password= @password";
                    var cmd = database.dataConnection(sql);

                    cmd.Parameters.Add("@username", OleDbType.VarChar).Value = username;
                    cmd.Parameters.Add("@password", OleDbType.VarChar).Value = enteredPassword;
                    var data = database.parameters();

                    var userUsername = data.Tables[0].Rows[0]["username"].ToString();
                    var userPassword = data.Tables[0].Rows[0]["password"].ToString();
                    var userID = data.Tables[0].Rows[0]["technicianID"].ToString();

                    if (username == userUsername && enteredPassword == userPassword)
                    {
                        Application.Current.Properties["sessionUsername"] = userUsername;
                        Application.Current.Properties["sessionUserID"] = userID;

                        TechnicianJobs technicianJobs = new TechnicianJobs();
                        technicianJobs.Show();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Failed to LogIn!", "Login", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                catch
                {
                    MessageBox.Show("Wrong username/password. Please try again!", "Login", MessageBoxButton.OK, MessageBoxImage.Error);
                    txtPassword.Password = "";
                }

            }
            else
            {
                MessageBox.Show("Username and Password required!", "Login", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            userLogin();
        }

        private void Grid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                userLogin();
            }
        }
    }
}
