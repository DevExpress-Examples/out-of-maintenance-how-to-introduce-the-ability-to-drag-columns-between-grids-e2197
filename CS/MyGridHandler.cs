using System;
using System.Windows.Forms;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Dragging;
using DevExpress.XtraGrid.Views.Base;
using System.Drawing;
using DevExpress.XtraGrid.Views.Grid.Drawing;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid;

namespace MyXtraGrid {
	public class MyGridHandler : DevExpress.XtraGrid.Views.Grid.Handler.GridHandler {
		public MyGridHandler(GridView gridView) : base(gridView) {}

		protected override void OnKeyDown(KeyEventArgs e) {
			base.OnKeyDown(e);
			if(e.KeyData == Keys.Delete && View.State == GridState.Normal)
				View.DeleteRow(View.FocusedRowHandle);
		}

        protected override GridDragManager CreateDragManager() { return new MyGridDragManager(View); }

        public virtual void DoStartDragObjectFromOutside(object drag, Size size, Point screenPoint) {
            (View as MyGridView).SetStateCore(GridState.ColumnDragging);
            (View.GridControl as MyGridControl).GetDragController().StartDraggingObjectFromOutside(DragManager, new AdvDragStartArgs(null, null, null, screenPoint, DragDropEffects.Copy, true));
        }

    }
    
}
