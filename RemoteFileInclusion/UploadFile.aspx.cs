using System;
using System.IO;

namespace UploadFileInclusion
{
    public partial class About : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            if (fileTest.HasFile)
            {
                string path = Server.MapPath("~/Uploads");
                File.WriteAllBytes(Path.Combine(path, fileTest.FileName), fileTest.FileBytes);
            }
        }
    }
}
