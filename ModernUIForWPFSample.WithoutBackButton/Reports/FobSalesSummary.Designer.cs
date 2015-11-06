namespace ModernUIForWPFSample.WithoutBackButton.Reports
{
    partial class FobSalesSummary
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
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.DataSet1 = new ModernUIForWPFSample.WithoutBackButton.Reports.DataSet1();
            this.FOBSalesFrequencyBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.FOBSalesFrequencyTableAdapter = new ModernUIForWPFSample.WithoutBackButton.Reports.DataSet1TableAdapters.FOBSalesFrequencyTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.DataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FOBSalesFrequencyBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.FOBSalesFrequencyBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "ModernUIForWPFSample.WithoutBackButton.Reports.FobSalesSummary.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(1607, 1129);
            this.reportViewer1.TabIndex = 0;
            // 
            // DataSet1
            // 
            this.DataSet1.DataSetName = "DataSet1";
            this.DataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // FOBSalesFrequencyBindingSource
            // 
            this.FOBSalesFrequencyBindingSource.DataMember = "FOBSalesFrequency";
            this.FOBSalesFrequencyBindingSource.DataSource = this.DataSet1;
            // 
            // FOBSalesFrequencyTableAdapter
            // 
            this.FOBSalesFrequencyTableAdapter.ClearBeforeFill = true;
            // 
            // FobSalesSummary
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1607, 1129);
            this.Controls.Add(this.reportViewer1);
            this.Name = "FobSalesSummary";
            this.Text = "FobSalesSummary";
            this.Load += new System.EventHandler(this.FobSalesSummary_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FOBSalesFrequencyBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource FOBSalesFrequencyBindingSource;
        private DataSet1 DataSet1;
        private DataSet1TableAdapters.FOBSalesFrequencyTableAdapter FOBSalesFrequencyTableAdapter;
    }
}