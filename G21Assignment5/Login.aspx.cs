using System;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.IO;
using System.Xml;
using System.Web.Security;
using DLLClass;
using G21Assignment5.BuyerServiceRef;

namespace G21Assignment5
{
    public partial class Login : Page
    {
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string user = txtUsername.Text.Trim();
            string pw = txtPassword.Text.Trim();
            string role = rblRole.SelectedValue;

            bool valid = false;

            if (role == "Member")
                valid = ValidateMember(user, pw);
            else if (role == "Staff")
                valid = ValidateStaff(user, pw);

            if (valid)
            {
                FormsAuthentication.SetAuthCookie(user, false);
                Response.Redirect(role == "Member" ? "Member.aspx" : "Staff.aspx");
            }
            else
            {
                lblMessage.Text = "Invalid credentials.";
            }
        }

        protected void btnShowRegister_Click(object sender, EventArgs e)
        {
            pnlLogin.Visible = false;
            pnlRegister.Visible = true;
            lblRegisterError.Text = "";
        }

        protected void btnBackToLogin_Click(object sender, EventArgs e)
        {
            pnlRegister.Visible = false;
            pnlLogin.Visible = true;
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            if (Session["Captcha"] == null ||
                txtCaptcha.Text.Trim().ToUpper() != Session["Captcha"].ToString().ToUpper())
            {
                lblRegisterError.Text = "Captcha incorrect.";
                return;
            }

            if (txtRegPassword.Text != txtRegConfirmPW.Text)
            {
                lblRegisterError.Text = "Passwords don't match.";
                return;
            }

            if (string.IsNullOrWhiteSpace(txtRegEmail.Text) ||
                string.IsNullOrWhiteSpace(txtRegName.Text) ||
                txtRegPassword.Text.Length < 6)
            {
                lblRegisterError.Text = "Valid email, name, and PW (6+ chars) required.";
                return;
            }

            // Hash PW correctly
            string hashedPw = SecurityHelper.HashString(txtRegPassword.Text);

            Service1Client client = new Service1Client();
            bool result = client.addBuyer(txtRegEmail.Text, hashedPw, txtRegName.Text);

            if (result)
            {
                lblRegisterError.ForeColor = System.Drawing.Color.Green;
                lblRegisterError.Text = "Registered successfully! Please log in.";
                pnlRegister.Visible = false;
                pnlLogin.Visible = true;
            }
            else
            {
                lblRegisterError.Text = "Email already registered.";
            }
        }

        protected void btnRefreshCaptcha_Click(object sender, EventArgs e)
        {
            imgCaptcha.ImageUrl = "~/CaptchaImage.aspx?ts=" + DateTime.Now.Ticks;
        }

        private bool ValidateMember(string email, string pw)
        {
            try
            {
                Service1Client client = new Service1Client();

                // Get all buyers
                var buyers = client.getBuyers();
                if (buyers == null) return false;

                var match = buyers.FirstOrDefault(b => b.Email == email);
                if (match == null) return false;

                // Compare hashed passwords
                string hashInput = SecurityHelper.HashString(pw);
                return hashInput == match.HashedPw;
            }
            catch
            {
                return false;
            }
        }

        private bool ValidateStaff(string username, string pw)
        {
            string path = Server.MapPath("~/Staff.xml");
            if (!File.Exists(path)) return false;

            XmlDocument doc = new XmlDocument();
            doc.Load(path);

            XmlNode node = doc.SelectSingleNode($"/StaffAccounts/Staff[Username='{username}']");
            if (node == null) return false;

            string storedHash = node.SelectSingleNode("Password").InnerText;
            return SecurityHelper.HashString(pw) == storedHash;
        }
    }
}
