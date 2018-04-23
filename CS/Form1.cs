using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Dragging;

namespace MyXtraGrid {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e) {
            for(int i = 0; i < 10; i++)
                dataTable1.Rows.Add(new object[] { "Item Wg " + i.ToString() });
        }

        private void myGridView2_DragObjectDrop(object sender, DevExpress.XtraGrid.Views.Base.DragObjectDropEventArgs e)
        {
            if (e.DropInfo.Valid && !e.Canceled && e.DragObject is GridColumn && ((GridColumn)e.DragObject).View != sender)
            {
                (sender as GridView).BeginUpdate();
                try
                {
                    GridColumn sourceCol = e.DragObject as GridColumn;
                    GridColumn column = (sender as GridView).Columns.ColumnByFieldName(sourceCol.FieldName);
                    if (column == null)
                        column = (sender as GridView).Columns.AddField(sourceCol.FieldName);
                    if (((ColumnPositionInfo)e.DropInfo).InGroupPanel)
                    {
                        column.Group();
                        column.GroupIndex = e.DropInfo.Index;
                    }
                    else
                        column.VisibleIndex = e.DropInfo.Index;
                }
                finally
                {
                    (sender as GridView).EndDataUpdate();
                }
            }
        }

        private void myGridView2_DragObjectOver(object sender, DevExpress.XtraGrid.Views.Base.DragObjectOverEventArgs e)
        {
            if (e.DragObject is GridColumn && ((GridColumn)e.DragObject).View != sender)
            {
                e.DropInfo.Valid = !((e.DropInfo as ColumnPositionInfo).InGroupPanel || ((sender as GridView).VisibleColumns.Count > 0));
            }
        }


    }
}