using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication.Models;

namespace WebApplication
{
    public partial class Products : System.Web.UI.Page
    {
        DbActions db;
        Cart myCart;
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["addProduct"] = "false";

            logIn_Btn.Click += LogIn_Btn_Click;
            yearLbl.Text = DateTime.Now.Year.ToString();
            profile_btn.Click += Profile_btn_Click;
            searchBtn.ServerClick += SearchBtn_ServerClick;
            db = new DbActions();

            if (!IsPostBack)
            {
                if (Session["Username"] != null)
                {
                    logIn_Btn.Visible = false;
                    profile_btn.Visible = true;
                    wlcLbl.Text = "Welcome:" + Session["Username"].ToString();
                }
                fillProductType();
                fillConditions();
                loadProducts();
            }
        }

        //This function will show products based on user inputs.
        private void SearchBtn_ServerClick(object sender, EventArgs e)
        {
            UserProducts userProducts = new UserProducts();
            userProducts.ProductName = searchName.Value;
            userProducts.ProductType = productTypeDropDownList.SelectedValue;
            userProducts.ProductCondition = productConditionList.SelectedValue;
            List<UserProducts> searchResults = db.GetProductsBySearchInput(userProducts).Result;
            if (searchResults == null)
            {
                ApiController.Text = "Plaese check your connection to the API!";
                return;
            }


            if (searchResults.Count == 0)
            {
                //Clear old results
                productDataList.DataSource = null;
                productDataList.DataBind();
                noResult.Visible = true;
            }
            else
            {
                noResult.Visible = false;

                //Clear old results
                productDataList.DataSource = null;
                productDataList.DataBind();

                //Show new results
                productDataList.DataSource = searchResults;
                productDataList.DataBind();
            }

            
        }


        //This function will redirect the user to login page.
        private void LogIn_Btn_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }

        //This function will redirect the user to profile page.
        private void Profile_btn_Click(object sender, EventArgs e)
        {
            Response.Redirect("UserInterest.aspx");
        }


        //This function load all the products.
        private void loadProducts()
        {
            List<UserProducts> allproducts = db.LoadAllProducts().Result;
            if (allproducts == null)
            {
                ApiController.Text = "Plaese check your connection to the API!";
                return;
            }
            if (allproducts.Count == 0)
            {
                lblEmpty.Visible = true;
                //Clear old products from view --> Maybe delete this.
                productDataList.DataSource = null;
                productDataList.DataBind();
            }
            else
            {
                var minOrderd = allproducts.OrderByDescending(s => s.productPrice);
                productDataList.DataSource = minOrderd;
                productDataList.DataBind();
            }
           

        }


        //This function will populate the type dropdownlist with types.
        private void fillProductType()
        {
            string[] productTypeArray = { "Laptops", "Mobile phones", "Accessories", "Other" };
            productTypeDropDownList.DataSource = productTypeArray;
            productTypeDropDownList.DataBind();
        }
        //This function will populate the condition dropdownlist with conditions.
        private void fillConditions()
        {
            string[] conditionsArray = { "New", "Very good", "Good", "Not working properly" };
            productConditionList.DataSource = conditionsArray;
            productConditionList.DataBind();
        }


        //When user press on min or max
        protected void priceRangeList_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<UserProducts> allproducts = db.LoadAllProducts().Result;

            if (allproducts == null)
            {
                ApiController.Text = "Plaese check your connection to the API!";
                return;
            }
            else if (allproducts.Count == 0)
            {
                lblEmpty.Visible = true;
                //Clear old products from view --> Maybe delete this.
                productDataList.DataSource = null;
                productDataList.DataBind();
            }
            else
            {
                if (IsPostBack)
                {
                    if (priceRangeList.SelectedValue == "Max")
                    {
                        //Clear old products from view --> Maybe delete this.
                        productDataList.DataSource = null;
                        productDataList.DataBind();

                        var maxOrderd = allproducts.OrderBy(s => s.productPrice);
                        productDataList.DataSource = maxOrderd;
                        productDataList.DataBind();
                    }
                    else
                    {
                        //Clear old products from view --> Maybe delete this.
                        productDataList.DataSource = null;
                        productDataList.DataBind();

                        var minOrderd = allproducts.OrderByDescending(s => s.productPrice);
                        productDataList.DataSource = minOrderd;
                        productDataList.DataBind();
                    }
                }
                
            }
 
        }

        protected void productDataList_ItemCommand(object source, DataListCommandEventArgs e)
        {
            
            if (e.CommandName == "AddToCart")
            {
                if (Session["Username"] != null)
                {
                    if (Session["myCart"] == null)
                    {
                        myCart = new Cart();
                        Session["myCart"] = myCart;
                    }
                    string productId = e.CommandArgument.ToString();
                    myCart = (Cart)Session["myCart"];

                   UserProducts addedProduct = db.GetCartProductById(new Guid(productId)).Result;


                 bool done =  myCart.AddItemToCart(new CartItem(
                        new Guid(productId), 
                        addedProduct.ProductName, 
                        addedProduct.productPrice,
                        addedProduct.ProductYearOfMake, 
                        addedProduct.ProductColour, 
                        addedProduct.ProductCondition, 
                        addedProduct.ProductOwner));

                    if (done)
                    {
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "addProductCartSuccess()", true);
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "productExistInCart()", true);
                    }
 
                    
                }
                else
                {
                    //Please login first!
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "logInFirst()", true);
                }
               
            }
        }

        protected void cartBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("UserCart.aspx");
        }
    }
}