namespace ModernUIForWPFSample.WithoutBackButton.Views
{
    partial class StockLotsSalesSearch
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.showBnSDetailsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.adoraDBSetDataSet = new ModernUIForWPFSample.WithoutBackButton.adoraDBSetDataSet();
            this.showBnSDetailsTableAdapter = new ModernUIForWPFSample.WithoutBackButton.adoraDBSetDataSetTableAdapters.showBnSDetailsTableAdapter();
            this.shipmentNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.frequencyDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.frequencyNoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numberOfPiecesDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pricePerPieceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.totalGrossDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.showBnSDetailsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.adoraDBSetDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.shipmentNameDataGridViewTextBoxColumn,
            this.frequencyDateDataGridViewTextBoxColumn,
            this.frequencyNoDataGridViewTextBoxColumn,
            this.numberOfPiecesDataGridViewTextBoxColumn,
            this.pricePerPieceDataGridViewTextBoxColumn,
            this.totalGrossDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.showBnSDetailsBindingSource;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 33;
            this.dataGridView1.Size = new System.Drawing.Size(1247, 846);
            this.dataGridView1.TabIndex = 0;
            // 
            // showBnSDetailsBindingSource
            // 
            this.showBnSDetailsBindingSource.DataMember = "showBnSDetails";
            this.showBnSDetailsBindingSource.DataSource = this.adoraDBSetDataSet;
            // 
            // adoraDBSetDataSet
            // 
            this.adoraDBSetDataSet.DataSetName = "adoraDBSetDataSet";
            this.adoraDBSetDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // showBnSDetailsTableAdapter
            // 
            this.showBnSDetailsTableAdapter.ClearBeforeFill = true;
            // 
            // shipmentNameDataGridViewTextBoxColumn
            // 
            this.shipmentNameDataGridViewTextBoxColumn.DataPropertyName = "Shipment Name";
            this.shipmentNameDataGridViewTextBoxColumn.HeaderText = "Shipment Name";
            this.shipmentNameDataGridViewTextBoxColumn.MinimumWidth = 100;
            this.shipmentNameDataGridViewTextBoxColumn.Name = "shipmentNameDataGridViewTextBoxColumn";
            this.shipmentNameDataGridViewTextBoxColumn.ReadOnly = true;
            this.shipmentNameDataGridViewTextBoxColumn.Width = 300;
            // 
            // frequencyDateDataGridViewTextBoxColumn
            // 
            this.frequencyDateDataGridViewTextBoxColumn.DataPropertyName = "Frequency Date";
            this.frequencyDateDataGridViewTextBoxColumn.HeaderText = "Frequency Date";
            this.frequencyDateDataGridViewTextBoxColumn.Name = "frequencyDateDataGridViewTextBoxColumn";
            this.frequencyDateDataGridViewTextBoxColumn.ReadOnly = true;
            this.frequencyDateDataGridViewTextBoxColumn.Width = 300;
            // 
            // frequencyNoDataGridViewTextBoxColumn
            // 
            this.frequencyNoDataGridViewTextBoxColumn.DataPropertyName = "Frequency No";
            this.frequencyNoDataGridViewTextBoxColumn.HeaderText = "Frequency No";
            this.frequencyNoDataGridViewTextBoxColumn.Name = "frequencyNoDataGridViewTextBoxColumn";
            this.frequencyNoDataGridViewTextBoxColumn.ReadOnly = true;
            this.frequencyNoDataGridViewTextBoxColumn.Width = 150;
            // 
            // numberOfPiecesDataGridViewTextBoxColumn
            // 
            this.numberOfPiecesDataGridViewTextBoxColumn.DataPropertyName = "Number of Pieces";
            this.numberOfPiecesDataGridViewTextBoxColumn.HeaderText = "Number of Pieces";
            this.numberOfPiecesDataGridViewTextBoxColumn.Name = "numberOfPiecesDataGridViewTextBoxColumn";
            this.numberOfPiecesDataGridViewTextBoxColumn.ReadOnly = true;
            this.numberOfPiecesDataGridViewTextBoxColumn.Width = 150;
            // 
            // pricePerPieceDataGridViewTextBoxColumn
            // 
            this.pricePerPieceDataGridViewTextBoxColumn.DataPropertyName = "Price per piece";
            this.pricePerPieceDataGridViewTextBoxColumn.HeaderText = "Price per piece";
            this.pricePerPieceDataGridViewTextBoxColumn.Name = "pricePerPieceDataGridViewTextBoxColumn";
            this.pricePerPieceDataGridViewTextBoxColumn.ReadOnly = true;
            this.pricePerPieceDataGridViewTextBoxColumn.Width = 150;
            // 
            // totalGrossDataGridViewTextBoxColumn
            // 
            this.totalGrossDataGridViewTextBoxColumn.DataPropertyName = "Total Gross";
            this.totalGrossDataGridViewTextBoxColumn.HeaderText = "Total Gross";
            this.totalGrossDataGridViewTextBoxColumn.Name = "totalGrossDataGridViewTextBoxColumn";
            this.totalGrossDataGridViewTextBoxColumn.ReadOnly = true;
            this.totalGrossDataGridViewTextBoxColumn.Width = 150;
            // 
            // StockLotsSalesSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1247, 846);
            this.Controls.Add(this.dataGridView1);
            this.Name = "StockLotsSalesSearch";
            this.Text = "StockLotsSalesSearch";
            this.Load += new System.EventHandler(this.StockLotsSalesSearch_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.showBnSDetailsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.adoraDBSetDataSet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private adoraDBSetDataSet adoraDBSetDataSet;
        private System.Windows.Forms.BindingSource showBnSDetailsBindingSource;
        private adoraDBSetDataSetTableAdapters.showBnSDetailsTableAdapter showBnSDetailsTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn shipmentNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn frequencyDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn frequencyNoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn numberOfPiecesDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn pricePerPieceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn totalGrossDataGridViewTextBoxColumn;
    }
}