Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Text
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Dragging
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraGrid
Imports System.Drawing
Imports System.Windows.Forms
Imports System.Reflection
Imports DevExpress.XtraGrid.Views.Grid.ViewInfo
Imports DevExpress.XtraGrid.Columns

Namespace MyXtraGrid
	Public Interface IDragObjectTarget
        Sub DoDragDropFromOutside(ByVal dragObject As Object)
		Sub DoDragging(ByVal drag As Object, ByVal size As Size, ByVal screenPoint As Point)
		Sub CancelDrag(ByVal dragObject As Object)
		Sub StopDrag()
	End Interface

	Public Interface IDragObjectTargetView
		Sub DoStartDragObject(ByVal drag As Object, ByVal size As Size, ByVal screenPoint As Point)
	End Interface

	Public Class MyDragController
		Inherits DragController
		Public Sub New(ByVal grid As GridControl)
			MyBase.New(grid)
		End Sub

		Friend IsDraggingFromOutside As Boolean = False

		Public Overridable Sub StartDraggingObjectFromOutside(ByVal manager As DragManager, ByVal args As DragStartArgs)
			If ActiveDragManager IsNot Nothing Then
				CancelDrag()
			End If
			Dim fi As FieldInfo = GetType(DragController).GetField("activeDragManager", BindingFlags.NonPublic Or BindingFlags.Instance)
			fi.SetValue(Me, manager)
			If ActiveDragManager IsNot Nothing Then
				ActiveDragManager.StartDragging(args)
				IsDraggingFromOutside = True
			End If
		End Sub

		Public Overridable Sub CancelDragObjectFromOutside(ByVal dragObject As Object)
			ActiveDragManager.DragObject = dragObject
			CancelDrag()
			IsDraggingFromOutside = False
		End Sub

		Public Overridable Sub StopDragObjectFromOutside()
			Dim view As MyGridView = TryCast(ActiveDragManager.View, MyGridView)
			view.LockDragDropEvents()
			Try
				CancelDrag()
				IsDraggingFromOutside = False
			Finally
				view.UnLockDragDropEvents()
			End Try
		End Sub

		Public Overridable Sub EndDragObjectFromOutside(ByVal dragObject As Object)
			ActiveDragManager.DragObject = dragObject
			MyBase.EndDrag(New MouseEventArgs(MouseButtons.Left, 0, 0, 0, 0))
			IsDraggingFromOutside = False
		End Sub
	End Class

	Public Class AdvDragStartArgs
		Inherits GridDragStartArgs
		Public Sub New(ByVal startHitInfo As GridHitInfo, ByVal dragObject As Object, ByVal bmp As Bitmap, ByVal startPoint As Point, ByVal allowedEffects As DragDropEffects, ByVal isOutside As Boolean)
			MyBase.New(startHitInfo, dragObject, bmp, startPoint, allowedEffects)
			_isOutside = isOutside
		End Sub
		Private _isOutside As Boolean = False
		Public ReadOnly Property IsOutside() As Boolean
			Get
				Return _isOutside
			End Get
		End Property
	End Class

	Public Class MyGridDragManager
		Inherits GridDragManager
		Public Sub New(ByVal view As GridView)
			MyBase.New(view)
		End Sub
		Protected Overrides Function CreateColumnPositionInfo() As ColumnPositionInfo
			Return New MyColumnPositionInfo()
		End Function

		Public Overrides Sub ShowDropTargetHighlighting()
			MyBase.ShowDropTargetHighlighting()
		End Sub

		Private draggedColumn As GridColumn = Nothing

		Public Overrides Sub StartDragging(ByVal args As DragStartArgs)
			Dim ee As AdvDragStartArgs = TryCast(args, AdvDragStartArgs)
			If ee IsNot Nothing AndAlso ee.IsOutside Then
				ClearLastPosition()
				draggedColumn = (TryCast(View, MyGridView)).Columns.AddField("@#$")
				draggedColumn.Tag = GridControl.InvalidRowHandle
				Me.DragObject = draggedColumn
			Else
				MyBase.StartDragging(args)
			End If
		End Sub

		Private currentTarget As IDragObjectTarget = Nothing

		Public Overrides Sub DoDragging(ByVal screenPoint As Point)
			MyBase.DoDragging(screenPoint)
			Dim f As Form = View.GridControl.FindForm()
			Dim target As IDragObjectTarget = TryCast(f.GetChildAtPoint(f.PointToClient(screenPoint)), IDragObjectTarget)

			If target IsNot Nothing AndAlso (Not View.GridControl.Equals(target)) Then
				If currentTarget IsNot target Then
					If currentTarget IsNot Nothing Then
						currentTarget.StopDrag()
					End If
					currentTarget = target
				End If
				target.DoDragging(DragObject, Size.Empty, screenPoint)
			Else
				If currentTarget IsNot Nothing Then
					currentTarget.StopDrag()
				End If
				currentTarget = Nothing
			End If
		End Sub

		Public ReadOnly Property IsDraggingFromOutside() As Boolean
			Get
				Return (TryCast(View.GridControl, MyGridControl)).GetDragController().IsDraggingFromOutside
			End Get
		End Property

		Protected Overrides Sub StopDragging(ByVal hideDrag As Boolean)
			MyBase.StopDragging((Not IsDraggingFromOutside))
			If draggedColumn IsNot Nothing Then
				draggedColumn.Dispose()
				draggedColumn = Nothing
			End If
			currentTarget = Nothing
		End Sub

		Public Overrides Sub EndDrag()
			If currentTarget IsNot Nothing Then
                currentTarget.DoDragDropFromOutside(DragObject)
				currentTarget = Nothing
			End If
			MyBase.EndDrag()
		End Sub

		Public Overrides Sub CancelDrag()
			If currentTarget IsNot Nothing Then
				currentTarget.CancelDrag(DragObject)
				currentTarget = Nothing
			End If
			MyBase.CancelDrag()
		End Sub

	End Class

	Public Class MyColumnPositionInfo
		Inherits ColumnPositionInfo
		Public Sub New()
			MyBase.New()
		End Sub
		Public Shadows Sub SetIndex(ByVal index As Integer)
			MyBase.SetIndex(index)
		End Sub
	End Class
End Namespace
