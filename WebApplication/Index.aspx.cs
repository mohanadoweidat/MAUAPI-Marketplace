using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication.Models;

namespace WebApplication
{
    public partial class Index : System.Web.UI.Page
    {
        private DbActions db;
        Cart myCart;
        protected void Page_Load(object sender, EventArgs e)
        {
            db = new DbActions();
            logIn_Btn.Click += LogIn_Btn_Click;
            profile_btn.Click += Profile_btn_Click;
            yearLbl.Text = DateTime.Now.Year.ToString();

            if (!IsPostBack)
            {
                if (Session["Username"] != null)
                {
                    wlcLbl.Text = "Welcome:" + Session["Username"].ToString();
                    logIn_Btn.Visible = false;
                    profile_btn.Visible = true;
                }
                loadProducts();
            }
        }


        //This function load all the products.
        private void loadProducts()
        {
            List<UserProducts> allproducts = db.LoadSomeProducts().Result;
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



        private void Profile_btn_Click(object sender, EventArgs e)
        {
            Response.Redirect("UserInterest.aspx");
        }

        private void LogIn_Btn_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
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


                    bool done = myCart.AddItemToCart(new CartItem(
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
    }
}