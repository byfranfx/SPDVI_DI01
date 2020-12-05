using Dapper;
using PagedList;
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
    public partial class AdvancedForm : Form
    {
        private List<ProductModelComplete> productsList;
        private string lenguage = "en";
        DataTable dt;
        public AdvancedForm()
        {
            InitializeComponent();
            chargeTables();
        }

        public void Category()
        {
            
        }

        public void SelectSubCategory()
        {
            
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

            string conn = ConfigurationManager.ConnectionStrings["AdventureWorks2016"].ConnectionString;
            using (SqlConnection sqlconn = new SqlConnection(conn))
            {                      
                // comboBox Categories
                string sqlquery1 = $"SELECT [Name] FROM[AdventureWorks2016].[Production].[ProductCategory]";
                List<string> categories = new List<string>();
                categories = sqlconn.Query<string>(sqlquery1).ToList();
                foreach (string category in categories)
                {
                    categoryComboBox.Items.Add(category);
                }

                // comboBox SubCategories
                string sqlquery2 = $"SELECT [Name] FROM[AdventureWorks2016].[Production].[ProductSubcategory]";
                List<string> subCategories = new List<string>();
                subCategories = sqlconn.Query<string>(sqlquery2).ToList();
                foreach (string subcategory in subCategories)
                {
                    subCategoryComboBox.Items.Add(subcategory);
                }

                // comboBox Color
                string sqlquery3 = $"SELECT DISTINCT [Color] FROM[AdventureWorks2016].[Production].[Product] WHERE [Color] IS NOT NULL";
                List<string> Color = new List<string>();
                Color = sqlconn.Query<string>(sqlquery3).ToList();
                foreach (string color in Color)
                {
                    ColorComboBox.Items.Add(color);
                }
            }
        }
        private void chargeTables()
        {
            string conn = ConfigurationManager.ConnectionStrings["AdventureWorks2016"].ConnectionString;
            using (SqlConnection sqlconn = new SqlConnection(conn))
            {
                string sql = $"select Production.ProductModel.Name AS ProductModel, Production.ProductDescription.Description, Production.Product.Name, Production.Product.ProductNumber, Production.Product.Color, Production.Product.ListPrice, Production.Product.Size, Production.Product.ProductLine, Production.Product.Class, Production.Product.Style, Production.ProductCategory.Name AS[Product Category], Production.ProductSubcategory.Name AS[Product Subcategory] FROM Production.Product INNER JOIN Production.ProductSubcategory ON Production.Product.ProductSubcategoryID = Production.ProductSubcategory.ProductSubcategoryID INNER JOIN Production.ProductCategory ON Production.ProductSubcategory.ProductCategoryID = Production.ProductCategory.ProductCategoryID INNER JOIN Production.ProductModel ON Production.Product.ProductModelID = Production.ProductModel.ProductModelID INNER JOIN Production.ProductModelProductDescriptionCulture ON Production.ProductModel.ProductModelID = Production.ProductModelProductDescriptionCulture.ProductModelID INNER JOIN Production.ProductDescription ON Production.ProductModelProductDescriptionCulture.ProductDescriptionID = Production.ProductDescription.ProductDescriptionID WHERE ProductModelProductDescriptionCulture.CultureID = 'en' AND Product.ProductModelID IS NOT NULL";

                SqlCommand sqlcomn = new SqlCommand(sql, sqlconn);
                sqlconn.Open();
                dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(sqlcomn);
                da.Fill(dt);
                dataGridView1.AutoGenerateColumns = false;
                dataGridView1.ColumnCount = 2;
                dataGridView1.Columns[0].HeaderText = "Name";
                dataGridView1.Columns[0].DataPropertyName = "Name";
                DataGridViewColumn column0 = dataGridView1.Columns[0];
                column0.Width = 200;
                dataGridView1.Columns[1].HeaderText = "Description";
                dataGridView1.Columns[1].DataPropertyName = "Description";
                DataGridViewColumn column1 = dataGridView1.Columns[1];
                column1.Width = 11000;
                dataGridView1.DataSource = dt;
                sqlconn.Close();
                //dataTable.AsEnumerable().Skip(100).Take(25);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            (dataGridView1.DataSource as DataTable).DefaultView.RowFilter = string.Format("[ProductModel] LIKE '{0}%' OR [ProductModel] LIKE '%{0}%' OR [ProductModel] LIKE '%{0}'", textBox1.Text);

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            (dataGridView1.DataSource as DataTable).DefaultView.RowFilter = string.Format("[Description] LIKE '{0}%' OR [Description] LIKE '%{0}%' OR [Description] LIKE '%{0}'", textBox2.Text);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            CompleteForm cf = new CompleteForm();
            //

            //
            cf.Show();
        }

        private void categoryComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string conn = ConfigurationManager.ConnectionStrings["AdventureWorks2016"].ConnectionString;
            using (SqlConnection sqlconn = new SqlConnection(conn))
            {
                string sql = $"select Production.ProductModel.Name AS ProductModel, Production.ProductDescription.Description, Production.Product.Name, Production.Product.ProductNumber, Production.Product.Color, Production.Product.ListPrice, Production.Product.Size, Production.Product.ProductLine, Production.Product.Class, Production.Product.Style, Production.ProductCategory.Name AS[Product Category], Production.ProductSubcategory.Name AS[Product Subcategory] FROM Production.Product INNER JOIN Production.ProductSubcategory ON Production.Product.ProductSubcategoryID = Production.ProductSubcategory.ProductSubcategoryID INNER JOIN Production.ProductCategory ON Production.ProductSubcategory.ProductCategoryID = Production.ProductCategory.ProductCategoryID INNER JOIN Production.ProductModel ON Production.Product.ProductModelID = Production.ProductModel.ProductModelID INNER JOIN Production.ProductModelProductDescriptionCulture ON Production.ProductModel.ProductModelID = Production.ProductModelProductDescriptionCulture.ProductModelID INNER JOIN Production.ProductDescription ON Production.ProductModelProductDescriptionCulture.ProductDescriptionID = Production.ProductDescription.ProductDescriptionID WHERE ProductModelProductDescriptionCulture.CultureID = 'en' AND Product.ProductModelID IS NOT NULL AND Production.ProductCategory.Name = '{categoryComboBox.Text}';";

                SqlCommand sqlcomn = new SqlCommand(sql, sqlconn);
                sqlconn.Open();
                SqlDataAdapter sdr = new SqlDataAdapter(sqlcomn);
                DataTable dt = new DataTable();
                sdr.Fill(dt);
                dataGridView1.DataSource = dt;
                sqlconn.Close();
                // count
                string i = dt.Rows.Count.ToString();
                countRowsLabel.Text = i;
            }

            //(dataGridView1.DataSource as DataTable).DefaultView.RowFilter = string.Format("[Product Category] LIKE '{0}%' OR [Product Category] LIKE '%{0}%'OR [Product Category] LIKE '%{0}'", categoryComboBox.Text);
        }

        private void ColorComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string conn = ConfigurationManager.ConnectionStrings["AdventureWorks2016"].ConnectionString;
            using (SqlConnection sqlconn = new SqlConnection(conn))
            {
                string sql = $"select Production.ProductModel.Name AS ProductModel, Production.ProductDescription.Description, Production.Product.Name, Production.Product.ProductNumber, Production.Product.Color, Production.Product.ListPrice, Production.Product.Size, Production.Product.ProductLine, Production.Product.Class, Production.Product.Style, Production.ProductCategory.Name AS[Product Category], Production.ProductSubcategory.Name AS[Product Subcategory] FROM Production.Product INNER JOIN Production.ProductSubcategory ON Production.Product.ProductSubcategoryID = Production.ProductSubcategory.ProductSubcategoryID INNER JOIN Production.ProductCategory ON Production.ProductSubcategory.ProductCategoryID = Production.ProductCategory.ProductCategoryID INNER JOIN Production.ProductModel ON Production.Product.ProductModelID = Production.ProductModel.ProductModelID INNER JOIN Production.ProductModelProductDescriptionCulture ON Production.ProductModel.ProductModelID = Production.ProductModelProductDescriptionCulture.ProductModelID INNER JOIN Production.ProductDescription ON Production.ProductModelProductDescriptionCulture.ProductDescriptionID = Production.ProductDescription.ProductDescriptionID WHERE ProductModelProductDescriptionCulture.CultureID = 'en' AND Product.ProductModelID IS NOT NULL AND [Color] = '{ColorComboBox.Text}';";

                SqlCommand sqlcomn = new SqlCommand(sql, sqlconn);
                sqlconn.Open();
                SqlDataAdapter sdr = new SqlDataAdapter(sqlcomn);
                DataTable dt = new DataTable();
                sdr.Fill(dt);
                dataGridView1.DataSource = dt;
                sqlconn.Close();
                // count
                string i = dt.Rows.Count.ToString();
                countRowsLabel.Text = i;
            }
        }

        private void subCategoryComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string conn = ConfigurationManager.ConnectionStrings["AdventureWorks2016"].ConnectionString;
            using (SqlConnection sqlconn = new SqlConnection(conn))
            {
                string sql = $"select Production.ProductModel.Name AS ProductModel, Production.ProductDescription.Description, Production.Product.Name, Production.Product.ProductNumber, Production.Product.Color, Production.Product.ListPrice, Production.Product.Size, Production.Product.ProductLine, Production.Product.Class, Production.Product.Style, Production.ProductCategory.Name AS[Product Category], Production.ProductSubcategory.Name AS[Product Subcategory] FROM Production.Product INNER JOIN Production.ProductSubcategory ON Production.Product.ProductSubcategoryID = Production.ProductSubcategory.ProductSubcategoryID INNER JOIN Production.ProductCategory ON Production.ProductSubcategory.ProductCategoryID = Production.ProductCategory.ProductCategoryID INNER JOIN Production.ProductModel ON Production.Product.ProductModelID = Production.ProductModel.ProductModelID INNER JOIN Production.ProductModelProductDescriptionCulture ON Production.ProductModel.ProductModelID = Production.ProductModelProductDescriptionCulture.ProductModelID INNER JOIN Production.ProductDescription ON Production.ProductModelProductDescriptionCulture.ProductDescriptionID = Production.ProductDescription.ProductDescriptionID WHERE ProductModelProductDescriptionCulture.CultureID = 'en' AND Product.ProductModelID IS NOT NULL AND Production.ProductSubcategory.Name = '{subCategoryComboBox.Text}';";

                SqlCommand sqlcomn = new SqlCommand(sql, sqlconn);
                sqlconn.Open();
                SqlDataAdapter sdr = new SqlDataAdapter(sqlcomn);
                DataTable dt = new DataTable();
                sdr.Fill(dt);
                dataGridView1.DataSource = dt;
                sqlconn.Close();
                // count
                string i = dt.Rows.Count.ToString();
                countRowsLabel.Text = i;
            }

            //(dataGridView1.DataSource as DataTable).DefaultView.RowFilter = string.Format("[Product Subcategory] LIKE '{0}%' OR [Product Subcategory] LIKE '%{0}%'OR [Product Subcategory] LIKE '%{0}'", subCategoryComboBox.Text);
        }
    }
}
