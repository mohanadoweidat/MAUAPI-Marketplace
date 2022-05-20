<%@ Page Title="Sell a product" Language="C#" MasterPageFile="~/UserMasterPage.Master" AutoEventWireup="true" CodeBehind="Sellproduct.aspx.cs" Inherits="WebApplication.Sellproduct" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
      <link href="https://stackpath.bootstrapcdn.com/bootstrap/4.4.1/css/bootstrap.min.css" rel="stylesheet">

    <script type="text/javascript" src="https://cdnjs.cloudflare.com/ajax/libs/jquery/3.4.1/jquery.min.js"></script>


     <!-- Infomessages -->
    <script src="//cdn.jsdelivr.net/npm/sweetalert2@11"></script>
    <script src="Style/Js/infoMessages.js"></script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
     <section class="home-section">
         <br />
          <center><h1>Sell a product</h1></center> 
           <hr />


    <div class="container-fluid">
          <div class="gridView-section">
              <h2>Product name:</h2>
              <asp:TextBox ID="productName" TextMode="SingleLine" CssClass="textbox" placeholder="MacBook Pro" runat="server"></asp:TextBox>
              <br />
              <br />
              <h2>Type:</h2>
              <asp:DropDownList ID="productTypeDropDownList" CssClass="textbox" runat="server"></asp:DropDownList>
              <br />
              <br />
              <h2>Price:</h2>
              <asp:TextBox ID="productPrice" TextMode="Number" CssClass="textbox" min="100"  placeholder="1000" runat="server"></asp:TextBox>
              <br />
              <br />
              <h2>Year of make:</h2>
              <asp:DropDownList ID="yearpicker" CssClass="textbox" runat="server"></asp:DropDownList>
              <br />
              <br />
              <h2>Colour:</h2>
              <%--<asp:TextBox ID="productColour" TextMode="Color" CssClass="textbox" placeholder="" runat="server"></asp:TextBox>--%>
              <asp:DropDownList ID="prodcutColorList" CssClass="textbox" onchange="SetDropDownListColor(this);" runat="server">
                   
                <asp:ListItem style="background-color: White !important;" >White</asp:ListItem>
                <asp:ListItem style="background-color: Green !important;" >Green</asp:ListItem>
                <asp:ListItem style="background-color: Yellow !important;" >Yellow</asp:ListItem>
                <asp:ListItem style="background-color: Red !important;" >Red</asp:ListItem>
                <asp:ListItem style="background-color: Blue !important;" >Blue</asp:ListItem>
                <asp:ListItem style="background-color: pink !important;" >Pink</asp:ListItem>
                <asp:ListItem style="background-color: orange !important;" >Orange</asp:ListItem>
                <asp:ListItem style="background-color: black !important; color:white" >Black</asp:ListItem>
                <asp:ListItem style="background-color: purple !important;" >Purple</asp:ListItem>
               </asp:DropDownList>
              <br />
              <br />
              <h2>Condition:</h2>
              <asp:DropDownList ID="productConditionList" CssClass="textbox" runat="server"></asp:DropDownList>
             
              <br />
              <br />
              <asp:Button ID="sellButton" CssClass="sellBtn" runat="server" Text="List product" />
            </div>
        </div>
          </section>


    <script type="text/javascript">

        /**
         * This function will fill the color dropdownlist with colors and show them.
         * @param ddl This is the color dropdownlist
         */
        function SetDropDownListColor(ddl) {
            for (var i = 0; i < ddl.options.length; i++) {
                if (ddl.options[i].selected) {
                    switch (i) {
                        case 0:
                            ddl.style.backgroundColor = 'White';
                            return;

                        case 1:
                            ddl.style.backgroundColor = 'Green';
                            return;

                        case 2:
                            ddl.style.backgroundColor = 'Yellow';
                            return;

                        case 3:
                            ddl.style.backgroundColor = 'Red';
                            return;

                        case 4:
                            ddl.style.backgroundColor = 'Blue';
                            return;
                        case 5:
                            ddl.style.backgroundColor = 'Pink';
                            return;
                        case 6:
                            ddl.style.backgroundColor = 'orange';
                            return;
                        case 7:
                            ddl.style.backgroundColor = 'black';
                            return;
                        case 8:
                            ddl.style.backgroundColor = 'purple';
                            return;
                    }
                }
            }
        }
    </script>
 </asp:Content>
