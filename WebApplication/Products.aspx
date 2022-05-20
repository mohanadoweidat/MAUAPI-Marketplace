<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Products.aspx.cs" Inherits="WebApplication.Products" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Products</title>

      <!-- Bootstrap style --> 
    <link href="Style/Bootstrap/bootstrap.min.css" rel="stylesheet" media="screen" />
    

    <link href="Style/Css/base.css" rel="stylesheet" media="screen" />
     
    <!-- Bootstrap style responsive -->	
    <link href="Style/Css/bootstrap-responsive.min.css" rel="stylesheet" />
    <link href="Style/Css/font-awesome.css" rel="stylesheet" type="text/css" />
	 

    <!-- Google-code-prettify -->	
    <link href="Style/Css/prettify.css" rel="stylesheet" />

     <!-- fav and touch icons -->
    <link rel="shortcut icon" href="Style/Images/Ico/favicon.ico"/>
 


     <!-- Infomessages -->
    <script src="//cdn.jsdelivr.net/npm/sweetalert2@11"></script>
    <script src="Style/Js/infoMessages.js"></script>


    <style>
        .box {
            display: table-cell;
            border-radius: 5px;
        }

        .wrapper {
            display: table;
            width: 100%;
        }

        .middle {
            display: table-cell;
            width: 5%;
        }

        .w {
            width: 60%;
        }

        .s {
            width: 80%
        }

        .searchbar {
            margin: 5px;
            padding: 10px;
            width: 100%;
            border-radius: 5px;
            background-color: #2f4353 !important;
            background-image: linear-gradient(315deg, #2f4353 0%, #d2ccc4 74%) !important;
        }


        .searchBtn {
            width: 20%;
            padding: 10px;
            color: black;
            font-size: 17px;
            border: 1px solid grey;
            border-left: none;
            border-radius: 5px;
            cursor: pointer;
        }


            .searchBtn:hover {
                /*background-color: #89d8d3;
            background-image: linear-gradient(315deg, #89d8d3 0%, #03c8a8 74%);*/
                /*background-color: #9dc5c3;
            background-image: linear-gradient(315deg, #9dc5c3 0%, #5e5c5c 74%);*/


                background-color: #485461;
                background-image: linear-gradient(315deg, #485461 0%, #28313b 74%);
                color: white
            }



        /* Footer style  */
        * {
            margin: 0;
            padding: 0;
        }

        .content {
            min-height: calc(90vh - 131px);
            /* 80px header + 40px footer = 120px  */
        }

        .footerS {
            height: 50px;
            color: white;
            font-size: 14px;
            background-color: #262626;
        }
    </style>

    

</head>
<body>
    <form id="form1" runat="server">
         <div id="header">
<div class="container">
<div id="welcomeLine" class="row">
     <div class="span6">
	   <center>
        <asp:Label ID="wlcLbl" runat="server"></asp:Label>
        </center>
 </div>

    <div class="span6">
	<div class="pull-right">
       <a href="UserCart.aspx"><span class="btn btn-mini btn-primary"><i class="icon-shopping-cart icon-white"></i>My cart</span> </a> 
 		 
	</div>
	</div>
    </div>
<!-- Navbar ================================================== -->
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
                 <asp:Button ID="logIn_Btn" CssClass="btn btn-large btn-success"  runat="server" Text="Login"/> 
                 <asp:Button ID="profile_btn" CssClass="btn btn-large btn-success" runat="server" Visible="false" Text="Dashboard"/> 
	             </li>
              </ul>
          </div>
      </div>
</div>
</div>
</div>
<!-- Header End====================================================================== -->

        <div class="content">
<div id="mainBody">
	<div class="container">
	<div class="row">
 	<div class="span9">
    <ul class="breadcrumb">
		<li><a href="Index.aspx">Home</a> <span class="divider">/</span></li>
		<li class="active">Products</li>
    </ul>
	<h3> Products<small class="pull-right">

              Price range:
 			  <asp:DropDownList AutoPostBack="True" OnSelectedIndexChanged="priceRangeList_SelectedIndexChanged" ID="priceRangeList"  runat="server">
                <asp:ListItem Value="Min" Text="Min"></asp:ListItem>
                   <asp:ListItem Value="Max" Text="Max"></asp:ListItem>
             </asp:DropDownList>


        </small></h3>	
 	<hr class="soft"/>
 
  <h2>Search</h2>
        
<center>
<div class="searchbar">
     
   <%-- //Searchbar--%>
   <div class="textbox s">
           <h5>Product name:</h5>
           <input type="search" runat="server" id="searchName" placeholder=" Search..." class="textbox s" />
  </div>
     



 <%--   //Dropdownlist--%>
   <div class="wrapper">

       <div class="middle"></div>
          <div class="box"> 
            <h5>Type:</h5>
            <asp:DropDownList ID="productTypeDropDownList"  runat="server"></asp:DropDownList>   
          </div>
         <div class="middle"></div>

         <div class="box">
            <h5>Condition:</h5>
            <asp:DropDownList ID="productConditionList" runat="server"></asp:DropDownList>
        </div>
       <div class="middle"></div>

       </div>
     
    <%--//Button--%>
           <button type="submit" runat="server" id="searchBtn" class="searchBtn">Search <i class="fa fa-search"></i></button>
      </div>    
 </center>
 
<%-- Products section--%>
<div class="tab-content">
	  
		<ul class="thumbnails">
			<li class="">
       <asp:DataList ID="productDataList" OnItemCommand="productDataList_ItemCommand" runat="server" RepeatDirection="Horizontal" RepeatColumns="5">
      <ItemTemplate>
           <div class="thumbnail">
              <%-- <a href="product_details.html"><img src="themes/images/products/3.jpg" alt=""/></a>--%>
          <div class="caption">
          <table class="table table-hover">
            <tr>
                <td>
                    Product name: <asp:Label ID="productName" runat="server" Text='<%#Eval("ProductName")%>' 
                      Font-Bold="true" Font-Names="Open Sans Extrabold"></asp:Label>
                </td>
            </tr>

              <tr>
                  <td>
                      Year: <asp:Label ID="yearOfMake" runat="server" Text='<%#Eval("ProductYearOfMake")%>' 
                      Font-Bold="true" Font-Names="Open Sans Extrabold"></asp:Label>
                  </td>
              </tr>

              <tr>

                <td>
                    Colour: <asp:Label ID="color" runat="server" Text='<%#Eval("ProductColour")%>' 
                      Font-Bold="true" Font-Names="Open Sans Extrabold"></asp:Label>
                </td>
              </tr>


              <tr>
                  <td>
                    Condition: <asp:Label ID="condition" runat="server" Text='<%#Eval("ProductCondition")%>' 
                      Font-Bold="true" Font-Names="Open Sans Extrabold"></asp:Label>
                  </td>
              </tr>

              <tr>
                  <td>
                      Seller: <asp:Label ID="owner" runat="server" Text='<%#Eval("ProductOwner")%>' 
                      Font-Bold="true" Font-Names="Open Sans Extrabold"></asp:Label>
                  </td>
              </tr>

              <tr>
                 <td>
                     Price: <asp:Label ID="price" runat="server" Text='<%#Eval("productPrice")%>' 
                  Font-Bold="true" Font-Names="Open Sans Extrabold"></asp:Label>
                </td>
              </tr>

              <tr>
                  <td style="text-align:center">
                        <%--Add to cart--%>
 					  <%-- <a class="btn" href="#">Add to <i class="icon-shopping-cart"></i></a> --%>

                      <asp:Button CommandName="AddToCart" CommandArgument='<%# Eval("Id")%>' runat="server" CssClass="btn-warning" Text="Add to" /> <i class="icon-shopping-cart"></i>

                       <%--<asp:ImageButton ID="cartImageBtn" ImageUrl="~/Style/Img/cart.jpg" 
                                               CommandArgument='<%# Eval("Id")%>' Width="150"   CommandName="AddToCart"  runat="server" />--%>
                  </td>
              </tr>

          </table>
			</div>	
          </div>


           </ItemTemplate>
           
          
           

           </asp:DataList>
			   <asp:Label ID="lblEmpty" Visible="false" runat="server" Text="There is No product to be displayed."></asp:Label>
                <asp:Label ID="noResult" Visible="false" runat="server" Text="There is no result."></asp:Label>
                <asp:Label ID="ApiController" runat="server"></asp:Label>
			</li>
 		  </ul>
 	 
</div>
 
</div>
</div>
</div>
</div>
</div>
        
<!-- MainBody End ============================= -->


        <!-- Footer ================================================================== -->
  
        <br />
        <br />
             <div class="footerS">
                 <div class="container">
                      <center>
                          <p></p>
                         <p> &copy; <asp:Label ID="yearLbl" runat="server" Text="Label"></asp:Label> Store</p>
                        </center>
                 </div>
             </div>

 <!-- Placed at the end of the document so the pages load faster ============================================= -->
        <script src="Style/Js/jquery.js"></script>
        <script src="Style/Js/bootstrap.min.js"></script>
        <script src="Style/Js/prettify.js"></script>

        <script src="Style/Js/bootshop.js"></script>
        <script src="Style/Js/jquery.lightbox-0.5.js"></script>
       </form>
</body>
</html>
