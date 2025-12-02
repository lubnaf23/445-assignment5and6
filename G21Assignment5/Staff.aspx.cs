using System;
using System.Web.UI;
using System.Xml.Linq;
using DLLClass; // For SecurityHelper

namespace G21Assignment5
{
    public partial class Staff : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["StaffUser"] != null)
            {
                ShowDashboard(Session["StaffUser"].ToString());
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            if (ValidateCredentials(username, password))
            {
                Session["StaffUser"] = username;
                ShowDashboard(username);
            }
            else
            {
                lblStatus.Text = "Invalid username or password.";
            }
        }

        private bool ValidateCredentials(string username, string password)
        {
            try
            {
                string path = Server.MapPath("~/App_Data/Staff.xml");
                XDocument doc = XDocument.Load(path);

                foreach (var staff in doc.Descendants("Staff"))
                {
                    string user = staff.Element("Username")?.Value;
                    string pass = staff.Element("Password")?.Value;

                    if (user != null && pass != null &&
                        user.Equals(username, StringComparison.OrdinalIgnoreCase) &&
                        pass == password)
                    {
                        return true;
                    }
                }
            }
            catch
            {
                lblStatus.Text = "Error reading Staff.xml file.";
            }

            return false;
        }

        private void ShowDashboard(string username)
        {
            pnlLogin.Visible = false;
            pnlDashboard.Visible = true;
            lblWelcome.Text = $"Welcome, {username}!";
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Clear();
            pnlLogin.Visible = true;
            pnlDashboard.Visible = false;
        }
    }
}
