using System;
using System.Windows;
using MahApps.Metro.Controls;
using System.Data;
using System.Data.OleDb;
using System.IO;

namespace Fault_Logger
{
    public partial class JobStatus
    {
        TechnicianJobs techJobs = new TechnicianJobs();
        public JobStatus()
        {
            InitializeComponent();
            loadUser();
        }

        private void loadUser()
        {
            string username = Application.Current.Properties["sessionUsername"].ToString();

            string user = "Welcome, " + username;
            cmbUser.SetValue(TextBoxHelper.WatermarkProperty, user);
        }

        public void loadForm(int jobID, int zone, string dateTime, string status, string comments)
        {
            txtJobID.Text = jobID.ToString();
            txtZone.Text = zone.ToString();
            txtTime.Text = dateTime;
            txtComments.Text = comments;

        }
        private void cmbLogout(object sender, RoutedEventArgs e)
        {
            TechnicianLogin techLogin = new TechnicianLogin();
            techLogin.Show();
            this.Close();
        }

        private void btnCancle_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            techJobs.Show();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            string jobID = txtJobID.Text;
            string techID = Application.Current.Properties["sessionUserID"].ToString(); 
            string zone = txtZone.Text;
            DateTime submitedDateTime = DateTime.Parse(txtTime.Text);
            string dispatchComments = txtComments.Text;
            string techComments = txtTechComments.Text;

            if (cmbStatus.Text == "" || txtTechComments.Text == "")
            {
                MessageBox.Show("Please enter status and comments!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                if(cmbStatus.Text == "Finished") {

                    OleDbConnection conn = new OleDbConnection();
                    conn.ConnectionString = @"Provider = Microsoft.ACE.OLEDB.12.0; Data Source = ..\..\..\techDatabase.accdb";

                    DateTime date = DateTime.Now;

                    OleDbCommand cmd = new OleDbCommand("INSERT INTO finishedJobs (jobID, techID, zoneNo, submitedDateTime, finishedDateTime, dispatchComments, technicianComments) VALUES (@jobID, @techID, @zone, @submitDateTime, @finishedDateTime, @dispatchComm, @techComm)");
                    OleDbCommand cmd2 = new OleDbCommand("DELETE FROM jobs WHERE jobID = jobID");
                    
                    cmd.Connection = conn;
                    cmd2.Connection = conn;

                    conn.Open();

                    if (conn.State == ConnectionState.Open)
                    {
                        cmd.Parameters.Add("@jobID", OleDbType.VarChar).Value = jobID;
                        cmd.Parameters.Add("@techID", OleDbType.VarChar).Value = techID;
                        cmd.Parameters.Add("@zone", OleDbType.VarChar).Value = zone;
                        cmd.Parameters.Add("@submitDateTime", OleDbType.Date).Value = submitedDateTime;
                        cmd.Parameters.Add("@finishedDateTime", OleDbType.Date).Value = date;
                        cmd.Parameters.Add("@dispatchComm", OleDbType.VarChar).Value = dispatchComments;
                        cmd.Parameters.Add("@techComm", OleDbType.VarChar).Value = techComments;

                        try
                        {
                            cmd.ExecuteNonQuery();

                            cmd2.Parameters.Add("@jobID", OleDbType.VarChar).Value = jobID;
                            cmd2.ExecuteNonQuery();

                            conn.Close();

                            string updateRecord = "Updated Job: " + jobID + "," + techID + "," + zone + "," + submitedDateTime + "," + date + "," + dispatchComments + "," + techComments + "<br>";
                            using (StreamWriter writer = new StreamWriter(@"..\..\..\log.txt", true))
                            {
                                writer.WriteLine(updateRecord);
                            }

                            MessageBoxResult result = MessageBox.Show("Job seccessfuly updated!", "Job Status", MessageBoxButton.OK, MessageBoxImage.Information);
                            switch (result)
                            {
                                case MessageBoxResult.OK:
                                    techJobs.Show();                                 
                                    this.Close();
                                    break;
                            }
                            
                        }
                        catch
                        {
                            MessageBox.Show("Ooops. Something went wrong!", "Job Status", MessageBoxButton.OK, MessageBoxImage.Warning);
                            conn.Close();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Databse connection error!", "Job Status", MessageBoxButton.OK, MessageBoxImage.Error);
                    }                    
        
                }
                else if (cmbStatus.Text == "Unresolved")
                {
                    OleDbConnection conn = new OleDbConnection();
                    conn.ConnectionString = @"Provider = Microsoft.ACE.OLEDB.12.0; Data Source = ..\..\..\techDatabase.accdb";

                    OleDbCommand cmd3 = new OleDbCommand("UPDATE jobs SET status = @status, techComments = @techComments WHERE jobID = @jobID");

                    cmd3.Connection = conn;
                  
                    conn.Open();

                    if (conn.State == ConnectionState.Open)
                    {
                        cmd3.Parameters.Add("@status", OleDbType.VarChar).Value = "Unresolved";                
                        cmd3.Parameters.Add("@techComments", OleDbType.VarChar).Value = txtTechComments.Text;
                        cmd3.Parameters.Add("@jobID", OleDbType.VarChar).Value = txtJobID.Text;

                        try
                        {
                            cmd3.ExecuteNonQuery();
                            conn.Close();

                            string updateRecord = "Updated Job: " + txtJobID.Text + "," + techID + "," + "Unresolved" + "," + txtTechComments.Text + "<br>";
                            using (StreamWriter writer = new StreamWriter(@"..\..\..\log.txt", true))
                            {
                                writer.WriteLine(updateRecord);
                            }

                            MessageBoxResult result = MessageBox.Show("Job status updated!", "Job Status", MessageBoxButton.OK, MessageBoxImage.Information);

                            switch (result)
                            {
                                case MessageBoxResult.OK:
                                    techJobs.Show();
                                    this.Close();
                                    break;
                            }
                        }
                        catch
                        {
                            MessageBox.Show("Oops, something went wrong!", "Job Status", MessageBoxButton.OK, MessageBoxImage.Information);
                        }
                    }
                }
            }
        }
    }
}
