Imports Microsoft.VisualBasic
Imports System
Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Registrator
Imports DevExpress.XtraGrid.Dragging
Imports System.Windows.Forms
Imports System.Drawing

Namespace MyXtraGrid
	Public Class MyGridControl
		Inherits GridControl
		Implements IDragObjectTarget
		Public Sub New()
			MyBase.New()
			_dragController = New MyDragController(Me)
		End Sub

		Protected Overrides Function CreateDefaultView() As BaseView
			Return CreateView("MyGridView")
		End Function
		Protected Overrides Sub RegisterAvailableViewsCore(ByVal collection As InfoCollection)
			MyBase.RegisterAvailableViewsCore(collection)
			collection.Add(New MyGridViewInfoRegistrator())
		End Sub

		Private _dragController As MyDragController

		Friend Function GetDragController() As MyDragController
			Return _dragController
		End Function

		Protected Overrides ReadOnly Property DragController() As DragController
			Get
				Return _dragController
			End Get
		End Property


		#Region "IDragObjectTarget Members"

        Private Sub DoDragDropFromOutside(ByVal dragObject As Object) Implements IDragObjectTarget.DoDragDropFromOutside
            _dragController.EndDragObjectFromOutside(dragObject)
        End Sub


        Private Sub DoDragging(ByVal drag As Object, ByVal size As Size, ByVal screenPoint As Point) Implements IDragObjectTarget.DoDragging
            Dim targetView As IDragObjectTargetView = TryCast(GetViewAt(PointToClient(screenPoint)), IDragObjectTargetView)

            If (Not _dragController.IsDragging) Then
                If targetView IsNot Nothing Then
                    targetView.DoStartDragObject(drag, size, screenPoint)
                End If

            Else
                Dim p As Point = PointToClient(screenPoint)
                _dragController.DoDragging(New MouseEventArgs(MouseButtons.Left, 0, p.X, p.Y, 0))
            End If

        End Sub

        Private Sub CancelDrag(ByVal dragObject As Object) Implements IDragObjectTarget.CancelDrag
            _dragController.CancelDragObjectFromOutside(dragObject)
        End Sub

        Private Sub StopDrag() Implements IDragObjectTarget.StopDrag
            _dragController.StopDragObjectFromOutside()
        End Sub

#End Region
    End Class
End Namespace
