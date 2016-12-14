using System.Windows;
using MahApps.Metro.Controls;

namespace Fault_Logger
{
    public partial class reports
    {
        public reports()
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
        private void cmbLogout(object sender, RoutedEventArgs e)
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
        private void Button_Click(object sender, RoutedEventArgs e)
        {           
            Technician_Dispatch dispatch = new Technician_Dispatch();
            this.Close();
            dispatch.Show();
        }

        private void btnJobs_Click(object sender, RoutedEventArgs e)
        {
            jobLogs joblogs = new jobLogs();
            this.Close();
            joblogs.Show();
        }

        private void btnTechinicans_Click(object sender, RoutedEventArgs e)
        {
            technicianReport techReport = new technicianReport();
            this.Close();
            techReport.Show();           
        }

        private void btnDashboard_Click(object sender, RoutedEventArgs e)
        {
            dashboard dashboard = new dashboard();
            dashboard.Show();
        }      
    }
}
