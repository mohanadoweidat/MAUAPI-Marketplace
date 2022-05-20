<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserCart.aspx.cs" Inherits="WebApplication.UserCart" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>My cart</title>

     <!-- Bootstrap style --> 
    <link href="Style/Bootstrap/bootstrap.min.css" rel="stylesheet" media="screen" />
    

    <link href="Style/Css/base.css" rel="stylesheet" media="screen" />
     
    <!-- Bootstrap style responsive -->	
    <link href="Style/Css/bootstrap-responsive.min.css" rel="stylesheet" />
    <link href="Style/Css/font-awesome.css" rel="stylesheet" type="text/css" />
	 

    <!-- Google-code-prettify -->	
    <link href="Style/Css/prettify.css" rel="stylesheet" />

     <!-- fav and touch icons -->
    <link rel="shortcut icon" href="themes/images/ico/favicon.ico"/>
   


     <!-- Infomessages -->
    <script src="//cdn.jsdelivr.net/npm/sweetalert2@11"></script>
    <script src="Style/Js/infoMessages.js"></script>

    <style>
        
        .btn:hover{
          background-color: #485461;
            background-image: linear-gradient(315deg, #485461 0%, #28313b 74%);
            color:white
        }
         
        .btn-large:hover{
          background-color: #485461;
            background-image: linear-gradient(315deg, #485461 0%, #28313b 74%);
            color:white
        }
    </style>


</head>
<body>
    <form id="form1" runat="server">
             <!-- Header Start ================================================== -->  
        <div id="header">
            <div class="container">
            <div id="welcomeLine" class="row">
                <center>
                    <asp:Label ID="wlcLbl" runat="server"></asp:Label>
                </center>
            </div>
       
 <!-- Header End ================================================== --> 
 <!-- Navbar Start ================================================== -->
  
  <div id="logoArea" class="navbar">
<a id="smallScreen" data-target="#topMenu" data-toggle="collapse" class="btn btn-navbar">
	<span class="icon-bar"></span>
	<span class="icon-bar"></span>
	<span class="icon-bar"></span>
</a>
      <div class="navbar-inner">
          <div class="searchCatDiv">
              <a class="brand" href="Index.aspx">
                  <img src="Style/Images/logo.png" alt="Bootsshop"/></a>
               <ul id="topMenu" class="nav pull-right">
                  <li class=""><a href="Index.aspx">Home</a></li>
                  <li class=""><a href="Products.aspx">Products</a></li>
                   <li><a href="ContactUs.aspx">Contact us</a></li>
                    <li style="margin-top:5px;"> 
          <asp:Button ID="profile_btn" CssClass="btn btn-large btn-success" runat="server" Visible="false" Text="Dashboard"/> 
	            </li>
              </ul>
          </div>
      </div>
</div>
   </div>
    </div>
<!-- Navbar End ================================================== -->
<!-- MainBody Start====================================================================== -->
     <div id="mainBody">
         <div class="container">
             <div class="row">
                 <div class="span12"> <%--span9--%>
                     <ul class="breadcrumb">
                         <li><a href="Index.aspx">Home</a> <span class="divider">/</span></li>
                         <li class="active">SHOPPING CART</li>
                     </ul>
                     
                     <h3>  
                      SHOPPING CART [   <asp:Label ID="cartItemsNumber" runat="server">0</asp:Label> Items]
                     <a href="Products.aspx" class="btn btn-large pull-right"><i class="icon-arrow-left"></i> Continue Shopping </a>
                    </h3>	
	<hr class="soft"/>

                     <%--//Login form--%>
                    <asp:Panel ID="login_form" runat="server">
                         <table class="table table-bordered">
                             <tr>
                                 <th>You must log in: </th>
                             </tr>
                             <tr>
                                 <td>
                                     <form class="form-horizontal">
                                         <div class="control-group">
                                             <label class="control-label" for="inputUsername">Username</label>
                                             <div class="controls">
                                                 <input type="text" runat="server" id="inputUsername" placeholder="Username">
                                             </div>
                                         </div>
                                         <div class="control-group">
                                             <label class="control-label" for="inputPassword">Password</label>
                                             <div class="controls">
                                                 <input type="password" runat="server" id="inputPassword" placeholder="Password">
                                             </div>
                                         </div>
                                         <div class="control-group">
                                             <div class="controls">
                                                 <button type="submit" runat="server" id="signInBtn" class="btn">Sign in</button>
                                                 OR <a href="SignUp.aspx"" class="btn">Register Now!</a>
                                             </div>
                                         </div>
                                         <div class="control-group">
                                             <div class="controls">
                                                 <a href="ForgotPassword.aspx" style="text-decoration: underline">Forgot password ?</a>
                                             </div>
                                         </div>
                                     </form>
                                 </td>
                             </tr>
                         </table>
                 </asp:Panel>
 	
                     <%--  //Cart form--%>
        <asp:Panel ID="cart_from" runat="server">
           <br />
           <asp:GridView ShowFooter="true" ID="cartGridView" runat="server" OnRowDeleting="cartGridView_RowDeleting" CssClass="table table-bordered" AutoGenerateColumns="false">
              <Columns>
                   <asp:CommandField ShowDeleteButton="true" ControlStyle-CssClass="btn btn-danger" HeaderText="Remove" DeleteText="X"/>

                  <asp:TemplateField HeaderText="Product name">
                      <ItemTemplate>
                            <asp:Label ID="productName" runat="server" Text='<%#Eval("productName")%>' Font-Bold="true" Font-Names="Open Sans Extrabold"></asp:Label>
                      </ItemTemplate>
                   </asp:TemplateField>

                   <asp:TemplateField HeaderText="Description">
                        <ItemTemplate>
                      Year: <asp:Label ID="yearOfMake" runat="server" Text='<%#Eval("ProductYearOfMake")%>' 
                      Font-Bold="true" Font-Names="Open Sans Extrabold"></asp:Label>
                      <br/>
                      Colour: <asp:Label ID="color" runat="server" Text='<%#Eval("ProductColour")%>' 
                      Font-Bold="true" Font-Names="Open Sans Extrabold"></asp:Label>
                      <br />
                       Condition: <asp:Label ID="condition" runat="server" Text='<%#Eval("ProductCondition")%>' 
                      Font-Bold="true" Font-Names="Open Sans Extrabold"></asp:Label>
                      <br />
                      Seller: <asp:Label ID="owner" runat="server" Text='<%#Eval("ProductOwner")%>' 
                      Font-Bold="true" Font-Names="Open Sans Extrabold"></asp:Label>
                       </ItemTemplate>

                         <FooterTemplate>
                          <asp:Label ID="totalPrice" Text="Total price:" Font-Bold="true" Font-Size="Large" Font-Italic="true" runat="server" CssClass="" Visible="true"></asp:Label>
                      </FooterTemplate>

                       
                  </asp:TemplateField>


                  <asp:TemplateField HeaderText="Price">
                      <ItemTemplate>
                         <asp:Label ID="price" runat="server" Text='<%#Eval("productPrice")%>' 
                  Font-Bold="true" Font-Names="Open Sans Extrabold"></asp:Label> <span style="color:red">SEK</span>
                          </ItemTemplate>

                      <FooterTemplate >
                           <asp:Label ID="totalPrice" Font-Size="Large" Font-Bold="true" runat="server" Visible="true"></asp:Label>
                      </FooterTemplate>
                       
                  </asp:TemplateField>
                   
   
               </Columns>
          </asp:GridView>
          <br />
          <br />
    <a href="Products.aspx" class="btn btn-large"><i class="icon-arrow-left"></i> Continue Shopping </a>
            <button type="submit" runat="server" id="order_btn" class="btn btn-large pull-right">Next <i class="icon-arrow-right"></i></button>
     
	 
          </asp:Panel>
                     <center>
        <asp:Label ID="emptyCartLbl" CssClass="btn btn-large btn-danger" runat="server" Text="Your cart is empty" Visible="false"></asp:Label>
                         </center>
                </div>      
                   </div>
              </div>
          </div>
      
 
<!-- MainBody End ============================= -->	



	 


 <!-- Placed at the end of the document so the pages load faster ============================================= -->
        <script src="Style/Js/jquery.js"></script>
        <script src="Style/Js/bootstrap.min.js"></script>
        <script src="Style/Js/prettify.js"></script>

        <script src="Style/Js/bootshop.js"></script>
        <script src="Style/Js/jquery.lightbox-0.5.js"></script>
    </form>
</body>
</html>
