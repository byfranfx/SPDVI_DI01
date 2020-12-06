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
                string sqlquery1 = $"SELECT [Name] FROM [AdventureWorks2016].[Production].[ProductCategory];";
                List<string> categories = new List<string>();
                categories = sqlconn.Query<string>(sqlquery1).ToList();
                foreach (string category in categories)
                {
                    categoryComboBox.Items.Add(category);
                }

                // comboBox SubCategories
                string sqlquery2 = $"SELECT [Name] FROM [AdventureWorks2016].[Production].[ProductSubcategory];";
                List<string> subCategories = new List<string>();
                subCategories = sqlconn.Query<string>(sqlquery2).ToList();
                foreach (string subcategory in subCategories)
                {
                    subCategoryComboBox.Items.Add(subcategory);
                }

                // comboBox Color
                string sqlquery3 = $"SELECT DISTINCT [Color] FROM [AdventureWorks2016].[Production].[Product] WHERE [Color] IS NOT NULL;";
                List<string> Color = new List<string>();
                Color = sqlconn.Query<string>(sqlquery3).ToList();
                foreach (string color in Color)
                {
                    colorComboBox.Items.Add(color);
                }

                // comboBox Size
                string sqlquery4 = $"SELECT DISTINCT Size FROM [AdventureWorks2016].[Production].[Product] WHERE [Size] IS NOT NULL;";
                List<string> Size = new List<string>();
                Size = sqlconn.Query<string>(sqlquery4).ToList();
                foreach (string size in Size)
                {
                    sizeComboBox.Items.Add(size);
                }

                // comboBox Product Line
                string sqlquery5 = $"SELECT DISTINCT [ProductLine] FROM [AdventureWorks2016].[Production].[Product] WHERE ProductLine IS NOT NULL;";
                List<string> ProductLine = new List<string>();
                ProductLine = sqlconn.Query<string>(sqlquery5).ToList();
                foreach (string productLine in ProductLine)
                {
                    productLineComboBox.Items.Add(productLine);
                }

                // comboBox class
                string sqlquery6 = $"SELECT DISTINCT [Class] FROM [AdventureWorks2016].[Production].[Product] WHERE Class IS NOT NULL;";
                List<string> Class = new List<string>();
                Class = sqlconn.Query<string>(sqlquery6).ToList();
                foreach (string clas in Class)
                {
                    classComboBox.Items.Add(clas);
                }

                // comboBox style
                string sqlquery7 = $"SELECT DISTINCT [Style] FROM [AdventureWorks2016].[Production].[Product] WHERE Style IS NOT NULL;";
                List<string> Style = new List<string>();
                Style = sqlconn.Query<string>(sqlquery7).ToList();
                foreach (string style in Style)
                {
                    styleComboBox.Items.Add(style);
                }
            }
        }
        // Button Filter {Apply : Clear}
        private void clearButton_Click(object sender, EventArgs e)
        {
            completeResultQuery();

            searchTextBox.Text = "";
            lenguageComboBox.Text = "en";
            colorComboBox.Text = "";
            price0TextBox.Text = "";
            price1TextBox.Text = "";
            sizeComboBox.Text = "";
            productLineComboBox.Text = "";
            classComboBox.Text = "";
            styleComboBox.Text = "";
            categoryComboBox.Text = "";
            subCategoryComboBox.Text = "";
        }
        // Falta realizar la query! {apply all filters}
        private void applyAllFiltersButton_Click(object sender, EventArgs e)
        {
            string conn = ConfigurationManager.ConnectionStrings["AdventureWorks2016"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(conn))
            {
                string sql = $@";";

                listView1.Items.Clear();
                List<Model> listApplyAllFilters = new List<Model>();
                listApplyAllFilters = connection.Query<Model>(sql).ToList();
                foreach (Model model in listApplyAllFilters)
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
                string sql = $@"select Production.ProductModel.ProductModelID, Production.ProductModel.Name, Production.ProductDescription.Description FROM Production.Product INNER JOIN Production.ProductSubcategory ON Production.Product.ProductSubcategoryID = Production.ProductSubcategory.ProductSubcategoryID INNER JOIN Production.ProductCategory ON Production.ProductSubcategory.ProductCategoryID = Production.ProductCategory.ProductCategoryID INNER JOIN Production.ProductModel ON Production.Product.ProductModelID = Production.ProductModel.ProductModelID INNER JOIN Production.ProductModelProductDescriptionCulture ON Production.ProductModel.ProductModelID = Production.ProductModelProductDescriptionCulture.ProductModelID INNER JOIN Production.ProductDescription ON Production.ProductModelProductDescriptionCulture.ProductDescriptionID = Production.ProductDescription.ProductDescriptionID WHERE ProductModelProductDescriptionCulture.CultureID = '{lenguageComboBox.Text}' AND Product.ProductModelID IS NOT NULL AND [Color] = '{colorComboBox.Text}';";
                listView1.Items.Clear();
                //listView1.Columns.Add("1.column");
                List<Model> listColor = new List<Model>();
                listColor = connection.Query<Model>(sql).ToList();
                foreach (Model model in listColor)
                {
                    listView1.Items.Add(model.ToString());
                }
            }
        }
        // Querys pendientes
        private void price1TextBox_TextChanged(object sender, EventArgs e)
        {

        }
        private void price0TextBox_TextChanged(object sender, EventArgs e)
        {

        }
        //
        private void sizeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string conn = ConfigurationManager.ConnectionStrings["AdventureWorks2016"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(conn))
            {
                string sql = $@"select Production.ProductModel.ProductModelID, Production.ProductModel.Name, Production.ProductDescription.Description FROM Production.Product INNER JOIN Production.ProductSubcategory ON Production.Product.ProductSubcategoryID = Production.ProductSubcategory.ProductSubcategoryID INNER JOIN Production.ProductCategory ON Production.ProductSubcategory.ProductCategoryID = Production.ProductCategory.ProductCategoryID INNER JOIN Production.ProductModel ON Production.Product.ProductModelID = Production.ProductModel.ProductModelID INNER JOIN Production.ProductModelProductDescriptionCulture ON Production.ProductModel.ProductModelID = Production.ProductModelProductDescriptionCulture.ProductModelID INNER JOIN Production.ProductDescription ON Production.ProductModelProductDescriptionCulture.ProductDescriptionID = Production.ProductDescription.ProductDescriptionID WHERE ProductModelProductDescriptionCulture.CultureID = '{lenguageComboBox.Text}' AND Product.ProductModelID IS NOT NULL AND Production.Product.Size = '{sizeComboBox.Text}';";
                listView1.Items.Clear();
                List<Model> listSize = new List<Model>();
                listSize = connection.Query<Model>(sql).ToList();
                foreach (Model model in listSize)
                {
                    listView1.Items.Add(model.ToString());
                }
            }
        }
        private void productLineComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string conn = ConfigurationManager.ConnectionStrings["AdventureWorks2016"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(conn))
            {
                string sql = $@"select Production.ProductModel.ProductModelID, Production.ProductModel.Name, Production.ProductDescription.Description FROM Production.Product INNER JOIN Production.ProductSubcategory ON Production.Product.ProductSubcategoryID = Production.ProductSubcategory.ProductSubcategoryID INNER JOIN Production.ProductCategory ON Production.ProductSubcategory.ProductCategoryID = Production.ProductCategory.ProductCategoryID INNER JOIN Production.ProductModel ON Production.Product.ProductModelID = Production.ProductModel.ProductModelID INNER JOIN Production.ProductModelProductDescriptionCulture ON Production.ProductModel.ProductModelID = Production.ProductModelProductDescriptionCulture.ProductModelID INNER JOIN Production.ProductDescription ON Production.ProductModelProductDescriptionCulture.ProductDescriptionID = Production.ProductDescription.ProductDescriptionID WHERE ProductModelProductDescriptionCulture.CultureID = '{lenguageComboBox.Text}' AND Product.ProductModelID IS NOT NULL AND Production.Product.ProductLine = '{productLineComboBox.Text}';";
                listView1.Items.Clear();
                List<Model> listProductLine = new List<Model>();
                listProductLine = connection.Query<Model>(sql).ToList();
                foreach (Model model in listProductLine)
                {
                    listView1.Items.Add(model.ToString());
                }
            }
        }
        private void classComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string conn = ConfigurationManager.ConnectionStrings["AdventureWorks2016"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(conn))
            {
                string sql = $@"select Production.ProductModel.ProductModelID, Production.ProductModel.Name, Production.ProductDescription.Description FROM Production.Product INNER JOIN Production.ProductSubcategory ON Production.Product.ProductSubcategoryID = Production.ProductSubcategory.ProductSubcategoryID INNER JOIN Production.ProductCategory ON Production.ProductSubcategory.ProductCategoryID = Production.ProductCategory.ProductCategoryID INNER JOIN Production.ProductModel ON Production.Product.ProductModelID = Production.ProductModel.ProductModelID INNER JOIN Production.ProductModelProductDescriptionCulture ON Production.ProductModel.ProductModelID = Production.ProductModelProductDescriptionCulture.ProductModelID INNER JOIN Production.ProductDescription ON Production.ProductModelProductDescriptionCulture.ProductDescriptionID = Production.ProductDescription.ProductDescriptionID WHERE ProductModelProductDescriptionCulture.CultureID = '{lenguageComboBox.Text}' AND Product.ProductModelID IS NOT NULL AND Production.Product.Class = '{classComboBox.Text}';";
                listView1.Items.Clear();
                List<Model> listClass = new List<Model>();
                listClass = connection.Query<Model>(sql).ToList();
                foreach (Model model in listClass)
                {
                    listView1.Items.Add(model.ToString());
                }
            }
        }
        private void styleComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string conn = ConfigurationManager.ConnectionStrings["AdventureWorks2016"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(conn))
            {
                string sql = $@"select Production.ProductModel.ProductModelID, Production.ProductModel.Name, Production.ProductDescription.Description FROM Production.Product INNER JOIN Production.ProductSubcategory ON Production.Product.ProductSubcategoryID = Production.ProductSubcategory.ProductSubcategoryID INNER JOIN Production.ProductCategory ON Production.ProductSubcategory.ProductCategoryID = Production.ProductCategory.ProductCategoryID INNER JOIN Production.ProductModel ON Production.Product.ProductModelID = Production.ProductModel.ProductModelID INNER JOIN Production.ProductModelProductDescriptionCulture ON Production.ProductModel.ProductModelID = Production.ProductModelProductDescriptionCulture.ProductModelID INNER JOIN Production.ProductDescription ON Production.ProductModelProductDescriptionCulture.ProductDescriptionID = Production.ProductDescription.ProductDescriptionID WHERE ProductModelProductDescriptionCulture.CultureID = '{lenguageComboBox.Text}' AND Product.ProductModelID IS NOT NULL AND Production.Product.Style = '{styleComboBox.Text}';";
                listView1.Items.Clear();
                List<Model> listStyle = new List<Model>();
                listStyle = connection.Query<Model>(sql).ToList();
                foreach (Model model in listStyle)
                {
                    listView1.Items.Add(model.ToString());
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
                List<Model> listCategory = new List<Model>();
                listCategory = connection.Query<Model>(sql).ToList();
                foreach (Model model in listCategory)
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
                List<Model> listSubCategory = new List<Model>();
                listSubCategory = connection.Query<Model>(sql).ToList();
                foreach (Model model in listSubCategory)
                {
                    listView1.Items.Add(model.ToString());
                }
            }
        }

        private void searchTextBox_TextChanged(object sender, EventArgs e)
        {
            string conn = ConfigurationManager.ConnectionStrings["AdventureWorks2016"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(conn))
            {
                string sql = $@"select Production.ProductModel.ProductModelID, Production.ProductModel.Name, Production.ProductDescription.Description FROM Production.Product INNER JOIN Production.ProductSubcategory ON Production.Product.ProductSubcategoryID = Production.ProductSubcategory.ProductSubcategoryID INNER JOIN Production.ProductCategory ON Production.ProductSubcategory.ProductCategoryID = Production.ProductCategory.ProductCategoryID INNER JOIN Production.ProductModel ON Production.Product.ProductModelID = Production.ProductModel.ProductModelID INNER JOIN Production.ProductModelProductDescriptionCulture ON Production.ProductModel.ProductModelID = Production.ProductModelProductDescriptionCulture.ProductModelID INNER JOIN Production.ProductDescription ON Production.ProductModelProductDescriptionCulture.ProductDescriptionID = Production.ProductDescription.ProductDescriptionID WHERE ProductModelProductDescriptionCulture.CultureID = '{lenguageComboBox.Text}' AND Product.ProductModelID IS NOT NULL AND Production.Product.Name LIKE '%{searchTextBox.Text}%' OR Production.ProductModel.Name LIKE '%{searchTextBox.Text}%' ";
                listView1.Items.Clear();
                List<Model> listSubCategory = new List<Model>();
                listSubCategory = connection.Query<Model>(sql).ToList();
                foreach (Model model in listSubCategory)
                {
                    listView1.Items.Add(model.ToString());
                }
            }
        }
    }
}
