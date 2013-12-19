using System.IO;
using System.Security;
using System.Web;

namespace FileDownloadHandler
{
    /// <summary>
    /// Summary description for DownloadFile
    /// </summary>
    public class DownloadFile : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            if (!context.User.Identity.IsAuthenticated)
            {
                throw new SecurityException("User must be authenticated");
            }
            string fileName = context.Request.QueryString["file"];
            string filesRootFolder = context.Server.MapPath("~/App_Data/Files/" + context.User.Identity.Name);

            var fullFilePath = Path.Combine(filesRootFolder, fileName);
            var fileBytes = File.ReadAllBytes(fullFilePath);

            context.Response.ContentType = "application/octet-stream";
            context.Response.AddHeader("content-disposition", "attachment; filename=" + fileName);

            context.Response.BinaryWrite(fileBytes);
            context.Response.Flush();
            context.Response.End();
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}