using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication.Models;

namespace WebApplication
{
    public partial class UserInterest : System.Web.UI.Page
    {
        private DbActions db;
        protected void Page_Load(object sender, EventArgs e)
        {
            db = new DbActions();
            if (!IsPostBack)
            {
                fillTypeList();
                notifyInterest();
            }
            
            registrerBtn.Click += RegistrerBtn_Click;
            
        }


        //Add the choosen type to the Interest field in the database for the UserAccount model.
        private void RegistrerBtn_Click(object sender, EventArgs e)
        {
                UserAccount userAccount = new UserAccount();
                userAccount.Username = Session["Username"].ToString();
                userAccount.Interest = productTypeDropDownList.SelectedValue;
                bool done  =  db.AddInterest(userAccount).Result;
                if (done)
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "addInterestSuccess()", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "InterestAlreadyExist()", true);
                }
        }


        private void notifyInterest()
        {
            string username = Session["Username"].ToString();
            UserAccount account = db.GetNotificationByUsername(username).Result;
            if (!string.IsNullOrEmpty(account.Notification))
            {
                interestPanel.Visible = true;
                notificationLbl.Text = account.Notification;
                //Reset the notification column in database for this logged in user.
                resetNotification();
            }
        }

        private void resetNotification()
        {
            string username = Session["Username"].ToString();
            UserAccount userAccount = new UserAccount();
            userAccount.Username=username;
            db.resetNotification(userAccount).Wait();
        }


        //This function will populate the type dropdownlist with types.
        private void fillTypeList()
        {
            string[] productTypeArray = { "Laptops", "Mobile phones", "Accessories", "Other" };
            productTypeDropDownList.DataSource = productTypeArray;
            productTypeDropDownList.DataBind();
        }
    }
}