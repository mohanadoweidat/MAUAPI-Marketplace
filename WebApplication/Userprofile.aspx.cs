using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication.Models;

namespace WebApplication
{
    public partial class Userprofile : System.Web.UI.Page
    {
        private DbActions db;
        protected void Page_Load(object sender, EventArgs e)
        {
            updateProfile_btn.ServerClick += UpdateProfile_btn_ServerClick;
            db = new DbActions();
            if (!IsPostBack)
            {
                if (Session["Username"] != null)
                {
                    username.Value = Session["Username"].ToString();
                    LoadUserInfo();
                }
                else
                {
                    Response.Redirect("Login.aspx");
                }
            }
        }


        //This function will update user information.
        private void UpdateProfile_btn_ServerClick(object sender, EventArgs e)
        {
            UserAccount user = new UserAccount();
            user.Username = username.Value;
            user.FirstName = firstName.Value;
            user.LastName = lastName.Value;
            user.DateOfBirth = DateTime.ParseExact(dateOfBirth.Value, "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture);
            user.Email = email.Value;
            user.Password = newPassword.Value;
            db.UpdateUserProfile(user).Wait();
            if (IsPostBack)
            {
                LoadUserInfo();
            }
            
        }




        //This function will load user info in the profile page.
        private void LoadUserInfo()
        {
            UserAccount user = new UserAccount();
            user.Username = username.Value;
            List<UserAccount> userInfo = db.GetUserInformationByUsername(user).Result;
             
            for (int i = 0; i < userInfo.Count; i++)
            {
                firstName.Value = userInfo[i].FirstName;
                lastName.Value = userInfo[i].LastName;
                DateTime dateT = userInfo[i].DateOfBirth;
                string strDate = dateT.Date.ToString("yyyy-MM-dd");
                dateOfBirth.Value = strDate;
                email.Value = userInfo[i].Email;
                currentPassword.Value = userInfo[i].Password;
            }
        }
    }
}