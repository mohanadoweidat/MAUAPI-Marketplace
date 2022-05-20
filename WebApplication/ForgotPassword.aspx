﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ForgotPassword.aspx.cs" Inherits="WebApplication.ForgotPassword" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Forgot password</title>
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
   


    <style>
        .btn-large:hover {
            background-color: #485461;
            background-image: linear-gradient(315deg, #485461 0%, #28313b 74%);
            color: white
        }
    </style>


     <!--Infomessages -->
    <script src="//cdn.jsdelivr.net/npm/sweetalert2@11"></script>
    <script src="Style/Js/infoMessages.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <!--Header Start ================================================== -->  
        <div id="header">
            <div id="welcomeLine" class="row">
                 
            </div>
        </div>
 <!-- Header End ================================================== --> 
<!-- Navbar Start ================================================== -->

         <div class="container">
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
              </ul>
          </div>
      </div>
</div>
<!-- Navbar End ================================================== -->
<!-- MainBody Start====================================================================== -->
            
     <div id="mainBody">
         <div class="container">
             <div class="row">
                 <div class="span9">
                     <ul class="breadcrumb">
                         <li><a href="Index.aspx">Home</a> <span class="divider">/</span></li>
                         <li class="active">Forgot password</li>
                     </ul>
                     <h3>Forgot password</h3>
                     <div class="well">
                         <h2>Please enter your Username to get your password!</h2>

                         <%--<h4>Please login:</h4>--%>
                         <div class="control-group">
                             <label class="control-label" for="inputFname1">Username <sup>*</sup></label>
                             <div class="controls">
                                 <input runat="server" required="required" type="text" id="username_input" />
                              </div>
                         </div>
                         
                         <div class="control-group">
                               <asp:Label ID="passwordLbl" runat="server"></asp:Label>
                          </div>

                         <div class="control-group">
                             <div class="controls">
                                 <asp:Button CssClass="btn btn-large btn-success" ID="getPassword_btn" runat="server" Text="Get password" />
                                 <asp:Button CssClass="btn btn-large btn-success" ID="loginbtn" runat="server" Visible="false" Text="Login" />
                                
                             </div>
                          </div>
                      </div>
                  </div>
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
