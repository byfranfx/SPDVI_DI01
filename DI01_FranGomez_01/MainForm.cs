﻿using System;
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
        public static string AvailableCheckBox = "";
        public static string QueryBase = "select Production.ProductModel.ProductModelID, Production.ProductModel.Name, Production.ProductDescription.Description FROM Production.Product INNER JOIN Production.ProductSubcategory ON Production.Product.ProductSubcategoryID = Production.ProductSubcategory.ProductSubcategoryID INNER JOIN Production.ProductCategory ON Production.ProductSubcategory.ProductCategoryID = Production.ProductCategory.ProductCategoryID INNER JOIN Production.ProductModel ON Production.Product.ProductModelID = Production.ProductModel.ProductModelID INNER JOIN Production.ProductModelProductDescriptionCulture ON Production.ProductModel.ProductModelID = Production.ProductModelProductDescriptionCulture.ProductModelID INNER JOIN Production.ProductDescription ON Production.ProductModelProductDescriptionCulture.ProductDescriptionID = Production.ProductDescription.ProductDescriptionID WHERE ";

        public static string QuerySearch = $"";
        public static string QueryColor = $"";
        public static string QuerySize = "";
        public static string QueryProductLine = "";
        public static string QueryCLass = "";
        public static string QueryStyle = "";
        public static string QueryCategory = "";
        public static string QuerySubCategory = "";

        public MainForm()
        {
            InitializeComponent();

            // null
            colorComboBox.Items.Add("");
            sizeComboBox.Items.Add("");
            productLineComboBox.Items.Add("");
            classComboBox.Items.Add("");
            styleComboBox.Items.Add("");
            categoryComboBox.Items.Add("");
            subCategoryComboBox.Items.Add("");

            // lenguatge
            lenguageComboBox.Text = "en";
            lenguageComboBox.Items.Add("en");
            lenguageComboBox.Items.Add("fr");

            // ComboBox Pagination
            paginationComboBox.Items.Add("10");
            paginationComboBox.Items.Add("20");
            paginationComboBox.Items.Add("50");

            // Price
            price0TextBox.Text = "0";
            price1TextBox.Text = "4000";

            // complete listview
            completeResultQuery();
        }

        public void completeResultQuery()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["AdventureWorks2016"].ConnectionString;
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    string sql = $@"select Production.ProductModel.ProductModelID, Production.ProductModel.Name, Production.ProductDescription.Description FROM Production.Product INNER JOIN Production.ProductSubcategory ON Production.Product.ProductSubcategoryID = Production.ProductSubcategory.ProductSubcategoryID INNER JOIN Production.ProductCategory ON Production.ProductSubcategory.ProductCategoryID = Production.ProductCategory.ProductCategoryID INNER JOIN Production.ProductModel ON Production.Product.ProductModelID = Production.ProductModel.ProductModelID INNER JOIN Production.ProductModelProductDescriptionCulture ON Production.ProductModel.ProductModelID = Production.ProductModelProductDescriptionCulture.ProductModelID INNER JOIN Production.ProductDescription ON Production.ProductModelProductDescriptionCulture.ProductDescriptionID = Production.ProductDescription.ProductDescriptionID WHERE ProductModelProductDescriptionCulture.CultureID = '{lenguageComboBox.Text}' AND Product.ProductModelID IS NOT NULL {AvailableCheckBox};";
                    List<Model> models = new List<Model>();
                    models = connection.Query<Model>(sql).ToList();
                    foreach (Model model in models)
                    {
                        listView1.Items.Add(model.ToString());
                    }
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Error from  Sql: " + ex);
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
            try { 
                string conn = ConfigurationManager.ConnectionStrings["AdventureWorks2016"].ConnectionString;
                using (SqlConnection connection = new SqlConnection(conn))
                {
                    // comboBox Categories
                    string sqlquery1 = $"SELECT [Name] FROM [AdventureWorks2016].[Production].[ProductCategory];";
                    List<string> categories = new List<string>();
                    categories = connection.Query<string>(sqlquery1).ToList();
                    foreach (string category in categories)
                    {
                        categoryComboBox.Items.Add(category);
                    }

                    // comboBox Color
                    string sqlquery3 = $"SELECT DISTINCT [Color] FROM [AdventureWorks2016].[Production].[Product] WHERE [Color] IS NOT NULL;";
                    List<string> Color = new List<string>();
                    Color = connection.Query<string>(sqlquery3).ToList();
                    foreach (string color in Color)
                    {
                        colorComboBox.Items.Add(color);
                    }

                    // comboBox Size
                    string sqlquery4 = $"SELECT DISTINCT Size FROM [AdventureWorks2016].[Production].[Product] WHERE [Size] IS NOT NULL;";
                    List<string> Size = new List<string>();
                    Size = connection.Query<string>(sqlquery4).ToList();
                    foreach (string size in Size)
                    {
                        sizeComboBox.Items.Add(size);
                    }

                    // comboBox Product Line
                    string sqlquery5 = $"SELECT DISTINCT [ProductLine] FROM [AdventureWorks2016].[Production].[Product] WHERE ProductLine IS NOT NULL;";
                    List<string> ProductLine = new List<string>();
                    ProductLine = connection.Query<string>(sqlquery5).ToList();
                    foreach (string productLine in ProductLine)
                    {
                        productLineComboBox.Items.Add(productLine);
                    }

                    // comboBox class
                    string sqlquery6 = $"SELECT DISTINCT [Class] FROM [AdventureWorks2016].[Production].[Product] WHERE Class IS NOT NULL;";
                    List<string> Class = new List<string>();
                    Class = connection.Query<string>(sqlquery6).ToList();
                    foreach (string clas in Class)
                    {
                        classComboBox.Items.Add(clas);
                    }

                    // comboBox style
                    string sqlquery7 = $"SELECT DISTINCT [Style] FROM [AdventureWorks2016].[Production].[Product] WHERE Style IS NOT NULL;";
                    List<string> Style = new List<string>();
                    Style = connection.Query<string>(sqlquery7).ToList();
                    foreach (string style in Style)
                    {
                        styleComboBox.Items.Add(style);
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error from  Sql: " + ex);
            }
        }
        private void searchTextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string conn = ConfigurationManager.ConnectionStrings["AdventureWorks2016"].ConnectionString;
                using (SqlConnection connection = new SqlConnection(conn))
                {
                    string sql = $@"select Production.ProductModel.ProductModelID, Production.ProductModel.Name, Production.ProductDescription.Description FROM Production.Product INNER JOIN Production.ProductSubcategory ON Production.Product.ProductSubcategoryID = Production.ProductSubcategory.ProductSubcategoryID INNER JOIN Production.ProductCategory ON Production.ProductSubcategory.ProductCategoryID = Production.ProductCategory.ProductCategoryID INNER JOIN Production.ProductModel ON Production.Product.ProductModelID = Production.ProductModel.ProductModelID INNER JOIN Production.ProductModelProductDescriptionCulture ON Production.ProductModel.ProductModelID = Production.ProductModelProductDescriptionCulture.ProductModelID INNER JOIN Production.ProductDescription ON Production.ProductModelProductDescriptionCulture.ProductDescriptionID = Production.ProductDescription.ProductDescriptionID WHERE ProductModelProductDescriptionCulture.CultureID = '{lenguageComboBox.Text}' AND Product.ProductModelID IS NOT NULL AND Production.Product.Name LIKE '%{searchTextBox.Text}%' OR Production.ProductModel.Name LIKE '%{searchTextBox.Text}%'{AvailableCheckBox};";
                    listView1.Items.Clear();
                    List<Model> listSubCategory = new List<Model>();
                    listSubCategory = connection.Query<Model>(sql).ToList();
                    foreach (Model model in listSubCategory)
                    {
                        listView1.Items.Add(model.ToString());
                    }
                }
            }
            catch (SqlException ex)
            {
                if (System.Text.RegularExpressions.Regex.IsMatch(searchTextBox.Text, "[a-zA - Z]"))
                {
                    MessageBox.Show("Please enter letters.");
                    searchTextBox.Text = searchTextBox.Text.Remove(searchTextBox.Text.Length - 1);
                }
                else
                {
                    MessageBox.Show("Error from  Sql: " + ex);
                }
            }
        }
        private void ColorComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (colorComboBox.Text != "")
            {
                QueryColor = $" AND [Color] = '{colorComboBox.Text}'";
                
            }
            else
            {
                QueryColor = "";
            }
            if (sizeComboBox.Text != "")
            {
                QuerySize = $" AND Production.Product.Size = '{sizeComboBox.Text}' ";
            }
            else
            {
                QuerySize = "";

            }
            if (productLineComboBox.Text != "")
            {
                QueryProductLine = $" AND Production.Product.ProductLine = '{productLineComboBox.Text}' ";
            }
            else
            {
                QueryProductLine = "";
            }
            if (classComboBox.Text != "")
            {
                QueryCLass = $" AND Production.Product.Class = '{classComboBox.Text}' ";
            }
            else
            {
                QueryCLass = "";
            }
            if (styleComboBox.Text != "")
            {
                QueryStyle = $" AND Production.Product.Style = '{styleComboBox.Text}' ";
            }
            else
            {
                QueryStyle = "";
            }
            if (categoryComboBox.Text != "")
            {
                QueryCategory = $" AND Production.ProductCategory.Name = '{categoryComboBox.Text}' ";
            }
            else
            {
                QueryCategory = "";
            }
            if (subCategoryComboBox.Text != "") 
            {
                QuerySubCategory = $" AND Production.ProductSubcategory.Name = '{subCategoryComboBox.Text}' ";
            }
            else
            {
                QuerySubCategory = "";
            }

            try { 
            string conn = ConfigurationManager.ConnectionStrings["AdventureWorks2016"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(conn))
            {
                string sql = QueryBase + $@"ProductModelProductDescriptionCulture.CultureID = '{lenguageComboBox.Text}'{QueryColor}{QuerySize}{QueryProductLine}{QueryCLass}{QueryStyle}{QueryCategory}{QuerySubCategory}AND (Production.Product.ListPrice > '{price0TextBox.Text}') AND (Production.Product.ListPrice < '{price1TextBox.Text}'){AvailableCheckBox};";
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
            catch (SqlException ex)
            {
                MessageBox.Show("Error from  Sql: " + ex);
            }
        }
        private void price0TextBox_TextChanged_1(object sender, EventArgs e)
        {
            
            if (colorComboBox.Text != "")
            {
                QueryColor = $" AND [Color] = '{colorComboBox.Text}'";

            }
            else
            {
                QueryColor = "";
            }
            if (sizeComboBox.Text != "")
            {
                QuerySize = $" AND Production.Product.Size = '{sizeComboBox.Text}' ";
            }
            else
            {
                QuerySize = "";

            }
            if (productLineComboBox.Text != "")
            {
                QueryProductLine = $" AND Production.Product.ProductLine = '{productLineComboBox.Text}' ";
            }
            else
            {
                QueryProductLine = "";
            }
            if (classComboBox.Text != "")
            {
                QueryCLass = $" AND Production.Product.Class = '{classComboBox.Text}' ";
            }
            else
            {
                QueryCLass = "";
            }
            if (styleComboBox.Text != "")
            {
                QueryStyle = $" AND Production.Product.Style = '{styleComboBox.Text}' ";
            }
            else
            {
                QueryStyle = "";
            }
            if (categoryComboBox.Text != "")
            {
                QueryCategory = $" AND Production.ProductCategory.Name = '{categoryComboBox.Text}' ";
            }
            else
            {
                QueryCategory = "";
            }
            if (subCategoryComboBox.Text != "")
            {
                QuerySubCategory = $" AND Production.ProductSubcategory.Name = '{subCategoryComboBox.Text}' ";
            }
            else
            {
                QuerySubCategory = "";
            }

            try { 
            string conn = ConfigurationManager.ConnectionStrings["AdventureWorks2016"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(conn))
            {
                string sql = QueryBase + $@"ProductModelProductDescriptionCulture.CultureID = '{lenguageComboBox.Text}'{QueryColor}{QuerySize}{QueryProductLine}{QueryCLass}{QueryStyle}{QueryCategory}{QuerySubCategory}AND (Production.Product.ListPrice > '{price0TextBox.Text}') AND (Production.Product.ListPrice < '{price1TextBox.Text}'){AvailableCheckBox};";
                listView1.Items.Clear();
                List<Model> listSize = new List<Model>();
                listSize = connection.Query<Model>(sql).ToList();
                foreach (Model model in listSize)
                {
                    listView1.Items.Add(model.ToString());
                }
            }
            }
            catch (SqlException ex)
            {
                if (System.Text.RegularExpressions.Regex.IsMatch(price0TextBox.Text, "[^0-9]"))
                {
                    MessageBox.Show("Please enter only numbers.");
                    price0TextBox.Text = price0TextBox.Text.Remove(price0TextBox.Text.Length - 1);
                } else
                {
                    MessageBox.Show("Error from  Sql: " + ex);
                }   
            }
        }
        private void price1TextBox_TextChanged(object sender, EventArgs e)
        {

            if (colorComboBox.Text != "")
            {
                QueryColor = $" AND [Color] = '{colorComboBox.Text}'";

            }
            else
            {
                QueryColor = "";
            }
            if (sizeComboBox.Text != "")
            {
                QuerySize = $" AND Production.Product.Size = '{sizeComboBox.Text}' ";
            }
            else
            {
                QuerySize = "";

            }
            if (productLineComboBox.Text != "")
            {
                QueryProductLine = $" AND Production.Product.ProductLine = '{productLineComboBox.Text}' ";
            }
            else
            {
                QueryProductLine = "";
            }
            if (classComboBox.Text != "")
            {
                QueryCLass = $" AND Production.Product.Class = '{classComboBox.Text}' ";
            }
            else
            {
                QueryCLass = "";
            }
            if (styleComboBox.Text != "")
            {
                QueryStyle = $" AND Production.Product.Style = '{styleComboBox.Text}' ";
            }
            else
            {
                QueryStyle = "";
            }
            if (categoryComboBox.Text != "")
            {
                QueryCategory = $" AND Production.ProductCategory.Name = '{categoryComboBox.Text}' ";
            }
            else
            {
                QueryCategory = "";
            }
            if (subCategoryComboBox.Text != "")
            {
                QuerySubCategory = $" AND Production.ProductSubcategory.Name = '{subCategoryComboBox.Text}' ";
            }
            else
            {
                QuerySubCategory = "";
            }

            try { 
            string conn = ConfigurationManager.ConnectionStrings["AdventureWorks2016"].ConnectionString;
                using (SqlConnection connection = new SqlConnection(conn))
                {
                    string sql = QueryBase + $@"ProductModelProductDescriptionCulture.CultureID = '{lenguageComboBox.Text}'{QueryColor}{QuerySize}{QueryProductLine}{QueryCLass}{QueryStyle}{QueryCategory}{QuerySubCategory}AND (Production.Product.ListPrice > '{price0TextBox.Text}') AND (Production.Product.ListPrice < '{price1TextBox.Text}'){AvailableCheckBox};";
                    listView1.Items.Clear();
                    List<Model> listSize = new List<Model>();
                    listSize = connection.Query<Model>(sql).ToList();
                    foreach (Model model in listSize)
                    {
                        listView1.Items.Add(model.ToString());
                    }
                }
            }
            catch (SqlException ex)
            {
                if (System.Text.RegularExpressions.Regex.IsMatch(price1TextBox.Text, "[^0-9]"))
                {
                    MessageBox.Show("Please enter only numbers.");
                    price1TextBox.Text = price1TextBox.Text.Remove(price1TextBox.Text.Length - 1);
                }
                else
                {
                    MessageBox.Show("Error from  Sql: " + ex);
                }
            }
        }
        private void sizeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (colorComboBox.Text != "")
            {
                QueryColor = $" AND [Color] = '{colorComboBox.Text}'";

            }
            else
            {
                QueryColor = "";
            }
            if (sizeComboBox.Text != "")
            {
                QuerySize = $" AND Production.Product.Size = '{sizeComboBox.Text}' ";
            }
            else
            {
                QuerySize = "";

            }
            if (productLineComboBox.Text != "")
            {
                QueryProductLine = $" AND Production.Product.ProductLine = '{productLineComboBox.Text}' ";
            }
            else
            {
                QueryProductLine = "";
            }
            if (classComboBox.Text != "")
            {
                QueryCLass = $" AND Production.Product.Class = '{classComboBox.Text}' ";
            }
            else
            {
                QueryCLass = "";
            }
            if (styleComboBox.Text != "")
            {
                QueryStyle = $" AND Production.Product.Style = '{styleComboBox.Text}' ";
            }
            else
            {
                QueryStyle = "";
            }
            if (categoryComboBox.Text != "")
            {
                QueryCategory = $" AND Production.ProductCategory.Name = '{categoryComboBox.Text}' ";
            }
            else
            {
                QueryCategory = "";
            }
            if (subCategoryComboBox.Text != "")
            {
                QuerySubCategory = $" AND Production.ProductSubcategory.Name = '{subCategoryComboBox.Text}' ";
            }
            else
            {
                QuerySubCategory = "";
            }

            try {
                string conn = ConfigurationManager.ConnectionStrings["AdventureWorks2016"].ConnectionString;
                using (SqlConnection connection = new SqlConnection(conn))
                {
                    string sql = QueryBase + $@"ProductModelProductDescriptionCulture.CultureID = '{lenguageComboBox.Text}'{QueryColor}{QuerySize}{QueryProductLine}{QueryCLass}{QueryStyle}{QueryCategory}{QuerySubCategory}AND (Production.Product.ListPrice > '{price0TextBox.Text}') AND (Production.Product.ListPrice < '{price1TextBox.Text}'){AvailableCheckBox};";
                    listView1.Items.Clear();
                    List<Model> listSize = new List<Model>();
                    listSize = connection.Query<Model>(sql).ToList();
                    foreach (Model model in listSize)
                    {
                        listView1.Items.Add(model.ToString());
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error from  Sql: " + ex);
            }
        }
        private void productLineComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (colorComboBox.Text != "")
            {
                QueryColor = $" AND [Color] = '{colorComboBox.Text}'";

            }
            else
            {
                QueryColor = "";
            }
            if (sizeComboBox.Text != "")
            {
                QuerySize = $" AND Production.Product.Size = '{sizeComboBox.Text}' ";
            }
            else
            {
                QuerySize = "";

            }
            if (productLineComboBox.Text != "")
            {
                QueryProductLine = $" AND Production.Product.ProductLine = '{productLineComboBox.Text}' ";
            }
            else
            {
                QueryProductLine = "";
            }
            if (classComboBox.Text != "")
            {
                QueryCLass = $" AND Production.Product.Class = '{classComboBox.Text}' ";
            }
            else
            {
                QueryCLass = "";
            }
            if (styleComboBox.Text != "")
            {
                QueryStyle = $" AND Production.Product.Style = '{styleComboBox.Text}' ";
            }
            else
            {
                QueryStyle = "";
            }
            if (categoryComboBox.Text != "")
            {
                QueryCategory = $" AND Production.ProductCategory.Name = '{categoryComboBox.Text}' ";
            }
            else
            {
                QueryCategory = "";
            }
            if (subCategoryComboBox.Text != "")
            {
                QuerySubCategory = $" AND Production.ProductSubcategory.Name = '{subCategoryComboBox.Text}' ";
            }
            else
            {
                QuerySubCategory = "";
            }

            try { 
                string conn = ConfigurationManager.ConnectionStrings["AdventureWorks2016"].ConnectionString;
                using (SqlConnection connection = new SqlConnection(conn))
                {
                    string sql = QueryBase + $@"ProductModelProductDescriptionCulture.CultureID = '{lenguageComboBox.Text}'{QueryColor}{QuerySize}{QueryProductLine}{QueryCLass}{QueryStyle}{QueryCategory}{QuerySubCategory}AND (Production.Product.ListPrice > '{price0TextBox.Text}') AND (Production.Product.ListPrice < '{price1TextBox.Text}'){AvailableCheckBox};";
                    listView1.Items.Clear();
                    List<Model> listProductLine = new List<Model>();
                    listProductLine = connection.Query<Model>(sql).ToList();
                    foreach (Model model in listProductLine)
                    {
                        listView1.Items.Add(model.ToString());
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error from  Sql: " + ex);
            }
        }
        private void classComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (colorComboBox.Text != "")
            {
                QueryColor = $" AND [Color] = '{colorComboBox.Text}'";

            }
            else
            {
                QueryColor = "";
            }
            if (sizeComboBox.Text != "")
            {
                QuerySize = $" AND Production.Product.Size = '{sizeComboBox.Text}' ";
            }
            else
            {
                QuerySize = "";

            }
            if (productLineComboBox.Text != "")
            {
                QueryProductLine = $" AND Production.Product.ProductLine = '{productLineComboBox.Text}' ";
            }
            else
            {
                QueryProductLine = "";
            }
            if (classComboBox.Text != "")
            {
                QueryCLass = $" AND Production.Product.Class = '{classComboBox.Text}' ";
            }
            else
            {
                QueryCLass = "";
            }
            if (styleComboBox.Text != "")
            {
                QueryStyle = $" AND Production.Product.Style = '{styleComboBox.Text}' ";
            }
            else
            {
                QueryStyle = "";
            }
            if (categoryComboBox.Text != "")
            {
                QueryCategory = $" AND Production.ProductCategory.Name = '{categoryComboBox.Text}' ";
            }
            else
            {
                QueryCategory = "";
            }
            if (subCategoryComboBox.Text != "")
            {
                QuerySubCategory = $" AND Production.ProductSubcategory.Name = '{subCategoryComboBox.Text}' ";
            }
            else
            {
                QuerySubCategory = "";
            }

            try { 
            string conn = ConfigurationManager.ConnectionStrings["AdventureWorks2016"].ConnectionString;
                using (SqlConnection connection = new SqlConnection(conn))
                {
                    string sql = QueryBase + $@"ProductModelProductDescriptionCulture.CultureID = '{lenguageComboBox.Text}'{QueryColor}{QuerySize}{QueryProductLine}{QueryCLass}{QueryStyle}{QueryCategory}{QuerySubCategory}AND (Production.Product.ListPrice > '{price0TextBox.Text}') AND (Production.Product.ListPrice < '{price1TextBox.Text}'){AvailableCheckBox};";
                    listView1.Items.Clear();
                    List<Model> listClass = new List<Model>();
                    listClass = connection.Query<Model>(sql).ToList();
                    foreach (Model model in listClass)
                    {
                        listView1.Items.Add(model.ToString());
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error from  Sql: " + ex);
            }
        }
        private void styleComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (colorComboBox.Text != "")
            {
                QueryColor = $" AND [Color] = '{colorComboBox.Text}'";

            }
            else
            {
                QueryColor = "";
            }
            if (sizeComboBox.Text != "")
            {
                QuerySize = $" AND Production.Product.Size = '{sizeComboBox.Text}' ";
            }
            else
            {
                QuerySize = "";

            }
            if (productLineComboBox.Text != "")
            {
                QueryProductLine = $" AND Production.Product.ProductLine = '{productLineComboBox.Text}' ";
            }
            else
            {
                QueryProductLine = "";
            }
            if (classComboBox.Text != "")
            {
                QueryCLass = $" AND Production.Product.Class = '{classComboBox.Text}' ";
            }
            else
            {
                QueryCLass = "";
            }
            if (styleComboBox.Text != "")
            {
                QueryStyle = $" AND Production.Product.Style = '{styleComboBox.Text}' ";
            }
            else
            {
                QueryStyle = "";
            }
            if (categoryComboBox.Text != "")
            {
                QueryCategory = $" AND Production.ProductCategory.Name = '{categoryComboBox.Text}' ";
            }
            else
            {
                QueryCategory = "";
            }
            if (subCategoryComboBox.Text != "")
            {
                QuerySubCategory = $" AND Production.ProductSubcategory.Name = '{subCategoryComboBox.Text}' ";
            }
            else
            {
                QuerySubCategory = "";
            }

            try { 
                string conn = ConfigurationManager.ConnectionStrings["AdventureWorks2016"].ConnectionString;
                using (SqlConnection connection = new SqlConnection(conn))
                {
                    string sql = QueryBase + $@"ProductModelProductDescriptionCulture.CultureID = '{lenguageComboBox.Text}'{QueryColor}{QuerySize}{QueryProductLine}{QueryCLass}{QueryStyle}{QueryCategory}{QuerySubCategory}AND (Production.Product.ListPrice > '{price0TextBox.Text}') AND (Production.Product.ListPrice < '{price1TextBox.Text}'){AvailableCheckBox};";
                    listView1.Items.Clear();
                    List<Model> listStyle = new List<Model>();
                    listStyle = connection.Query<Model>(sql).ToList();
                    foreach (Model model in listStyle)
                    {
                        listView1.Items.Add(model.ToString());
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error from  Sql: " + ex);
            }
        }
        private void categoryComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (colorComboBox.Text != "")
            {
                QueryColor = $" AND [Color] = '{colorComboBox.Text}'";

            }
            else
            {
                QueryColor = "";
            }
            if (sizeComboBox.Text != "")
            {
                QuerySize = $" AND Production.Product.Size = '{sizeComboBox.Text}' ";
            }
            else
            {
                QuerySize = "";

            }
            if (productLineComboBox.Text != "")
            {
                QueryProductLine = $" AND Production.Product.ProductLine = '{productLineComboBox.Text}' ";
            }
            else
            {
                QueryProductLine = "";
            }
            if (classComboBox.Text != "")
            {
                QueryCLass = $" AND Production.Product.Class = '{classComboBox.Text}' ";
            }
            else
            {
                QueryCLass = "";
            }
            if (styleComboBox.Text != "")
            {
                QueryStyle = $" AND Production.Product.Style = '{styleComboBox.Text}' ";
            }
            else
            {
                QueryStyle = "";
            }
            if (categoryComboBox.Text != "")
            {
                QueryCategory = $" AND Production.ProductCategory.Name = '{categoryComboBox.Text}' ";
            }
            else
            {
                QueryCategory = "";
            }
            if (subCategoryComboBox.Text != "")
            {
                QuerySubCategory = $" AND Production.ProductSubcategory.Name = '{subCategoryComboBox.Text}' ";
            }
            else
            {
                QuerySubCategory = "";
            }

            try { 
                string conn = ConfigurationManager.ConnectionStrings["AdventureWorks2016"].ConnectionString;
                using (SqlConnection connection = new SqlConnection(conn))
                {

                    // comboBox SubCategories
                    subCategoryComboBox.Items.Clear();
                    string sqlquery2 = $"SELECT DISTINCT Production.ProductSubcategory.Name FROM Production.Product INNER JOIN Production.ProductSubcategory ON Production.Product.ProductSubcategoryID = Production.ProductSubcategory.ProductSubcategoryID INNER JOIN Production.ProductCategory ON Production.ProductSubcategory.ProductCategoryID = Production.ProductCategory.ProductCategoryID INNER JOIN Production.ProductModel ON Production.Product.ProductModelID = Production.ProductModel.ProductModelID INNER JOIN Production.ProductModelProductDescriptionCulture ON Production.ProductModel.ProductModelID = Production.ProductModelProductDescriptionCulture.ProductModelID INNER JOIN Production.ProductDescription ON Production.ProductModelProductDescriptionCulture.ProductDescriptionID = Production.ProductDescription.ProductDescriptionID WHERE Production.ProductCategory.Name = '{categoryComboBox.Text}';";
                    List<string> subCategories = new List<string>();
                    subCategories = connection.Query<string>(sqlquery2).ToList();
                    foreach (string subcategory in subCategories)
                    {
                        subCategoryComboBox.Items.Add(subcategory);
                    }

                    //
                    string sql = QueryBase + $@"ProductModelProductDescriptionCulture.CultureID = '{lenguageComboBox.Text}'{QueryColor}{QuerySize}{QueryProductLine}{QueryCLass}{QueryStyle}{QueryCategory}{QuerySubCategory}AND (Production.Product.ListPrice > '{price0TextBox.Text}') AND (Production.Product.ListPrice < '{price1TextBox.Text}'){AvailableCheckBox};";
                    listView1.Items.Clear();
                    List<Model> listCategory = new List<Model>();
                    listCategory = connection.Query<Model>(sql).ToList();
                    foreach (Model model in listCategory)
                    {
                        listView1.Items.Add(model.ToString());
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error from  Sql: " + ex);
            }
        }
        private void subCategoryComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (colorComboBox.Text != "")
            {
                QueryColor = $" AND [Color] = '{colorComboBox.Text}'";

            }
            else
            {
                QueryColor = "";
            }
            if (sizeComboBox.Text != "")
            {
                QuerySize = $" AND Production.Product.Size = '{sizeComboBox.Text}' ";
            }
            else
            {
                QuerySize = "";

            }
            if (productLineComboBox.Text != "")
            {
                QueryProductLine = $" AND Production.Product.ProductLine = '{productLineComboBox.Text}' ";
            }
            else
            {
                QueryProductLine = "";
            }
            if (classComboBox.Text != "")
            {
                QueryCLass = $" AND Production.Product.Class = '{classComboBox.Text}' ";
            }
            else
            {
                QueryCLass = "";
            }
            if (styleComboBox.Text != "")
            {
                QueryStyle = $" AND Production.Product.Style = '{styleComboBox.Text}' ";
            }
            else
            {
                QueryStyle = "";
            }
            if (categoryComboBox.Text != "")
            {
                QueryCategory = $" AND Production.ProductCategory.Name = '{categoryComboBox.Text}' ";
            }
            else
            {
                QueryCategory = "";
            }
            if (subCategoryComboBox.Text != "")
            {
                QuerySubCategory = $" AND Production.ProductSubcategory.Name = '{subCategoryComboBox.Text}' ";
            }
            else
            {
                QuerySubCategory = "";
            }

            try { 
                string conn = ConfigurationManager.ConnectionStrings["AdventureWorks2016"].ConnectionString;
                using (SqlConnection connection = new SqlConnection(conn))
                {
                    string sql = QueryBase + $@"ProductModelProductDescriptionCulture.CultureID = '{lenguageComboBox.Text}'{QueryColor}{QuerySize}{QueryProductLine}{QueryCLass}{QueryStyle}{QueryCategory}{QuerySubCategory}AND (Production.Product.ListPrice > '{price0TextBox.Text}') AND (Production.Product.ListPrice < '{price1TextBox.Text}'){AvailableCheckBox};";
                    listView1.Items.Clear();
                    List<Model> listSubCategory = new List<Model>();
                    listSubCategory = connection.Query<Model>(sql).ToList();
                    foreach (Model model in listSubCategory)
                    {
                        listView1.Items.Add(model.ToString());
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error from  Sql: " + ex);
            }
        }
        private void availableBox_CheckedChanged(object sender, EventArgs e)
        {

            if (colorComboBox.Text != "")
            {
                QueryColor = $" AND [Color] = '{colorComboBox.Text}'";

            }
            else
            {
                QueryColor = "";
            }
            if (sizeComboBox.Text != "")
            {
                QuerySize = $" AND Production.Product.Size = '{sizeComboBox.Text}' ";
            }
            else
            {
                QuerySize = "";

            }
            if (productLineComboBox.Text != "")
            {
                QueryProductLine = $" AND Production.Product.ProductLine = '{productLineComboBox.Text}' ";
            }
            else
            {
                QueryProductLine = "";
            }
            if (classComboBox.Text != "")
            {
                QueryCLass = $" AND Production.Product.Class = '{classComboBox.Text}' ";
            }
            else
            {
                QueryCLass = "";
            }
            if (styleComboBox.Text != "")
            {
                QueryStyle = $" AND Production.Product.Style = '{styleComboBox.Text}' ";
            }
            else
            {
                QueryStyle = "";
            }
            if (categoryComboBox.Text != "")
            {
                QueryCategory = $" AND Production.ProductCategory.Name = '{categoryComboBox.Text}' ";
            }
            else
            {
                QueryCategory = "";
            }
            if (subCategoryComboBox.Text != "")
            {
                QuerySubCategory = $" AND Production.ProductSubcategory.Name = '{subCategoryComboBox.Text}' ";
            }
            else
            {
                QuerySubCategory = "";
            }

            if (availableBox.Checked == true)
            {
                AvailableCheckBox = "";
            }
            else if (availableBox.Checked == false)
            {
                AvailableCheckBox = " AND Production.Product.SellEndDate IS NULL";
            }

            try { 
                string conn = ConfigurationManager.ConnectionStrings["AdventureWorks2016"].ConnectionString;
                using (SqlConnection connection = new SqlConnection(conn))
                {
                    string sql = QueryBase + $@"ProductModelProductDescriptionCulture.CultureID = '{lenguageComboBox.Text}'{QueryColor}{QuerySize}{QueryProductLine}{QueryCLass}{QueryStyle}{QueryCategory}{QuerySubCategory}AND (Production.Product.ListPrice > '{price0TextBox.Text}') AND (Production.Product.ListPrice < '{price1TextBox.Text}'){AvailableCheckBox};";
                    listView1.Items.Clear();
                    List<Model> listAvailable = new List<Model>();
                    listAvailable = connection.Query<Model>(sql).ToList();
                    foreach (Model model in listAvailable)
                    {
                        listView1.Items.Add(model.ToString());
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error from  Sql: " + ex);
            }
        }
        // pagination
        private void nextPageButton_Click(object sender, EventArgs e)
        {
            currentPage--;
            if (currentPage == -1)
            {
                nextPageButton.Enabled = false;
            }
            previousBPageButton.Enabled = true;
            completeResultQuery();
        }
        private void previousBPageButton_Click(object sender, EventArgs e)
        {
            currentPage--;
            if(currentPage == 0)
            {
                previousBPageButton.Enabled = false;
            }
            nextPageButton.Enabled = true;
            completeResultQuery();

        }
        private void paginationComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            productPerPage = int.Parse(paginationComboBox.Text);
            int lastSelectedIndex = categoryComboBox.SelectedIndex;
            categoryComboBox.SelectedIndex = -1;
            categoryComboBox.SelectedIndex = lastSelectedIndex;
        }
        private void helpLabel_Click(object sender, EventArgs e)
        {
            MessageBox.Show("");
        }
    }
}
