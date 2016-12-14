using System;
using System.Windows.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using MahApps.Metro.Controls;
using System.Data.OleDb;
using System.Data;
using System.IO;

namespace Fault_Logger
{
    public partial class Maintenance
    {        
        dataBaseConnection database = new dataBaseConnection();
        dataBaseConnection2 database2 = new dataBaseConnection2();

        DispatcherTimer dispatcherTimer = new DispatcherTimer();

        int techID;
        string name;
        string surname;
        string specialization;
        int currentIndex = -1;

        public Maintenance()
        {
            InitializeComponent();
            loadUser();
            loadAllTechnicians();

            dispatcherTimer.Tick += new EventHandler(OnTimedEvent);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 3);
            dispatcherTimer.Start();
        }

        private void loadUser()
        {
            try
            {
                string username = Application.Current.Properties["sessionUsername"].ToString();

                string user = "Welcome, " + username;
                cmbUser.SetValue(TextBoxHelper.WatermarkProperty, user);
            }
            catch
            {
                MessageBoxResult result = MessageBox.Show("You are not logged in!", "Maintenance", MessageBoxButton.OK,
                    MessageBoxImage.Warning);

                switch (result)
                {
                    case MessageBoxResult.OK:
                        Login loginWindow = new Login();
                        this.Close();
                        loginWindow.Show();
                        break;
                }           
            }
        }

        private void OnTimedEvent(object sender, EventArgs e)
        {
            var data = database.parameters();

            dgTechnicians.ItemsSource = data.Tables[0].DefaultView;

            moveSelection();
        }

        private void loadAllTechnicians()
        {           
            string sqlAllTechs = "SELECT technicianID, username, technician_Name, technician_Surname, specialization, current_Location, status FROM technicians";
            var cmd = database.dataConnection(sqlAllTechs);
            var data = database.parameters();
           
            dgTechnicians.ItemsSource = data.Tables[0].DefaultView;
            
        }

        private void btnAvailable_Click(object sender, RoutedEventArgs e)
        {
            string sqlAvailableTechs = "SELECT technicianID, username, technician_Name, technician_Surname, specialization, current_Location, status FROM technicians WHERE status= @status";

            var cmd = database.dataConnection(sqlAvailableTechs);
            cmd.Parameters.Add("@status", OleDbType.VarChar).Value = "available";
            var data = database.parameters();

            dgTechnicians.ItemsSource = data.Tables[0].DefaultView;
        }

        private void txtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            string search = txtSearch.Text;
            string sqlSearchTech = "SELECT technicianID, username, technician_Name, technician_Surname, specialization, current_Location, status FROM technicians WHERE technicianID LIKE @searchInt OR technician_Name LIKE @search OR technician_Surname LIKE @search OR specialization LIKE @search OR current_location LIKE @searchInt";

            var cmd = database.dataConnection(sqlSearchTech);

            cmd.Parameters.AddWithValue("@search", OleDbType.VarChar).Value = "%" + search + "%";
            cmd.Parameters.AddWithValue("@searchInt", OleDbType.Integer).Value = "%" + search + "%";

            var data = database.parameters();//send parameters and return data

            dgTechnicians.ItemsSource = data.Tables[0].DefaultView;//apply data to datagrid
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            TextRange comments = new TextRange(rtxtComments.Document.ContentStart, rtxtComments.Document.ContentEnd);

            string techID = txtTechID.Text;
            string techName = txtTechName.Text;
            string techSurname = txtTechSurname.Text;
            string specialization = txtTechSpecialization.Text;
            string zone = cmbZone.Text;
            string comment = comments.Text;

            if (techID == "" || zone == "" || comment == "")
            {
                MessageBox.Show("Please enter all required fields!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {

            DateTime date = DateTime.Now;
            string status = "Waiting";

            string sqlMaintenanceJob = "INSERT INTO jobs (assignedTechnicianID, zoneNo, date_time, status, comments) VALUES (@techID, @zone, @dateTime, @status, @comments)";

            var cmd = database2.dataConnection(sqlMaintenanceJob);

            cmd.Parameters.Add("@techID", OleDbType.VarChar).Value = techID;
            cmd.Parameters.Add("@zone", OleDbType.VarChar).Value = zone;
            cmd.Parameters.Add("@dateTime", OleDbType.Date).Value = date;
            cmd.Parameters.Add("@status", OleDbType.VarChar).Value = status;
            cmd.Parameters.Add("@comments", OleDbType.VarChar).Value = comment;

            var data = database2.parameters();

                try
                {                    
                    MessageBoxResult result = MessageBox.Show("Are you sure you wish to add this maintenance job?", "Maintenance", MessageBoxButton.YesNo, MessageBoxImage.Warning);

                    switch (result)
                    {
                        case MessageBoxResult.Yes:

                            string newRecord = "Added new maintenance job: " + techID + "," + zone + "," + date + "," + status + "," + comment + "<br>";
                            using (StreamWriter writer = new StreamWriter(@"..\..\..\log.txt", true))
                            {
                                writer.WriteLine(newRecord);
                            }

                            MessageBox.Show("Job seccessfuly added!", "Maintenance", MessageBoxButton.OK, MessageBoxImage.Information);
                            ClearFields();

                            break;
                        case MessageBoxResult.No:
                            break;
                    }
                }
                catch
                {
                    MessageBox.Show("Ooops. Something went wrong!", "Maintenance", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
        
            }
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            ClearFields();
        }

        private void ClearFields()
        {
            TextRange comments = new TextRange(rtxtComments.Document.ContentStart, rtxtComments.Document.ContentEnd);

            currentIndex = -1;
            dgTechnicians.UnselectAll();

            txtTechID.Text = "";
            txtTechName.Text = "";
            txtTechSurname.Text = "";
            txtTechSpecialization.Text = "";
            cmbZone.Text = "";
            comments.Text = "";
        }

        private void btnHome_Click(object sender, RoutedEventArgs e)
        {
            Technician_Dispatch dispatch = new Technician_Dispatch();
            dispatch.Show();
            this.Close();
        }

        private void cmbLogout(object sender, RoutedEventArgs e)
        {
            Login loginWindow = new Login();
            this.Close();
            loginWindow.Show();
        }

        private void dgTechnicians_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            if (e.PropertyName.StartsWith("technicianID")) {
                e.Column.Header = "ID";
            }
            else if(e.PropertyName.StartsWith("technician_Name")) {
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

        private void moveSelection()
        {
            try
            {
                if (currentIndex != -1)
                {
                    object item = dgTechnicians.Items[currentIndex];
                    dgTechnicians.SelectedItem = item;
                    dgTechnicians.ScrollIntoView(item);
                }
            }
            catch
            {
                
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
                name = dataRow["technician_Name"].ToString();
                surname = dataRow["technician_Surname"].ToString();
                specialization = dataRow["specialization"].ToString();
            }
            catch
            {
                
            }

            txtTechID.Text = techID.ToString();
            txtTechName.Text = name;
            txtTechSurname.Text = surname;
            txtTechSpecialization.Text = specialization;
        }

        private void btnClearFilter_Click(object sender, RoutedEventArgs e)
        {
            loadAllTechnicians();
        }
    }
}
