using System;
using System.Windows.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using MahApps.Metro.Controls;
using System.Data.OleDb;
using System.Data;

namespace Fault_Logger
{
    public partial class TechnicianJobs
    {
        dataBaseConnection database = new dataBaseConnection();
        DispatcherTimer dispatcherTimer = new DispatcherTimer();

        string techID = "";

        public TechnicianJobs()
        {
            InitializeComponent();
            loadJobs();
            checkMyStatus();
            loadUser();

            dispatcherTimer.Tick += new EventHandler(OnTimedEvent);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 5);
            dispatcherTimer.Start();
        }

        private void OnTimedEvent(object sender, EventArgs e)//auto refresh job list and status
        {
            loadJobs();
            checkMyStatus();

        }
        private void loadUser()
        {
            string username = Application.Current.Properties["sessionUsername"].ToString();

            string user = "Welcome, " + username;
            cmbUser.SetValue(TextBoxHelper.WatermarkProperty, user);
        }
        private void cmbLogout(object sender, RoutedEventArgs e)
        {
            TechnicianLogin techLogin = new TechnicianLogin();
            techLogin.Show();
            this.Close();           
        }
        private void loadJobs()
        {
            techID = Application.Current.Properties["sessionUserID"].ToString();           

            string sqlAllTechs = "SELECT jobID, zoneNo, date_time, status, comments FROM Jobs WHERE assignedTechnicianID = @techID";

            var cmd = database.dataConnection(sqlAllTechs);
            cmd.Parameters.AddWithValue("@search", OleDbType.VarChar).Value = techID;
            var data = database.parameters();
           
            try
            {
                if (data.Tables[0].Rows.Count == 0)//if no jobs are assigned change text and paint it red
                {
                    lblStatus.Content = "No jobs assigned!";
                    lblStatus.Foreground = Brushes.Red;
                    dgJobs.ItemsSource = data.Tables[0].DefaultView;
                }
                else
                {
                    lblStatus.Content = "New jobs found!";
                    lblStatus.Foreground = Brushes.Green;
                    dgJobs.ItemsSource = data.Tables[0].DefaultView;
                }
            }
            catch
            {

            }

        }
        private void changeStatus()//change status of job when it is selected
        {
            DataRowView dataRow = (DataRowView)dgJobs.SelectedItem;

            int jobID = Convert.ToInt32(dataRow["jobID"]);

            string sqlAllTechs = "UPDATE jobs SET status = 'Doing' WHERE jobID = @jobID";

            var cmd = database.dataConnection(sqlAllTechs);
            cmd.Parameters.Add("@jobID", OleDbType.VarChar).Value = jobID;
            var data = database.parameters();
        }
        private void dgJobs_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            if (e.PropertyName.StartsWith("jobID"))
            {
                e.Column.Header = "Job ID";
            }
            else if (e.PropertyName.StartsWith("zoneNo"))
            {
                e.Column.Header = "Zone";
            }
            else if (e.PropertyName.StartsWith("date_time"))
            {
                e.Column.Header = "Date/Time";
            }
        }

        private void dgJobs_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                dispatcherTimer.Stop();
                DataRowView dataRow = (DataRowView)dgJobs.SelectedItem;

                int jobID = Convert.ToInt32(dataRow["jobID"]);
                int zone = Convert.ToInt32(dataRow["zoneNo"]);
                string dateTime = dataRow["date_time"].ToString();
                string status = dataRow["status"].ToString();
                string comments = dataRow["comments"].ToString();

                JobStatus jobstatus = new JobStatus();
                jobstatus.loadForm(jobID, zone, dateTime, status, comments);//pass data to next form

                changeStatus();
                this.Close();
                jobstatus.Show();
            }
            catch
            {
                
            }
           
        }

        private void btnBreak_Click(object sender, RoutedEventArgs e)
        {           
            string currentColor = btnBreak.Background.ToString();

            if (currentColor == "#FF228B22")//if current button colour is green
            {
                string sqlSetStatus = "UPDATE technicians SET status = 'On break' WHERE technicianID = @techID";//update the technicians status to "on break"

                var cmd = database.dataConnection(sqlSetStatus);
                cmd.Parameters.Add("@techID", OleDbType.VarChar).Value = techID;

                var data = database.parameters();

                btnBreak.Background = Brushes.Red;//change colour of a button
                MessageBox.Show("You are now on break!", "Change of status", MessageBoxButton.OK, MessageBoxImage.Information);
                checkMyStatus();
            }
            else if (currentColor == "#FFFF0000")//if current button colour is red
            {
                string sqlSetStatus = "UPDATE technicians SET status = 'available' WHERE technicianID = @techID";

                var cmd = database.dataConnection(sqlSetStatus);
                cmd.Parameters.Add("@techID", OleDbType.VarChar).Value = techID;

                var data = database.parameters();
                btnBreak.Background = Brushes.ForestGreen;
                MessageBox.Show("You are now available!", "Change of status", MessageBoxButton.OK, MessageBoxImage.Information);
                checkMyStatus();
            }
                   
        }

        private void checkMyStatus()//check current status of technician
        {
            string sqlMyStatus = "SELECT status from technicians WHERE technicianID = @techID";

            var cmd = database.dataConnection(sqlMyStatus);
            cmd.Parameters.Add("@techID", OleDbType.VarChar).Value = techID;

            var data = database.parameters();
            string status = data.Tables[0].Rows[0]["status"].ToString();
            lblMyStatus.Content = "My status: " + status;

            if (status == "available")//based on status paint the button
            {
                btnBreak.Background = Brushes.ForestGreen;
            }
            else
            {
                btnBreak.Background = Brushes.Red;
            }
        }
    }
}
