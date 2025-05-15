namespace Einkaufsliste_ML
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            label1 = new Label();
            textBox1 = new TextBox();
            dataGridView1 = new DataGridView();
            PredictionTypeBindingSource = new BindingSource(components);
            dataSet1 = new DataSet1();
            category_saveButton = new Button();
            articleTextBox = new TextBox();
            label2 = new Label();
            label3 = new Label();
            categorieTextBox = new TextBox();
            category_deleteButton = new Button();
            CategorieColumn = new DataGridViewTextBoxColumn();
            categoryDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            articleDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            valueDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)PredictionTypeBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataSet1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(35, 45);
            label1.Name = "label1";
            label1.Size = new Size(38, 15);
            label1.TabIndex = 0;
            label1.Text = "label1";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(94, 42);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(381, 23);
            textBox1.TabIndex = 1;
            textBox1.Text = "brot;apfel;bla;birne 0.5;weintrauben 3 kg;fleisch 3 kg;bratwurst";
            textBox1.KeyDown += textBox1_KeyDown;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { CategorieColumn, categoryDataGridViewTextBoxColumn, articleDataGridViewTextBoxColumn, valueDataGridViewTextBoxColumn });
            dataGridView1.DataSource = PredictionTypeBindingSource;
            dataGridView1.Location = new Point(94, 110);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(381, 328);
            dataGridView1.TabIndex = 2;
            // 
            // PredictionTypeBindingSource
            // 
            PredictionTypeBindingSource.DataMember = "PredictionType";
            PredictionTypeBindingSource.DataSource = dataSet1;
            PredictionTypeBindingSource.Sort = "Category";
            // 
            // dataSet1
            // 
            dataSet1.DataSetName = "DataSet1";
            dataSet1.Namespace = "http://tempuri.org/DataSet1.xsd";
            dataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // category_saveButton
            // 
            category_saveButton.Location = new Point(481, 227);
            category_saveButton.Name = "category_saveButton";
            category_saveButton.Size = new Size(128, 23);
            category_saveButton.TabIndex = 3;
            category_saveButton.Text = "Kategorie speichern";
            category_saveButton.UseVisualStyleBackColor = true;
            category_saveButton.Click += category_saveButton_Click;
            // 
            // articleTextBox
            // 
            articleTextBox.DataBindings.Add(new Binding("Text", PredictionTypeBindingSource, "Article", true));
            articleTextBox.Location = new Point(481, 128);
            articleTextBox.Name = "articleTextBox";
            articleTextBox.ReadOnly = true;
            articleTextBox.Size = new Size(307, 23);
            articleTextBox.TabIndex = 4;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(481, 109);
            label2.Name = "label2";
            label2.Size = new Size(41, 15);
            label2.TabIndex = 5;
            label2.Text = "Article";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(481, 159);
            label3.Name = "label3";
            label3.Size = new Size(58, 15);
            label3.TabIndex = 7;
            label3.Text = "Categorie";
            // 
            // categorieTextBox
            // 
            categorieTextBox.DataBindings.Add(new Binding("Text", PredictionTypeBindingSource, "Category", true));
            categorieTextBox.Location = new Point(481, 178);
            categorieTextBox.Name = "categorieTextBox";
            categorieTextBox.Size = new Size(307, 23);
            categorieTextBox.TabIndex = 6;
            // 
            // category_deleteButton
            // 
            category_deleteButton.Location = new Point(660, 227);
            category_deleteButton.Name = "category_deleteButton";
            category_deleteButton.Size = new Size(128, 23);
            category_deleteButton.TabIndex = 8;
            category_deleteButton.Text = "Kategorie löschen";
            category_deleteButton.UseVisualStyleBackColor = true;
            category_deleteButton.Click += category_deleteButton_Click;
            // 
            // CategorieColumn
            // 
            CategorieColumn.FillWeight = 7F;
            CategorieColumn.HeaderText = "";
            CategorieColumn.Name = "CategorieColumn";
            CategorieColumn.ReadOnly = true;
            CategorieColumn.Resizable = DataGridViewTriState.True;
            CategorieColumn.SortMode = DataGridViewColumnSortMode.NotSortable;
            // 
            // categoryDataGridViewTextBoxColumn
            // 
            categoryDataGridViewTextBoxColumn.DataPropertyName = "Category";
            categoryDataGridViewTextBoxColumn.HeaderText = "Category";
            categoryDataGridViewTextBoxColumn.Name = "categoryDataGridViewTextBoxColumn";
            // 
            // articleDataGridViewTextBoxColumn
            // 
            articleDataGridViewTextBoxColumn.DataPropertyName = "Article";
            articleDataGridViewTextBoxColumn.HeaderText = "Article";
            articleDataGridViewTextBoxColumn.Name = "articleDataGridViewTextBoxColumn";
            // 
            // valueDataGridViewTextBoxColumn
            // 
            valueDataGridViewTextBoxColumn.DataPropertyName = "Value";
            valueDataGridViewTextBoxColumn.HeaderText = "Value";
            valueDataGridViewTextBoxColumn.Name = "valueDataGridViewTextBoxColumn";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(category_deleteButton);
            Controls.Add(label3);
            Controls.Add(categorieTextBox);
            Controls.Add(label2);
            Controls.Add(articleTextBox);
            Controls.Add(category_saveButton);
            Controls.Add(dataGridView1);
            Controls.Add(textBox1);
            Controls.Add(label1);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)PredictionTypeBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataSet1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox textBox1;
        private DataGridView dataGridView1;
        private Button category_saveButton;
        private TextBox articleTextBox;
        private Label label2;
        private Label label3;
        private TextBox categorieTextBox;
        private BindingSource PredictionTypeBindingSource;
        private DataSet1 dataSet1;
        private Button category_deleteButton;
        private DataGridViewTextBoxColumn CategorieColumn;
        private DataGridViewTextBoxColumn categoryDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn articleDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn valueDataGridViewTextBoxColumn;
    }
}
