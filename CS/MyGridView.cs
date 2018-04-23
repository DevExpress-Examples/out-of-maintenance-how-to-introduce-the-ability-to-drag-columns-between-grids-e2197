using System;
using DevExpress.XtraGrid.Views.Grid;
using System.Drawing;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Dragging;

namespace MyXtraGrid {
    public class MyGridView : DevExpress.XtraGrid.Views.Grid.GridView, IDragObjectTargetView
    {
		public MyGridView() : this(null) {}
		public MyGridView(DevExpress.XtraGrid.GridControl grid) : base(grid) {
			// put your initialization code here
		}
		protected override string ViewName { get { return "MyGridView"; } }

        protected internal void SetStateCore(GridState state) {
            SetState((int)state);
        }


        public override bool CanSortColumn(GridColumn column)
        {
            if (column.Tag != null && Object.Equals(column.Tag, InvalidRowHandle))
                return true;
            return base.CanSortColumn(column);
        }

        public override bool CanGroupColumn(GridColumn column) {
            if (column.Tag != null && Object.Equals(column.Tag, InvalidRowHandle))
                return true;
            return base.CanGroupColumn(column);
        }

        protected override void OnColumnsCollectionChanged(object sender, System.ComponentModel.CollectionChangeEventArgs e)
        {
            MyGridControl grid = (GridControl as MyGridControl);
            DragController controller = (grid != null) ? grid.GetDragController() : null;
            if (controller != null && controller.IsDragging)
                return;
            base.OnColumnsCollectionChanged(sender, e);
        }

        #region IDragObjectTargetView Members

        void IDragObjectTargetView.DoStartDragObject(object drag, Size size, Point screenPoint)
        {
            (Handler as MyGridHandler).DoStartDragObjectFromOutside(drag, size, screenPoint);
        }

        #endregion

        int dragDropEventsLockCount = 0;

        protected internal void LockDragDropEvents() {
            dragDropEventsLockCount++;
        }

        protected internal void UnLockDragDropEvents() {
            if (dragDropEventsLockCount > 0)
                dragDropEventsLockCount--;
        }

        internal bool IsDragDropEventLocked { get { return dragDropEventsLockCount > 0; } }
        protected override void RaiseDragObjectDrop(DragObjectDropEventArgs e)
        {
            if (IsDragDropEventLocked)
                return;
            base.RaiseDragObjectDrop(e);
        }
    }
}
