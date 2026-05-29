namespace UI
{
    partial class FormPrenotazione
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
            label2 = new Label();
            monthCalendar1 = new MonthCalendar();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            UtentiPrenotati = new ListBox();
            label8 = new Label();
            panel1 = new Panel();
            button5 = new Button();
            button3 = new Button();
            button2 = new Button();
            panel2 = new Panel();
            label10 = new Label();
            label9 = new Label();
            listBox1 = new ListBox();
            dateTimePicker1 = new DateTimePicker();
            label12 = new Label();
            label13 = new Label();
            Nome = new Label();
            textBox4 = new TextBox();
            textBox1 = new TextBox();
            label14 = new Label();
            button4 = new Button();
            textBoxIdRist = new TextBox();
            panel3 = new Panel();
            label16 = new Label();
            button1 = new Button();
            button6 = new Button();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft YaHei UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(528, 36);
            label1.Name = "label1";
            label1.Size = new Size(132, 26);
            label1.TabIndex = 4;
            label1.Text = "Prenotazioni";
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft YaHei UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(686, 36);
            label2.Name = "label2";
            label2.Size = new Size(164, 26);
            label2.TabIndex = 5;
            label2.Text = "nomeRistorante";
            label2.Click += label2_Click;
            // 
            // monthCalendar1
            // 
            monthCalendar1.Location = new Point(50, 189);
            monthCalendar1.Margin = new Padding(8, 8, 8, 8);
            monthCalendar1.Name = "monthCalendar1";
            monthCalendar1.TabIndex = 6;
            monthCalendar1.DateChanged += monthCalendar1_DateChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(46, 426);
            label3.Name = "label3";
            label3.Size = new Size(93, 15);
            label3.TabIndex = 7;
            label3.Text = "Posti  Prenotati: ";
            label3.Click += label3_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.Black;
            label4.Location = new Point(150, 426);
            label4.Name = "label4";
            label4.Size = new Size(116, 15);
            label4.TabIndex = 8;
            label4.Text = "varPostiPrenotati";
            label4.Click += label4_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = SystemColors.InfoText;
            label5.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.ForeColor = Color.Lime;
            label5.Location = new Point(153, 456);
            label5.Name = "label5";
            label5.Size = new Size(111, 13);
            label5.TabIndex = 10;
            label5.Text = "varPostiDisponibili";
            label5.Click += label5_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.Location = new Point(150, 399);
            label6.Name = "label6";
            label6.Size = new Size(109, 15);
            label6.TabIndex = 12;
            label6.Text = "constPostiTotali";
            label6.Click += label6_Click;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(46, 399);
            label7.Name = "label7";
            label7.Size = new Size(74, 15);
            label7.TabIndex = 11;
            label7.Text = "Posti  Totali: ";
            label7.Click += label7_Click;
            // 
            // UtentiPrenotati
            // 
            UtentiPrenotati.FormattingEnabled = true;
            UtentiPrenotati.Location = new Point(771, 165);
            UtentiPrenotati.Margin = new Padding(3, 2, 3, 2);
            UtentiPrenotati.Name = "UtentiPrenotati";
            UtentiPrenotati.Size = new Size(407, 214);
            UtentiPrenotati.TabIndex = 13;
            UtentiPrenotati.SelectedIndexChanged += UtentiPrenotati_SelectedIndexChanged;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(48, 456);
            label8.Name = "label8";
            label8.Size = new Size(98, 15);
            label8.TabIndex = 16;
            label8.Text = "Posti Disponibili: ";
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.MenuBar;
            panel1.Controls.Add(label5);
            panel1.Controls.Add(button5);
            panel1.Controls.Add(button3);
            panel1.Controls.Add(button2);
            panel1.Controls.Add(panel2);
            panel1.Controls.Add(monthCalendar1);
            panel1.Controls.Add(label7);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(label6);
            panel1.Controls.Add(label8);
            panel1.Location = new Point(241, 122);
            panel1.Margin = new Padding(4);
            panel1.Name = "panel1";
            panel1.Size = new Size(368, 529);
            panel1.TabIndex = 17;
            panel1.Paint += panel1_Paint;
            // 
            // button5
            // 
            button5.BackColor = Color.Transparent;
            button5.Cursor = Cursors.Hand;
            button5.FlatStyle = FlatStyle.Flat;
            button5.Location = new Point(134, 120);
            button5.Margin = new Padding(4);
            button5.Name = "button5";
            button5.Size = new Size(98, 29);
            button5.TabIndex = 17;
            button5.Text = "Settimana";
            button5.UseVisualStyleBackColor = false;
            button5.Click += button5_Click;
            // 
            // button3
            // 
            button3.BackColor = Color.Transparent;
            button3.FlatStyle = FlatStyle.Flat;
            button3.Location = new Point(232, 120);
            button3.Margin = new Padding(4);
            button3.Name = "button3";
            button3.Size = new Size(83, 29);
            button3.TabIndex = 16;
            button3.Text = "Mese";
            button3.UseVisualStyleBackColor = false;
            // 
            // button2
            // 
            button2.BackColor = Color.CornflowerBlue;
            button2.Cursor = Cursors.Hand;
            button2.FlatStyle = FlatStyle.Flat;
            button2.Location = new Point(50, 120);
            button2.Margin = new Padding(4);
            button2.Name = "button2";
            button2.Size = new Size(88, 29);
            button2.TabIndex = 7;
            button2.Text = "Giorno";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // panel2
            // 
            panel2.BackColor = Color.CornflowerBlue;
            panel2.Controls.Add(label10);
            panel2.Controls.Add(label9);
            panel2.Location = new Point(0, 0);
            panel2.Margin = new Padding(4);
            panel2.Name = "panel2";
            panel2.Size = new Size(368, 83);
            panel2.TabIndex = 3;
            panel2.Paint += panel2_Paint;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Microsoft YaHei Light", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label10.Location = new Point(18, 49);
            label10.Margin = new Padding(4, 0, 4, 0);
            label10.Name = "label10";
            label10.Size = new Size(121, 16);
            label10.TabIndex = 1;
            label10.Text = "Prenota Gratuitamente";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Microsoft YaHei UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label9.Location = new Point(18, 11);
            label9.Margin = new Padding(4, 0, 4, 0);
            label9.Name = "label9";
            label9.Size = new Size(208, 22);
            label9.TabIndex = 0;
            label9.Text = "Consulta le prenotazioni";
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.Location = new Point(771, 406);
            listBox1.Margin = new Padding(3, 2, 3, 2);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(407, 244);
            listBox1.TabIndex = 18;
            listBox1.SelectedIndexChanged += listBox1_SelectedIndexChanged;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Location = new Point(928, 514);
            dateTimePicker1.Margin = new Padding(4);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(224, 23);
            dateTimePicker1.TabIndex = 67;
            dateTimePicker1.ValueChanged += dateTimePicker1_ValueChanged;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(811, 546);
            label12.Name = "label12";
            label12.Size = new Size(96, 15);
            label12.TabIndex = 66;
            label12.Text = "Numero Persone";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(811, 516);
            label13.Name = "label13";
            label13.Size = new Size(103, 15);
            label13.TabIndex = 65;
            label13.Text = "Data Prenotazione";
            // 
            // Nome
            // 
            Nome.AutoSize = true;
            Nome.Location = new Point(811, 484);
            Nome.Name = "Nome";
            Nome.Size = new Size(78, 15);
            Nome.TabIndex = 64;
            Nome.Text = "Nome Utente";
            // 
            // textBox4
            // 
            textBox4.Location = new Point(927, 546);
            textBox4.Margin = new Padding(3, 2, 3, 2);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(225, 23);
            textBox4.TabIndex = 63;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(928, 475);
            textBox1.Margin = new Padding(3, 2, 3, 2);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(225, 23);
            textBox1.TabIndex = 62;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label14.Location = new Point(900, 430);
            label14.Margin = new Padding(4, 0, 4, 0);
            label14.Name = "label14";
            label14.Size = new Size(147, 16);
            label14.TabIndex = 68;
            label14.Text = "Conferma Prenotazione";
            // 
            // button4
            // 
            button4.BackColor = Color.MidnightBlue;
            button4.FlatStyle = FlatStyle.Flat;
            button4.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button4.ForeColor = Color.Snow;
            button4.Location = new Point(928, 599);
            button4.Margin = new Padding(4);
            button4.Name = "button4";
            button4.Size = new Size(120, 34);
            button4.TabIndex = 69;
            button4.Text = "PRENOTA";
            button4.UseVisualStyleBackColor = false;
            button4.Click += button4_Click;
            // 
            // textBoxIdRist
            // 
            textBoxIdRist.Location = new Point(592, -1);
            textBoxIdRist.Margin = new Padding(3, 2, 3, 2);
            textBoxIdRist.Name = "textBoxIdRist";
            textBoxIdRist.Size = new Size(197, 23);
            textBoxIdRist.TabIndex = 70;
            textBoxIdRist.Visible = false;
            // 
            // panel3
            // 
            panel3.BackColor = Color.CornflowerBlue;
            panel3.Controls.Add(label16);
            panel3.Location = new Point(771, 122);
            panel3.Margin = new Padding(4);
            panel3.Name = "panel3";
            panel3.Size = new Size(409, 43);
            panel3.TabIndex = 4;
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Font = new Font("Microsoft YaHei UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label16.Location = new Point(18, 11);
            label16.Margin = new Padding(4, 0, 4, 0);
            label16.Name = "label16";
            label16.Size = new Size(226, 22);
            label16.TabIndex = 0;
            label16.Text = "                 Utenti Prenotati";
            // 
            // button1
            // 
            button1.Location = new Point(1008, 353);
            button1.Margin = new Padding(4);
            button1.Name = "button1";
            button1.Size = new Size(88, 26);
            button1.TabIndex = 71;
            button1.Text = "Modifica";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click_1;
            // 
            // button6
            // 
            button6.Location = new Point(1092, 353);
            button6.Margin = new Padding(4);
            button6.Name = "button6";
            button6.Size = new Size(88, 26);
            button6.TabIndex = 72;
            button6.Text = "Elimina";
            button6.UseVisualStyleBackColor = true;
            button6.Click += button6_Click;
            // 
            // FormPrenotazione
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            AutoScrollMinSize = new Size(20, 20);
            BackColor = SystemColors.ButtonHighlight;
            ClientSize = new Size(1382, 696);
            Controls.Add(button6);
            Controls.Add(button1);
            Controls.Add(panel3);
            Controls.Add(textBoxIdRist);
            Controls.Add(button4);
            Controls.Add(label14);
            Controls.Add(dateTimePicker1);
            Controls.Add(label12);
            Controls.Add(label13);
            Controls.Add(Nome);
            Controls.Add(textBox4);
            Controls.Add(textBox1);
            Controls.Add(listBox1);
            Controls.Add(panel1);
            Controls.Add(UtentiPrenotati);
            Controls.Add(label2);
            Controls.Add(label1);
            Margin = new Padding(3, 2, 3, 2);
            Name = "FormPrenotazione";
            Text = "Prenotazione";
            Load += Prenotazione_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.MonthCalendar monthCalendar1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ListBox UtentiPrenotati;

        public System.Windows.Forms.Label GetPostiDisponibili()
        {
            return label4;
        }

        public System.Windows.Forms.Label GetPostiTotali()
        {
            return label6;
        }

        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label Nome;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.TextBox textBoxIdRist;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button6;
    }
}