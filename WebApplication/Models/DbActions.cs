




using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication.Models
{
    public class DbActions
    {
        //HttoClient used to send requests to the API.
         HttpClient client;
          
        /******UserAccount functions*****/

        //This function will add a new user to the db.
        public async Task AddUser(UserAccount user)
        {
            client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:7024/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var stringContent = new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json");
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            try
            {
                var response = await client.PostAsync("UserAccount/Add", stringContent).ConfigureAwait(false);
                response.EnsureSuccessStatusCode();

                if (response.IsSuccessStatusCode)
                {
                    dynamic result = await response.Content.ReadAsStringAsync();
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message.ToString());
            }
         }

        //This function will add a new interest to the user.
        public async Task<bool> AddInterest(UserAccount user)
        {
            client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:7024/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var stringContent = new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json");
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            try
            {
                var response = await client.PostAsync("UserAccount/AddInterest", stringContent).ConfigureAwait(false);
                response.EnsureSuccessStatusCode();

                if (response.IsSuccessStatusCode)
                {
                    dynamic result = await response.Content.ReadAsStringAsync();
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
                return false;
            }
            return false;
        }
         
        //This function will change add a new Notification based on the intrest
        public async Task<bool> AddNotification(Notify notify)
        {
            client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:7024/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var stringContent = new StringContent(JsonConvert.SerializeObject(notify), Encoding.UTF8, "application/json");
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            try
            {
                var response = await client.PostAsync("UserAccount/AddNotification", stringContent).ConfigureAwait(false);
                response.EnsureSuccessStatusCode();

                if (response.IsSuccessStatusCode)
                {
                    dynamic result = await response.Content.ReadAsStringAsync();
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
            }
            return false;

        }

        //Reset the notfication field for the logged in user by its username.
        public async Task<bool> resetNotification(UserAccount username)
        {
            client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:7024/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var stringContent = new StringContent(JsonConvert.SerializeObject(username), Encoding.UTF8, "application/json");
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            try
            {
                var response = await client.PostAsync("UserAccount/ResetNotification", stringContent).ConfigureAwait(false);
                response.EnsureSuccessStatusCode();

                if (response.IsSuccessStatusCode)
                {
                    dynamic result = await response.Content.ReadAsStringAsync();
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
            }
            return false;
        }
 
        //Get all users that have interest.
        public async Task<List<UserAccount>> GetUsersWithInterest(UserAccount user)
        {
            client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:7024/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var stringContent = new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json");
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            try
            {
                var response = await client.PostAsync("UserAccount/GetUserWithInterest", stringContent).ConfigureAwait(false);


                if (response.IsSuccessStatusCode)
                {
                    dynamic result = await response.Content.ReadAsStringAsync();
                    var myobjList = JsonConvert.DeserializeObject<List<UserAccount>>(result);

                    List<UserAccount> users = new List<UserAccount>();
                    foreach (var item in myobjList)
                    {
                        users.Add(item);
                    }
                    return users;
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message.ToString());
            }
            return null;


        }

        //Notify user by its username.
        public async Task<UserAccount> GetNotificationByUsername(String username)
        {
            client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:7024/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            try
            {
                //https://localhost:7024/UserAccount/username?username=hosi
                var response = await client.GetAsync("UserAccount/username?username=" + username).ConfigureAwait(false);


                if (response.IsSuccessStatusCode)
                {
                    dynamic result = await response.Content.ReadAsStringAsync();
                    UserAccount account = JsonConvert.DeserializeObject<UserAccount>(result);
                    return account;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
            }
            return null;
        }

          
        //This function will check if user Username exist in the db.
        public async Task<bool> CheckUsernameExist(UserAccount user)
        {
            client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:7024/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var stringContent = new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json");
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            try
            {
                var response = await client.PostAsync("UserAccount/CheckUsernameExist", stringContent).ConfigureAwait(false);
                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message.ToString());
            }
           
            return false;
        }

       //This function will check if ther is an existing user in the db for login.
        public async Task<bool> CheckUserLogin(UserAccount user)
        {
            client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:7024/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var stringContent = new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json");
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            try
            {
                var response = await client.PostAsync("UserAccount/CheckUserLogin", stringContent).ConfigureAwait(false);
                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message.ToString());
            }
           
            return false;
        }

        //This will get user password by its username.
        public async Task<String> GetUserPassword(UserAccount user)
        {

           
            client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:7024/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var stringContent = new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json");
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            try
            {
                var response = await client.PostAsync("UserAccount/GetUserPassword", stringContent).ConfigureAwait(false);
                if (response.IsSuccessStatusCode)
                {
                    dynamic result = await response.Content.ReadAsStringAsync();
                    return result;
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message.ToString());
            }
            
            return null;
        }

        //This will get user information by its username.
        public async Task<List<UserAccount>> GetUserInformationByUsername(UserAccount user)
        {
            client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:7024/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var stringContent = new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json");
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            try
            {
                var response = await client.PostAsync("UserAccount/GetUserInformationByUsername", stringContent).ConfigureAwait(false);
                if (response.IsSuccessStatusCode)
                {
                    dynamic result = await response.Content.ReadAsStringAsync();
                    UserAccount rootObject = JsonConvert.DeserializeObject<UserAccount>(result);

                    List<UserAccount> userInfo = new List<UserAccount>();
                    userInfo.Add(rootObject);
                    return userInfo;
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message.ToString());
            }
           
            return null;
        }

        //This function will update logged in user profile information by its username.
        public async Task<bool> UpdateUserProfile(UserAccount user)
        {

            client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:7024/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var stringContent = new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json");
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            try
            {
                var response = await client.PostAsync("UserAccount/UpdateUserProfile", stringContent).ConfigureAwait(false);
                if (response.IsSuccessStatusCode)
                {
                    dynamic result = await response.Content.ReadAsStringAsync();
                    return true;
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message.ToString());
            }
            
            return false;
        }

        


        /******UserProducts functions*****/

        //Add a product.
        public async Task AddProduct(UserProducts product)
        {
            client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:7024/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var stringContent = new StringContent(JsonConvert.SerializeObject(product), Encoding.UTF8, "application/json");
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
              try
              {
                var response = await client.PostAsync("UserProducts/Add", stringContent).ConfigureAwait(false);
                response.EnsureSuccessStatusCode();

                if (response.IsSuccessStatusCode)
                {
                    dynamic result = await response.Content.ReadAsStringAsync();
                }
              }
              catch (Exception ex)
              {
                 Console.WriteLine(ex.Message.ToString());
              }
        }

        //Get products information by its owner username.
        public async Task<List<UserProducts>> GetProductsByOwner(UserProducts product)
        {
            client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:7024/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var stringContent = new StringContent(JsonConvert.SerializeObject(product), Encoding.UTF8, "application/json");
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
             try
            {
                var response = await client.PostAsync("UserProducts/GetProductsByOwner", stringContent).ConfigureAwait(false);


                if (response.IsSuccessStatusCode)
                {
                    dynamic result = await response.Content.ReadAsStringAsync();
                    var myobjList = JsonConvert.DeserializeObject<List<UserProducts>>(result);

                    List<UserProducts> products = new List<UserProducts>();
                    foreach (var item in myobjList)
                    {
                        products.Add(item);
                    }
                    return products;
                }
            }
            catch (Exception ex)
             {

                Console.WriteLine(ex.Message.ToString());
             }
              return null;
        }

        //Delete a products by its id.
        public async Task<bool> DeleteProductById(UserProducts productID)
        {
            client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:7024/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var stringContent = new StringContent(JsonConvert.SerializeObject(productID), Encoding.UTF8, "application/json");
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            try
            {
                var response = await client.DeleteAsync("UserProducts/" + productID.Id).ConfigureAwait(false);
                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message.ToString());
            }
            return false;
        }

        //This function till load all the products
        public async Task<List<UserProducts>> LoadAllProducts()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:7024/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            try
            {
                var response = await client.GetAsync("UserProducts/Get/All").ConfigureAwait(false);
                if (response.IsSuccessStatusCode)
                {
                    dynamic result = await response.Content.ReadAsStringAsync();
                    //UserProducts rootObject = JsonConvert.DeserializeObject<UserProducts>(result);
                    var myobjList = JsonConvert.DeserializeObject<List<UserProducts>>(result);

                    List<UserProducts> products = new List<UserProducts>();
                    foreach (var item in myobjList)
                    {
                        products.Add(item);
                    }
                    return products;
                }
            }
            catch (Exception ex)
            {
                 Console.WriteLine(ex.Message.ToString());
            }
           
            //response.EnsureSuccessStatusCode();
             return null;
        }

        //This function till load some products
        public async Task<List<UserProducts>> LoadSomeProducts()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:7024/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            try
            {
                var response = await client.GetAsync("UserProducts/Get/Some").ConfigureAwait(false);
                if (response.IsSuccessStatusCode)
                {
                    dynamic result = await response.Content.ReadAsStringAsync();
                    //UserProducts rootObject = JsonConvert.DeserializeObject<UserProducts>(result);
                    var myobjList = JsonConvert.DeserializeObject<List<UserProducts>>(result);

                    List<UserProducts> products = new List<UserProducts>();
                    foreach (var item in myobjList)
                    {
                        products.Add(item);
                    }
                    return products;
                }
            }
            catch (Exception ex)
            {
                 Console.WriteLine(ex.Message.ToString());
            }
             return null;
        }

        //Get products based on user search filter ---> (ProductName, ProductType, ProductCondition).
        public async Task<List<UserProducts>> GetProductsBySearchInput(UserProducts product)
        {
            client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:7024/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var stringContent = new StringContent(JsonConvert.SerializeObject(product), Encoding.UTF8, "application/json");
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
           
            try
            {
                var response = await client.PostAsync("UserProducts/GetProductsBySearchInput", stringContent).ConfigureAwait(false);
                if (response.IsSuccessStatusCode)
                {
                    dynamic result = await response.Content.ReadAsStringAsync();
                    var myobjList = JsonConvert.DeserializeObject<List<UserProducts>>(result);

                    List<UserProducts> products = new List<UserProducts>();
                    foreach (var item in myobjList)
                    {
                        products.Add(item);
                    }
                    return products;
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message.ToString());
            }
              return null;
        }

        //Get product information to fill inside the cart by its id.
        public async Task<UserProducts> GetCartProductById(Guid id)
        {
            client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:7024/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            try
            {
                var response = await client.GetAsync("UserProducts/" + id).ConfigureAwait(false);


                if (response.IsSuccessStatusCode)
                {
                    dynamic result = await response.Content.ReadAsStringAsync();
                    UserProducts product = JsonConvert.DeserializeObject<UserProducts>(result);
                    return product;
                }
            }
            catch (Exception ex)
            {
             Console.WriteLine(ex.Message.ToString());
            }
            return null;
        }

        //This function will change product status to sold --> When the order stats is Accepted.
        public async Task<bool> ChangeProductStatus(List<UserProducts> products)
        {
            client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:7024/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var stringContent = new StringContent(JsonConvert.SerializeObject(products), Encoding.UTF8, "application/json");
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            try
            {
                var response = await client.PostAsync("UserProducts/ChangeProductStatus", stringContent).ConfigureAwait(false);
                response.EnsureSuccessStatusCode();

                if (response.IsSuccessStatusCode)
                {
                    dynamic result = await response.Content.ReadAsStringAsync();
                    return true;
                }
            }
            catch (Exception ex)
            {
               Console.WriteLine(ex.Message.ToString());
            }
            return false;
        }


        /******UserOrders functions*****/

        //This function will add a new user to the db.
        public async Task<bool> AddOrder(UserOrders orders)
        {
            client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:7024/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var stringContent = new StringContent(JsonConvert.SerializeObject(orders), Encoding.UTF8, "application/json");
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            try
            {
                var response = await client.PostAsync("UserOrders/Add/Order", stringContent).ConfigureAwait(false);
                response.EnsureSuccessStatusCode();

                if (response.IsSuccessStatusCode)
                {
                    dynamic result = await response.Content.ReadAsStringAsync();
                    return true;
                }
            }
            catch (Exception ex)
            {
                 Console.WriteLine(ex.Message.ToString());
            }
            return false;
        }

        //This function will show Users order that need to be accepted by the seller. (Pending)
        public async Task<List<UserOrders>> GetPendingOrdersByUser(string username)
        {
            client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:7024/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            try
            {
                //https://localhost:7024/UserOrders/username?username=hosi
                var response = await client.GetAsync("/UserOrders/username?username=" + username).ConfigureAwait(false);


                if (response.IsSuccessStatusCode)
                {
                    dynamic result = await response.Content.ReadAsStringAsync();

                    var orders = JsonConvert.DeserializeObject<List<UserOrders>>(result);
                    return orders;
                     
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message.ToString());

            }
          return null;
        }

        //This function will show Users order that need to be accepted by the seller. (Pending)
        public async Task<List<UserOrders>> GetCompletedOrdersByUser(string username)
        {
            client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:7024/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            try
            {
                var response = await client.GetAsync("/UserOrders/Completed/username?username=" + username).ConfigureAwait(false);
                if (response.IsSuccessStatusCode)
                {
                    dynamic result = await response.Content.ReadAsStringAsync();

                    var orders = JsonConvert.DeserializeObject<List<UserOrders>>(result);
                    return orders;

                }
            }
            catch (Exception ex)
            {
                 Console.WriteLine(ex.Message.ToString());
            }
            return null;
        }

        // Get a list of all purchased orders for the logged in user and with from-to date filter.
        public async Task<List<UserOrders>> GetOrderHistoryByUser(string username, DateTime searchDateFrom, DateTime searchDateTo)
        {
            client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:7024/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            try
            {
                
                var response = await client.GetAsync("/UserOrders/Completed/History?username=" + username + "&searchDateFrom=" + searchDateFrom + "&searchDateTo=" + searchDateTo).ConfigureAwait(false);
                if (response.IsSuccessStatusCode)
                {
                    dynamic result = await response.Content.ReadAsStringAsync();

                    var orders = JsonConvert.DeserializeObject<List<UserOrders>>(result);
                    return orders;

                }
            }
            catch (Exception ex)
            {
             Console.WriteLine(ex.Message.ToString());

            }
            return null;
        }

        //This function will show the seller all the buying request from users thats needs to be accepted or rejected 
        public async Task<List<UserOrders>> GetSellerOrders(string sellerName)
        {
            client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:7024/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            try
            {
                //https://localhost:7024/UserOrders/sellerName?sellerName=hosi
                var response = await client.GetAsync("/UserOrders/sellerName?sellerName=" + sellerName).ConfigureAwait(false);


                if (response.IsSuccessStatusCode)
                {
                    dynamic result = await response.Content.ReadAsStringAsync();

                    var orders = JsonConvert.DeserializeObject<List<UserOrders>>(result);
                    return orders;
                }
            }
            catch (Exception ex)
            {
              Console.WriteLine(ex.Message.ToString());
            }
             return null;
        }

        //This will change order status from Pending to Accepted.
        public async Task<bool> ChangeOrderStatus(string sellerName, string newOrderState, Guid orderId)
        {
            client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:7024/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var stringContent = new StringContent(JsonConvert.SerializeObject(sellerName), Encoding.UTF8, "application/json");
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            try
            {
                //https://localhost:7024/UserOrders/hosi
                var response = await client.PutAsync($"UserOrders/{sellerName},{newOrderState},{orderId}", stringContent).ConfigureAwait(false);
                response.EnsureSuccessStatusCode();

                if (response.IsSuccessStatusCode)
                {
                    dynamic result = await response.Content.ReadAsStringAsync();
                    return true;
                }
            }
            catch (Exception ex)
            {
               Console.WriteLine(ex.Message.ToString());
             }
            return false;

        }
 
        //This function will get all the products that within in order that has been accepted.
        public async Task<List<UserOrders>> GetAllProductsIdInAcceptedOrders()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:7024/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            try
            {
                 var response = await client.GetAsync("/UserOrders/GetAllProductsInAcceptedOrders").ConfigureAwait(false);


                if (response.IsSuccessStatusCode)
                {
                    dynamic result = await response.Content.ReadAsStringAsync();

                    var orders = JsonConvert.DeserializeObject<List<UserOrders>>(result);
                    return orders;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
            }
            return null;
        }
 
        //Send email
        public async Task<bool> SendEmail(EmailData data)
        {

            bool send = false;
            //https://localhost:7024/Send/Email?Username=Test&Subject=Test&Email=mohanad.h.owidat%40gmail.com&Message=Test%20message
            client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:7024/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var stringContent = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            try
            {
                var response = await client.PostAsync("Email/Send", stringContent).ConfigureAwait(false);
                response.EnsureSuccessStatusCode();

                if (response.IsSuccessStatusCode)
                {
                    dynamic result = await response.Content.ReadAsStringAsync();
                    send = true;
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message.ToString());
            }
            return send;
        }
    }
}