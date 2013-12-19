using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;

namespace InjectionSQL
{
    public partial class Search2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            ParameterizedQuerySearch();
        }

        private void ParameterizedQuerySearch()
        {
            var connString = WebConfigurationManager.ConnectionStrings["Northwind"].ConnectionString;
            string searchTerm = txtSearchTerm.Text;
            string searchQuery = "SELECT * FROM dbo.Products WHERE ProductName LIKE'%@searchTerm%'";
            using (var conn = new SqlConnection(connString))
            {
                using (var command = new SqlCommand(searchQuery, conn))
                {
                    var searchTermParam = new SqlParameter("searchTerm", SqlDbType.NVarChar);
                    searchTermParam.Value = searchTerm;
                    command.Parameters.Add(searchTermParam);

                    command.CommandType = CommandType.Text;
                    command.Connection.Open();
                    this.ProductGridView.DataSource = command.ExecuteReader();
                    this.ProductGridView.DataBind();
                }
            }

            this.ProductCount.Text = this.ProductGridView.Rows.Count.ToString("n0");
            this.SearchPanel.Visible = true;
        }
    }
}