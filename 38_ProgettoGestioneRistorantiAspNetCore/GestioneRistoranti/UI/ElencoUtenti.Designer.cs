namespace UI
{
    partial class ElencoUtenti
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
            label1 = new Label();
            dataGridView1 = new DataGridView();
            button3 = new Button();
            button2 = new Button();
            button1 = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(514, 52);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(118, 20);
            label1.TabIndex = 3;
            label1.Text = "Elenco Utenti";
            label1.Click += label1_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(125, 122);
            dataGridView1.Margin = new Padding(2);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.RowTemplate.Height = 24;
            dataGridView1.Size = new Size(974, 457);
            dataGridView1.TabIndex = 6;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // button3
            // 
            button3.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            button3.Location = new Point(765, 617);
            button3.Margin = new Padding(2);
            button3.Name = "button3";
            button3.Size = new Size(79, 33);
            button3.TabIndex = 22;
            button3.Text = "Elimina";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button2
            // 
            button2.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            button2.Location = new Point(611, 617);
            button2.Margin = new Padding(2);
            button2.Name = "button2";
            button2.Size = new Size(79, 33);
            button2.TabIndex = 21;
            button2.Text = "Modifica";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            button1.Location = new Point(446, 617);
            button1.Margin = new Padding(2);
            button1.Name = "button1";
            button1.Size = new Size(79, 33);
            button1.TabIndex = 20;
            button1.Text = "Aggiungi";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // ElencoUtenti
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1206, 690);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(dataGridView1);
            Controls.Add(label1);
            Margin = new Padding(2);
            Name = "ElencoUtenti";
            Text = "ElencoUtenti";
            Load += ElencoUtenti_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        //private DevExpress.XtraEditors.SimpleButton simpleButton3;
        //private DevExpress.XtraEditors.SimpleButton simpleButton2;
        //private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private System.Windows.Forms.DataGridView dataGridView1;

        public System.Windows.Forms.DataGridView GetDataGridView()
        {
            return dataGridView1;
        }
        public void SetDataGridView(System.Windows.Forms.DataGridView dataGridView)
        {
            dataGridView1 = dataGridView;
        }

        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
    }
}