<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SignUp.aspx.cs" Inherits="WebApplication.SignUp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>User registration</title>
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
    </style>

</head>
<body>
	

     <form id="form1" runat="server">
		<asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
<!-- Header Start====================================================================== -->
  		<div id="header">
  		<div id="welcomeLine" class="row">
  		 </div>
 		</div>
  <!-- Header End====================================================================== -->
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
    <a class="brand" href="Index.aspx"><img src="Style/Images/logo.png" alt="Bootsshop"/></a>
     <ul id="topMenu" class="nav pull-right">
	 <li><a href="Index.aspx">Home</a></li>
	 <li><a href="Products.aspx">Products</a></li>
	 <li><a href="ContactUs.aspx">Contact us</a></li>
     </ul>
	</div>
     </div>
</div>
 <!-- Navbar End====================================================================== -->


 <!-- MainBody Start ================================================== -->
<div id="mainBody">
	<div class="container">
	<div class="row">
	<div class="span9">
    <ul class="breadcrumb">
		<li><a href="Index.aspx">Home</a> <span class="divider">/</span></li>
		<li class="active">Registration</li>
    </ul>
	<h3> Registration</h3>	
	<div class="well">
 
	 
		<h4>Your personal information</h4>
	 <div class="control-group">
			<label class="control-label" for="inputFname1">First name <sup>*</sup></label>
			<div class="controls">
			  <input runat="server" required="required" type="text" id="inputFName" placeholder="First Name"/>
			</div>
		 </div>
		<div class="control-group">
			<label class="control-label" for="inputLnam">Last name <sup>*</sup></label>
			<div class="controls">
			  <input runat="server" required="required" type="text" id="inputLName" placeholder="Last Name"/>
			</div>
		 </div>
		<div class="control-group">
		<label class="control-label" for="input_email">Email <sup>*</sup></label>
		<div class="controls">
		  <input type="text" required="required" runat="server" id="inputEmail" placeholder="Email"/>
		</div>
	  </div>	
		<div class="control-group">
			<label class="control-label" for="input_username">Username <sup>*</sup></label>
			<div class="controls">
			  <input type="text" required="required" id="input_Username" runat="server" placeholder="Username"/>
			</div>
		  </div>	
		<div class="control-group">
			<label class="control-label" for="inputPassword1">Password <sup>*</sup></label>
			<div class="controls">
			  <input type="password" required="required" id="input_Password" runat="server" placeholder="Password"/>
			</div>
		  </div>	  
		<div class="control-group">
		<label class="control-label">Date of Birth <sup>*</sup></label>
		<div class="controls">
		  <input id="inputDate" required="required" runat="server" type="date"/>
		</div>
	  </div>
 		<p><sup>*</sup> Required field</p>
 		<br />
		<br />
   		<div class="control-group">
				<div class="controls">
 					  <asp:Button CssClass="btn btn-large btn-success" ID="createUserBtn" runat="server" Text="Register"/>		
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
