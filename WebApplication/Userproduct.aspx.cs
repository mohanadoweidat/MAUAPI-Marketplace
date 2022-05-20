using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication.Models;

namespace WebApplication
{
    public partial class Userproduct : System.Web.UI.Page
    {
        DbActions db;
        

        protected void Page_Load(object sender, EventArgs e)
        {
            
            db = new DbActions();
             
            if (!IsPostBack)
            {
                bindGrid();
                fillOrdersGrid();
            }
        }



        //Fill the grid with products that the seller owns.
        private void bindGrid()
        {
            string productOwner = Session["Username"].ToString();
            UserProducts userProducts = new UserProducts();
            userProducts.ProductOwner = productOwner;
            List<UserProducts> userproduct = db.GetProductsByOwner(userProducts).Result;
            
            productsGrid.DataSource = userproduct;
            productsGrid.DataBind();
        }


        //This function will delete the selected product when user click the delete button.
        protected void productsGrid_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            Label productToDelete = productsGrid.Rows[e.RowIndex].FindControl("Id") as Label;
            Label productStatus = productsGrid.Rows[e.RowIndex].FindControl("productStatus") as Label;
            if (productStatus.Text != "Available")
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "ErrorDelete()", true);
            }
            else
            {
                //Delete
                UserProducts products = new UserProducts();
                products.Id = new Guid(productToDelete.Text);

                bool done = db.DeleteProductById(products).Result;
                if (done)
                {
                    //Update grid
                    bindGrid();
                }
            }
        }
 

        //This will fill the buying request grid with orders that needs to be confirmed.
        private void fillOrdersGrid()
        {
            string sellerName = Session["Username"].ToString();
            List<UserOrders> orders  = db.GetSellerOrders(sellerName).Result;
             
            DataTable dt = new DataTable();
            DataRow dr = null;
            dt.Columns.Add("Order id", System.Type.GetType("System.String"));
            dt.Columns.Add("Product id", System.Type.GetType("System.String"));
            dt.Columns.Add("Product name", System.Type.GetType("System.String"));
            dt.Columns.Add("Buyer name", System.Type.GetType("System.String"));
           
          
            foreach (UserOrders item in orders)
            {
                foreach (var orderItems in item.Items)
                {
                    dr = dt.NewRow();
                    dr["Order id"] = item.Id;
                    dr["Product id"] = orderItems.ProductId;
                    dr["Product name"] = orderItems.ProductName;
                    dr["Buyer name"] = item.BuyerName;

                    dt.Rows.Add(dr);
                }
            }
            dt.AcceptChanges();
            ordersGrid.DataSource = dt;
            ordersGrid.DataBind();


        }



        //If the seller accept the order. --> Change order status to : Accepted.
        //Change the status for products within the order to sold.
        //protected void acceptBtn_Click(object sender, EventArgs e)
        //{
        // //   string sellerName = Session["Username"].ToString();

        // //   //If the seller accept the order. --> Change order status to : Accepted.
        // //  bool done =  db.ChangeOrderStatus(sellerName, "Accepted").Result;
        // //  if (done)
        // //  {

        // //       ////Get products id in order with orderStatus => Accepted form the databse.
        // //       List<UserOrders> productsIdInOrder = db.GetAllProductsIdInAcceptedOrders().Result;

        // //       //ALl products id
        // //       List<UserProducts> allproducts = db.LoadAllProducts().Result; 


        // //       //This list will contain the id that have order with accepted status.
        // //       List<UserProducts> productsIdToSend = new List<UserProducts>();

        // //       //Check if there is an id match.
        // //       CheckId(productsIdInOrder, allproducts, productsIdToSend);
               

        // //       //Send them to a function for product status changing to ---> Sold
        // //       bool ok = db.ChangeProductStatus(productsIdToSend).Result;
                
        // //  }
        // ////Update the grids.
        // //fillOrdersGrid();
        // //bindGrid();
        //}


        /*This function will check if the id of products in order exist in all products and it will add the match id to an object
        Then add the object to a list.*/
        private void CheckId(List<UserOrders> productsIdInOrder, List<UserProducts> allproducts, List<UserProducts> productsIdToSend)
        {
            bool found = false; ;
            foreach (var orders in productsIdInOrder)
            {
                foreach (var ordersItem in orders.Items)
                {
                    foreach (var products in allproducts)
                    {
                        //There is id match
                        if (ordersItem.ProductId == products.Id)
                        {
                            //Save the ids.
                            UserProducts p = new UserProducts();
                            p.Id = products.Id;
                            productsIdToSend.Add(p);
                        }
                         
                    }
                }
            }
        }


        //If the seller decline the order.
        //protected void declineBtn_Click(object sender, EventArgs e)
        //{
        //    string sellerName = Session["Username"].ToString();

        //    //If the seller accept the order. --> Change order status to : Accepted.
        //    bool done = db.ChangeOrderStatus(sellerName, "Rejected").Result;

        //    //Update the grids.
        //    fillOrdersGrid();
        //    bindGrid();
        //}

        protected void ordersGrid_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            //If the seller accept the order. --> Change order status to : Accepted.
            if (e.CommandName == "accept")
            {
                string sellerName = Session["Username"].ToString();

              
                string orderId = e.CommandArgument.ToString();
                 
                bool done = db.ChangeOrderStatus(sellerName, "Accepted", new Guid(orderId)).Result;
                if (done)
                {

                    ////Get products id in order with orderStatus => Accepted form the databse.
                    List<UserOrders> productsIdInOrder = db.GetAllProductsIdInAcceptedOrders().Result;

                    //ALl products id
                    List<UserProducts> allproducts = db.LoadAllProducts().Result;


                    //This list will contain the id that have order with accepted status.
                    List<UserProducts> productsIdToSend = new List<UserProducts>();

                    //Check if there is an id match.
                    CheckId(productsIdInOrder, allproducts, productsIdToSend);


                    //Send them to a function for product status changing to ---> Sold
                    bool ok = db.ChangeProductStatus(productsIdToSend).Result;

                }
                //Update the grids.
                fillOrdersGrid();
                bindGrid();
            }
            //If the seller accept the order. --> Change order status to : Rejected.
            else if (e.CommandName == "decline")
            {
                string sellerName = Session["Username"].ToString();
                string orderId = e.CommandArgument.ToString();

                bool done = db.ChangeOrderStatus(sellerName, "Rejected", new Guid(orderId)).Result;

                //Update the grids.
                fillOrdersGrid();
                bindGrid();
            }
             
        }
    }
}