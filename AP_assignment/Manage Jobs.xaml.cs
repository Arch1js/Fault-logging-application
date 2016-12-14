using System;
using System.Windows.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using MahApps.Metro.Controls;
using System.Data;
using System.Data.OleDb;
using System.IO;

namespace Fault_Logger
{
    public partial class Manage_Jobs
    {
        dataBaseConnection database = new dataBaseConnection();//for filter queries
        dataBaseConnection2 database2 = new dataBaseConnection2();//for updating and deleting
        DispatcherTimer dispatcherTimer = new DispatcherTimer();

        private int currentIndex = -1;

        public Manage_Jobs()
        {
            InitializeComponent();
            loadUser();
            loadAllJobs();

            dispatcherTimer.Tick += new EventHandler(OnTimedEvent);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 5);
            dispatcherTimer.Start();
        }

        private void OnTimedEvent(object sender, EventArgs e)
        {
            var data = database.parameters();
            dgJobs.ItemsSource = data.Tables[0].DefaultView;

            moveSelection();
        }
        private void moveSelection()
        {
            try
            {
                if (currentIndex != -1)
                {
                    object item = dgJobs.Items[currentIndex];
                    dgJobs.SelectedItem = item;
                    dgJobs.ScrollIntoView(item);
                }
            }
            catch
            {

            }      
        }

        private void loadUser()
        {
            string username = Application.Current.Properties["sessionUsername"].ToString();

            string user = "Welcome, " + username;
            cmbUser.SetValue(TextBoxHelper.WatermarkProperty, user);
        }
        private void ComboBoxItem_Selected(object sender, RoutedEventArgs e)
        {
            Login loginWindow = new Login();
            this.Close();
            loginWindow.Show();
        }
        private void btnHome_Click(object sender, RoutedEventArgs e)
        {
            Technician_Dispatch dispatch = new Technician_Dispatch();
            dispatch.Show();
            this.Close();
        }

        private void loadAllJobs()
        {
            string sqlAllJobs = "SELECT * FROM Jobs";

            var cmd = database.dataConnection(sqlAllJobs);           
            var data = database.parameters();

            dgJobs.ItemsSource = data.Tables[0].DefaultView;
        }

        private void dgJobs_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)//edit information inline (updating)
        {
            try
            {
                TextBox t = e.EditingElement as TextBox;//get the edditing element

                DataRowView dataRow = (DataRowView)dgJobs.SelectedItem;
                string columnName = e.Column.Header.ToString();

                if (columnName == "Zone No")
                {
                    columnName = "zoneNo";
                }
                else if (columnName == "Assigned Tech")
                {
                    columnName = "assignedTechnicianID";
                }
                else if (columnName == "Tech Comments")
                {
                    columnName = "techComments";
                }

                var newValue = t.Text;
                var prevValue = dataRow[columnName];//save previous value before editing

                MessageBoxResult result = MessageBox.Show("Are you sure you wish to update this Job information?" + "\n" + "\nYou are about to make change to " + columnName + "\n" + "\nCurrent value: "+ prevValue + "\nNew value: " + newValue, "Edit Job information", MessageBoxButton.YesNo, MessageBoxImage.Warning);                
                switch (result)
                {
                    case MessageBoxResult.Yes:               
                        int jobID = Convert.ToInt32(dataRow["jobID"]);

                        string sqlUpdateField = "UPDATE jobs SET " + columnName + " = @newValue WHERE jobID = @jobID";

                        var cmd = database2.dataConnection(sqlUpdateField);
                        cmd.Parameters.Add("@newValue", OleDbType.VarChar).Value = newValue;
                        cmd.Parameters.Add("@jobID", OleDbType.VarChar).Value = jobID;

                        string newRecord = "Job updated: " + jobID + ", Changed: " + prevValue + ", To: " + newValue +"<br>";

                        using (StreamWriter writer = new StreamWriter(@"..\..\..\log.txt", true))
                         {
                            writer.WriteLine(newRecord);
                         }

                        var data = database2.parameters();
                        dispatcherTimer.Start();

                        break;
                    case MessageBoxResult.No:       
                                        
                        TextBox editingValue = e.EditingElement as TextBox;
                        editingValue.Text = prevValue.ToString();

                        break;
                }                
            }

            catch
            {
                MessageBox.Show("Error occured while editing value!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void dgJobs_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            if (e.Column.Header.ToString() == "jobID")
            {
                e.Column.IsReadOnly = true; // Makes the column as read only
            }
            if (e.Column.Header.ToString() == "reportingStaffID")
            {
                e.Column.IsReadOnly = true; 
            }
            if (e.Column.Header.ToString() == "reportingMachineID")
            {
                e.Column.IsReadOnly = true; 
            }
            if (e.Column.Header.ToString() == "date_time")
            {
                e.Column.IsReadOnly = true; 
            }
            if (e.Column.Header.ToString() == "techComments")
            {
                e.Column.IsReadOnly = true; 
            }

            if (e.PropertyName.StartsWith("jobID"))
            {
                e.Column.Header = "Job ID";
            }
            else if (e.PropertyName.StartsWith("reportingStaffID"))
            {
                e.Column.Header = "Reporting Staff";
            }
            else if (e.PropertyName.StartsWith("reportingMachineID"))
            {
                e.Column.Header = "Machine ID";
            }
            else if (e.PropertyName.StartsWith("zoneNo"))
            {
                e.Column.Header = "Zone No";
            }
            else if (e.PropertyName.StartsWith("assignedTechnicianID"))
            {
                e.Column.Header = "Assigned Tech";
            }
            else if (e.PropertyName.StartsWith("date_time"))
            {
                e.Column.Header = "Date/Time";
            }
            else if (e.PropertyName.StartsWith("techComments"))
            {
                e.Column.Header = "Tech Comments";
            }
        }
        

        private void dgJobs_PreviewKeyDown(object sender, KeyEventArgs e)//delete record on key press
        {
            if (e.Key == Key.Delete)
            {
                DataRowView dataRow = (DataRowView)dgJobs.SelectedItem; 

                int jobID = 0;
                int reportingMachine = 0;
                int reportingStaff = 0;
                int faultZone = 0;
                int assignedTech = 0;

                try
                {                                       
                    reportingMachine = Convert.ToInt32(dataRow["reportingMachineID"]);
                    reportingStaff = Convert.ToInt32(dataRow["reportingStaffID"]);                    
                }
                catch
                {
                    reportingMachine = 0;
                    reportingStaff = 0;
                }

                jobID = Convert.ToInt32(dataRow["jobID"]);
                faultZone = Convert.ToInt32(dataRow["zoneNo"]);
                assignedTech = Convert.ToInt32(dataRow["assignedTechnicianID"]);

                var result = MessageBox.Show("Are you sure you wish to delete this job?" + "\n" + "\nJob ID: " + jobID + "\nReporting machine ID: " + reportingMachine + "\nReporting Staff ID: " + reportingStaff + "\nFault zone: " + faultZone + "\nAssigned Techncian: " + assignedTech, "Warning", MessageBoxButton.YesNo, MessageBoxImage.Warning);

                switch (result)
                {
                    case MessageBoxResult.Yes:                                          

                        string sqlDelete = "DELETE FROM jobs WHERE jobID = @jobID";

                        var cmd = database2.dataConnection(sqlDelete);
                        cmd.Parameters.Add("@jobID", OleDbType.VarChar).Value = jobID;

                        string deleteRecord = "Deleted Job: " + jobID + "," + reportingMachine + "," + reportingStaff + "," + faultZone + "," + assignedTech + "<br>";

                        using (StreamWriter writer = new StreamWriter(@"..\..\..\log.txt", true))
                        {
                           writer.WriteLine(deleteRecord);
                        }

                        var data = database2.parameters();
                        e.Handled = false;

                        break;
                    case MessageBoxResult.No:
                        e.Handled = true;

                        break;
                }            
            }
        }

        private void btnDoingFilter_Click(object sender, RoutedEventArgs e)
        {
            string sqlDoing = "SELECT * FROM Jobs WHERE status = 'Doing'";

            var cmd = database.dataConnection(sqlDoing);
            var data = database.parameters();

            dgJobs.ItemsSource = data.Tables[0].DefaultView;
        }

        private void btnWaitingFilter_Click(object sender, RoutedEventArgs e)
        {
            string sqlWaiting = "SELECT * FROM Jobs WHERE status = 'Waiting'";

            var cmd = database.dataConnection(sqlWaiting);
            var data = database.parameters();

            dgJobs.ItemsSource = data.Tables[0].DefaultView;
        }

        private void btnUnresolvedFilter_Click(object sender, RoutedEventArgs e)
        {
            string sqlUnresolved = "SELECT * FROM Jobs WHERE status = 'Unresolved'";

            var cmd = database.dataConnection(sqlUnresolved);
            var data = database.parameters();

            dgJobs.ItemsSource = data.Tables[0].DefaultView;
        }

        private void txtSearchQuery_TextChanged(object sender, TextChangedEventArgs e)
        {
            string search = txtSearchQuery.Text;
            string sqlSearchStaff = "SELECT * FROM jobs WHERE reportingStaffID LIKE @search OR reportingMachineID LIKE @search OR assignedTechnicianID LIKE @search OR zoneNo LIKE @search OR comments LIKE @search OR techComments LIKE @search";

            var cmd = database.dataConnection(sqlSearchStaff);
            cmd.Parameters.AddWithValue("@search", OleDbType.VarChar).Value = "%" + search + "%";
            var data = database.parameters();

            dgJobs.ItemsSource = data.Tables[0].DefaultView;
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            loadAllJobs();
        }

        private void dgJobs_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dgJobs.SelectedIndex != -1)
            {
                currentIndex = dgJobs.SelectedIndex;
            } 
        }

        private void dgJobs_BeginningEdit(object sender, DataGridBeginningEditEventArgs e)
        {
            dispatcherTimer.Stop();
        }
    }
}
