using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraPivotGrid;
using System.IO;
using DevExpress.Utils;
using System.Collections;
using DevExpress.XtraPivotGrid.Data;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Filtering;
using DevExpress.Skins;
using DevExpress.Utils.Drawing;
using System.Diagnostics;
using DevExpress.XtraPivotGrid.ViewInfo;
using DevExpress.Data.Filtering.Helpers;
using DevExpress.Data;
using DevExpress.Data.PivotGrid;

namespace WindowsFormsSample {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }
        PivotDataController controller;
        private void Form1_Load(object sender, EventArgs e) {
            pivotGridControl1.BeginUpdate();
            pivotGridControl1.DataSource = CreateDataSource();
            controller = ((IPivotGridViewInfoDataOwner)pivotGridControl1).DataViewInfo.DataController;
            pivotGridControl1.RetrieveFields();
            pivotGridControl1.Fields["RowField1"].Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            pivotGridControl1.Fields["ColumnField1"].Area = DevExpress.XtraPivotGrid.PivotArea.ColumnArea;
            pivotGridControl1.Fields["DataField1"].Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            PivotGridField field1 = pivotGridControl1.Fields.Add("Unbound Field1", PivotArea.DataArea);
            field1.UnboundType = DevExpress.Data.UnboundColumnType.Integer;
            field1.UnboundExpression = String.Format("{0} + {1}", pivotGridControl1.Fields["RowField1"].Name, pivotGridControl1.Fields["ColumnField1"].Name);
            field1.Options.ShowUnboundExpressionMenu = true;
            PivotGridField field2 = pivotGridControl1.Fields.Add("Unbound Field2", PivotArea.DataArea);
            field2.UnboundType = DevExpress.Data.UnboundColumnType.Integer;
            expressions[field2.FieldName] = "[RowField1] + [ColumnField1]";
            field2.Options.ShowUnboundExpressionMenu = true;
            field2.CellFormat.FormatString = "d";
            field2.CellFormat.FormatType = FormatType.Numeric;
            pivotGridControl1.EndUpdate();
        }

        private DataTable CreateDataSource() {
            DataTable table = new DataTable();
            table.Columns.Add("RowField1", typeof(Int32));
            table.Columns.Add("ColumnField1", typeof(Int32));
            table.Columns.Add("DataField1", typeof(Int32));
            table.Rows.Add(1, 1, 1);
            table.Rows.Add(1, 1, 1);
            table.Rows.Add(1, 1, 1);
            table.Rows.Add(1, 1, 1);
            table.Rows.Add(1, 2, 2);
            table.Rows.Add(1, 2, 2);
            table.Rows.Add(2, 1, 3);
            table.Rows.Add(2, 2, 4);
            table.Rows.Add(2, 2, 4);
            return table;
        }

        Dictionary<string, string> expressions = new Dictionary<string,string>();

        private void pivotGridControl1_CustomUnboundFieldData(object sender, CustomFieldDataEventArgs e) {
            if (e.Field.FieldName == "Unbound Field2") {
                e.Value = new ExpressionEvaluator(controller.GetDescriptorCollection(), expressions[e.Field.FieldName])
                    .Evaluate(controller.ListSource[e.ListSourceRowIndex]);
            }
        }

        private void pivotGridControl1_BeforeShowUnboundExpressionEditor(object sender, PivotGridFieldEventArgs e) {
            if (e.Field.FieldName == "Unbound Field2") {
                e.Field.UnboundExpression = expressions[e.Field.FieldName];
            }
        }

        private void pivotGridControl1_AfterShowUnboundExpressionEditor(object sender, PivotGridFieldEventArgs e) {
            if (e.Field.FieldName == "Unbound Field2") {
                expressions[e.Field.FieldName] = new OperatorNameToFieldNamePatcher(pivotGridControl1.Fields, true).Patch(e.Field.ExpressionOperator).LegacyToString();
                e.Field.UnboundExpression = String.Empty;
            }
        }
    }
    public class MyPivotGridControl : PivotGridControl {
        public override bool ShowUnboundExpressionEditor(PivotGridField field) {
            bool result = false;
            BeginUpdate();
            try {
                if (BeforeShowUnboundExpressionEditor != null) {
                    BeforeShowUnboundExpressionEditor(this, new PivotGridFieldEventArgs(field));
                }
                result = base.ShowUnboundExpressionEditor(field);
                if (AfterShowUnboundExpressionEditor != null) {
                    AfterShowUnboundExpressionEditor(this, new PivotGridFieldEventArgs(field));
                }
            } finally {
                EndUpdate();
            }
            return result;
        }
        public event EventHandler<PivotGridFieldEventArgs> BeforeShowUnboundExpressionEditor;
        public event EventHandler<PivotGridFieldEventArgs> AfterShowUnboundExpressionEditor;
    }
    public class PivotGridFieldEventArgs : EventArgs{
        public PivotGridFieldEventArgs(PivotGridField field){
            _Field = field;
        }
        private PivotGridField _Field;
        public PivotGridField Field
        {
        	get	{ return _Field; }
        	set
        	{
        		_Field = value;
        	}
        }
        
    }
}
