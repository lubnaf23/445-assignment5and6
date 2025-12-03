using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace G21Assignment5
{
    public partial class CaptchaImage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Create a new random captcha string
            string captchaText = GenerateRandomCode(5);
            Session["Captcha"] = captchaText;

            // Create the image
            using (Bitmap bitmap = new Bitmap(120, 50))
            using (Graphics g = Graphics.FromImage(bitmap))
            {
                g.Clear(Color.White);

                // Draw text
                using (Font font = new Font("Arial", 20, FontStyle.Bold))
                using (Brush brush = new SolidBrush(Color.Black))
                {
                    g.DrawString(captchaText, font, brush, 10, 10);
                }

                // Add noise
                Random rand = new Random();
                for (int i = 0; i < 15; i++)
                {
                    int x = rand.Next(bitmap.Width);
                    int y = rand.Next(bitmap.Height);
                    bitmap.SetPixel(x, y, Color.Gray);
                }

                // Output the image
                Response.ContentType = "image/png";
                bitmap.Save(Response.OutputStream, ImageFormat.Png);
            }
        }

        private string GenerateRandomCode(int length)
        {
            string chars = "ABCDEFGHJKLMNPQRSTUVWXYZ23456789";
            Random rand = new Random();
            char[] code = new char[length];
            for (int i = 0; i < length; i++)
            {
                code[i] = chars[rand.Next(chars.Length)];
            }
            return new string(code);
        }

    }
}