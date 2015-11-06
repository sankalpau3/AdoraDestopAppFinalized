namespace ModernUIForWPFSample.WithoutBackButton.Reports
{
    partial class ReportInputs
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
            this.label1 = new System.Windows.Forms.Label();
            this.radioMonthly = new System.Windows.Forms.RadioButton();
            this.radioYearly = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dropYear = new System.Windows.Forms.ComboBox();
            this.dropMonth = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.radioRange = new System.Windows.Forms.RadioButton();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.fromDatePicker = new System.Windows.Forms.DateTimePicker();
            this.toDatePicker = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(275, 16);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(156, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Pick the Report Type";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // radioMonthly
            // 
            this.radioMonthly.AutoSize = true;
            this.radioMonthly.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioMonthly.Location = new System.Drawing.Point(54, 80);
            this.radioMonthly.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.radioMonthly.Name = "radioMonthly";
            this.radioMonthly.Size = new System.Drawing.Size(82, 24);
            this.radioMonthly.TabIndex = 1;
            this.radioMonthly.TabStop = true;
            this.radioMonthly.Text = "Monthly";
            this.radioMonthly.UseVisualStyleBackColor = true;
            this.radioMonthly.CheckedChanged += new System.EventHandler(this.radioMonthly_CheckedChanged);
            // 
            // radioYearly
            // 
            this.radioYearly.AutoSize = true;
            this.radioYearly.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioYearly.Location = new System.Drawing.Point(302, 80);
            this.radioYearly.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.radioYearly.Name = "radioYearly";
            this.radioYearly.Size = new System.Drawing.Size(71, 24);
            this.radioYearly.TabIndex = 2;
            this.radioYearly.TabStop = true;
            this.radioYearly.Text = "Yearly";
            this.radioYearly.UseVisualStyleBackColor = true;
            this.radioYearly.CheckedChanged += new System.EventHandler(this.radioYearly_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(14, 244);
            this.label2.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Month";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(14, 194);
            this.label3.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "Year";
            // 
            // dropYear
            // 
            this.dropYear.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dropYear.FormattingEnabled = true;
            this.dropYear.Location = new System.Drawing.Point(180, 194);
            this.dropYear.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.dropYear.Name = "dropYear";
            this.dropYear.Size = new System.Drawing.Size(129, 28);
            this.dropYear.TabIndex = 5;
            this.dropYear.SelectedIndexChanged += new System.EventHandler(this.dropYear_SelectedIndexChanged);
            // 
            // dropMonth
            // 
            this.dropMonth.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dropMonth.FormattingEnabled = true;
            this.dropMonth.Location = new System.Drawing.Point(180, 244);
            this.dropMonth.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.dropMonth.Name = "dropMonth";
            this.dropMonth.Size = new System.Drawing.Size(129, 28);
            this.dropMonth.TabIndex = 6;
            this.dropMonth.SelectedIndexChanged += new System.EventHandler(this.dropMonth_SelectedIndexChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(599, 319);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(181, 39);
            this.button1.TabIndex = 7;
            this.button1.Text = "Generate";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // radioRange
            // 
            this.radioRange.AutoSize = true;
            this.radioRange.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioRange.Location = new System.Drawing.Point(529, 80);
            this.radioRange.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.radioRange.Name = "radioRange";
            this.radioRange.Size = new System.Drawing.Size(75, 24);
            this.radioRange.TabIndex = 8;
            this.radioRange.TabStop = true;
            this.radioRange.Text = "Range";
            this.radioRange.UseVisualStyleBackColor = true;
            this.radioRange.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(401, 197);
            this.label4.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 20);
            this.label4.TabIndex = 10;
            this.label4.Text = "From";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(420, 252);
            this.label5.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(27, 20);
            this.label5.TabIndex = 9;
            this.label5.Text = "To";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // fromDatePicker
            // 
            this.fromDatePicker.Location = new System.Drawing.Point(512, 190);
            this.fromDatePicker.Name = "fromDatePicker";
            this.fromDatePicker.Size = new System.Drawing.Size(268, 26);
            this.fromDatePicker.TabIndex = 11;
            // 
            // toDatePicker
            // 
            this.toDatePicker.Location = new System.Drawing.Point(512, 247);
            this.toDatePicker.Name = "toDatePicker";
            this.toDatePicker.Size = new System.Drawing.Size(268, 26);
            this.toDatePicker.TabIndex = 12;
            // 
            // ReportInputs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(799, 373);
            this.Controls.Add(this.toDatePicker);
            this.Controls.Add(this.fromDatePicker);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.radioRange);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dropMonth);
            this.Controls.Add(this.dropYear);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.radioYearly);
            this.Controls.Add(this.radioMonthly);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.Name = "ReportInputs";
            this.Text = "ReportInputs";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton radioMonthly;
        private System.Windows.Forms.RadioButton radioYearly;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox dropYear;
        private System.Windows.Forms.ComboBox dropMonth;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.RadioButton radioRange;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker fromDatePicker;
        private System.Windows.Forms.DateTimePicker toDatePicker;
    }
}