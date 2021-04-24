namespace MyNeuralNetwork
{
    partial class ModelConstructor
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.LayersColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.createNetworkButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.rateTextBox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.LayersColumn});
            this.dataGridView1.Location = new System.Drawing.Point(12, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(172, 164);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dataGridView1_RowPostPaint);
            // 
            // LayersColumn
            // 
            this.LayersColumn.HeaderText = "Network Layers";
            this.LayersColumn.Name = "LayersColumn";
            this.LayersColumn.Width = 120;
            // 
            // createNetworkButton
            // 
            this.createNetworkButton.Location = new System.Drawing.Point(12, 211);
            this.createNetworkButton.Name = "createNetworkButton";
            this.createNetworkButton.Size = new System.Drawing.Size(172, 23);
            this.createNetworkButton.TabIndex = 1;
            this.createNetworkButton.Text = "Create Model";
            this.createNetworkButton.UseVisualStyleBackColor = true;
            this.createNetworkButton.Click += new System.EventHandler(this.createNetworkButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 188);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Learning rate:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // rateTextBox
            // 
            this.rateTextBox.Location = new System.Drawing.Point(104, 185);
            this.rateTextBox.Name = "rateTextBox";
            this.rateTextBox.Size = new System.Drawing.Size(80, 20);
            this.rateTextBox.TabIndex = 3;
            this.rateTextBox.Text = "0,05";
            // 
            // ModelConstructor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(192, 246);
            this.Controls.Add(this.rateTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.createNetworkButton);
            this.Controls.Add(this.dataGridView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "ModelConstructor";
            this.Text = "Constructor";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button createNetworkButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox rateTextBox;
        private System.Windows.Forms.DataGridViewTextBoxColumn LayersColumn;
    }
}