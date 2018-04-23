Imports Microsoft.VisualBasic
Imports System
Namespace MyXtraGrid
	Partial Public Class Form1
		''' <summary>
		''' Required designer variable.
		''' </summary>
		Private components As System.ComponentModel.IContainer = Nothing

		''' <summary>
		''' Clean up any resources being used.
		''' </summary>
		''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		Protected Overrides Sub Dispose(ByVal disposing As Boolean)
			If disposing AndAlso (components IsNot Nothing) Then
				components.Dispose()
			End If
			MyBase.Dispose(disposing)
		End Sub

		#Region "Windows Form Designer generated code"

		''' <summary>
		''' Required method for Designer support - do not modify
		''' the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
			Me.components = New System.ComponentModel.Container()
			Me.dataSet1 = New System.Data.DataSet()
			Me.dataTable1 = New System.Data.DataTable()
			Me.dataColumn1 = New System.Data.DataColumn()
			Me.dataColumn2 = New System.Data.DataColumn()
			Me.dataColumn3 = New System.Data.DataColumn()
			Me.myGridControl1 = New MyXtraGrid.MyGridControl()
			Me.bindingSource1 = New System.Windows.Forms.BindingSource(Me.components)
			Me.myGridView1 = New MyXtraGrid.MyGridView()
			Me.colColumn1 = New DevExpress.XtraGrid.Columns.GridColumn()
			Me.colColumn2 = New DevExpress.XtraGrid.Columns.GridColumn()
			Me.colColumn3 = New DevExpress.XtraGrid.Columns.GridColumn()
			Me.myGridControl2 = New MyXtraGrid.MyGridControl()
			Me.myGridView2 = New MyXtraGrid.MyGridView()
			Me.simpleButton1 = New DevExpress.XtraEditors.SimpleButton()
			CType(Me.dataSet1, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.dataTable1, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.myGridControl1, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.bindingSource1, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.myGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.myGridControl2, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.myGridView2, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.SuspendLayout()
			' 
			' dataSet1
			' 
			Me.dataSet1.DataSetName = "NewDataSet"
			Me.dataSet1.Locale = New System.Globalization.CultureInfo("en-US")
			Me.dataSet1.Tables.AddRange(New System.Data.DataTable() { Me.dataTable1})
			' 
			' dataTable1
			' 
			Me.dataTable1.Columns.AddRange(New System.Data.DataColumn() { Me.dataColumn1, Me.dataColumn2, Me.dataColumn3})
			Me.dataTable1.TableName = "Table1"
			' 
			' dataColumn1
			' 
			Me.dataColumn1.ColumnName = "Column1"
			' 
			' dataColumn2
			' 
			Me.dataColumn2.ColumnName = "Column2"
			' 
			' dataColumn3
			' 
			Me.dataColumn3.ColumnName = "Column3"
			' 
			' myGridControl1
			' 
			Me.myGridControl1.DataSource = Me.bindingSource1
			Me.myGridControl1.Dock = System.Windows.Forms.DockStyle.Top
			Me.myGridControl1.Location = New System.Drawing.Point(0, 0)
			Me.myGridControl1.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat
			Me.myGridControl1.LookAndFeel.UseDefaultLookAndFeel = False
			Me.myGridControl1.MainView = Me.myGridView1
			Me.myGridControl1.Name = "myGridControl1"
			Me.myGridControl1.Size = New System.Drawing.Size(437, 162)
			Me.myGridControl1.TabIndex = 1
			Me.myGridControl1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() { Me.myGridView1})
			' 
			' bindingSource1
			' 
			Me.bindingSource1.DataMember = "Table1"
			Me.bindingSource1.DataSource = Me.dataSet1
			' 
			' myGridView1
			' 
			Me.myGridView1.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() { Me.colColumn1, Me.colColumn2, Me.colColumn3})
			Me.myGridView1.GridControl = Me.myGridControl1
			Me.myGridView1.Name = "myGridView1"
'			Me.myGridView1.DragObjectOver += New DevExpress.XtraGrid.Views.Base.DragObjectOverEventHandler(Me.myGridView2_DragObjectOver);
'			Me.myGridView1.DragObjectDrop += New DevExpress.XtraGrid.Views.Base.DragObjectDropEventHandler(Me.myGridView2_DragObjectDrop);
			' 
			' colColumn1
			' 
			Me.colColumn1.FieldName = "Column1"
			Me.colColumn1.Name = "colColumn1"
			Me.colColumn1.Visible = True
			Me.colColumn1.VisibleIndex = 0
			' 
			' colColumn2
			' 
			Me.colColumn2.FieldName = "Column2"
			Me.colColumn2.Name = "colColumn2"
			Me.colColumn2.Visible = True
			Me.colColumn2.VisibleIndex = 1
			' 
			' colColumn3
			' 
			Me.colColumn3.FieldName = "Column3"
			Me.colColumn3.Name = "colColumn3"
			Me.colColumn3.Visible = True
			Me.colColumn3.VisibleIndex = 2
			' 
			' myGridControl2
			' 
			Me.myGridControl2.DataSource = Me.bindingSource1
			Me.myGridControl2.Dock = System.Windows.Forms.DockStyle.Top
			Me.myGridControl2.Location = New System.Drawing.Point(0, 162)
			Me.myGridControl2.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat
			Me.myGridControl2.LookAndFeel.UseDefaultLookAndFeel = False
			Me.myGridControl2.MainView = Me.myGridView2
			Me.myGridControl2.Name = "myGridControl2"
			Me.myGridControl2.Size = New System.Drawing.Size(437, 191)
			Me.myGridControl2.TabIndex = 2
			Me.myGridControl2.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() { Me.myGridView2})
			' 
			' myGridView2
			' 
			Me.myGridView2.GridControl = Me.myGridControl2
			Me.myGridView2.Name = "myGridView2"
			Me.myGridView2.OptionsBehavior.AutoPopulateColumns = False
'			Me.myGridView2.DragObjectOver += New DevExpress.XtraGrid.Views.Base.DragObjectOverEventHandler(Me.myGridView2_DragObjectOver);
'			Me.myGridView2.DragObjectDrop += New DevExpress.XtraGrid.Views.Base.DragObjectDropEventHandler(Me.myGridView2_DragObjectDrop);
			' 
			' simpleButton1
			' 
			Me.simpleButton1.Location = New System.Drawing.Point(83, 382)
			Me.simpleButton1.Name = "simpleButton1"
			Me.simpleButton1.Size = New System.Drawing.Size(75, 23)
			Me.simpleButton1.TabIndex = 3
			Me.simpleButton1.Text = "simpleButton1"
			' 
			' Form1
			' 
			Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
			Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
			Me.ClientSize = New System.Drawing.Size(437, 446)
			Me.Controls.Add(Me.simpleButton1)
			Me.Controls.Add(Me.myGridControl2)
			Me.Controls.Add(Me.myGridControl1)
			Me.Name = "Form1"
			Me.Text = "Form1"
'			Me.Load += New System.EventHandler(Me.Form1_Load);
			CType(Me.dataSet1, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.dataTable1, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.myGridControl1, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.bindingSource1, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.myGridView1, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.myGridControl2, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.myGridView2, System.ComponentModel.ISupportInitialize).EndInit()
			Me.ResumeLayout(False)

		End Sub

		#End Region

		Private dataSet1 As System.Data.DataSet
		Private dataTable1 As System.Data.DataTable
		Private dataColumn1 As System.Data.DataColumn
		Private myGridControl1 As MyGridControl
		Private bindingSource1 As System.Windows.Forms.BindingSource
		Private WithEvents myGridView1 As MyGridView
		Private dataColumn2 As System.Data.DataColumn
		Private dataColumn3 As System.Data.DataColumn
		Private myGridControl2 As MyGridControl
		Private WithEvents myGridView2 As MyGridView
		Private colColumn1 As DevExpress.XtraGrid.Columns.GridColumn
		Private colColumn2 As DevExpress.XtraGrid.Columns.GridColumn
		Private colColumn3 As DevExpress.XtraGrid.Columns.GridColumn
		Private simpleButton1 As DevExpress.XtraEditors.SimpleButton
	End Class
End Namespace

