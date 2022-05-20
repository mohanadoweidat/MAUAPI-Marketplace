<%@ Page Title="Order history" Language="C#" MasterPageFile="~/UserMasterPage.Master" AutoEventWireup="true" CodeBehind="OrderHistory.aspx.cs" Inherits="WebApplication.OrderHistory" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <link href="https://stackpath.bootstrapcdn.com/bootstrap/4.4.1/css/bootstrap.min.css" rel="stylesheet">


      <style>
        
         
        .btn-large:hover{
          background-color: #485461;
            background-image: linear-gradient(315deg, #485461 0%, #28313b 74%);
            color:white
        }


        .errBtn{
            display: inline-block;
            padding: 10px;
            border: 0;
            color: black;
            text-decoration: none;
            border-radius: 15px;
           
            background-color: #ffcfdf;
            background-image: linear-gradient(315deg, #ffcfdf 0%, #b0f3f1 74%);


            border: 1px solid rgba(255,255,255,0.1);
            backdrop-filter: blur(30px);
            font-size: 14px;
            letter-spacing: 2px;
             
            text-transform: uppercase;
            text-decoration: none !important;
        }
    </style>

      <!-- Infomessages -->
    <script src="//cdn.jsdelivr.net/npm/sweetalert2@11"></script>
    <script src="Style/Js/infoMessages.js"></script>


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <section class="home-section">
         <div class="container-fluid">
               <br />
            <center><h1>Choose a date to see order history:</h1>
                <br />

                <h2>From:</h2>
                  <br />
             <input type="date" required="required" class="textbox" id="searchDateFrom" runat="server" />
                <br />
                 <br />
                  <h2>To:</h2>
                  <br />
              <input type="date" required="required"  class="textbox" id="searchDateTo" runat="server" />
            
             <br />
             <br />

             <asp:Button ID="searchBtn"  OnClick="searchBtn_Click" runat="server" Text="Search" CssClass="sellBtn" />
                <br />
                
                </center>


             <asp:Panel ID="gridPanel" Visible="false" runat="server">
              <div class="gridView-section">
                    
                <asp:GridView ID="orderHistoryGrid"  AutoGenerateColumns="false"  CssClass="table table-responsive" runat="server" CellPadding="3" ForeColor="Black" GridLines="Both" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px">
                      <AlternatingRowStyle BackColor="#CCCCCC"></AlternatingRowStyle>

                      <FooterStyle BackColor="#CCCCCC"></FooterStyle>

                      <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White"></HeaderStyle>

                      <PagerStyle HorizontalAlign="Center" BackColor="#999999" ForeColor="Black"></PagerStyle>

                      <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White"></SelectedRowStyle>

                      <SortedAscendingCellStyle BackColor="#F1F1F1"></SortedAscendingCellStyle>

                      <SortedAscendingHeaderStyle BackColor="#808080"></SortedAscendingHeaderStyle>

                      <SortedDescendingCellStyle BackColor="#CAC9C9"></SortedDescendingCellStyle>

                      <SortedDescendingHeaderStyle BackColor="#383838"></SortedDescendingHeaderStyle>

                      

                     

                      <Columns>

                    <asp:TemplateField HeaderText="Order id">
                        <ItemTemplate>
                             <asp:Label runat="server" ID="Id" Text='<%#Eval("Id")%>'></asp:Label>
                         </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Order date ">
                        <ItemTemplate>
                             <asp:Label runat="server" Text=' <%#Eval("OrderDate")%>'></asp:Label>
                         </ItemTemplate>
                    </asp:TemplateField>
 

                          <asp:TemplateField HeaderText="Order Price">
                        <ItemTemplate>
                             <asp:Label runat="server" ID="OrdePrice" Text='<%#Eval("GrandTotal")%>'></asp:Label>
                         </ItemTemplate>
                    </asp:TemplateField>

                           <asp:TemplateField HeaderText="Order status ">
                        <ItemTemplate>
                             <asp:Label ID="orderStatus" runat="server" Text=' <%#Eval("OrderStatus")%>'></asp:Label>
                         </ItemTemplate>
                    </asp:TemplateField>
                        </Columns>
                      </asp:GridView>
                    </div>
              </asp:Panel>

             <br />
             <br />
             <center>
             <asp:Label ID="errResult" CssClass="errBtn" runat="server" Visible="false" Text="There is no orders during this period"></asp:Label>
                 </center>

              </div>
         </section>
</asp:Content>
