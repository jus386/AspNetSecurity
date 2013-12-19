using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;

namespace XSSStored
{
    public partial class Search : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            var connString = WebConfigurationManager.ConnectionStrings["Northwind"].ConnectionString;
            string searchTerm = txtSearchTerm.Text;
            string searchQuery = "SELECT * FROM dbo.Products WHERE ProductName LIKE'%" + searchTerm + "%'";
            using (var conn = new SqlConnection(connString))
            {
                using (var command = new SqlCommand(searchQuery, conn))
                {
                    command.CommandType = CommandType.Text;
                    command.Connection.Open();
                    this.rptSearchResults.DataSource = command.ExecuteReader();
                    this.rptSearchResults.DataBind();
                }
            }

            this.ProductCount.Text = this.rptSearchResults.Items.Count.ToString("n0");
            this.SearchPanel.Visible = true;
        }
    }
}