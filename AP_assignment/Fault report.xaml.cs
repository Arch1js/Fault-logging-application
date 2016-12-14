using System;
using System.Windows.Threading;
using System.Windows;
using System.Windows.Controls;
using MahApps.Metro.Controls;
using System.Data;
using System.Data.OleDb;

namespace Fault_Logger
{
    public partial class FaultReport
    {
        dataBaseConnection database = new dataBaseConnection();//new instance of database connection
        DispatcherTimer dispatcherTimer = new DispatcherTimer();

        int staffID;
        int machineID;
        int zoneNo;
        string staffName;
        string staffSurname;
        int currentIndex = -1;

        public FaultReport()
        {
            InitializeComponent();
            loadUser();//load session user
            loadAllUsers();//load all users in to datagrid

            dispatcherTimer.Tick += new EventHandler(OnTimedEvent);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 3);
            dispatcherTimer.Start();
        }

        private void OnTimedEvent(object sender, EventArgs e)//auto refresh function
        {
            var data = database.parameters();
            dgUsers.ItemsSource = data.Tables[0].DefaultView;

            moveSelection();
        }

        private void moveSelection()//move selection in to place after auto refresh has refreshed datagrid
        {
            try
            {
                if (currentIndex != -1)//if index of selected item is not outside the bounds
                {              
                    object item = dgUsers.Items[currentIndex];//get the object of selected item

                    dgUsers.SelectedItem = item;//select the item from datagrid
                    dgUsers.ScrollIntoView(item);//scroll in to view
                }
            }
            catch 
            {                
               //do nothing
            }
           
        }

        private void loadUser()
        {
            string username = Application.Current.Properties["sessionUsername"].ToString();
            string user = "Welcome, " + username;
            cmbUser.SetValue(TextBoxHelper.WatermarkProperty, user);
        }

        private void loadAllUsers()
        {
            string sqlAvailableTechs = "SELECT userID, currentMachineID, zoneNo, username, staffName, staffSurname, jobTitle FROM users";
            var cmd = database.dataConnection(sqlAvailableTechs);
            
            var data = database.parameters();
            dgUsers.ItemsSource = data.Tables[0].DefaultView;
        }

        private void txtSearchQuery_TextChanged(object sender, TextChangedEventArgs e)//search on keystroke
        {
            string search = txtSearchQuery.Text;
            string sqlSearchStaff = "SELECT userID, zoneNo, currentMachineID, username, staffName, staffSurname, jobTitle FROM users WHERE username LIKE @search OR staffName LIKE @search  OR staffSurname LIKE @search";

            var cmd = database.dataConnection(sqlSearchStaff);
            cmd.Parameters.AddWithValue("@search", OleDbType.VarChar).Value = "%" + search + "%";
            var data = database.parameters();

            dgUsers.ItemsSource = data.Tables[0].DefaultView;
        }

        private void btnContinue_Click(object sender, RoutedEventArgs e)
        {
            dispatcherTimer.Stop();

            string staffID = txtStaffID.Text;
            string machineID = txtMachineID.Text;
            string zoneNo = txtZoneNo.Text;
            string staffName = txtStaffName.Text;
            string staffSurname = txtStaffSurname.Text;
            string comment = txtComments.Text;

            if (machineID == "" || zoneNo == "" || staffID == "" || staffName == "" || staffSurname == "" || comment == "")
            {
                MessageBox.Show("Please enter all required fields!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                FaultReport2 report2 = new FaultReport2();
                report2.loadForm(staffID, zoneNo, machineID, comment);//pass values to next form
                report2.Show();
                this.Close();
            }
        }

        private void btnHome_Click(object sender, RoutedEventArgs e)
        {
            Technician_Dispatch dispatch = new Technician_Dispatch();
            dispatch.Show();
            this.Close();
        }

        private void cmbLogout(object sender, RoutedEventArgs e)//logout button
        {
            Login loginWindow = new Login();
            this.Close();
            loginWindow.Show();
        }

        private void dgUsers_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)//rename columns
        {
            if (e.PropertyName.StartsWith("userID"))
            {
                e.Column.Header = "ID";
            }
            else if (e.PropertyName.StartsWith("currentMachine"))
            {
                e.Column.Header = "Current Machine";
            }
            else if (e.PropertyName.StartsWith("zoneNo"))
            {
                e.Column.Header = "Zone";
            }
            else if (e.PropertyName.StartsWith("staffName"))
            {
                e.Column.Header = "Staff Name";
            }
            else if (e.PropertyName.StartsWith("staffSurname"))
            {
                e.Column.Header = "Staff Surname";
            }
            else if (e.PropertyName.StartsWith("jobTitle"))
            {
                e.Column.Header = "Job Title";
            }
        }

        private void dgUsers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
            if (dgUsers.SelectedIndex != -1)
            {
                currentIndex = dgUsers.SelectedIndex;
            }

            try
            {
                DataRowView dataRow = (DataRowView)dgUsers.SelectedItem;

                staffID = Convert.ToInt32(dataRow["userID"]);
                machineID = Convert.ToInt32(dataRow["currentMachineID"]);
                zoneNo = Convert.ToInt32(dataRow["zoneNo"]);
                staffName = dataRow["staffName"].ToString();
                staffSurname = dataRow["staffSurname"].ToString();
            }
            catch
            {
                
            }

            txtStaffID.Text = staffID.ToString();//set the text boxes to slected values
            txtMachineID.Text = machineID.ToString();
            txtZoneNo.Text = zoneNo.ToString();
            txtStaffName.Text = staffName;
            txtStaffSurname.Text = staffSurname;       
        }

        private void txtComments_TextChanged(object sender, TextChangedEventArgs e)//comment symbol count
        {
            lblTextCount.Content = txtComments.Text.Length + "/200";
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            currentIndex = -1;
            dgUsers.UnselectAll();

            txtStaffID.Text = "";
            txtMachineID.Text = "";
            txtStaffName.Text = "";
            txtStaffSurname.Text = "";
            txtZoneNo.Text = "";
            txtComments.Text = "";
        }
    }
}
