<%@ Page Title="UserInterest" Language="C#" MasterPageFile="~/UserMasterPage.Master" AutoEventWireup="true" CodeBehind="UserInterest.aspx.cs" Inherits="WebApplication.UserInterest" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <link href="https://stackpath.bootstrapcdn.com/bootstrap/4.4.1/css/bootstrap.min.css" rel="stylesheet">


      <!-- Infomessages -->
    <script src="//cdn.jsdelivr.net/npm/sweetalert2@11"></script>
    <script src="Style/Js/infoMessages.js"></script>

    <style>
    
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>


    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>

      <section class="home-section">
          <div class="container">
              <br />
               
              <center>
              <h2>Register your interest for a specific product type:</h2>
                  <br />
                  <br />
              <asp:DropDownList ID="productTypeDropDownList" CssClass="textbox" runat="server"></asp:DropDownList>
               <br />
              <br />
              <asp:Button ID="registrerBtn" CssClass="sellBtn" runat="server" Text="Register interest" />
                  </center>
                   </div>
              
         <br />
          <br />


     
        
          <asp:Panel ID="interestPanel" Visible="false" runat="server">
               <center><h2>New products with the type that you are interested in:</h2></center>
         <div class="gridView-section">
            <center><h5>New product/s with type: [<asp:Label ID="notificationLbl" runat="server"></asp:Label>] has been added.</h5></center>
          </div>
              </asp:Panel>
         </section>
        </ContentTemplate>
        </asp:UpdatePanel>

</asp:Content>
