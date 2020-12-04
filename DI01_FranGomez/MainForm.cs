using Dapper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlServerCe;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace DI01_FranGomez
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            string mainconn = ConfigurationManager.ConnectionStrings["AdventureWorks2016"].ConnectionString;
            SqlConnection sqlconn = new SqlConnection(mainconn);
            string sqlquery = $"select Production.ProductModel.Name AS ProductModel, Production.ProductDescription.Description, Production.Product.Name, Production.Product.ProductNumber, Production.Product.Color, Production.Product.ListPrice, Production.Product.Size, Production.Product.ProductLine, Production.Product.Class, Production.Product.Style, Production.ProductCategory.Name AS[Product Category], Production.ProductSubcategory.Name AS[Product Subcategory] FROM Production.Product INNER JOIN Production.ProductSubcategory ON Production.Product.ProductSubcategoryID = Production.ProductSubcategory.ProductSubcategoryID INNER JOIN Production.ProductCategory ON Production.ProductSubcategory.ProductCategoryID = Production.ProductCategory.ProductCategoryID INNER JOIN Production.ProductModel ON Production.Product.ProductModelID = Production.ProductModel.ProductModelID INNER JOIN Production.ProductModelProductDescriptionCulture ON Production.ProductModel.ProductModelID = Production.ProductModelProductDescriptionCulture.ProductModelID INNER JOIN Production.ProductDescription ON Production.ProductModelProductDescriptionCulture.ProductDescriptionID = Production.ProductDescription.ProductDescriptionID WHERE ProductModelProductDescriptionCulture.CultureID = 'en' AND Product.ProductModelID IS NOT NULL";

            SqlCommand sqlcomn = new SqlCommand(sqlquery, sqlconn);
            sqlconn.Open();
            SqlDataAdapter sdr = new SqlDataAdapter(sqlcomn);
            DataTable dt = new DataTable();
            sdr.Fill(dt);
            dataGridView1.DataSource = dt;
            sqlconn.Close();

        }
    }
}
