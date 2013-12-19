<%@ Page Title="Upload file" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="UploadFile.aspx.cs" Inherits="UploadFileInclusion.About" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2>
        File upload. Uploaded files are in the /Uploads folder
    </h2>
    <p>
        <asp:FileUpload runat="server" ID="fileTest" />
    </p>
    <p>
        <asp:Button runat="server" ID="btnUpload" Text="Upload" OnClick="btnUpload_Click" />
    </p>
</asp:Content>
