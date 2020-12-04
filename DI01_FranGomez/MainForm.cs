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
using TareaDI01;

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
            string conn = ConfigurationManager.ConnectionStrings["AdventureWorks2016"].ConnectionString;


            using (SqlConnection sqlconn = new SqlConnection(conn))
            {
                string sql = $"select Production.ProductModel.Name AS ProductModel, Production.ProductDescription.Description, Production.Product.Name, Production.Product.ProductNumber, Production.Product.Color, Production.Product.ListPrice, Production.Product.Size, Production.Product.ProductLine, Production.Product.Class, Production.Product.Style, Production.ProductCategory.Name AS[Product Category], Production.ProductSubcategory.Name AS[Product Subcategory] FROM Production.Product INNER JOIN Production.ProductSubcategory ON Production.Product.ProductSubcategoryID = Production.ProductSubcategory.ProductSubcategoryID INNER JOIN Production.ProductCategory ON Production.ProductSubcategory.ProductCategoryID = Production.ProductCategory.ProductCategoryID INNER JOIN Production.ProductModel ON Production.Product.ProductModelID = Production.ProductModel.ProductModelID INNER JOIN Production.ProductModelProductDescriptionCulture ON Production.ProductModel.ProductModelID = Production.ProductModelProductDescriptionCulture.ProductModelID INNER JOIN Production.ProductDescription ON Production.ProductModelProductDescriptionCulture.ProductDescriptionID = Production.ProductDescription.ProductDescriptionID WHERE ProductModelProductDescriptionCulture.CultureID = 'en' AND Product.ProductModelID IS NOT NULL";
                SqlCommand sqlcomn = new SqlCommand(sql, sqlconn);
                sqlconn.Open();
                SqlDataAdapter sdr = new SqlDataAdapter(sqlcomn);
                DataTable dt = new DataTable();
                sdr.Fill(dt);
                dataGridView1.DataSource = dt;
                sqlconn.Close();


                // comboBox
                string sqlquery = $"SELECT [Name] FROM[AdventureWorks2016].[Production].[ProductCategory]";
                List<string> categories = new List<string>();
                categories = sqlconn.Query<string>(sqlquery).ToList();
                foreach (string categpry in categories)
                {
                    comboBox1.Items.Add(categpry);
                }                
            }
        }

        

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            (dataGridView1.DataSource as DataTable).DefaultView.RowFilter = string.Format("'Product Category' LIKE '{0}%' OR 'Product Category' LIKE '%{0}%'OR 'Product Category' LIKE '%{0}'", comboBox1.Text);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //(dataGridView1.DataSource as DataTable).DefaultView.RowFilter = string.Format("ProductModel LIKE '{0}%' OR ProductModel LIKE '%{0}%'OR ProductModel LIKE '%{0}'", textBox1.Text);
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            //(dataGridView1.DataSource as DataTable).DefaultView.RowFilter = string.Format("Color LIKE '{0}%' OR Color LIKE '%{0}%'OR Color LIKE '%{0}'", textBox2.Text);
        }

        private void button1_Click(object sender, EventArgs e)
        {

            (dataGridView1.DataSource as DataTable).DefaultView.RowFilter = string.Format("Color LIKE '{0}%' OR Color LIKE '%{0}%'OR Color LIKE '%{0}'", textBox2.Text);

        }
    }
}
