using System;
using System.Windows.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using MahApps.Metro.Controls;
using System.Data;
using System.Data.OleDb;
using System.IO;

namespace Fault_Logger
{
    public partial class FaultReport2
    {
        dataBaseConnection database = new dataBaseConnection();
        dataBaseConnection2 database2 = new dataBaseConnection2();

        DispatcherTimer dispatcherTimer = new DispatcherTimer();

        int techID;
        int zone;
        string techName;
        int currentIndex = -1;
        

        public FaultReport2()
        {
            InitializeComponent();
            loadUser();
            loadAvailableTechs();

            dispatcherTimer.Tick += new EventHandler(OnTimedEvent);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 3);
            dispatcherTimer.Start();
        }
        private void loadUser()
        {
            string username = Application.Current.Properties["sessionUsername"].ToString();
            string user = "Welcome, " + username;
            cmbUser.SetValue(TextBoxHelper.WatermarkProperty, user);
        }

        private void OnTimedEvent(object sender, EventArgs e)
        {
            
            var data = database.parameters();
            
            dgTechnicians.ItemsSource = data.Tables[0].DefaultView;
           
            moveSelection();
            
        }
        private void moveSelection()
        {
            if (currentIndex != -1)
            {
                object item = dgTechnicians.Items[currentIndex];

                dgTechnicians.SelectedItem = item;
                dgTechnicians.ScrollIntoView(item);
            }
           
        }
        
        private void dgTechnicians_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           
            if (dgTechnicians.SelectedIndex != -1)
            {
                currentIndex = dgTechnicians.SelectedIndex;
            }                       

            try
            {
                DataRowView dataRow = (DataRowView)dgTechnicians.SelectedItem;

                techID = Convert.ToInt32(dataRow["technicianID"]);
                zone = Convert.ToInt32(dataRow["current_Location"]);
                techName = dataRow["technician_Name"].ToString();
            }
            catch
            {

            }
            txtTechID.Text = techID.ToString();
            txtTechName.Text = techName;
            txtZone.Text = zone.ToString();
        }

        public void loadForm(string staffID, string zone, string machineID, string comment)
        {
            txtStaffID.Text = staffID;
            cmbZone.Text = zone;
            txtMachineID.Text = machineID;
            txtComments.Text = comment;
        }
        private void loadAvailableTechs()
        {
            string sqlAvailableTechs = "SELECT technicianID, username, technician_Name, technician_Surname, specialization, current_Location, status FROM technicians WHERE status= @status";

            var cmd = database.dataConnection(sqlAvailableTechs);
            cmd.Parameters.Add("@status", OleDbType.VarChar).Value = "available";
            var data = database.parameters();

            dgTechnicians.ItemsSource = data.Tables[0].DefaultView;
        }

        private void btnAuto_Click(object sender, RoutedEventArgs e)
        {
            dispatcherTimer.Stop();
            string specialization = cmbSpecializations.Text;           

            if (specialization == "" || cmbZone.Text == "")
            {
                cmbSpecializations.BorderBrush = Brushes.Red;
                cmbZone.BorderBrush = Brushes.Red;

                MessageBox.Show("Please select specialization and zone!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                cmbSpecializations.ClearValue(Border.BorderBrushProperty);
                cmbZone.ClearValue(Border.BorderBrushProperty);

                int faultZone = Convert.ToInt32(cmbZone.Text);

                autoAssignTechnician auto = new autoAssignTechnician();
                Array result = auto.autoAssign(specialization, faultZone);

                if (result.GetValue(0).ToString() == "Error")
                {
                    MessageBox.Show("Auto-assign couldn't find any matching technicians! Please try again!", "Fault report", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    txtTechID.Text = result.GetValue(0).ToString();
                    txtTechName.Text = result.GetValue(1).ToString();
                    txtZone.Text = result.GetValue(2).ToString();
                    txtJobs.Text = result.GetValue(3).ToString();

                    foreach (System.Data.DataRowView dr in dgTechnicians.ItemsSource)
                    {
                        var value = Convert.ToInt32(dr[0]);
                        int index = dgTechnicians.Items.IndexOf(dr);
                        if (value == Convert.ToInt32(result.GetValue(0)))
                        {
                            dgTechnicians.ScrollIntoView(dgTechnicians.Items[index]);
                            DataGridRow row = (DataGridRow)dgTechnicians.ItemContainerGenerator.ContainerFromIndex(index);
                            TextBlock cellContent = dgTechnicians.Columns[1].GetCellContent(row) as TextBlock;

                            object item = dgTechnicians.Items[index];
                            dgTechnicians.SelectedItem = item;
                            dgTechnicians.ScrollIntoView(item);
                            row.MoveFocus(new TraversalRequest(FocusNavigationDirection.Next));
                        }
                        
                    }
                    MessageBox.Show("Technician found!" + "\n" + "\nTechincian ID: " + result.GetValue(0).ToString() + "\nName: " + result.GetValue(1).ToString(), "Fault report", MessageBoxButton.OK, MessageBoxImage.Information);
                    dispatcherTimer.Start();
                }
                
            }
        }

        private void btnCancleFault_Click(object sender, RoutedEventArgs e)
        {
           MessageBoxResult result = MessageBox.Show("Are you sure you wish to leave this window? Any entered information will be deleted!", "Fault report", MessageBoxButton.YesNo, MessageBoxImage.Warning);

            switch (result)
            {
                case MessageBoxResult.Yes:
                    FaultReport report = new FaultReport();
                    report.Show();
                    this.Close();
                    break;
                case MessageBoxResult.No:
                    break;
            }
        }

        private void btnHome_Click(object sender, RoutedEventArgs e)
        {
            Technician_Dispatch dispatch = new Technician_Dispatch();
            dispatch.Show();
            this.Close();
        }

        private void btnSaveFault_Click(object sender, RoutedEventArgs e)
        {
            int staffID = Convert.ToInt32(txtStaffID.Text);
            int staffMachineID = Convert.ToInt32(txtMachineID.Text);
            int techID = Convert.ToInt32(txtTechID.Text);
            int zone = Convert.ToInt32(cmbZone.Text);
            string comments = txtComments.Text;
            string status = "Waiting";
            DateTime date = DateTime.Now;

            string insertNewJob = "INSERT INTO jobs (reportingStaffID, reportingMachineID, assignedTechnicianID, zoneNo, date_time, status, comments) VALUES (@staffID, @staffMachineID, @techID, @zone, @dateTime, @status, @comments)";
            
            var cmd = database2.dataConnection(insertNewJob);

            cmd.Parameters.Add("@staffID", OleDbType.Integer).Value = staffID;
            cmd.Parameters.Add("@staffMachineID", OleDbType.Integer).Value = staffMachineID;
            cmd.Parameters.Add("@techID", OleDbType.Integer).Value = techID;
            cmd.Parameters.Add("@zone", OleDbType.Integer).Value = zone;
            cmd.Parameters.Add("@dateTime", OleDbType.Date).Value = date;
            cmd.Parameters.Add("@status", OleDbType.VarChar).Value = status;
            cmd.Parameters.Add("@comments", OleDbType.VarChar).Value = comments;

            var data = database2.parameters();

                try
                {
                    MessageBoxResult result = MessageBox.Show("Are you sure you wish to add this job?", "Fault report", MessageBoxButton.YesNo, MessageBoxImage.Warning);

                    switch (result)
                    {
                        case MessageBoxResult.Yes:
                            MessageBox.Show("Job seccessfuly added!", "Fault report", MessageBoxButton.OK, MessageBoxImage.Information);

                            string newRecord = "Added new user reported job: " + staffID + "," + staffMachineID + "," + techID + "," + zone + "," + date + "," + status + "," + comments + "<br>";
                            using (StreamWriter writer = new StreamWriter(@"..\..\..\log.txt", true))
                            {
                                writer.WriteLine(newRecord);
                            }

                            Technician_Dispatch dispatch = new Technician_Dispatch();
                            dispatch.Show();
                            this.Close();

                            break;
                        case MessageBoxResult.No:
                            break;
                    }                    
                }
                catch
                {
                    MessageBox.Show("Ooops. Something went wrong!", "Fault report", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
        }

        private void cmbLogout(object sender, RoutedEventArgs e)
        {
            Login loginWindow = new Login();
            this.Close();
            loginWindow.Show();
        }

        private void dgTechnicians_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            if (e.PropertyName.StartsWith("technicianID"))
            {
                e.Column.Header = "ID";
            }
            else if (e.PropertyName.StartsWith("technician_Name"))
            {
                e.Column.Header = "Technician Name";
            }
            else if (e.PropertyName.StartsWith("technician_Surname"))
            {
                e.Column.Header = "Technician Surname";
            }
            else if (e.PropertyName.StartsWith("current_Location"))
            {
                e.Column.Header = "Current Location";
            }
        }

        private void txtComments_TextChanged(object sender, TextChangedEventArgs e)
        {
            lblTextCount.Content = txtComments.Text.Length + "/200";
        }
    }
}
