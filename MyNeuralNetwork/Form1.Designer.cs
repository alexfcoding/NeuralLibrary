﻿namespace MyNeuralNetwork
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.testNetworkButton = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // testNetworkButton
            // 
            this.testNetworkButton.Location = new System.Drawing.Point(12, 303);
            this.testNetworkButton.Name = "testNetworkButton";
            this.testNetworkButton.Size = new System.Drawing.Size(120, 23);
            this.testNetworkButton.TabIndex = 0;
            this.testNetworkButton.Text = "CreateNetwork";
            this.testNetworkButton.UseVisualStyleBackColor = true;
            this.testNetworkButton.Click += new System.EventHandler(this.testNetworkButton_Click);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 16;
            this.listBox1.Location = new System.Drawing.Point(12, 12);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(120, 276);
            this.listBox1.TabIndex = 1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1440, 575);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.testNetworkButton);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button testNetworkButton;
        private System.Windows.Forms.ListBox listBox1;
    }
}

