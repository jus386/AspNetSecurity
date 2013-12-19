using System;

namespace UploadFileInclusion
{
    public partial class PrintSession : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected string PrintSessionVars()
        {
            string value = string.Empty;
            foreach (string key in Session.Keys)
            {
                value += key + "=" + Session[key] + "</br>";
            }
            return value;
        }
    }
}