using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace G21Assignment5
{
    public partial class ProductCard : System.Web.UI.UserControl
    {
        // public properties make the control reusable and configurable
        public string ProductName
        {
            get { return lblName.Text; }
            set { lblName.Text = value; }
        }

        public string Description
        {
            get { return lblDescription.Text; }
            set { lblDescription.Text = value; }
        }

        public double Price
        {
            get
            {
                double.TryParse(lblPrice.Text.Replace("$", ""), out double price);
                return price;
            }
            set { lblPrice.Text = "$" + value.ToString("F2"); }
        }

        public bool IsAvailable
        {
            get { return lblAvailability.Text == "Available"; }
            set
            {
                lblAvailability.Text = value ? "Available" : "Out of Stock";
                lblAvailability.ForeColor = value ? System.Drawing.Color.Green : System.Drawing.Color.Red;
            }
        }

        public string ImageUrl
        {
            get { return imgProduct.ImageUrl; }
            set { imgProduct.ImageUrl = value; }
        }

        protected void Page_Load(object sender, EventArgs e) { }
    }
}
