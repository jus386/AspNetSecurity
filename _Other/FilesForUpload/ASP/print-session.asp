<%
dim i
For Each i in Session.Contents
  Response.Write(i & "<br>")
Next
%>