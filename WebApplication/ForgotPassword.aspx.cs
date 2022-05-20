using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication.Models;

namespace WebApplication
{
    public partial class ForgotPassword : System.Web.UI.Page
    {
        DbActions db;
        protected void Page_Load(object sender, EventArgs e)
        {
            db = new DbActions();
            loginbtn.Click += Loginbtn_Click;
            getPassword_btn.Click += GetPassword_btn_Click;
        }


        //This function will get userpassword from the database.
        private void GetPassword_btn_Click(object sender, EventArgs e)
        {
            UserAccount user = new UserAccount();
            user.Username = username_input.Value;
            String password = db.GetUserPassword(user).Result;
            if (password != "")
            {
                passwordLbl.Text = "Your password is:" + password;
                passwordLbl.ForeColor = System.Drawing.Color.Green;
                getPassword_btn.Visible = false;
                loginbtn.Visible = true;
            }
            else
            {
                passwordLbl.Text = "Your username does not exist in our system!";
                passwordLbl.ForeColor = System.Drawing.Color.Red;
                username_input.Value = "";
            }
        }

        //This function will redirect the user to the login page.
        private void Loginbtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }
    }
}