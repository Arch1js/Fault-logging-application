using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using MahApps.Metro.Controls;
using System.Data.OleDb;


namespace Fault_Logger
{
    public partial class Login
    {
        dataBaseConnection database = new dataBaseConnection();
        encryptPassword encrypt = new encryptPassword();

        public Login()
        {
            InitializeComponent();
            TechnicianLogin techLogin = new TechnicianLogin();
            techLogin.Show();
            txtUsername.Focus();
        }

        private void userLogin()
        {
            string username = txtUsername.Text;
            string password = txtPassword.Password;

            if (username != "" && password != "")
            {
                var enteredPassword = encrypt.sha256_hash(password);//encrypt entered password

                try
                {
                    string sql ="SELECT username, password, jobTitle FROM users WHERE username= @username AND password= @password";
                    var cmd = database.dataConnection(sql);

                    cmd.Parameters.Add("@username", OleDbType.VarChar).Value = username;
                    cmd.Parameters.Add("@password", OleDbType.VarChar).Value = enteredPassword;
                    var data = database.parameters();

                    var userUsername = data.Tables[0].Rows[0]["username"].ToString();
                    var userPassword = data.Tables[0].Rows[0]["password"].ToString();
                    var jobTitle = data.Tables[0].Rows[0]["jobTitle"].ToString();

                    if (username == userUsername && enteredPassword == userPassword && jobTitle == "dispatch manager")//if username, password and job title are correct
                    {
                        Application.Current.Properties["sessionUsername"] = userUsername;

                        Technician_Dispatch dispatch = new Technician_Dispatch();
                        dispatch.Show();
                        this.Close();

                        checkJobs checkJobStatus = new checkJobs();//get the number of waiting and unresolved jobs
                        Array jobs = checkJobStatus.checkPendingJobs();

                        int waiting = Convert.ToInt32(jobs.GetValue(0));
                        int unresolved = Convert.ToInt32(jobs.GetValue(1));

                        if (waiting != 0 || unresolved != 0)
                        {
                            MessageBox.Show("Attention! It appears that there are a few uncompleted jobs!" + "\n" + "\nWaiting: " + waiting + "\nUnresolved: " + unresolved, "Job status", MessageBoxButton.OK, MessageBoxImage.Warning);
                        }                                             

                    }
                    else if (jobTitle != "dispatch manager")
                    {
                        MessageBox.Show("Only dispatch managers are authorized to use this application!", "Login", MessageBoxButton.OK, MessageBoxImage.Error);
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
                txtUsername.BorderBrush = Brushes.Red;//paint the textbox boarder red if one of the fields is not entered
                txtPassword.BorderBrush = Brushes.Red;
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
