<%

Dim szCurrentRoot: szCurrentRoot= ""

'Create the File System Ojbect
Set objFSO = Server.CreateObject("Scripting.FileSystemObject")

'Get the Absolute Path of the current directory
szCurrentRoot = objFSO.GetParentFolderName(Server.MapPath(Request.ServerVariables("URL")))

'Print to the screen.  The following line is line 17 which causes the error
Response.Write szCurrentRoot
%>