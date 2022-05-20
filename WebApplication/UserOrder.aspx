<%@ Page Title="My orders" Language="C#" MasterPageFile="~/UserMasterPage.Master" AutoEventWireup="true" CodeBehind="UserOrder.aspx.cs" Inherits="WebApplication.UserOrder" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <link href="https://stackpath.bootstrapcdn.com/bootstrap/4.4.1/css/bootstrap.min.css" rel="stylesheet">

     <!-- Infomessages -->
    <script src="//cdn.jsdelivr.net/npm/sweetalert2@11"></script>
    <script src="Style/Js/infoMessages.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <section class="home-section">
          <div class="container-fluid">
               <br />
            <center><h1>Pending or rejected orders:(Waiting for the seller's confirmation)</h1></center>
             <hr />
               <div class="gridView-section">
                  <asp:GridView ID="pendingProductsGrid"  AutoGenerateColumns="false"  CssClass="table table-responsive" runat="server" CellPadding="3" ForeColor="Black" GridLines="Both" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px">
                      <AlternatingRowStyle BackColor="#CCCCCC"></AlternatingRowStyle>

                      <FooterStyle BackColor="#CCCCCC"></FooterStyle>

                      <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White"></HeaderStyle>

                      <PagerStyle HorizontalAlign="Center" BackColor="#999999" ForeColor="Black"></PagerStyle>

                      <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White"></SelectedRowStyle>

                      <SortedAscendingCellStyle BackColor="#F1F1F1"></SortedAscendingCellStyle>

                      <SortedAscendingHeaderStyle BackColor="#808080"></SortedAscendingHeaderStyle>

                      <SortedDescendingCellStyle BackColor="#CAC9C9"></SortedDescendingCellStyle>

                      <SortedDescendingHeaderStyle BackColor="#383838"></SortedDescendingHeaderStyle>

                      <EmptyDataRowStyle ForeColor="black" CssClass="center"/>
                      <EmptyDataTemplate>You have no orders waiting for the seller's confirmation</EmptyDataTemplate>

                     

                      <Columns>

                    <asp:TemplateField HeaderText="Order id">
                        <ItemTemplate>
                             <asp:Label runat="server" ID="Id" Text='<%#Eval("Id")%>'></asp:Label>
                         </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Order date ">
                        <ItemTemplate>
                             <asp:Label  runat="server" Text=' <%#Eval("OrderDate")%>'></asp:Label>
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

                   <hr />
             <center><h1>Completed orders:</h1></center>
                <hr />
          <div class="gridView-section">
                    
                <asp:GridView ID="completedOrdersGrid"  AutoGenerateColumns="false"  CssClass="table table-responsive" runat="server" CellPadding="3" ForeColor="Black" GridLines="Both" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px">
                      <AlternatingRowStyle BackColor="#CCCCCC"></AlternatingRowStyle>

                      <FooterStyle BackColor="#CCCCCC"></FooterStyle>

                      <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White"></HeaderStyle>

                      <PagerStyle HorizontalAlign="Center" BackColor="#999999" ForeColor="Black"></PagerStyle>

                      <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White"></SelectedRowStyle>

                      <SortedAscendingCellStyle BackColor="#F1F1F1"></SortedAscendingCellStyle>

                      <SortedAscendingHeaderStyle BackColor="#808080"></SortedAscendingHeaderStyle>

                      <SortedDescendingCellStyle BackColor="#CAC9C9"></SortedDescendingCellStyle>

                      <SortedDescendingHeaderStyle BackColor="#383838"></SortedDescendingHeaderStyle>

                      <EmptyDataRowStyle ForeColor="black" CssClass="center"/>
                      <EmptyDataTemplate>You have no orders that has been accepted by the seller.</EmptyDataTemplate>

                     

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

              </div>
         </section>
</asp:Content>
