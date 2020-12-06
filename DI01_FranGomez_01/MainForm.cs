using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using Dapper;

namespace DI01_FranGomez_01
{
    public partial class MainForm : Form
    {
        int productPerPage;
        int numberOfPages;
        int currentPage = 0;
        public MainForm()
        {
            InitializeComponent();

            // lenguatge
            lenguageComboBox.Text = "en";
            lenguageComboBox.Items.Add("en");
            lenguageComboBox.Items.Add("fr");


            // complete listview
            completeResultQuery();
        }

        public void completeResultQuery()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["AdventureWorks2016"].ConnectionString;
            using (IDbConnection connection = new SqlConnection(connectionString))
            {

                string sql = $@"select Production.ProductModel.ProductModelID, Production.ProductModel.Name, Production.ProductDescription.Description FROM Production.Product INNER JOIN Production.ProductSubcategory ON Production.Product.ProductSubcategoryID = Production.ProductSubcategory.ProductSubcategoryID INNER JOIN Production.ProductCategory ON Production.ProductSubcategory.ProductCategoryID = Production.ProductCategory.ProductCategoryID INNER JOIN Production.ProductModel ON Production.Product.ProductModelID = Production.ProductModel.ProductModelID INNER JOIN Production.ProductModelProductDescriptionCulture ON Production.ProductModel.ProductModelID = Production.ProductModelProductDescriptionCulture.ProductModelID INNER JOIN Production.ProductDescription ON Production.ProductModelProductDescriptionCulture.ProductDescriptionID = Production.ProductDescription.ProductDescriptionID WHERE ProductModelProductDescriptionCulture.CultureID = '{lenguageComboBox.Text}' AND Product.ProductModelID IS NOT NULL";
                List<Model> models = new List<Model>();
                models = connection.Query<Model>(sql).ToList();
                foreach (Model model in models)
                {
                    listView1.Items.Add(model.ToString());
                }
            }
        }
        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            string productSelected = listView1.SelectedItems[0].Text;
            int productId = int.Parse(productSelected.Split(',')[0]);

            ProductForm pf = new ProductForm(productId);
            pf.Show();

        }
        private void MainForm_Load(object sender, EventArgs e)
        {
            string conn = ConfigurationManager.ConnectionStrings["AdventureWorks2016"].ConnectionString;
            using (SqlConnection sqlconn = new SqlConnection(conn))
            {
                // Pagination


                // comboBox Categories
                string sqlquery1 = $"SELECT [Name] FROM [AdventureWorks2016].[Production].[ProductCategory]";
                List<string> categories = new List<string>();
                categories = sqlconn.Query<string>(sqlquery1).ToList();
                foreach (string category in categories)
                {
                    categoryComboBox.Items.Add(category);
                }

                // comboBox SubCategories
                string sqlquery2 = $"SELECT [Name] FROM [AdventureWorks2016].[Production].[ProductSubcategory]";
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
        private void categoryComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string conn = ConfigurationManager.ConnectionStrings["AdventureWorks2016"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(conn))
            {
                string sql = $@"select Production.ProductModel.ProductModelID, Production.ProductModel.Name, Production.ProductDescription.Description FROM Production.Product INNER JOIN Production.ProductSubcategory ON Production.Product.ProductSubcategoryID = Production.ProductSubcategory.ProductSubcategoryID INNER JOIN Production.ProductCategory ON Production.ProductSubcategory.ProductCategoryID = Production.ProductCategory.ProductCategoryID INNER JOIN Production.ProductModel ON Production.Product.ProductModelID = Production.ProductModel.ProductModelID INNER JOIN Production.ProductModelProductDescriptionCulture ON Production.ProductModel.ProductModelID = Production.ProductModelProductDescriptionCulture.ProductModelID INNER JOIN Production.ProductDescription ON Production.ProductModelProductDescriptionCulture.ProductDescriptionID = Production.ProductDescription.ProductDescriptionID WHERE ProductModelProductDescriptionCulture.CultureID = '{lenguageComboBox.Text}' AND Product.ProductModelID IS NOT NULL AND Production.ProductCategory.Name = '{categoryComboBox.Text}';";
                listView1.Items.Clear();
                //listView1.Columns.Add("1.column");
                List<Model> modelsCategory = new List<Model>();
                modelsCategory = connection.Query<Model>(sql).ToList();
                foreach (Model model in modelsCategory)
                {
                    listView1.Items.Add(model.ToString());
                }
            }
        }
        private void subCategoryComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string conn = ConfigurationManager.ConnectionStrings["AdventureWorks2016"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(conn))
            {
                string sql = $@"select Production.ProductModel.ProductModelID, Production.ProductModel.Name, Production.ProductDescription.Description FROM Production.Product INNER JOIN Production.ProductSubcategory ON Production.Product.ProductSubcategoryID = Production.ProductSubcategory.ProductSubcategoryID INNER JOIN Production.ProductCategory ON Production.ProductSubcategory.ProductCategoryID = Production.ProductCategory.ProductCategoryID INNER JOIN Production.ProductModel ON Production.Product.ProductModelID = Production.ProductModel.ProductModelID INNER JOIN Production.ProductModelProductDescriptionCulture ON Production.ProductModel.ProductModelID = Production.ProductModelProductDescriptionCulture.ProductModelID INNER JOIN Production.ProductDescription ON Production.ProductModelProductDescriptionCulture.ProductDescriptionID = Production.ProductDescription.ProductDescriptionID WHERE ProductModelProductDescriptionCulture.CultureID = '{lenguageComboBox.Text}' AND Product.ProductModelID IS NOT NULL AND Production.ProductSubcategory.Name = '{subCategoryComboBox.Text}';";
                listView1.Items.Clear();
                //listView1.Columns.Add("1.column");
                List<Model> modelsSubcategory = new List<Model>();
                modelsSubcategory = connection.Query<Model>(sql).ToList();
                foreach (Model model in modelsSubcategory)
                {
                    listView1.Items.Add(model.ToString());
                }
            }
        }
        private void ColorComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string conn = ConfigurationManager.ConnectionStrings["AdventureWorks2016"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(conn))
            {
                string sql = $@"select Production.ProductModel.ProductModelID, Production.ProductModel.Name, Production.ProductDescription.Description FROM Production.Product INNER JOIN Production.ProductSubcategory ON Production.Product.ProductSubcategoryID = Production.ProductSubcategory.ProductSubcategoryID INNER JOIN Production.ProductCategory ON Production.ProductSubcategory.ProductCategoryID = Production.ProductCategory.ProductCategoryID INNER JOIN Production.ProductModel ON Production.Product.ProductModelID = Production.ProductModel.ProductModelID INNER JOIN Production.ProductModelProductDescriptionCulture ON Production.ProductModel.ProductModelID = Production.ProductModelProductDescriptionCulture.ProductModelID INNER JOIN Production.ProductDescription ON Production.ProductModelProductDescriptionCulture.ProductDescriptionID = Production.ProductDescription.ProductDescriptionID WHERE ProductModelProductDescriptionCulture.CultureID = '{lenguageComboBox.Text}' AND Product.ProductModelID IS NOT NULL AND [Color] = '{ColorComboBox.Text}';";
                listView1.Items.Clear();
                //listView1.Columns.Add("1.column");
                List<Model> modelsSubcategory = new List<Model>();
                modelsSubcategory = connection.Query<Model>(sql).ToList();
                foreach (Model model in modelsSubcategory)
                {
                    listView1.Items.Add(model.ToString());
                }
            }
        }
        private void clearButton_Click(object sender, EventArgs e)
        {
            categoryComboBox.Text = "";
            subCategoryComboBox.Text = "";
            ColorComboBox.Text = "";

            
            completeResultQuery();
        }
    }
}
