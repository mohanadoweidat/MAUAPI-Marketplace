using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication
{
    public partial class UserMasterPage : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            logOut_btn.ServerClick += LogOut_btn_ServerClick;
            if (!IsPostBack)
            {
                if (Session["Username"] != null)
                {
                    inloggedUserName.Text = Session["Username"].ToString();
                }
            }

        }

        private void LogOut_btn_ServerClick(object sender, EventArgs e)
        {
            Session["Username"] = null;
            Session.Clear();
            Response.Redirect("index.aspx");
        }
    }
}