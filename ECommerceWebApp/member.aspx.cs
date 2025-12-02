using System;
using System.Web.UI;
using System.Web.Security;//forms
using System.Xml;
using System.IO;
using DLLClass;
using SellerAccountService;

namespace ECommerceWebApp
{
    public partial class Member : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (User.Identity.IsAuthenticated)
                {
                    pnlLogin.Visible = false;
                    pnlRegister.Visible = false;
                    pnlMemberContent.Visible = true;
                    lblWelcomeUser.Text = User.Identity.Name; //from auth
                }
                else
                {
                    pnlLogin.Visible = true;
                    pnlRegister.Visible = false;
                    pnlMemberContent.Visible = false;
                }
            }
        }

        protected void ShowRegister(object sender, EventArgs e)
        {
            pnlLogin.Visible = false;
            pnlRegister.Visible = true;
            lblRegisterError.Visible = false;
            //captcha load
        }

        protected void ShowLogin(object sender, EventArgs e)
        {
            pnlRegister.Visible = false;
            pnlLogin.Visible = true;
            lblLoginError.Visible = false;
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            lblLoginError.Visible = false;
            if (ValidateUser(txtEmail.Text, txtPassword.Text))
            {
                FormsAuthentication.SetAuthCookie(txtEmail.Text, false); //no persistent cookie
                Response.Redirect("Member.aspx");
            }
            else
            {
                lblLoginError.Text = "Invalid email or password.";
                lblLoginError.Visible = true;
            }
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            lblRegisterError.Visible = false;
            if (txtRegPassword.Text != txtRegConfirmPW.Text)
            {
                lblRegisterError.Text = "Passwords don't match.";
                lblRegisterError.Visible = true;
                return;
            }
            
            if (string.IsNullOrWhiteSpace(txtRegEmail.Text) || string.IsNullOrWhiteSpace(txtRegName.Text) || txtRegPassword.Text.Length < 6)
            {
                lblRegisterError.Text = "Valid email, name, and PW (6+ chars) required.";
                lblRegisterError.Visible = true;
                return;
            }
            string hashedPw = SecurityHelper.Encrypt(txtRegPassword.Text, ""); // Your DLL
            if (AddToMemberXML(txtRegEmail.Text, hashedPw, txtRegName.Text))
            {
                lblRegisterError.Text = "Registered successfully! Login above.";
                lblRegisterError.ForeColor = System.Drawing.Color.Green;
                lblRegisterError.Visible = true;
                ShowLogin(null, null); // Switch panels
            }
            else
            {
                lblRegisterError.Text = "Email already registered.";
                lblRegisterError.Visible = true;
            }
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            FormsAuthentication.SignOut();
            Session.Clear(); //clear temp data
            Response.Redirect("Default.aspx");
        }

        protected void btnViewListings_Click(object sender, EventArgs e)
        {
            //seller service
            lblWelcomeUser.Text += " - Listings loaded (call CreateListing here)";
            //SellerAccountService.SellerServiceClient client = new SellerAccountService.SellerServiceClient();
        }

        // Helper Methods
        private bool ValidateUser(string email, string pw)
        {
            string path = Server.MapPath("~/Member.xml");
            if (!File.Exists(path)) return false;
            XmlDocument doc = new XmlDocument();
            doc.Load(path);
            XmlNodeList nodes = doc.SelectNodes($"/members/member[email='{email}']");
            if (nodes.Count == 0) return false;
            string storedHash = nodes[0].SelectSingleNode("hashedPw").InnerText;
            return SecurityHelper.Encrypt(pw, "") == storedHash; // DLL compare
        }

        private bool AddToMemberXML(string email, string hashedPw, string name)
        {
            string path = Server.MapPath("~/Member.xml");
            XmlDocument doc = new XmlDocument();
            if (File.Exists(path))
                doc.Load(path);
            else
                doc.LoadXml("<members></members>");

            //check duplicate
            XmlNodeList existing = doc.SelectNodes($"/members/member[email='{email}']");
            if (existing.Count > 0) return false;

            XmlElement member = doc.CreateElement("member");
            member.InnerXml = $"<email>{email}</email><hashedPw>{hashedPw}</hashedPw><name>{name}</name>";
            doc.DocumentElement.AppendChild(member);
            doc.Save(path);
            return true;
        }

        
       
    }
}