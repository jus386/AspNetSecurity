<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Search.aspx.cs" Inherits="XSSStored.Search" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <hgroup class="title">
        <h1>Search.</h1>
        <h2>This page is built with ASP.NET 3.5 and deliberately doesn't encode content with AntiXSS encoder. Vulnerable to stored XSS attack.</h2>
    </hgroup>
    <fieldset>
        <legend>Search</legend>
        <ol>
            <li>
                <asp:Label ID="Label1" runat="server" AssociatedControlID="txtSearchTerm">Search term</asp:Label>
                <asp:TextBox runat="server" ID="txtSearchTerm" />
            </li>
        </ol>
        <asp:Button ID="Button1" runat="server" Text="Search" OnClick="Button1_Click" />
    </fieldset>

    <asp:Panel runat="server" ID="SearchPanel" Visible="False">
        <p>
            There were
    <b>
        <asp:Label runat="server" ID="ProductCount"></asp:Label></b>
            products found
        </p>

        <table style="width: 100%;">
            <thead>
                <tr>
                    <th>Name</th>
                    <th>Units In Stock</th>
                    <th>Price</th>
                </tr>
            </thead>
            <tbody>
                <asp:Repeater runat="server" ID="rptSearchResults">
                    <ItemTemplate>
                        <tr>
                            <td><%# Eval("ProductName") %> </td>
                            <td><%# Eval("UnitsInStock") %> </td>
                            <td><%# Eval("Discontinued") %> </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </tbody>
        </table>
    </asp:Panel>
</asp:Content>
