﻿namespace DI01_FranGomez_01
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.categoryComboBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.colorComboBox = new System.Windows.Forms.ComboBox();
            this.subCategoryComboBox = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.lenguageComboBox = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.searchTextBox = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.helpLabel = new System.Windows.Forms.Label();
            this.availableBox = new System.Windows.Forms.CheckBox();
            this.price1TextBox = new System.Windows.Forms.TextBox();
            this.price0TextBox = new System.Windows.Forms.TextBox();
            this.styleComboBox = new System.Windows.Forms.ComboBox();
            this.classComboBox = new System.Windows.Forms.ComboBox();
            this.productLineComboBox = new System.Windows.Forms.ComboBox();
            this.sizeComboBox = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.listView1 = new System.Windows.Forms.ListView();
            this.Products = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.nextPageButton = new System.Windows.Forms.Button();
            this.previousBPageButton = new System.Windows.Forms.Button();
            this.productsFoundLabel = new System.Windows.Forms.Label();
            this.paginationComboBox = new System.Windows.Forms.ComboBox();
            this.totalOfPagesLabel = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.numberOfPageLabel = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // categoryComboBox
            // 
            this.categoryComboBox.FormattingEnabled = true;
            this.categoryComboBox.Location = new System.Drawing.Point(142, 320);
            this.categoryComboBox.Name = "categoryComboBox";
            this.categoryComboBox.Size = new System.Drawing.Size(174, 23);
            this.categoryComboBox.TabIndex = 5;
            this.categoryComboBox.SelectedIndexChanged += new System.EventHandler(this.categoryComboBox_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Malgun Gothic", 8F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(27, 324);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Categories:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Malgun Gothic", 8F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(27, 74);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Lenguage:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Malgun Gothic", 8F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(27, 360);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Sub Categories:";
            // 
            // colorComboBox
            // 
            this.colorComboBox.FormattingEnabled = true;
            this.colorComboBox.Location = new System.Drawing.Point(142, 109);
            this.colorComboBox.Name = "colorComboBox";
            this.colorComboBox.Size = new System.Drawing.Size(174, 23);
            this.colorComboBox.TabIndex = 15;
            this.colorComboBox.SelectedIndexChanged += new System.EventHandler(this.ColorComboBox_SelectedIndexChanged);
            // 
            // subCategoryComboBox
            // 
            this.subCategoryComboBox.FormattingEnabled = true;
            this.subCategoryComboBox.Location = new System.Drawing.Point(142, 356);
            this.subCategoryComboBox.Name = "subCategoryComboBox";
            this.subCategoryComboBox.Size = new System.Drawing.Size(174, 23);
            this.subCategoryComboBox.TabIndex = 11;
            this.subCategoryComboBox.SelectedIndexChanged += new System.EventHandler(this.subCategoryComboBox_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Malgun Gothic", 8F, System.Drawing.FontStyle.Bold);
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(27, 113);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(38, 13);
            this.label7.TabIndex = 16;
            this.label7.Text = "Color:";
            // 
            // lenguageComboBox
            // 
            this.lenguageComboBox.FormattingEnabled = true;
            this.lenguageComboBox.Location = new System.Drawing.Point(142, 70);
            this.lenguageComboBox.Name = "lenguageComboBox";
            this.lenguageComboBox.Size = new System.Drawing.Size(174, 23);
            this.lenguageComboBox.TabIndex = 18;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Malgun Gothic", 8F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(27, 39);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 13);
            this.label5.TabIndex = 20;
            this.label5.Text = "Search: ";
            // 
            // searchTextBox
            // 
            this.searchTextBox.Location = new System.Drawing.Point(142, 35);
            this.searchTextBox.Name = "searchTextBox";
            this.searchTextBox.Size = new System.Drawing.Size(174, 21);
            this.searchTextBox.TabIndex = 21;
            this.searchTextBox.TextChanged += new System.EventHandler(this.searchTextBox_TextChanged);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(39)))));
            this.panel1.Controls.Add(this.helpLabel);
            this.panel1.Controls.Add(this.availableBox);
            this.panel1.Controls.Add(this.price1TextBox);
            this.panel1.Controls.Add(this.price0TextBox);
            this.panel1.Controls.Add(this.styleComboBox);
            this.panel1.Controls.Add(this.classComboBox);
            this.panel1.Controls.Add(this.productLineComboBox);
            this.panel1.Controls.Add(this.sizeComboBox);
            this.panel1.Controls.Add(this.searchTextBox);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.categoryComboBox);
            this.panel1.Controls.Add(this.lenguageComboBox);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.subCategoryComboBox);
            this.panel1.Controls.Add(this.colorComboBox);
            this.panel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(26, 95);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(347, 515);
            this.panel1.TabIndex = 3;
            // 
            // helpLabel
            // 
            this.helpLabel.AutoSize = true;
            this.helpLabel.Font = new System.Drawing.Font("Malgun Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.helpLabel.ForeColor = System.Drawing.Color.White;
            this.helpLabel.Location = new System.Drawing.Point(267, 481);
            this.helpLabel.Name = "helpLabel";
            this.helpLabel.Size = new System.Drawing.Size(44, 15);
            this.helpLabel.TabIndex = 31;
            this.helpLabel.Text = "¿Help?";
            this.helpLabel.Click += new System.EventHandler(this.helpLabel_Click);
            // 
            // availableBox
            // 
            this.availableBox.AutoSize = true;
            this.availableBox.Font = new System.Drawing.Font("Malgun Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.availableBox.ForeColor = System.Drawing.Color.White;
            this.availableBox.Location = new System.Drawing.Point(142, 400);
            this.availableBox.Name = "availableBox";
            this.availableBox.Size = new System.Drawing.Size(169, 19);
            this.availableBox.TabIndex = 30;
            this.availableBox.Text = "Available / Not Available";
            this.availableBox.UseVisualStyleBackColor = true;
            this.availableBox.CheckedChanged += new System.EventHandler(this.availableBox_CheckedChanged);
            // 
            // price1TextBox
            // 
            this.price1TextBox.Location = new System.Drawing.Point(247, 144);
            this.price1TextBox.Name = "price1TextBox";
            this.price1TextBox.Size = new System.Drawing.Size(51, 21);
            this.price1TextBox.TabIndex = 28;
            this.price1TextBox.TextChanged += new System.EventHandler(this.price1TextBox_TextChanged);
            // 
            // price0TextBox
            // 
            this.price0TextBox.Location = new System.Drawing.Point(142, 144);
            this.price0TextBox.Name = "price0TextBox";
            this.price0TextBox.Size = new System.Drawing.Size(51, 21);
            this.price0TextBox.TabIndex = 28;
            this.price0TextBox.TextChanged += new System.EventHandler(this.price0TextBox_TextChanged_1);
            // 
            // styleComboBox
            // 
            this.styleComboBox.FormattingEnabled = true;
            this.styleComboBox.Location = new System.Drawing.Point(142, 284);
            this.styleComboBox.Name = "styleComboBox";
            this.styleComboBox.Size = new System.Drawing.Size(174, 23);
            this.styleComboBox.TabIndex = 27;
            this.styleComboBox.SelectedIndexChanged += new System.EventHandler(this.styleComboBox_SelectedIndexChanged);
            // 
            // classComboBox
            // 
            this.classComboBox.FormattingEnabled = true;
            this.classComboBox.Location = new System.Drawing.Point(142, 250);
            this.classComboBox.Name = "classComboBox";
            this.classComboBox.Size = new System.Drawing.Size(174, 23);
            this.classComboBox.TabIndex = 26;
            this.classComboBox.SelectedIndexChanged += new System.EventHandler(this.classComboBox_SelectedIndexChanged);
            // 
            // productLineComboBox
            // 
            this.productLineComboBox.FormattingEnabled = true;
            this.productLineComboBox.Location = new System.Drawing.Point(142, 215);
            this.productLineComboBox.Name = "productLineComboBox";
            this.productLineComboBox.Size = new System.Drawing.Size(174, 23);
            this.productLineComboBox.TabIndex = 25;
            this.productLineComboBox.SelectedIndexChanged += new System.EventHandler(this.productLineComboBox_SelectedIndexChanged);
            // 
            // sizeComboBox
            // 
            this.sizeComboBox.FormattingEnabled = true;
            this.sizeComboBox.Location = new System.Drawing.Point(142, 179);
            this.sizeComboBox.Name = "sizeComboBox";
            this.sizeComboBox.Size = new System.Drawing.Size(174, 23);
            this.sizeComboBox.TabIndex = 24;
            this.sizeComboBox.SelectedIndexChanged += new System.EventHandler(this.sizeComboBox_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Malgun Gothic", 8F, System.Drawing.FontStyle.Bold);
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(199, 150);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(114, 13);
            this.label6.TabIndex = 16;
            this.label6.Text = "€  to                   €";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Malgun Gothic", 8F, System.Drawing.FontStyle.Bold);
            this.label12.ForeColor = System.Drawing.Color.White;
            this.label12.Location = new System.Drawing.Point(27, 288);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(35, 13);
            this.label12.TabIndex = 16;
            this.label12.Text = "Style:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Malgun Gothic", 8F, System.Drawing.FontStyle.Bold);
            this.label11.ForeColor = System.Drawing.Color.White;
            this.label11.Location = new System.Drawing.Point(27, 254);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(36, 13);
            this.label11.TabIndex = 16;
            this.label11.Text = "Class:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Malgun Gothic", 8F, System.Drawing.FontStyle.Bold);
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(27, 219);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(73, 13);
            this.label10.TabIndex = 16;
            this.label10.Text = "ProductLine:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Malgun Gothic", 8F, System.Drawing.FontStyle.Bold);
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(27, 183);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(30, 13);
            this.label9.TabIndex = 16;
            this.label9.Text = "Size:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Malgun Gothic", 8F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(27, 148);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 16;
            this.label4.Text = "Price:";
            // 
            // listView1
            // 
            this.listView1.Alignment = System.Windows.Forms.ListViewAlignment.Left;
            this.listView1.BackColor = System.Drawing.Color.White;
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Products});
            this.listView1.Font = new System.Drawing.Font("Malgun Gothic", 9F);
            this.listView1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(379, 95);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(936, 515);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.DoubleClick += new System.EventHandler(this.listView1_DoubleClick);
            // 
            // Products
            // 
            this.Products.Text = "Products";
            this.Products.Width = 1750;
            // 
            // nextPageButton
            // 
            this.nextPageButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(71)))), ((int)(((byte)(111)))));
            this.nextPageButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.nextPageButton.Font = new System.Drawing.Font("Malgun Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.nextPageButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.nextPageButton.Location = new System.Drawing.Point(495, 15);
            this.nextPageButton.Name = "nextPageButton";
            this.nextPageButton.Size = new System.Drawing.Size(63, 23);
            this.nextPageButton.TabIndex = 1;
            this.nextPageButton.Text = ">";
            this.nextPageButton.UseVisualStyleBackColor = false;
            this.nextPageButton.Click += new System.EventHandler(this.nextPageButton_Click);
            // 
            // previousBPageButton
            // 
            this.previousBPageButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(71)))), ((int)(((byte)(111)))));
            this.previousBPageButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.previousBPageButton.Font = new System.Drawing.Font("Malgun Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.previousBPageButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.previousBPageButton.Location = new System.Drawing.Point(380, 15);
            this.previousBPageButton.Name = "previousBPageButton";
            this.previousBPageButton.Size = new System.Drawing.Size(63, 23);
            this.previousBPageButton.TabIndex = 2;
            this.previousBPageButton.Text = "<";
            this.previousBPageButton.UseVisualStyleBackColor = false;
            this.previousBPageButton.Click += new System.EventHandler(this.previousBPageButton_Click);
            // 
            // productsFoundLabel
            // 
            this.productsFoundLabel.AutoSize = true;
            this.productsFoundLabel.Font = new System.Drawing.Font("Malgun Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.productsFoundLabel.ForeColor = System.Drawing.Color.White;
            this.productsFoundLabel.Location = new System.Drawing.Point(17, 19);
            this.productsFoundLabel.Name = "productsFoundLabel";
            this.productsFoundLabel.Size = new System.Drawing.Size(69, 15);
            this.productsFoundLabel.TabIndex = 3;
            this.productsFoundLabel.Text = "0 Products";
            // 
            // paginationComboBox
            // 
            this.paginationComboBox.Font = new System.Drawing.Font("Malgun Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.paginationComboBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.paginationComboBox.FormattingEnabled = true;
            this.paginationComboBox.Location = new System.Drawing.Point(850, 16);
            this.paginationComboBox.Name = "paginationComboBox";
            this.paginationComboBox.Size = new System.Drawing.Size(69, 23);
            this.paginationComboBox.TabIndex = 4;
            this.paginationComboBox.SelectedIndexChanged += new System.EventHandler(this.paginationComboBox_SelectedIndexChanged);
            // 
            // totalOfPagesLabel
            // 
            this.totalOfPagesLabel.AutoSize = true;
            this.totalOfPagesLabel.Font = new System.Drawing.Font("Malgun Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.totalOfPagesLabel.ForeColor = System.Drawing.Color.White;
            this.totalOfPagesLabel.Location = new System.Drawing.Point(645, 19);
            this.totalOfPagesLabel.Name = "totalOfPagesLabel";
            this.totalOfPagesLabel.Size = new System.Drawing.Size(86, 15);
            this.totalOfPagesLabel.TabIndex = 5;
            this.totalOfPagesLabel.Text = "0 Total Pages";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Malgun Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(796, 19);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(39, 15);
            this.label8.TabIndex = 6;
            this.label8.Text = "Page:";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(39)))));
            this.panel2.Controls.Add(this.productsFoundLabel);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.nextPageButton);
            this.panel2.Controls.Add(this.previousBPageButton);
            this.panel2.Controls.Add(this.paginationComboBox);
            this.panel2.Controls.Add(this.numberOfPageLabel);
            this.panel2.Controls.Add(this.totalOfPagesLabel);
            this.panel2.Location = new System.Drawing.Point(379, 22);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(936, 55);
            this.panel2.TabIndex = 7;
            // 
            // numberOfPageLabel
            // 
            this.numberOfPageLabel.AutoSize = true;
            this.numberOfPageLabel.Font = new System.Drawing.Font("Malgun Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.numberOfPageLabel.ForeColor = System.Drawing.Color.White;
            this.numberOfPageLabel.Location = new System.Drawing.Point(462, 19);
            this.numberOfPageLabel.Name = "numberOfPageLabel";
            this.numberOfPageLabel.Size = new System.Drawing.Size(25, 15);
            this.numberOfPageLabel.TabIndex = 5;
            this.numberOfPageLabel.Text = "0 P";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Malgun Gothic", 16F);
            this.label13.ForeColor = System.Drawing.Color.White;
            this.label13.Location = new System.Drawing.Point(48, 37);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(276, 30);
            this.label13.TabIndex = 16;
            this.label13.Text = "AdventureWorks Products";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(39)))));
            this.ClientSize = new System.Drawing.Size(1337, 641);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.label13);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DI01 AdventureWorks : Products";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox categoryComboBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox colorComboBox;
        private System.Windows.Forms.ComboBox subCategoryComboBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox lenguageComboBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox searchTextBox;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader Products;
        private System.Windows.Forms.Button nextPageButton;
        private System.Windows.Forms.Button previousBPageButton;
        private System.Windows.Forms.Label productsFoundLabel;
        private System.Windows.Forms.ComboBox paginationComboBox;
        private System.Windows.Forms.Label totalOfPagesLabel;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox sizeComboBox;
        private System.Windows.Forms.ComboBox productLineComboBox;
        private System.Windows.Forms.ComboBox classComboBox;
        private System.Windows.Forms.ComboBox styleComboBox;
        private System.Windows.Forms.TextBox price1TextBox;
        private System.Windows.Forms.TextBox price0TextBox;
        private System.Windows.Forms.Label numberOfPageLabel;
        private System.Windows.Forms.CheckBox availableBox;
        private System.Windows.Forms.Label helpLabel;
    }
}

