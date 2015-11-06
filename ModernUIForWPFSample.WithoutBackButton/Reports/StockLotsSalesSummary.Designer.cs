namespace ModernUIForWPFSample.WithoutBackButton.Reports
{
    partial class StockLotsSalesSummary
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
            this.adoraDBSetDataSet = new ModernUIForWPFSample.WithoutBackButton.adoraDBSetDataSet();
            this.adoraDBSetDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.PurchasingShipmentsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.BnSFrequencyBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.DataSet1 = new ModernUIForWPFSample.WithoutBackButton.Reports.DataSet1();
            this.BnSFrequencyTableAdapter = new ModernUIForWPFSample.WithoutBackButton.Reports.DataSet1TableAdapters.BnSFrequencyTableAdapter();
            this.PurchasingShipmentsTableAdapter = new ModernUIForWPFSample.WithoutBackButton.Reports.DataSet1TableAdapters.PurchasingShipmentsTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.adoraDBSetDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.adoraDBSetDataSetBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PurchasingShipmentsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BnSFrequencyBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataSet1)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.reportViewer1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.BnSFrequencyBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "ModernUIForWPFSample.WithoutBackButton.Reports.StockLotsSalesSummary.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(1659, 1271);
            this.reportViewer1.TabIndex = 0;
            // 
            // adoraDBSetDataSet
            // 
            this.adoraDBSetDataSet.DataSetName = "adoraDBSetDataSet";
            this.adoraDBSetDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // adoraDBSetDataSetBindingSource
            // 
            this.adoraDBSetDataSetBindingSource.DataSource = this.adoraDBSetDataSet;
            this.adoraDBSetDataSetBindingSource.Position = 0;
            // 
            // PurchasingShipmentsBindingSource
            // 
            this.PurchasingShipmentsBindingSource.DataMember = "PurchasingShipments";
            this.PurchasingShipmentsBindingSource.DataSource = this.adoraDBSetDataSet;
            // 
            // BnSFrequencyBindingSource
            // 
            this.BnSFrequencyBindingSource.DataMember = "BnSFrequency";
            this.BnSFrequencyBindingSource.DataSource = this.DataSet1;
            // 
            // DataSet1
            // 
            this.DataSet1.DataSetName = "DataSet1";
            this.DataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // BnSFrequencyTableAdapter
            // 
            this.BnSFrequencyTableAdapter.ClearBeforeFill = true;
            // 
            // PurchasingShipmentsTableAdapter
            // 
            this.PurchasingShipmentsTableAdapter.ClearBeforeFill = true;
            // 
            // StockLotsSalesSummary
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1659, 1271);
            this.Controls.Add(this.reportViewer1);
            this.Name = "StockLotsSalesSummary";
            this.Text = "StockLotsSalesSummary";
            this.Load += new System.EventHandler(this.StockLotsSalesSummary_Load);
            ((System.ComponentModel.ISupportInitialize)(this.adoraDBSetDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.adoraDBSetDataSetBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PurchasingShipmentsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BnSFrequencyBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataSet1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource adoraDBSetDataSetBindingSource;
        private adoraDBSetDataSet adoraDBSetDataSet;
        private System.Windows.Forms.BindingSource PurchasingShipmentsBindingSource;
        private System.Windows.Forms.BindingSource BnSFrequencyBindingSource;
        private DataSet1 DataSet1;
        private DataSet1TableAdapters.BnSFrequencyTableAdapter BnSFrequencyTableAdapter;
        private DataSet1TableAdapters.PurchasingShipmentsTableAdapter PurchasingShipmentsTableAdapter;

    }
}