using System.Windows;
using MahApps.Metro.Controls;

namespace Fault_Logger
{
    public partial class Technician_Dispatch
    {
        public Technician_Dispatch()
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

        private void btnFault_Click(object sender, RoutedEventArgs e)
        {
            FaultReport fault = new FaultReport();
            fault.Show();
            this.Close();
        }

        private void btnMaintenance_Click(object sender, RoutedEventArgs e)
        {
            Maintenance maintenance_window = new Maintenance();
            maintenance_window.Show();
            this.Close();
        }

        private void cmbLogout(object sender, RoutedEventArgs e)
        {
            Login loginWindow = new Login();
            this.Close();
            loginWindow.Show();
        }

        private void btnReport_Click(object sender, RoutedEventArgs e)
        {
            reports reports = new reports();

            reports.Show();
            this.Close();
        }

        private void btnManage_Click(object sender, RoutedEventArgs e)
        {
            Manage_Jobs manageJobs = new Manage_Jobs();
            manageJobs.Show();
            this.Close();
        }
    }
}
