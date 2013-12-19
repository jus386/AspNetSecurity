using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;

namespace InjectionSQL
{
    public partial class Product2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var categoryId = Request.QueryString["CategoryId"];

            var connString = WebConfigurationManager.ConnectionStrings["Northwind"].ConnectionString;
            var sqlString = "SELECT * FROM Products WHERE CategoryID = @categoryId";
            using (var conn = new SqlConnection(connString))
            {
                using (var command = new SqlCommand(sqlString, conn))
                {
                    var categoryIdParam = new SqlParameter("categoryId", SqlDbType.Int);
                    categoryIdParam.Value = categoryId;
                    command.Parameters.Add(categoryIdParam);

                    command.Connection.Open();
                    ProductGridView.DataSource = command.ExecuteReader();
                    ProductGridView.DataBind();
                }
            }

            ProductCount.Text = ProductGridView.Rows.Count.ToString("n0");
        }
    }
}