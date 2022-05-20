using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication.Models;

namespace WebApplication
{
    public partial class Login : System.Web.UI.Page
    {
        DbActions db;
        protected void Page_Load(object sender, EventArgs e)
        {
            login_btn.Click += Login_btn_Click;
            db = new DbActions();
          }

        private void Login_btn_Click(object sender, EventArgs e)
        {
            UserAccount user = new UserAccount();
            user.Username = username_input.Value;
            user.Password = password_input.Value;
            bool found = db.CheckUserLogin(user).Result;
            if (!found)
            {
                clear();
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "errorLogin()", true);
            }
            else
            {
                Session["Username"] = user.Username;
                Response.Redirect("index.aspx");
            }
        }
        private void clear()
        {
            username_input.Value = password_input.Value = "";
        }
    }
}