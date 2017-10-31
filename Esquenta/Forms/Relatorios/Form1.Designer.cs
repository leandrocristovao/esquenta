namespace Esquenta.Forms.Relatorios
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
            this.components = new System.ComponentModel.Container();
            DevExpress.XtraGrid.GridLevelNode gridLevelNode1 = new DevExpress.XtraGrid.GridLevelNode();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colID1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colVenda_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colProduto_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colQuantidade = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDataVenda1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colValor = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.vendaBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.vendasMDDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.vendasMDDataSet = new Esquenta.VendasMDDataSet();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colComanda_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDataVenda = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colValorTotal = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colValorDesconto = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colValorAcrescimo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colValorFinal = new DevExpress.XtraGrid.Columns.GridColumn();
            this.vendaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.produtoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.vendaTableAdapter = new Esquenta.VendasMDDataSetTableAdapters.VendaTableAdapter();
            this.itemVendaTableAdapter1 = new Esquenta.VendasMDDataSetTableAdapters.ItemVendaTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vendaBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vendasMDDataSetBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vendasMDDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vendaBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.produtoBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // gridView2
            // 
            this.gridView2.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colID1,
            this.colVenda_ID,
            this.colProduto_ID,
            this.colQuantidade,
            this.colDataVenda1,
            this.colValor});
            this.gridView2.GridControl = this.gridControl1;
            this.gridView2.Name = "gridView2";
            // 
            // colID1
            // 
            this.colID1.FieldName = "ID";
            this.colID1.Name = "colID1";
            // 
            // colVenda_ID
            // 
            this.colVenda_ID.FieldName = "Venda_ID";
            this.colVenda_ID.Name = "colVenda_ID";
            // 
            // colProduto_ID
            // 
            this.colProduto_ID.FieldName = "Produto_ID";
            this.colProduto_ID.Name = "colProduto_ID";
            this.colProduto_ID.Visible = true;
            this.colProduto_ID.VisibleIndex = 0;
            // 
            // colQuantidade
            // 
            this.colQuantidade.FieldName = "Quantidade";
            this.colQuantidade.Name = "colQuantidade";
            this.colQuantidade.Visible = true;
            this.colQuantidade.VisibleIndex = 1;
            // 
            // colDataVenda1
            // 
            this.colDataVenda1.FieldName = "DataVenda";
            this.colDataVenda1.Name = "colDataVenda1";
            // 
            // colValor
            // 
            this.colValor.FieldName = "Valor";
            this.colValor.Name = "colValor";
            this.colValor.Visible = true;
            this.colValor.VisibleIndex = 2;
            // 
            // gridControl1
            // 
            this.gridControl1.DataSource = this.vendaBindingSource1;
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            gridLevelNode1.LevelTemplate = this.gridView2;
            gridLevelNode1.RelationName = "FK_ItemVenda__Venda_ID";
            this.gridControl1.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
            gridLevelNode1});
            this.gridControl1.Location = new System.Drawing.Point(0, 0);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(429, 356);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1,
            this.gridView2});
            // 
            // vendaBindingSource1
            // 
            this.vendaBindingSource1.DataMember = "Venda";
            this.vendaBindingSource1.DataSource = this.vendasMDDataSetBindingSource;
            // 
            // vendasMDDataSetBindingSource
            // 
            this.vendasMDDataSetBindingSource.DataSource = this.vendasMDDataSet;
            this.vendasMDDataSetBindingSource.Position = 0;
            // 
            // vendasMDDataSet
            // 
            this.vendasMDDataSet.DataSetName = "VendasMDDataSet";
            this.vendasMDDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colID,
            this.colComanda_ID,
            this.colDataVenda,
            this.colValorTotal,
            this.colValorDesconto,
            this.colValorAcrescimo,
            this.colValorFinal});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ShowFooter = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // colID
            // 
            this.colID.FieldName = "ID";
            this.colID.Name = "colID";
            this.colID.OptionsColumn.AllowEdit = false;
            // 
            // colComanda_ID
            // 
            this.colComanda_ID.FieldName = "Comanda_ID";
            this.colComanda_ID.Name = "colComanda_ID";
            this.colComanda_ID.OptionsColumn.AllowEdit = false;
            // 
            // colDataVenda
            // 
            this.colDataVenda.FieldName = "DataVenda";
            this.colDataVenda.Name = "colDataVenda";
            this.colDataVenda.Visible = true;
            this.colDataVenda.VisibleIndex = 0;
            // 
            // colValorTotal
            // 
            this.colValorTotal.FieldName = "ValorTotal";
            this.colValorTotal.Name = "colValorTotal";
            this.colValorTotal.Visible = true;
            this.colValorTotal.VisibleIndex = 1;
            // 
            // colValorDesconto
            // 
            this.colValorDesconto.FieldName = "ValorDesconto";
            this.colValorDesconto.Name = "colValorDesconto";
            this.colValorDesconto.Visible = true;
            this.colValorDesconto.VisibleIndex = 2;
            // 
            // colValorAcrescimo
            // 
            this.colValorAcrescimo.FieldName = "ValorAcrescimo";
            this.colValorAcrescimo.Name = "colValorAcrescimo";
            this.colValorAcrescimo.Visible = true;
            this.colValorAcrescimo.VisibleIndex = 4;
            // 
            // colValorFinal
            // 
            this.colValorFinal.FieldName = "ValorFinal";
            this.colValorFinal.Name = "colValorFinal";
            this.colValorFinal.Visible = true;
            this.colValorFinal.VisibleIndex = 3;
            // 
            // vendaBindingSource
            // 
            this.vendaBindingSource.DataSource = typeof(Esquenta.Entities.Venda);
            // 
            // produtoBindingSource
            // 
            this.produtoBindingSource.DataSource = typeof(Esquenta.Entities.Produto);
            // 
            // vendaTableAdapter
            // 
            this.vendaTableAdapter.ClearBeforeFill = true;
            // 
            // itemVendaTableAdapter1
            // 
            this.itemVendaTableAdapter1.ClearBeforeFill = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(429, 356);
            this.Controls.Add(this.gridControl1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vendaBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vendasMDDataSetBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vendasMDDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vendaBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.produtoBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.BindingSource produtoBindingSource;
        private System.Windows.Forms.BindingSource vendaBindingSource;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private System.Windows.Forms.BindingSource vendasMDDataSetBindingSource;
        private VendasMDDataSet vendasMDDataSet;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private System.Windows.Forms.BindingSource vendaBindingSource1;
        private VendasMDDataSetTableAdapters.VendaTableAdapter vendaTableAdapter;
        private DevExpress.XtraGrid.Columns.GridColumn colID;
        private DevExpress.XtraGrid.Columns.GridColumn colComanda_ID;
        private DevExpress.XtraGrid.Columns.GridColumn colDataVenda;
        private DevExpress.XtraGrid.Columns.GridColumn colValorTotal;
        private DevExpress.XtraGrid.Columns.GridColumn colValorDesconto;
        private DevExpress.XtraGrid.Columns.GridColumn colValorFinal;
        private DevExpress.XtraGrid.Columns.GridColumn colValorAcrescimo;
        private VendasMDDataSetTableAdapters.ItemVendaTableAdapter itemVendaTableAdapter1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private DevExpress.XtraGrid.Columns.GridColumn colID1;
        private DevExpress.XtraGrid.Columns.GridColumn colVenda_ID;
        private DevExpress.XtraGrid.Columns.GridColumn colProduto_ID;
        private DevExpress.XtraGrid.Columns.GridColumn colQuantidade;
        private DevExpress.XtraGrid.Columns.GridColumn colDataVenda1;
        private DevExpress.XtraGrid.Columns.GridColumn colValor;
    }
}