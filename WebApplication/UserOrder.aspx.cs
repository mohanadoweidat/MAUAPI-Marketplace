using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication.Models;

namespace WebApplication
{
    public partial class UserOrder : System.Web.UI.Page
    {
        DbActions db;
        protected void Page_Load(object sender, EventArgs e)
        {
            db = new DbActions();

            if (!IsPostBack)
            {
               fillPendingOrdersGrid();
               fillCompletedOrdersGrid();
            }
        }



        private void fillPendingOrdersGrid()
        {
            string username = Session["Username"].ToString();
            List<UserOrders> orders = db.GetPendingOrdersByUser(username).Result;

            var order = from o in orders
                        select new
                        {
                            o.Id,
                            o.OrderDate,
                            o.OrderStatus,
                            o.GrandTotal
                         };
 
               pendingProductsGrid.DataSource = order;
               pendingProductsGrid.DataBind();
            
        }

        private void fillCompletedOrdersGrid()
        {
            string username = Session["Username"].ToString();
            List<UserOrders> orders = db.GetCompletedOrdersByUser(username).Result;

            var order = from o in orders
                        select new
                        {
                            o.Id,
                            o.OrderDate,
                            o.OrderStatus,
                            o.GrandTotal
                        };

            completedOrdersGrid.DataSource = order;
            completedOrdersGrid.DataBind();
        }
    }
}