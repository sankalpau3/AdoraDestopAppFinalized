namespace ModernUIForWPFSample.WithoutBackButton.Reports
{
    partial class FabricPurchasesSummary
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
            this.FabricBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.DataSet1 = new ModernUIForWPFSample.WithoutBackButton.Reports.DataSet1();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.FabricTableAdapter = new ModernUIForWPFSample.WithoutBackButton.Reports.DataSet1TableAdapters.FabricTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.FabricBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataSet1)).BeginInit();
            this.SuspendLayout();
            // 
            // FabricBindingSource
            // 
            this.FabricBindingSource.DataMember = "Fabric";
            this.FabricBindingSource.DataSource = this.DataSet1;
            // 
            // DataSet1
            // 
            this.DataSet1.DataSetName = "DataSet1";
            this.DataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.FabricBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "ModernUIForWPFSample.WithoutBackButton.Reports.FabricPurchasesSummary.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(1607, 1129);
            this.reportViewer1.TabIndex = 0;
            // 
            // FabricTableAdapter
            // 
            this.FabricTableAdapter.ClearBeforeFill = true;
            // 
            // FabricPurchasesSummary
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1607, 1129);
            this.Controls.Add(this.reportViewer1);
            this.Name = "FabricPurchasesSummary";
            this.Text = "FabricPurchasesSummary";
            this.Load += new System.EventHandler(this.FabricPurchasesSummary_Load);
            ((System.ComponentModel.ISupportInitialize)(this.FabricBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataSet1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource FabricBindingSource;
        private DataSet1 DataSet1;
        private DataSet1TableAdapters.FabricTableAdapter FabricTableAdapter;
    }
}