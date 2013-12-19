<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Product.aspx.cs" Inherits="InjectionSQL.Product" %>

<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
  <p>There are
    <b><asp:Label runat="server" ID="ProductCount"></asp:Label></b>
    products</p>
  <asp:GridView ID="ProductGridView" runat="server" AutoGenerateColumns="False" Width="100%">
    <Columns>
      <asp:BoundField DataField="ProductName" HeaderText="Name" />
      <asp:BoundField DataField="UnitsInStock" HeaderText="Units In Stock" />
      <asp:BoundField DataField="UnitPrice" HeaderText="Price" DataFormatString="{0:c}" />
    </Columns>
  </asp:GridView>
</asp:Content>
