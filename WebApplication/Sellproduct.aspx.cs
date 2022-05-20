using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication.Models;

namespace WebApplication
{
    public partial class Sellproduct : System.Web.UI.Page
    {
        DbActions db;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                fillTypeList();
                fillYears();
                fillConditions();
            }
            

            sellButton.Click += SellButton_Click;
            db = new DbActions();   
        }




        //This function will populate the type dropdownlist with types.
        private void fillTypeList()
        {
            string[] productTypeArray = { "Laptops", "Mobile phones", "Accessories", "Other" };
            productTypeDropDownList.DataSource = productTypeArray;
            productTypeDropDownList.DataBind();
        }

        //This function will populate the year dropdownlist with years.
        private void fillYears()
        {
            int startYear = 1800;
            int endYear = DateTime.Now.Year;
            for (int i = endYear; i > startYear; i--)
            {
                yearpicker.Items.Add(i.ToString());
            }
        }

        //This function will populate the condition dropdownlist with conditions.
        private void fillConditions()
        {
            string[] conditionsArray = { "New", "Very good", "Good", "Not working properly"};
            productConditionList.DataSource = conditionsArray;
            productConditionList.DataBind();
        }

       

        

        //This function will list the product to the market.
        private void SellButton_Click(object sender, EventArgs e)
        {
            UserProducts userProduct = new UserProducts();
            userProduct.ProductName = productName.Text;
            userProduct.ProductType = productTypeDropDownList.SelectedValue;
            userProduct.productPrice = productPrice.Text;
            userProduct.ProductYearOfMake = Int32.Parse(yearpicker.SelectedValue);
            userProduct.ProductColour = prodcutColorList.SelectedValue;
            userProduct.ProductCondition = productConditionList.SelectedValue;
            userProduct.productStatus = "Available";
            userProduct.ProductOwner = Session["Username"].ToString();

            if (CheckEmpty())
            {
                db.AddProduct(userProduct).Wait();

                //Get all the users that are inrtessted in this product type.
                UserAccount userAccount = new UserAccount();
                userAccount.Notification = productTypeDropDownList.SelectedValue;
                List<UserAccount> usersWithInterest =  db.GetUsersWithInterest(userAccount).Result;


                // Change the notification column for them to the product type they are intressted in.
                Notify n = new Notify(usersWithInterest, productTypeDropDownList.SelectedValue);
                
                bool ok = db.AddNotification(n).Result;

                Clear();
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "addProductSuccess()", true);

            }
            else
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "emptyFields()", true);
             }
         }

        private void Clear()
        {
            productName.Text = productPrice.Text = "";
            productPrice.Text = null;
            prodcutColorList.SelectedValue = productConditionList.SelectedValue = productTypeDropDownList.SelectedValue = null;
        }


        private bool CheckEmpty()
        {
            if (productName.Text.Length == 0 || productPrice.Text.Length == 0 || yearpicker.SelectedValue == null || prodcutColorList.SelectedValue == null || productConditionList.SelectedValue == null ||productTypeDropDownList.SelectedValue == null)
            {
                return false;
            }
            return true;
        }
    }
}