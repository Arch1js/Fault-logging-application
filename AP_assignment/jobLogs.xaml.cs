using System;
using System.Windows;
using MahApps.Metro.Controls;
using System.IO;


namespace Fault_Logger
{
    public partial class jobLogs
    {
        public jobLogs()
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
        private void btnPrint_Click(object sender, RoutedEventArgs e)
        {
            mshtml.IHTMLDocument2 doc = browser.Document as mshtml.IHTMLDocument2;
            doc.execCommand("Print", true, null);
        }

        string logFile = "";

        private void browser_Loaded(object sender, RoutedEventArgs e)//display the log file in web browser
        {
            using (StreamReader sr = new StreamReader(@"..\..\..\log.txt"))
            {
                logFile += "<!doctype html><html><head><meta charset='UTF-8'><style> body {font-family: Arial}</style><h5>";
                String line = sr.ReadToEnd();
                logFile += line;
                logFile += "</h5>";
                browser.NavigateToString(logFile);
            }
        }
        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            reports reports = new reports();
            reports.Show();
            this.Close();
        }
    }
}
