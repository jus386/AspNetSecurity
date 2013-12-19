<%@ Page Title="Print session" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PrintSession.aspx.cs" Inherits="UploadFileInclusion.PrintSession" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        Print session. Prints all session variables
    </h2>
    <p>
        <%=PrintSessionVars()%>
    </p>
</asp:Content>
