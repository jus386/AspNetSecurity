using System;
using System.IO;
using System.Web.UI;

namespace FileDownloadHandler
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string filesRootFolder = Server.MapPath("~/App_Data/Files/" + User.Identity.Name);
            DirectoryInfo di = new DirectoryInfo(filesRootFolder);
            var files = di.GetFiles();
            rptFiles.DataSource = files;
            rptFiles.DataBind();
        }
    }
}