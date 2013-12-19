<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="FileDownloadHandler._Default" %>
<%@ Import Namespace="System.IO" %>

<asp:Content runat="server" ID="FeaturedContent" ContentPlaceHolderID="FeaturedContent">
    <section class="featured">
        <div class="content-wrapper">
            <hgroup class="title">
                <h1><%: Title %>.</h1>
                <h2>This page lists all images for user.</h2>
            </hgroup>
            <p>
                Images are kept in App_Data\[Username] folder and downloaded trough http handler. The handler exposes direct file reference and is vulnerable to command injection.
            </p>
        </div>
    </section>
</asp:Content>
<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <h3>Files</h3>
    <ol class="round">
        <asp:Repeater runat="server" ID="rptFiles">
            <ItemTemplate>
                <li class="file">
                    <h5><%#((FileInfo)Container.DataItem).Name %>, size in bytes: <%#((FileInfo)Container.DataItem).Length %></h5>
                    <asp:HyperLink runat="server" Text="Download" NavigateUrl='<%#"DownloadFile.ashx?file=" + ((FileInfo)Container.DataItem).Name %>'></asp:HyperLink>
                </li>
            </ItemTemplate>
        </asp:Repeater>
    </ol>
</asp:Content>
