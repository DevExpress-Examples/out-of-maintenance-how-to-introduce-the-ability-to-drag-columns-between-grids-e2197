using System;
using System.Collections.Generic;
using System.Text;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Dragging;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid;
using System.Drawing;
using System.Windows.Forms;
using System.Reflection;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraGrid.Columns;

namespace MyXtraGrid
{
    public interface IDragObjectTarget {
        void DoDragDrop(object dragObject);
        void DoDragging(object drag, Size size, Point screenPoint);
        void CancelDrag(object dragObject);
        void StopDrag();
    }

    public interface IDragObjectTargetView {
        void DoStartDragObject(object drag, Size size, Point screenPoint);
    }

    public class MyDragController : DragController {
        public MyDragController(GridControl grid) : base(grid) { }

        internal bool IsDraggingFromOutside = false;

        public virtual void StartDraggingObjectFromOutside(DragManager manager, DragStartArgs args)
        {
            if (ActiveDragManager != null) CancelDrag();
            FieldInfo fi = typeof(DragController).GetField("activeDragManager", BindingFlags.NonPublic | BindingFlags.Instance);
            fi.SetValue(this, manager);
            if (ActiveDragManager != null) {
                ActiveDragManager.StartDragging(args);
                IsDraggingFromOutside = true;
            }
        }

        public virtual void CancelDragObjectFromOutside(object dragObject)
        {
            ActiveDragManager.DragObject = dragObject;
            CancelDrag();
            IsDraggingFromOutside = false;
        }

        public virtual void StopDragObjectFromOutside()
        {
            MyGridView view = ActiveDragManager.View as MyGridView;
            view.LockDragDropEvents(); 
            try 
	        {	        
                CancelDrag();
                IsDraggingFromOutside = false;
    	    }
	        finally
	        {
                view.UnLockDragDropEvents();
            }
        }
        
        public virtual void EndDragObjectFromOutside(object dragObject) {
            ActiveDragManager.DragObject = dragObject;
            base.EndDrag(new MouseEventArgs(MouseButtons.Left, 0, 0, 0, 0));
            IsDraggingFromOutside = false;
        }
    }

    public class AdvDragStartArgs : GridDragStartArgs
    {
        public AdvDragStartArgs(GridHitInfo startHitInfo, object dragObject, Bitmap bmp, Point startPoint, DragDropEffects allowedEffects, bool isOutside) : base(startHitInfo, dragObject, bmp, startPoint, allowedEffects) {
            _isOutside = isOutside;
        }
        bool _isOutside = false;
        public bool IsOutside {
            get { return _isOutside; }
        }
    }

    public class MyGridDragManager : GridDragManager
    {
        public MyGridDragManager(GridView view) : base(view) { }
        protected override ColumnPositionInfo CreateColumnPositionInfo()
        {
            return new MyColumnPositionInfo();
        }

        public override void ShowDropTargetHighlighting()
        {
            base.ShowDropTargetHighlighting();
        }

        private GridColumn draggedColumn = null;

        public override void StartDragging(DragStartArgs args)
        {
            AdvDragStartArgs ee = args as AdvDragStartArgs;
            if (ee != null && ee.IsOutside)
            {
                ClearLastPosition();
                draggedColumn = (View as MyGridView).Columns.AddField("@#$");
                draggedColumn.Tag = GridControl.InvalidRowHandle;
                this.DragObject = draggedColumn;
            }
            else
                base.StartDragging(args);
        }

        IDragObjectTarget currentTarget = null;

        public override void DoDragging(Point screenPoint)
        {
            base.DoDragging(screenPoint);
            Form f = View.GridControl.FindForm();
            IDragObjectTarget target = f.GetChildAtPoint(f.PointToClient(screenPoint)) as IDragObjectTarget;

            if (target != null && !View.GridControl.Equals(target))
            {
                if (currentTarget != target)
                {
                    if (currentTarget != null)
                        currentTarget.StopDrag();
                    currentTarget = target;
                }
                target.DoDragging(DragObject, Size.Empty, screenPoint);
            }
            else { 
                if (currentTarget != null) {
                    currentTarget.StopDrag();
                }
                currentTarget = null;
            }
        }

        public bool IsDraggingFromOutside {
            get { return (View.GridControl as MyGridControl).GetDragController().IsDraggingFromOutside; }
        }

        protected override void StopDragging(bool hideDrag)
        {
            base.StopDragging(!IsDraggingFromOutside);
            if (draggedColumn != null) {
                draggedColumn.Dispose();
                draggedColumn = null;
            }
            currentTarget = null;
        }

        public override void EndDrag() {
            if (currentTarget != null)
            {
                currentTarget.DoDragDrop(DragObject);
                currentTarget = null;
            }
            base.EndDrag();
        }

        public override void CancelDrag()
        {
            if (currentTarget != null)
            {
                currentTarget.CancelDrag(DragObject);
                currentTarget = null;
            }
            base.CancelDrag();
        }

    }

    public class MyColumnPositionInfo : ColumnPositionInfo
    {
        public MyColumnPositionInfo() : base() { }
        public new void SetIndex(int index)
        {
            base.SetIndex(index);
        }
    }
}
