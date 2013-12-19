using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;

namespace InjectionSQL
{
    public partial class SearchVulnerableSP : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            VulnerableSPSearch();
        }

        private void VulnerableSPSearch()
        {
            var connString = WebConfigurationManager.ConnectionStrings["Northwind"].ConnectionString;
            string searchTerm = txtSearchTerm.Text;
            using (var conn = new SqlConnection(connString))
            {
                using (var command = new SqlCommand("VulnerableSearch", conn))
                {
                    var searchTermParam = new SqlParameter("SearchTerm", SqlDbType.NVarChar);
                    searchTermParam.Value = searchTerm;
                    command.Parameters.Add(searchTermParam);

                    command.CommandType = CommandType.StoredProcedure;
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