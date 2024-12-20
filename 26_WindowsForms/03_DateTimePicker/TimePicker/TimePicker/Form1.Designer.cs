namespace TimePicker
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
            this.dateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.lblDateTime = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.lbl3DateDay = new System.Windows.Forms.Label();
            this.lbl4Time = new System.Windows.Forms.Label();
            this.lblTimeSeconds = new System.Windows.Forms.Label();
            this.btnShow = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // dateTimePicker
            // 
            this.dateTimePicker.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker.Location = new System.Drawing.Point(257, 48);
            this.dateTimePicker.Name = "dateTimePicker";
            this.dateTimePicker.Size = new System.Drawing.Size(331, 29);
            this.dateTimePicker.TabIndex = 0;
            // 
            // lblDateTime
            // 
            this.lblDateTime.AutoSize = true;
            this.lblDateTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDateTime.ForeColor = System.Drawing.Color.OrangeRed;
            this.lblDateTime.Location = new System.Drawing.Point(257, 114);
            this.lblDateTime.Name = "lblDateTime";
            this.lblDateTime.Size = new System.Drawing.Size(60, 24);
            this.lblDateTime.TabIndex = 1;
            this.lblDateTime.Text = "label1";
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDate.ForeColor = System.Drawing.Color.OrangeRed;
            this.lblDate.Location = new System.Drawing.Point(257, 153);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(60, 24);
            this.lblDate.TabIndex = 2;
            this.lblDate.Text = "label2";
            // 
            // lbl3DateDay
            // 
            this.lbl3DateDay.AutoSize = true;
            this.lbl3DateDay.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl3DateDay.ForeColor = System.Drawing.Color.OrangeRed;
            this.lbl3DateDay.Location = new System.Drawing.Point(257, 188);
            this.lbl3DateDay.Name = "lbl3DateDay";
            this.lbl3DateDay.Size = new System.Drawing.Size(60, 24);
            this.lbl3DateDay.TabIndex = 3;
            this.lbl3DateDay.Text = "label3";
            // 
            // lbl4Time
            // 
            this.lbl4Time.AutoSize = true;
            this.lbl4Time.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl4Time.ForeColor = System.Drawing.Color.OrangeRed;
            this.lbl4Time.Location = new System.Drawing.Point(257, 232);
            this.lbl4Time.Name = "lbl4Time";
            this.lbl4Time.Size = new System.Drawing.Size(60, 24);
            this.lbl4Time.TabIndex = 4;
            this.lbl4Time.Text = "label4";
            // 
            // lblTimeSeconds
            // 
            this.lblTimeSeconds.AutoSize = true;
            this.lblTimeSeconds.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTimeSeconds.ForeColor = System.Drawing.Color.OrangeRed;
            this.lblTimeSeconds.Location = new System.Drawing.Point(257, 279);
            this.lblTimeSeconds.Name = "lblTimeSeconds";
            this.lblTimeSeconds.Size = new System.Drawing.Size(60, 24);
            this.lblTimeSeconds.TabIndex = 5;
            this.lblTimeSeconds.Text = "label5";
            // 
            // btnShow
            // 
            this.btnShow.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnShow.Location = new System.Drawing.Point(622, 371);
            this.btnShow.Name = "btnShow";
            this.btnShow.Size = new System.Drawing.Size(115, 44);
            this.btnShow.TabIndex = 6;
            this.btnShow.Text = "Show";
            this.btnShow.UseVisualStyleBackColor = true;
            this.btnShow.Click += new System.EventHandler(this.btnShow_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnShow);
            this.Controls.Add(this.lblTimeSeconds);
            this.Controls.Add(this.lbl4Time);
            this.Controls.Add(this.lbl3DateDay);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.lblDateTime);
            this.Controls.Add(this.dateTimePicker);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dateTimePicker;
        private System.Windows.Forms.Label lblDateTime;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Label lbl3DateDay;
        private System.Windows.Forms.Label lbl4Time;
        private System.Windows.Forms.Label lblTimeSeconds;
        private System.Windows.Forms.Button btnShow;
    }
}

