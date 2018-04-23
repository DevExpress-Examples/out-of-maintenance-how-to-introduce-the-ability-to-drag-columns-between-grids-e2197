Imports Microsoft.VisualBasic
Imports System
Imports System.Windows.Forms
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraGrid.Dragging
Imports DevExpress.XtraGrid.Views.Base
Imports System.Drawing
Imports DevExpress.XtraGrid.Views.Grid.Drawing
Imports DevExpress.XtraGrid.Columns
Imports DevExpress.XtraGrid

Namespace MyXtraGrid
	Public Class MyGridHandler
		Inherits DevExpress.XtraGrid.Views.Grid.Handler.GridHandler
		Public Sub New(ByVal gridView As GridView)
			MyBase.New(gridView)
		End Sub

		Protected Overrides Sub OnKeyDown(ByVal e As KeyEventArgs)
			MyBase.OnKeyDown(e)
            If e.KeyData = Keys.Delete AndAlso View.State = GridState.Normal Then
                View.DeleteRow(View.FocusedRowHandle)
            End If
		End Sub

		Protected Overrides Function CreateDragManager() As GridDragManager
			Return New MyGridDragManager(View)
		End Function

		Public Overridable Sub DoStartDragObjectFromOutside(ByVal drag As Object, ByVal size As Size, ByVal screenPoint As Point)
			TryCast(View, MyGridView).SetStateCore(GridState.ColumnDragging)
			TryCast(View.GridControl, MyGridControl).GetDragController().StartDraggingObjectFromOutside(DragManager, New AdvDragStartArgs(Nothing, Nothing, Nothing, screenPoint, DragDropEffects.Copy, True))
		End Sub

	End Class

End Namespace
