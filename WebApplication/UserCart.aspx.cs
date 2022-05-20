using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication.Models;

namespace WebApplication
{
    public partial class UserCart : System.Web.UI.Page
    {
        DbActions db;
        Cart myCart;
        
        protected void Page_Load(object sender, EventArgs e)
        {
            db = new DbActions();
            signInBtn.ServerClick += SignInBtn_ServerClick;
            order_btn.ServerClick += Order_btn_ServerClick;

            if (Session["myCart"] == null)
            {
                Session["myCart"] = new Cart();
;           }
            myCart = (Cart)Session["myCart"];

            if (!IsPostBack)
            {
                fillCart();
                if (Session["Username"] != null)
                {
                    wlcLbl.Text = "Welcome back: " + Session["Username"].ToString();
                    login_form.Visible = false;
                     
                    if (cartGridView.Rows.Count > 0)
                    {
                        
                        cart_from.Visible = true;
                        cartItemsNumber.Text = cartGridView.Rows.Count.ToString();
                    }
                    else
                    {
                        cart_from.Visible = false;
                        emptyCartLbl.Visible = true;
                    }
                }
                else
                {
                    login_form.Visible = true;
                    cart_from.Visible = false;
                }
            }
        }

        //Fill the cart with added products by the user.
        private void fillCart()
        {
            cartGridView.DataSource = myCart.Items;
            cartGridView.DataBind();
            if (cartGridView.Rows.Count > 0)
            {
                cartGridView.FooterRow.Cells[3].Text = myCart.GrandTotal.ToString();
            }
        }


        //Place an order.
        private void Order_btn_ServerClick(object sender, EventArgs e)
        {
            string buyerName = Session["Username"].ToString();
            UserOrders orders = new UserOrders(buyerName);
             
            foreach (var item in myCart.Items)
            {
                orders.AddItemToOrder(new OrderItem(
                    item.Id,
                    orders.Id, 
                    item.ProductName, 
                    item.productPrice, 
                    item.ProductOwner));
            }


            //Place an order.
            bool ok =  db.AddOrder(orders).Result;
            if (ok)
            {
                myCart.Items.Clear();
                Session["myCart"] = null;
                Response.Redirect("Done.aspx");
            }
            else
            {
                //The products has been already ordered by this user or another!
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "productOrdered()", true);
                order_btn.Visible = false;
            }
        }

        //Sign in
        private void SignInBtn_ServerClick(object sender, EventArgs e)
        {
            UserAccount user = new UserAccount();
            user.Username = inputUsername.Value;
            user.Password = inputPassword.Value;
            bool found = db.CheckUserLogin(user).Result;
            if (!found)
            {
                Clear();
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "errorLogin()", true);
            }
            else
            {
                Session["Username"] = user.Username;
                Response.Redirect("index.aspx");
            }
        }


        //This function will clear the inputs field.
        private void Clear()
        {
            inputUsername.Value = inputPassword.Value = "" ;
        }
       

        //This function will fire when user delete an item from the cart.
        protected void cartGridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
           myCart.Delete(e.RowIndex);
           fillCart();

            if (IsPostBack)
            {
                if (cartGridView.Rows.Count == 0)
                {
                    cart_from.Visible = false;
                    emptyCartLbl.Visible = true;
                    cartItemsNumber.Text = "0";
                }
                else
                {
                    cartItemsNumber.Text = cartGridView.Rows.Count.ToString();
                }
            }
            
        }
    }
}