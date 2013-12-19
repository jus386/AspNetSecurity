using System;
using System.Web.UI;

namespace SessionHijack
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            phSecret.Visible = User.Identity.Name == "admin";
        }
    }
}