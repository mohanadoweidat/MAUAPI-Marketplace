using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication.Models;

namespace WebApplication
{
    public partial class SignUp : System.Web.UI.Page
    {
        DbActions db;
        protected void Page_Load(object sender, EventArgs e)
        {
            createUserBtn.Click += CreateUserBtn_Click;
             
            
            db = new DbActions();

            //Prevent inlogged user from entering this site after login.
            if (Session["Username"] != null)
            {
                Response.Redirect("index.aspx");
            }
        }

       

        //This method will add a user to the database.
        private void CreateUserBtn_Click(object sender, EventArgs e)
        {
            UserAccount user = new UserAccount();
            user.FirstName = Convert.ToString(inputFName.Value);
            user.LastName = Convert.ToString(inputLName.Value);
            user.DateOfBirth = DateTime.ParseExact(inputDate.Value, "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture);
            user.Email = Convert.ToString(inputEmail.Value);
            user.Username = Convert.ToString(input_Username.Value);
            user.Password = Convert.ToString(input_Password.Value);

            bool exist = db.CheckUsernameExist(user).Result;
            if (exist)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "UsernameExist()", true);
                Clear();
            }
            else
            {
                db.AddUser(user).Wait();
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", " signUpSuccess()", true);
            }
             
           // Response.Redirect("index.aspx");
           // ClientScript.RegisterStartupScript(this.GetType(), "myfunc" + UniqueID,
           //"alert('hello!'"+ inputFName.Value + ");", true);
        }


       

        //This function will clear the value of user inputs.
        private void Clear()
        {
            inputFName.Value = inputLName.Value = inputDate.Value = inputEmail.Value = input_Username.Value = input_Password.Value = "";
        }
    }
}