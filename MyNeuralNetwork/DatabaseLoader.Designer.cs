
namespace MyNeuralNetwork
{
    partial class DatabaseLoader
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
            this.btnViewModel = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmbDatabaseLoader = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.gridNLayers = new System.Windows.Forms.DataGridView();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.gridWeights = new System.Windows.Forms.DataGridView();
            this.btnLoadModel = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridNLayers)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridWeights)).BeginInit();
            this.SuspendLayout();
            // 
            // btnViewModel
            // 
            this.btnViewModel.Location = new System.Drawing.Point(687, 31);
            this.btnViewModel.Name = "btnViewModel";
            this.btnViewModel.Size = new System.Drawing.Size(100, 23);
            this.btnViewModel.TabIndex = 0;
            this.btnViewModel.Text = "View Model";
            this.btnViewModel.UseVisualStyleBackColor = true;
            this.btnViewModel.Click += new System.EventHandler(this.btnViewModel_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmbDatabaseLoader);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(309, 55);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Database Models";
            // 
            // cmbDatabaseLoader
            // 
            this.cmbDatabaseLoader.FormattingEnabled = true;
            this.cmbDatabaseLoader.Location = new System.Drawing.Point(7, 20);
            this.cmbDatabaseLoader.Name = "cmbDatabaseLoader";
            this.cmbDatabaseLoader.Size = new System.Drawing.Size(296, 21);
            this.cmbDatabaseLoader.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.gridNLayers);
            this.groupBox2.Location = new System.Drawing.Point(13, 74);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(775, 200);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Neuronal Layers";
            // 
            // gridNLayers
            // 
            this.gridNLayers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridNLayers.Location = new System.Drawing.Point(7, 19);
            this.gridNLayers.Name = "gridNLayers";
            this.gridNLayers.Size = new System.Drawing.Size(762, 175);
            this.gridNLayers.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.gridWeights);
            this.groupBox3.Location = new System.Drawing.Point(12, 280);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(775, 196);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Weights";
            // 
            // gridWeights
            // 
            this.gridWeights.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridWeights.Location = new System.Drawing.Point(8, 19);
            this.gridWeights.Name = "gridWeights";
            this.gridWeights.Size = new System.Drawing.Size(761, 171);
            this.gridWeights.TabIndex = 1;
            // 
            // btnLoadModel
            // 
            this.btnLoadModel.Enabled = false;
            this.btnLoadModel.Location = new System.Drawing.Point(713, 482);
            this.btnLoadModel.Name = "btnLoadModel";
            this.btnLoadModel.Size = new System.Drawing.Size(75, 23);
            this.btnLoadModel.TabIndex = 4;
            this.btnLoadModel.Text = "Load Model";
            this.btnLoadModel.UseVisualStyleBackColor = true;
            this.btnLoadModel.Click += new System.EventHandler(this.btnLoadModel_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(632, 482);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 5;
            this.btnClose.Text = "Return";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // DatabaseLoader
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 519);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnLoadModel);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnViewModel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "DatabaseLoader";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Database Loader";
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridNLayers)).EndInit();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridWeights)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnViewModel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView gridNLayers;
        private System.Windows.Forms.DataGridView gridWeights;
        private System.Windows.Forms.Button btnLoadModel;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.ComboBox cmbDatabaseLoader;
    }
}