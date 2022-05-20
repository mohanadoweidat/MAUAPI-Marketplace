<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="WebApplication.Index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Home page</title>
    <meta name="viewport" content="width=device-width, initial-scale=1.0"/>

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


        .btn:hover{
          background-color: #485461;
            background-image: linear-gradient(315deg, #485461 0%, #28313b 74%);
            color:white
        }

           /* Footer style  */ 
         * {
                margin:0;
                padding:0;
          }
        
        .content {
            min-height: calc(100vh - 200px);
            /* 80px header + 40px footer = 120px  */ 
        }
        .footerS {
            height: 50px;
             color:white;
             font-size:14px;
             
            background-color:#262626;
        }
    </style>

     
</head>
<body>
    <form id="form1" runat="server">
  <!-- Header Start================================================================= -->
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
    <a class="brand" href="Index.aspx"><img src="Style/Images/logo.png" alt="Bootsshop"/></a>
     <ul id="topMenu" class="nav pull-right">
	 <li><a href="Index.aspx">Home</a></li>
	 <li><a href="Products.aspx">Products</a></li>
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
 <!-- Carousel start====================================================================== -->
        <div id="carouselBlk">
            <div id="myCarousel" class="carousel slide">
                <div class="carousel-inner">
                    <div class="item active">
                        <div class="container">
                            <a href="SignUp.aspx">
                                <img style="width: 100%" src="Style/Images/Carousel/1.png" alt="special offers" /></a>
                            <div class="carousel-caption">
                                <h4>Second Thumbnail label</h4>
                             </div>
                        </div>
                    </div>
                    <div class="item">
                        <div class="container">
                             <a href="SignUp.aspx">
                                <img style="width: 100%" src="Style/Images/Carousel/2.png" alt="" /></a>
                            <div class="carousel-caption">
                                <h4>Second Thumbnail label</h4>
                             </div>
                        </div>
                    </div>
                    <div class="item">
                        <div class="container">
                           <a href="SignUp.aspx">
                                <img src="Style/Images/Carousel/3.png" alt="" /></a>
                            <div class="carousel-caption">
                                <h4>Second Thumbnail label</h4>
                             </div>

                        </div>
                    </div>
                    <div class="item">
                        <div class="container">
                            <a href="SignUp.aspx">
                                <img src="Style/Images/Carousel/4.png" alt="" /></a>
                            <div class="carousel-caption">
                                <h4>Second Thumbnail label</h4>
                             </div>

                        </div>
                    </div>
                    <div class="item">
                        <div class="container">
                            <a href="SignUp.aspx">
                                <img src="Style/Images/Carousel/5.png" alt="" /></a>
                            <div class="carousel-caption">
                                <h4>Second Thumbnail label</h4>
                             </div>
                        </div>
                    </div>
                    <div class="item">
                        <div class="container">
                            <a href="SignUp.aspx">
                                <img src="Style/Images/Carousel/6.png" alt="" /></a>
                            <div class="carousel-caption">
                                <h4>Second Thumbnail label</h4>
                             </div>
                        </div>
                    </div>
                </div>
                <a class="left carousel-control" href="#myCarousel" data-slide="prev">&lsaquo;</a>
                <a class="right carousel-control" href="#myCarousel" data-slide="next">&rsaquo;</a>
            </div>
        </div>
 <!-- Carousel End====================================================================== --> 


           <center><h2>Products:</h2></center> 


            <%-- Products section--%>


            <center>
 
 		<ul>
			<li>
       <asp:DataList ID="productDataList" OnItemCommand="productDataList_ItemCommand" runat="server" RepeatDirection="Horizontal" RepeatColumns="3">
      <ItemTemplate>
           <div class="thumbnail">
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
                        <asp:Button CommandName="AddToCart" CommandArgument='<%# Eval("Id")%>' runat="server" CssClass="btn-warning" Text="Add to" /> <i class="icon-shopping-cart"></i>
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
  </center>




            <center>
            <div class="container">
                <h2><a class="btn" href="Products.aspx">See more?</a></h2>
             </div>
                </center>

            </div>



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
