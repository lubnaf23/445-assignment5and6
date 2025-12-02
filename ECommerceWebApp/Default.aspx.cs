using SellerAccountService;
using ECommerceWebApp.SellerServiceRef;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ECommerceWebApp
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                MyDisplay.SellerId = 1;  //now visible
            }
        }

        protected void btnTestGlobal_Click(object sender, EventArgs e)
        {
            Response.Redirect(Request.RawUrl);  //triggers for asax
            lblGlobalLog.Text = "Reloaded - Check VS Debug Output for log"; //needs fix
        }

        protected void btnCreateSeller_Click(object sender, EventArgs e)
        {
            string hashPw = "temp_hash_" + txtPw.Text;  //temp
            var client = new SellerServiceClient();  //ref from service
            int id = client.CreateSeller(txtEmail.Text, hashPw, txtName.Text);
            lblSellerResult.Text = id > 0 ? "Success: ID " + id : "Error: Invalid";
            if (id > 0) MyDisplay.SellerId = id;  //change it up
        }
    }
}