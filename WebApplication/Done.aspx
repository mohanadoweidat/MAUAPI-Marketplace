<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Done.aspx.cs" Inherits="WebApplication.Done" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Done</title>
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

         .btn{
             background-color: #b8c6db;
background-image: linear-gradient(315deg, #b8c6db 0%, #f5f7fa 74%);
            color:black;
            font-weight:bold;
         }
          .btn-large:hover{
          background-color: #485461;
            background-image: linear-gradient(315deg, #485461 0%, #28313b 74%);
            color:white;
            
               
        }


          .wrapper {
            position: fixed;
            top: 50%;
            left: 50%;
            -webkit-transform: translate(-50%, -50%);
            transform: translate(-50%, -50%);
             
}
           

       html {
            height: 100%;
        }
        body {
            height: 100%;
            margin: 0;
            background-repeat: no-repeat;
            background-attachment: fixed;
              background-color: #e9bcb7;
            background-image: linear-gradient(315deg, #e9bcb7 0%, #29524a 74%); 
        }
    </style>

</head>
<body>
    <form id="form1" runat="server">
         

        <center>
        <div class="container-fluid wrapper">
             <h1><strong>Thank you for order, check order status in your dashboard!</strong></h1>
            <asp:Button ID="dashBtn" OnClick="dashBtn_Click" runat="server" CssClass="btn btn-large btn-success" Text="My orders" />
        </div>
            </center>
    </form>
</body>
</html>
