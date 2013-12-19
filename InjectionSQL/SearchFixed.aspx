<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SearchFixed.aspx.cs" Inherits="InjectionSQL.Search2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <hgroup class="title">
        <h1>Search.</h1>
        <h2>Uses parameterized query. Prevents SQL injection.</h2>
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
        <asp:GridView ID="ProductGridView" runat="server" AutoGenerateColumns="False" Width="100%">
            <Columns>
                <asp:BoundField DataField="ProductName" HeaderText="Name" />
                <asp:BoundField DataField="UnitsInStock" HeaderText="Units In Stock" />
                <asp:BoundField DataField="UnitPrice" HeaderText="Price" DataFormatString="{0:c}" />
            </Columns>
        </asp:GridView>
    </asp:Panel>
</asp:Content>
