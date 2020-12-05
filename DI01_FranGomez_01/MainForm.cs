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
        List<Model> models = new List<Model>();
        public MainForm()
        {
            InitializeComponent();

            string connectionString = ConfigurationManager.ConnectionStrings["AdventureWorks2016"].ConnectionString;
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                
                string sql = $@"select Production.ProductModel.ProductModelID, Production.ProductModel.Name, Production.ProductDescription.Description FROM Production.Product INNER JOIN Production.ProductSubcategory ON Production.Product.ProductSubcategoryID = Production.ProductSubcategory.ProductSubcategoryID INNER JOIN Production.ProductCategory ON Production.ProductSubcategory.ProductCategoryID = Production.ProductCategory.ProductCategoryID INNER JOIN Production.ProductModel ON Production.Product.ProductModelID = Production.ProductModel.ProductModelID INNER JOIN Production.ProductModelProductDescriptionCulture ON Production.ProductModel.ProductModelID = Production.ProductModelProductDescriptionCulture.ProductModelID INNER JOIN Production.ProductDescription ON Production.ProductModelProductDescriptionCulture.ProductDescriptionID = Production.ProductDescription.ProductDescriptionID WHERE ProductModelProductDescriptionCulture.CultureID = 'en' AND Product.ProductModelID IS NOT NULL";
                models = connection.Query<Model>(sql).ToList();
                foreach (Model model in models)
                {
                    listView1.Items.Add(model.ToString());
                    //listBox1.Items.Add(model.Name + model.Description);

                    //listBox1.Items.Add(model.ProductModelID.ToString());

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

        private void listBox1_DoubleClick(object sender, EventArgs e)
        {
            /*string str = listBox1.SelectedItem.ToString();
            textBox1.Text = str;


            ProductForm pf = new ProductForm(str);
            pf.Show();*/

            
        }
    }
}
