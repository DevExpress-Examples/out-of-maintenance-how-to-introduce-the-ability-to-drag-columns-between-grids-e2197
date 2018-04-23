using System;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Registrator;
using DevExpress.XtraGrid.Dragging;
using System.Windows.Forms;
using System.Drawing;

namespace MyXtraGrid {
    public class MyGridControl : GridControl, IDragObjectTarget
    {
        public MyGridControl() : base() { 
            _dragController = new MyDragController(this);
        }

		protected override BaseView CreateDefaultView() {
			return CreateView("MyGridView");
		}
		protected override void RegisterAvailableViewsCore(InfoCollection collection) {
			base.RegisterAvailableViewsCore(collection);
			collection.Add(new MyGridViewInfoRegistrator());
		}

        private MyDragController _dragController;

        internal MyDragController GetDragController() { return _dragController; }

        protected override DragController DragController { get { return _dragController; } }


        #region IDragObjectTarget Members

        void IDragObjectTarget.DoDragDrop(Object dragObject)
        {
            _dragController.EndDragObjectFromOutside(dragObject);
        }


        void IDragObjectTarget.DoDragging(object drag, Size size, Point screenPoint)
        {
            IDragObjectTargetView targetView = GetViewAt(PointToClient(screenPoint)) as IDragObjectTargetView;

            if (!_dragController.IsDragging)
            {
                if (targetView != null)
                {
                    targetView.DoStartDragObject(drag, size, screenPoint);
                }

            }
            else
            {
                Point p = PointToClient(screenPoint);
                _dragController.DoDragging(new MouseEventArgs(MouseButtons.Left, 0, p.X, p.Y, 0));
            }

        }

        void IDragObjectTarget.CancelDrag(object dragObject)
        {
            _dragController.CancelDragObjectFromOutside(dragObject);
        }

        void IDragObjectTarget.StopDrag()
        {
            _dragController.StopDragObjectFromOutside();
        }

        #endregion
    }
}
