Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Linq
Imports System.Text
Imports System.Windows.Forms
Imports DevExpress.XtraPivotGrid
Imports System.IO
Imports DevExpress.Utils
Imports System.Collections
Imports DevExpress.XtraPivotGrid.Data
Imports DevExpress.XtraEditors
Imports DevExpress.XtraEditors.Filtering
Imports DevExpress.Skins
Imports DevExpress.Utils.Drawing
Imports System.Diagnostics
Imports DevExpress.XtraPivotGrid.ViewInfo
Imports DevExpress.Data.Filtering.Helpers
Imports DevExpress.Data
Imports DevExpress.Data.PivotGrid

Namespace WindowsFormsSample
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub
		Private controller As PivotDataController
		Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
			pivotGridControl1.BeginUpdate()
			pivotGridControl1.DataSource = CreateDataSource()
			controller = (CType(pivotGridControl1, IPivotGridViewInfoDataOwner)).DataViewInfo.DataController
			pivotGridControl1.RetrieveFields()
			pivotGridControl1.Fields("RowField1").Area = DevExpress.XtraPivotGrid.PivotArea.RowArea
			pivotGridControl1.Fields("ColumnField1").Area = DevExpress.XtraPivotGrid.PivotArea.ColumnArea
			pivotGridControl1.Fields("DataField1").Area = DevExpress.XtraPivotGrid.PivotArea.DataArea
			Dim field1 As PivotGridField = pivotGridControl1.Fields.Add("Unbound Field1", PivotArea.DataArea)
			field1.UnboundType = DevExpress.Data.UnboundColumnType.Integer
			field1.UnboundExpression = String.Format("{0} + {1}", pivotGridControl1.Fields("RowField1").Name, pivotGridControl1.Fields("ColumnField1").Name)
			field1.Options.ShowUnboundExpressionMenu = True
			Dim field2 As PivotGridField = pivotGridControl1.Fields.Add("Unbound Field2", PivotArea.DataArea)
			field2.UnboundType = DevExpress.Data.UnboundColumnType.Integer
			expressions(field2.FieldName) = "[RowField1] + [ColumnField1]"
			field2.Options.ShowUnboundExpressionMenu = True
			field2.CellFormat.FormatString = "d"
			field2.CellFormat.FormatType = FormatType.Numeric
			pivotGridControl1.EndUpdate()
		End Sub

		Private Function CreateDataSource() As DataTable
			Dim table As New DataTable()
			table.Columns.Add("RowField1", GetType(Int32))
			table.Columns.Add("ColumnField1", GetType(Int32))
			table.Columns.Add("DataField1", GetType(Int32))
			table.Rows.Add(1, 1, 1)
			table.Rows.Add(1, 1, 1)
			table.Rows.Add(1, 1, 1)
			table.Rows.Add(1, 1, 1)
			table.Rows.Add(1, 2, 2)
			table.Rows.Add(1, 2, 2)
			table.Rows.Add(2, 1, 3)
			table.Rows.Add(2, 2, 4)
			table.Rows.Add(2, 2, 4)
			Return table
		End Function

		Private expressions As New Dictionary(Of String, String)()

		Private Sub pivotGridControl1_CustomUnboundFieldData(ByVal sender As Object, ByVal e As CustomFieldDataEventArgs) Handles pivotGridControl1.CustomUnboundFieldData
			If e.Field.FieldName = "Unbound Field2" Then
				e.Value = New ExpressionEvaluator(controller.GetDescriptorCollection(), expressions(e.Field.FieldName)).Evaluate(controller.ListSource(e.ListSourceRowIndex))
			End If
		End Sub

		Private Sub pivotGridControl1_BeforeShowUnboundExpressionEditor(ByVal sender As Object, ByVal e As PivotGridFieldEventArgs) Handles pivotGridControl1.BeforeShowUnboundExpressionEditor
			If e.Field.FieldName = "Unbound Field2" Then
				e.Field.UnboundExpression = expressions(e.Field.FieldName)
			End If
		End Sub

		Private Sub pivotGridControl1_AfterShowUnboundExpressionEditor(ByVal sender As Object, ByVal e As PivotGridFieldEventArgs) Handles pivotGridControl1.AfterShowUnboundExpressionEditor
			If e.Field.FieldName = "Unbound Field2" Then
				expressions(e.Field.FieldName) = New OperatorNameToFieldNamePatcher(pivotGridControl1.Fields, True).Patch(e.Field.ExpressionOperator).LegacyToString()
				e.Field.UnboundExpression = String.Empty
			End If
		End Sub
	End Class
	Public Class MyPivotGridControl
		Inherits PivotGridControl
		Public Overrides Function ShowUnboundExpressionEditor(ByVal field As PivotGridField) As Boolean
			Dim result As Boolean = False
			BeginUpdate()
			Try
				RaiseEvent BeforeShowUnboundExpressionEditor(Me, New PivotGridFieldEventArgs(field))
				result = MyBase.ShowUnboundExpressionEditor(field)
				RaiseEvent AfterShowUnboundExpressionEditor(Me, New PivotGridFieldEventArgs(field))
			Finally
				EndUpdate()
			End Try
			Return result
		End Function
		Public Event BeforeShowUnboundExpressionEditor As EventHandler(Of PivotGridFieldEventArgs)
		Public Event AfterShowUnboundExpressionEditor As EventHandler(Of PivotGridFieldEventArgs)
	End Class
	Public Class PivotGridFieldEventArgs
		Inherits EventArgs
		Public Sub New(ByVal field As PivotGridField)
			_Field = field
		End Sub
		Private _Field As PivotGridField
		Public Property Field() As PivotGridField
			Get
				Return _Field
			End Get
			Set(ByVal value As PivotGridField)
				_Field = value
			End Set
		End Property

	End Class
End Namespace
