<%@ Page Title="User products" Language="C#" MasterPageFile="~/UserMasterPage.Master" AutoEventWireup="true" CodeBehind="Userproduct.aspx.cs" Inherits="WebApplication.Userproduct" %>
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
            <center><h1>Products for selling:</h1></center>
             <hr />

        
              <div class="gridView-section">
                  <asp:GridView ID="productsGrid" OnRowDeleting="productsGrid_RowDeleting" AutoGenerateColumns="false"  CssClass="table table-responsive" runat="server" CellPadding="3" ForeColor="Black" GridLines="Both" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px">
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
                        <EmptyDataTemplate>You do not have any product for sell!</EmptyDataTemplate>

                     

                      <Columns>
                     <asp:TemplateField HeaderText="Delete">
                        <ItemTemplate>
                     <asp:Button ID="delete_Btn" runat="server" CssClass="remove-image_grid" CommandName="Delete" Text="X"/>
                        </ItemTemplate>
                     </asp:TemplateField>


                    <asp:TemplateField Visible="false">
                        <ItemTemplate>
                             <asp:Label runat="server" ID="Id" Text='<%#Eval("Id")%>'></asp:Label>
                         </ItemTemplate>
                    </asp:TemplateField>

                         
                          
                     <asp:TemplateField HeaderText="Product name">
                        <ItemTemplate>
                             <asp:Label runat="server" ID="ProductName" Text=' <%#Eval("ProductName")%>'></asp:Label>
                         </ItemTemplate>
                    </asp:TemplateField>
                     

                     <asp:TemplateField HeaderText="Product type">
                        <ItemTemplate>
                             <asp:Label runat="server" ID="ProductType" Text=' <%#Eval("ProductType")%>'></asp:Label>
                         </ItemTemplate>
                    </asp:TemplateField>


                     <asp:TemplateField HeaderText="Product price ">
                        <ItemTemplate>
                             <asp:Label runat="server" Text=' <%#Eval("productPrice")%>'></asp:Label>
                         </ItemTemplate>
                    </asp:TemplateField>


                    <asp:TemplateField HeaderText="Year Of Make ">
                        <ItemTemplate>
                             <asp:Label runat="server" Text=' <%#Eval("ProductYearOfMake")%>'></asp:Label>
                         </ItemTemplate>
                    </asp:TemplateField>


                      <asp:TemplateField HeaderText="Product colour ">
                        <ItemTemplate>
                             <asp:Label runat="server" Text=' <%#Eval("ProductColour")%>'></asp:Label>
                         </ItemTemplate>
                    </asp:TemplateField>

                      <asp:TemplateField HeaderText="Product condition ">
                        <ItemTemplate>
                             <asp:Label runat="server" Text=' <%#Eval("ProductCondition")%>'></asp:Label>
                         </ItemTemplate>
                    </asp:TemplateField>

                      <asp:TemplateField HeaderText="Product status ">
                        <ItemTemplate>
                             <asp:Label ID="productStatus" runat="server" Text=' <%#Eval("productStatus")%>'></asp:Label>
                         </ItemTemplate>
                    </asp:TemplateField>

                      </Columns>
                     </asp:GridView>
                     </div>

                 <hr />
             <center><h1>Buying request:</h1></center>
                <hr />
          <div class="gridView-section">
                    
                    <asp:GridView ID="ordersGrid" OnRowCommand="ordersGrid_RowCommand" CssClass="table table-responsive" CellPadding="3" ForeColor="Black" GridLines="Both" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px"  runat="server">
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
                         <EmptyDataTemplate>There is no buying request right now</EmptyDataTemplate>


                        <Columns>
                           <asp:TemplateField>
                               <ItemTemplate >
                                   <asp:Button  ID="acceptBtn" CommandName="accept" CommandArgument='<%# Eval("Order id") %>'  CssClass="btn btn-info" runat="server" Text="Accept"/>
                                </ItemTemplate>

                              
                           </asp:TemplateField>

                            <asp:TemplateField>
                                 <ItemTemplate>
                                    <asp:Button ID="declineBtn" CommandName="decline" CommandArgument='<%# Eval("Order id") %>'  CssClass="btn btn-danger" runat="server" Text="Decline"/>
                               </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        
                 
                     </asp:GridView>
                  </div>
              </div>
    </section>
</asp:Content>
