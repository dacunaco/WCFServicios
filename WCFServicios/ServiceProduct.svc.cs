using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WCFServicios
{
    public class ServiceProduct : IProduct
    {

        public Product GetProductByID(int ProductID)
        {
            string sqlCnx = ConfigurationManager.ConnectionStrings["Northwind"].ConnectionString;
            Product oProduct = new Product();
            using (SqlConnection cnx = new SqlConnection(sqlCnx)) {
                cnx.Open();
                using (SqlCommand cmd = new SqlCommand("select ProductID, ProductName, c.Description, " +
                    "UnitPrice, UnitsInStock from dbo.Products p " +
                    "inner join Categories c on p.CategoryID = c.CategoryID where ProductID = @Id", cnx)) {
                    cmd.Parameters.Add("@Id", System.Data.SqlDbType.Int).Value = ProductID;
                    SqlDataReader dr = cmd.ExecuteReader(System.Data.CommandBehavior.SingleRow);
                    dr.Read();
                    if (dr.HasRows) {
                        oProduct = new Product();
                        oProduct.ProductName = dr["ProductName"].ToString();
                        oProduct.UnitPrice = Convert.ToDouble(dr["UnitPrice"].ToString());
                        oProduct.Stock = Convert.ToInt32(dr["UnitsInStock"].ToString());
                        oProduct.Category = dr["Description"].ToString();
                    }
                }
            }

            return oProduct;
        }
    }
}
