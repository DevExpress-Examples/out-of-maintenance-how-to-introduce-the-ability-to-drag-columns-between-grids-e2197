Imports Microsoft.VisualBasic
Imports System
Imports DevExpress.XtraGrid.Views.Grid
Imports System.Drawing
Imports DevExpress.XtraGrid.Columns
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Dragging

Namespace MyXtraGrid
	Public Class MyGridView
		Inherits DevExpress.XtraGrid.Views.Grid.GridView
		Implements IDragObjectTargetView
		Public Sub New()
			Me.New(Nothing)
		End Sub
		Public Sub New(ByVal grid As DevExpress.XtraGrid.GridControl)
			MyBase.New(grid)
			' put your initialization code here
		End Sub
		Protected Overrides ReadOnly Property ViewName() As String
			Get
				Return "MyGridView"
			End Get
		End Property

		Protected Friend Sub SetStateCore(ByVal state As GridState)
			SetState(CInt(Fix(state)))
		End Sub


		Public Overrides Function CanSortColumn(ByVal column As GridColumn) As Boolean
			If column.Tag IsNot Nothing AndAlso Object.Equals(column.Tag, InvalidRowHandle) Then
				Return True
			End If
			Return MyBase.CanSortColumn(column)
		End Function

		Public Overrides Function CanGroupColumn(ByVal column As GridColumn) As Boolean
			If column.Tag IsNot Nothing AndAlso Object.Equals(column.Tag, InvalidRowHandle) Then
				Return True
			End If
			Return MyBase.CanGroupColumn(column)
		End Function

		Protected Overrides Sub OnColumnsCollectionChanged(ByVal sender As Object, ByVal e As System.ComponentModel.CollectionChangeEventArgs)
			Dim grid As MyGridControl = (TryCast(GridControl, MyGridControl))
			Dim controller As DragController
			If (grid IsNot Nothing) Then
				controller = grid.GetDragController()
			Else
				controller = Nothing
			End If
			If controller IsNot Nothing AndAlso controller.IsDragging Then
				Return
			End If
			MyBase.OnColumnsCollectionChanged(sender, e)
		End Sub

		#Region "IDragObjectTargetView Members"

		Private Sub DoStartDragObject(ByVal drag As Object, ByVal size As Size, ByVal screenPoint As Point) Implements IDragObjectTargetView.DoStartDragObject
			TryCast(Handler, MyGridHandler).DoStartDragObjectFromOutside(drag, size, screenPoint)
		End Sub

		#End Region

		Private dragDropEventsLockCount As Integer = 0

		Protected Friend Sub LockDragDropEvents()
			dragDropEventsLockCount += 1
		End Sub

		Protected Friend Sub UnLockDragDropEvents()
			If dragDropEventsLockCount > 0 Then
				dragDropEventsLockCount -= 1
			End If
		End Sub

		Friend ReadOnly Property IsDragDropEventLocked() As Boolean
			Get
				Return dragDropEventsLockCount > 0
			End Get
		End Property
		Protected Overrides Sub RaiseDragObjectDrop(ByVal e As DragObjectDropEventArgs)
			If IsDragDropEventLocked Then
				Return
			End If
			MyBase.RaiseDragObjectDrop(e)
		End Sub
	End Class
End Namespace
