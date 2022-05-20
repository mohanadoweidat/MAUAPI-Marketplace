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
    public partial class OrderHistory : System.Web.UI.Page
    {
        DbActions db;
        protected void Page_Load(object sender, EventArgs e)
        {
            db = new DbActions();
        }
         
        protected void searchBtn_Click(object sender, EventArgs e)
        {
            string username = Session["Username"].ToString();

            string dateFrom = searchDateFrom.Value;
            DateTime date_from = DateTime.ParseExact(dateFrom, "yyyy-MM-dd",
                                  CultureInfo.InvariantCulture);

            string dateTo = searchDateTo.Value;
           
            DateTime date_to = DateTime.ParseExact(dateTo, "yyyy-MM-dd",
                                  CultureInfo.InvariantCulture);


            List<UserOrders> orders = db.GetOrderHistoryByUser(username, date_from, date_to).Result;

            var order = from o in orders
                        select new
                        {
                            o.Id,
                            o.OrderDate,
                            o.OrderStatus,
                            o.GrandTotal
                        };

            orderHistoryGrid.DataSource = order;
            orderHistoryGrid.DataBind();

            if (orderHistoryGrid.Rows.Count > 0)
            {
                gridPanel.Visible = true;
                
            }
            else
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "noOrdersFound()", true);
                gridPanel.Visible = false;
            }
        }
    }
}