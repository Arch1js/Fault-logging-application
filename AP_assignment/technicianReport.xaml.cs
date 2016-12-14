using System;
using System.Windows.Threading;
using System.Windows;
using System.Windows.Controls;
using MahApps.Metro.Controls;

namespace Fault_Logger
{
    public partial class technicianReport
    {
        dataBaseConnection database = new dataBaseConnection();
        DispatcherTimer dispatcherTimer = new DispatcherTimer();

        int currentIndex = -1;

        public technicianReport()
        {
            InitializeComponent();
            loadUser();
            loadWorkingTechs();         

            dispatcherTimer.Tick += new EventHandler(OnTimeChange);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
            dispatcherTimer.Start();
        }
        private void OnTimeChange(object sender, EventArgs e)
        {
            String strDate = DateTime.Now.ToString();
            lblTime.Content = strDate;

            var data = database.parameters();
            dgTechnicians.ItemsSource = data.Tables[0].DefaultView;

            moveSelection();
        }
        private void loadUser()
        {
            string username = Application.Current.Properties["sessionUsername"].ToString();

            string user = "Welcome, " + username;
            cmbUser.SetValue(TextBoxHelper.WatermarkProperty, user);
        }
        private void cmbLogout(object sender, RoutedEventArgs e)
        {
            Login loginWindow = new Login();
            this.Close();
            loginWindow.Show();
        }
        private void btnHome_Click(object sender, RoutedEventArgs e)
        {
            dispatcherTimer.Stop();
            Technician_Dispatch dispatch = new Technician_Dispatch();
            dispatch.Show();
            this.Close();
        }

        private void loadWorkingTechs()
        {
            string sqlAvailableTechs = "SELECT technicianID, username, technician_Name, technician_Surname, specialization, current_Location, status FROM technicians";
            var cmd = database.dataConnection(sqlAvailableTechs);

            var data = database.parameters();
            dgTechnicians.ItemsSource = data.Tables[0].DefaultView;
        }

        private void OnDataGridPrinting(object sender, RoutedEventArgs e)//print the page
        {
            dispatcherTimer.Stop();
            PrintDialog Printdlg = new PrintDialog();

            if ((bool)Printdlg.ShowDialog().GetValueOrDefault())
            {
                Size pageSize = new Size(Printdlg.PrintableAreaWidth, Printdlg.PrintableAreaHeight);//setting the print size

                dgTechnicians.Measure(pageSize);
                dgTechnicians.Arrange(new Rect(5, 5, pageSize.Width, pageSize.Height));               

                Printdlg.PrintVisual(gridAll, Title);
            }
            dispatcherTimer.Start();
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            dispatcherTimer.Stop();
            reports reports = new reports();
            reports.Show();
            this.Close();
        }

        private void dgTechnicians_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            if (e.PropertyName.StartsWith("jobID"))
            {
                e.Column.Header = "ID";
            }
            else if (e.PropertyName.StartsWith("reportingStaffID"))
            {
                e.Column.Header = "Staff ID";
            }
            else if (e.PropertyName.StartsWith("reportingMachineID"))
            {
                e.Column.Header = "Machine ID";
            }
            else if (e.PropertyName.StartsWith("assignedTechnicianID"))
            {
                e.Column.Header = "Technician ID";
            }
            else if (e.PropertyName.StartsWith("zoneNo"))
            {
                e.Column.Header = "Zone No";
            }
            else if (e.PropertyName.StartsWith("date_time"))
            {
                e.Column.Header = "Date/time";
            }
            else if (e.PropertyName.StartsWith("status"))
            {
                e.Column.Header = "Status";
            }
            else if (e.PropertyName.StartsWith("comments"))
            {
                e.Column.Header = "Managers comments";
            }
            else if (e.PropertyName.StartsWith("techComments"))
            {
                e.Column.Header = "Technician comments";
            }
        }
        private void btnWorking_Click(object sender, RoutedEventArgs e)//get the currently working technicians and what machines they are working on
        {
            string sqlAvailableTechs = "SELECT technicianID, username, technician_Name, technician_Surname, specialization, current_Location, technicians.status, reportingMachineID FROM technicians INNER JOIN jobs ON technicians.technicianID = jobs.assignedTechnicianID";
            var cmd = database.dataConnection(sqlAvailableTechs);

            var data = database.parameters();
            dgTechnicians.ItemsSource = data.Tables[0].DefaultView;
        }

        private void btnAvailable_Click(object sender, RoutedEventArgs e)
        {
            string sqlAvailableTechs = "SELECT technicianID, username, technician_Name, technician_Surname, specialization, current_Location, status FROM technicians WHERE status = 'available'";
            var cmd = database.dataConnection(sqlAvailableTechs);

            var data = database.parameters();
            dgTechnicians.ItemsSource = data.Tables[0].DefaultView;
        }

        private void btnUnavailable_Click(object sender, RoutedEventArgs e)
        {
            string sqlAvailableTechs = "SELECT technicianID, username, technician_Name, technician_Surname, specialization, current_Location, status FROM technicians WHERE status = 'unavailable'";
            var cmd = database.dataConnection(sqlAvailableTechs);

            var data = database.parameters();
            dgTechnicians.ItemsSource = data.Tables[0].DefaultView;
        }

        private void btnBreak_Click(object sender, RoutedEventArgs e)
        {
            string sqlAvailableTechs = "SELECT technicianID, username, technician_Name, technician_Surname, specialization, current_Location, status FROM technicians WHERE status = 'On break'";
            var cmd = database.dataConnection(sqlAvailableTechs);

            var data = database.parameters();
            dgTechnicians.ItemsSource = data.Tables[0].DefaultView;
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            loadWorkingTechs();
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
        }
    }
}
