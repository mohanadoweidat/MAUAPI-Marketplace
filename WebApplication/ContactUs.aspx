<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ContactUs.aspx.cs" Inherits="WebApplication.ContactUs" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Contact us</title>

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
        
     
         
        .btn-large:hover{
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
            min-height: calc(90vh - 164px);
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
         
              
     <!-- all other page content -->
        

   
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
 <!-- MainBody Start ================================================== -->
 <div id="mainBody">
<div class="container">
	<hr class="soften">
	<h1>Contact us</h1>
	<hr class="soften"/>	
	<div class="row">
		<div class="span4">
		<h4>Contact Details</h4>
		<p>	Storgatan 52 k<br/> 21175, Sweden
			<br/><br/>
			wfpc.sweden@gmail.com<br/>
			﻿Tel 123-456-6780<br/>
		</p>		
		</div>
			
		<div class="span4">
		<h4>Opening Hours</h4>
			<h5> Monday - Friday</h5>
			<p>09:00am - 09:00pm<br/><br/></p>
			<h5>Saturday</h5>
			<p>09:00am - 07:00pm<br/><br/></p>
			<h5>Sunday</h5>
			<p>12:30pm - 06:00pm<br/><br/></p>
		</div>
		<div class="span4">
		<h4>Email Us</h4>
		<form class="form-horizontal">
        <fieldset>
          <div class="control-group">
           
              <input type="text"  id="name" runat="server" placeholder="name" class="input-xlarge"/>
           
          </div>
		   <div class="control-group">
           
              <input type="text" id="email" runat="server" placeholder="email" class="input-xlarge"/>
           
          </div>
		   <div class="control-group">
           
              <input type="text" id="subject" runat="server" placeholder="subject" class="input-xlarge"/>
          
          </div>
          <div class="control-group">
              <textarea placeholder="Message" runat="server" rows="3" id="textarea" class="input-xlarge"></textarea>
           
          </div>

            <button class="btn btn-large" runat="server" id="send_Btn" type="submit">Send Message</button>

        </fieldset>
      </form>
		</div>
	</div>
</div>
</div>
<!-- MainBody End ============================= -->
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
