using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DLLClass; // DLL local component (hash/encrypt/decrypt)

namespace G21Assignment5
{
    public partial class TryIt : System.Web.UI.Page
    {
        // Return to Default.aspx
        protected void btnReturn_Click(object sender, EventArgs e) => Response.Redirect("Default.aspx");

        // Hash button calling DLLClass.SecurityHelper.hashString
        protected void btnHash_Click(object sender, EventArgs e)
        {
            try
            {
                string input = txtDLLInput.Text ?? string.Empty;
                lblDLLResult.Text = SecurityHelper.HashString(input);
            }
            catch (Exception)
            {
                lblDLLResult.Text = "Hash failed.";
            }
        }

        // Encrypt button calling DLLClass.SecurityHelper.Encrypt
        protected void btnEncrypt_Click(object sender, EventArgs e)
        {
            try
            {
                string input = txtDLLInput.Text ?? string.Empty;
                string key = txtDLLKey.Text ?? string.Empty;
                if (string.IsNullOrWhiteSpace(key))
                {
                    lblDLLResult.Text = "Provide a key for encryption.";
                    return;
                }
                lblDLLResult.Text = SecurityHelper.Encrypt(input, key);
            }
            catch (Exception)
            {
                lblDLLResult.Text = "Encrypt failed.";
            }
        }

        // Decrypt button calling DLLClass.SecurityHelper.Decrypt
        protected void btnDecrypt_Click(object sender, EventArgs e)
        {
            try
            {
                String input = txtDLLInput.Text ?? string.Empty; // Input should be ciphertext
                string key = txtDLLKey.Text ?? string.Empty;
                if (string.IsNullOrWhiteSpace(key))
                {
                    lblDLLResult.Text = "Provide a key for decryption.";
                    return;
                }
                lblDLLResult.Text = SecurityHelper.Decrypt(input, key);
            }
            catch (FormatException)
            {
                lblDLLResult.Text = "Decrypt failed: provide a valid encrypted string.";
            }
            catch (Exception)
            {
                lblDLLResult.Text = "Decrypt failed.";
            }
        }

    }
}