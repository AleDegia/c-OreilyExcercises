﻿namespace EsRiassuntivoWF
{
    partial class Form1
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
            this.button1 = new System.Windows.Forms.Button();
            this.libraryProducts = new System.Windows.Forms.ListBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblBalance = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblCliente = new System.Windows.Forms.Label();
            this.Add_btn = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.checkout = new System.Windows.Forms.ListBox();
            this.SommaSpesa = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(777, 444);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(129, 50);
            this.button1.TabIndex = 0;
            this.button1.Text = "Buy";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // libraryProducts
            // 
            this.libraryProducts.FormattingEnabled = true;
            this.libraryProducts.ItemHeight = 16;
            this.libraryProducts.Location = new System.Drawing.Point(52, 70);
            this.libraryProducts.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.libraryProducts.Name = "libraryProducts";
            this.libraryProducts.Size = new System.Drawing.Size(211, 148);
            this.libraryProducts.TabIndex = 4;
            this.libraryProducts.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Window;
            this.panel1.Controls.Add(this.lblBalance);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.lblCliente);
            this.panel1.Location = new System.Drawing.Point(656, 70);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(304, 149);
            this.panel1.TabIndex = 5;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // lblBalance
            // 
            this.lblBalance.AutoSize = true;
            this.lblBalance.Location = new System.Drawing.Point(136, 78);
            this.lblBalance.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblBalance.Name = "lblBalance";
            this.lblBalance.Size = new System.Drawing.Size(14, 16);
            this.lblBalance.TabIndex = 2;
            this.lblBalance.Text = "0";
            this.lblBalance.Click += new System.EventHandler(this.label2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(59, 78);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "balance: ";
            // 
            // lblCliente
            // 
            this.lblCliente.AutoSize = true;
            this.lblCliente.Location = new System.Drawing.Point(55, 34);
            this.lblCliente.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCliente.Name = "lblCliente";
            this.lblCliente.Size = new System.Drawing.Size(82, 16);
            this.lblCliente.TabIndex = 0;
            this.lblCliente.Text = "nomeCliente";
            // 
            // Add_btn
            // 
            this.Add_btn.Location = new System.Drawing.Point(68, 226);
            this.Add_btn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Add_btn.Name = "Add_btn";
            this.Add_btn.Size = new System.Drawing.Size(177, 28);
            this.Add_btn.TabIndex = 6;
            this.Add_btn.Text = "Add to Basket";
            this.Add_btn.UseVisualStyleBackColor = true;
            this.Add_btn.Click += new System.EventHandler(this.Add_btn_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(455, 59);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 16);
            this.label2.TabIndex = 7;
            this.label2.Text = "label2";
            this.label2.Click += new System.EventHandler(this.label2_Click_1);
            // 
            // checkout
            // 
            this.checkout.FormattingEnabled = true;
            this.checkout.ItemHeight = 16;
            this.checkout.Location = new System.Drawing.Point(404, 102);
            this.checkout.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.checkout.Name = "checkout";
            this.checkout.Size = new System.Drawing.Size(159, 116);
            this.checkout.TabIndex = 8;
            this.checkout.SelectedIndexChanged += new System.EventHandler(this.checkout_SelectedIndexChanged);
            // 
            // SommaSpesa
            // 
            this.SommaSpesa.AutoSize = true;
            this.SommaSpesa.Location = new System.Drawing.Point(513, 104);
            this.SommaSpesa.Name = "SommaSpesa";
            this.SommaSpesa.Size = new System.Drawing.Size(44, 16);
            this.SommaSpesa.TabIndex = 9;
            this.SommaSpesa.Text = "label3";
            this.SommaSpesa.Click += new System.EventHandler(this.label3_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.SommaSpesa);
            this.Controls.Add(this.checkout);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Add_btn);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.libraryProducts);
            this.Controls.Add(this.button1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ListBox libraryProducts;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblCliente;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblBalance;
        private System.Windows.Forms.Button Add_btn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox checkout;
        private System.Windows.Forms.Label SommaSpesa;
    }
}

