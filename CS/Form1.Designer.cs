namespace MyXtraGrid {
    partial class Form1 {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if(disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            this.dataSet1 = new System.Data.DataSet();
            this.dataTable1 = new System.Data.DataTable();
            this.dataColumn1 = new System.Data.DataColumn();
            this.dataColumn2 = new System.Data.DataColumn();
            this.dataColumn3 = new System.Data.DataColumn();
            this.myGridControl1 = new MyXtraGrid.MyGridControl();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.myGridView1 = new MyXtraGrid.MyGridView();
            this.colColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.myGridControl2 = new MyXtraGrid.MyGridControl();
            this.myGridView2 = new MyXtraGrid.MyGridView();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTable1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.myGridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.myGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.myGridControl2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.myGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // dataSet1
            // 
            this.dataSet1.DataSetName = "NewDataSet";
            this.dataSet1.Locale = new System.Globalization.CultureInfo("en-US");
            this.dataSet1.Tables.AddRange(new System.Data.DataTable[] {
            this.dataTable1});
            // 
            // dataTable1
            // 
            this.dataTable1.Columns.AddRange(new System.Data.DataColumn[] {
            this.dataColumn1,
            this.dataColumn2,
            this.dataColumn3});
            this.dataTable1.TableName = "Table1";
            // 
            // dataColumn1
            // 
            this.dataColumn1.ColumnName = "Column1";
            // 
            // dataColumn2
            // 
            this.dataColumn2.ColumnName = "Column2";
            // 
            // dataColumn3
            // 
            this.dataColumn3.ColumnName = "Column3";
            // 
            // myGridControl1
            // 
            this.myGridControl1.DataSource = this.bindingSource1;
            this.myGridControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.myGridControl1.Location = new System.Drawing.Point(0, 0);
            this.myGridControl1.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
            this.myGridControl1.LookAndFeel.UseDefaultLookAndFeel = false;
            this.myGridControl1.MainView = this.myGridView1;
            this.myGridControl1.Name = "myGridControl1";
            this.myGridControl1.Size = new System.Drawing.Size(437, 162);
            this.myGridControl1.TabIndex = 1;
            this.myGridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.myGridView1});
            // 
            // bindingSource1
            // 
            this.bindingSource1.DataMember = "Table1";
            this.bindingSource1.DataSource = this.dataSet1;
            // 
            // myGridView1
            // 
            this.myGridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colColumn1,
            this.colColumn2,
            this.colColumn3});
            this.myGridView1.GridControl = this.myGridControl1;
            this.myGridView1.Name = "myGridView1";
            this.myGridView1.DragObjectOver += new DevExpress.XtraGrid.Views.Base.DragObjectOverEventHandler(this.myGridView2_DragObjectOver);
            this.myGridView1.DragObjectDrop += new DevExpress.XtraGrid.Views.Base.DragObjectDropEventHandler(this.myGridView2_DragObjectDrop);
            // 
            // colColumn1
            // 
            this.colColumn1.FieldName = "Column1";
            this.colColumn1.Name = "colColumn1";
            this.colColumn1.Visible = true;
            this.colColumn1.VisibleIndex = 0;
            // 
            // colColumn2
            // 
            this.colColumn2.FieldName = "Column2";
            this.colColumn2.Name = "colColumn2";
            this.colColumn2.Visible = true;
            this.colColumn2.VisibleIndex = 1;
            // 
            // colColumn3
            // 
            this.colColumn3.FieldName = "Column3";
            this.colColumn3.Name = "colColumn3";
            this.colColumn3.Visible = true;
            this.colColumn3.VisibleIndex = 2;
            // 
            // myGridControl2
            // 
            this.myGridControl2.DataSource = this.bindingSource1;
            this.myGridControl2.Dock = System.Windows.Forms.DockStyle.Top;
            this.myGridControl2.Location = new System.Drawing.Point(0, 162);
            this.myGridControl2.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
            this.myGridControl2.LookAndFeel.UseDefaultLookAndFeel = false;
            this.myGridControl2.MainView = this.myGridView2;
            this.myGridControl2.Name = "myGridControl2";
            this.myGridControl2.Size = new System.Drawing.Size(437, 191);
            this.myGridControl2.TabIndex = 2;
            this.myGridControl2.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.myGridView2});
            // 
            // myGridView2
            // 
            this.myGridView2.GridControl = this.myGridControl2;
            this.myGridView2.Name = "myGridView2";
            this.myGridView2.OptionsBehavior.AutoPopulateColumns = false;
            this.myGridView2.DragObjectOver += new DevExpress.XtraGrid.Views.Base.DragObjectOverEventHandler(this.myGridView2_DragObjectOver);
            this.myGridView2.DragObjectDrop += new DevExpress.XtraGrid.Views.Base.DragObjectDropEventHandler(this.myGridView2_DragObjectDrop);
            // 
            // simpleButton1
            // 
            this.simpleButton1.Location = new System.Drawing.Point(83, 382);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(75, 23);
            this.simpleButton1.TabIndex = 3;
            this.simpleButton1.Text = "simpleButton1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(437, 446);
            this.Controls.Add(this.simpleButton1);
            this.Controls.Add(this.myGridControl2);
            this.Controls.Add(this.myGridControl1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTable1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.myGridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.myGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.myGridControl2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.myGridView2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Data.DataSet dataSet1;
        private System.Data.DataTable dataTable1;
        private System.Data.DataColumn dataColumn1;
        private MyGridControl myGridControl1;
        private System.Windows.Forms.BindingSource bindingSource1;
        private MyGridView myGridView1;
        private System.Data.DataColumn dataColumn2;
        private System.Data.DataColumn dataColumn3;
        private MyGridControl myGridControl2;
        private MyGridView myGridView2;
        private DevExpress.XtraGrid.Columns.GridColumn colColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn colColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn colColumn3;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
    }
}

