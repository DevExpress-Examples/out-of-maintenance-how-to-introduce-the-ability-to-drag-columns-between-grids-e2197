Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms
Imports DevExpress.XtraGrid.Columns
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraGrid.Dragging

Namespace MyXtraGrid
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
			For i As Integer = 0 To 9
				dataTable1.Rows.Add(New Object() { "Item Wg " & i.ToString() })
			Next i
		End Sub

		Private Sub myGridView2_DragObjectDrop(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Base.DragObjectDropEventArgs) Handles myGridView1.DragObjectDrop, myGridView2.DragObjectDrop
			If e.DropInfo.Valid AndAlso (Not e.Canceled) AndAlso TypeOf e.DragObject Is GridColumn AndAlso (CType(e.DragObject, GridColumn)).View IsNot sender Then
				TryCast(sender, GridView).BeginUpdate()
				Try
					Dim sourceCol As GridColumn = TryCast(e.DragObject, GridColumn)
					Dim column As GridColumn = (TryCast(sender, GridView)).Columns.ColumnByFieldName(sourceCol.FieldName)
					If column Is Nothing Then
						column = (TryCast(sender, GridView)).Columns.AddField(sourceCol.FieldName)
					End If
					If (CType(e.DropInfo, ColumnPositionInfo)).InGroupPanel Then
						column.Group()
						column.GroupIndex = e.DropInfo.Index
					Else
						column.VisibleIndex = e.DropInfo.Index
					End If
				Finally
					TryCast(sender, GridView).EndDataUpdate()
				End Try
			End If
		End Sub

		Private Sub myGridView2_DragObjectOver(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Base.DragObjectOverEventArgs) Handles myGridView1.DragObjectOver, myGridView2.DragObjectOver
			If TypeOf e.DragObject Is GridColumn AndAlso (CType(e.DragObject, GridColumn)).View IsNot sender Then
				e.DropInfo.Valid = Not((TryCast(e.DropInfo, ColumnPositionInfo)).InGroupPanel OrElse ((TryCast(sender, GridView)).VisibleColumns.Count > 0))
			End If
		End Sub


	End Class
End Namespace