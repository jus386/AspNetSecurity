<%@ Page Language="C#" %>

<%=PrintSessionVars()%>

<script runat="server">
    protected string PrintSessionVars()
    {
        string value = string.Empty;
        foreach (string key in Session.Keys)
        {
            value += key + "=" + Session[key] + "</br>";
        }
		
        value += "MachineName=" + Server.MachineName + "</br>";

        foreach (string key in Application.AllKeys)
        {
            value += key + "=" + Application[key] + "</br>";
        }
        return value;
    }
</script>
