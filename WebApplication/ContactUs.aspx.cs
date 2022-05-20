using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication.Models;

namespace WebApplication
{
    public partial class ContactUs : System.Web.UI.Page
    {
        private DbActions db;
        protected void Page_Load(object sender, EventArgs e)
        {
            logIn_Btn.Click += LogIn_Btn_Click;
            profile_btn.Click += Profile_btn_Click;
            send_Btn.ServerClick += Send_Btn_ServerClick;
            yearLbl.Text = DateTime.Now.Year.ToString();
            db = new DbActions();

            if (!IsPostBack)
            {
                if (Session["Username"] != null)
                {
                    wlcLbl.Text = "Welcome:" + Session["Username"].ToString();
                    logIn_Btn.Visible = false;
                    profile_btn.Visible = true;

                }
            }
        }

       

        private void Profile_btn_Click(object sender, EventArgs e)
        {
            Response.Redirect("UserInterest.aspx");
        }

        private void LogIn_Btn_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }

        private void Send_Btn_ServerClick(object sender, EventArgs e)
        {

            if (emptyFields())
            {
                EmailData data = new EmailData();
                data.Username = name.Value;
                data.Subject = subject.Value;
                data.Email = email.Value;
                data.Message = textarea.Value;
                if (db.SendEmail(data).Result)
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "sendMessage()", true);
                    clear();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "InvalidEmail()", true);
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "emptyFields()", true);
            }
        }


        private bool emptyFields()
        {
            if (name.Value != "" ||subject.Value != "" || email.Value != "" || textarea.Value != "")
            {
                return true;
            }
            return false;
        }

        private void clear()
        {
            name.Value = subject.Value = email.Value = textarea.Value = "";
        }
    }
}