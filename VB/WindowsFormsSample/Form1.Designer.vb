﻿Imports Microsoft.VisualBasic
Imports System
Namespace WindowsFormsSample
	Partial Public Class Form1
		''' <summary>
		''' Required designer variable.
		''' </summary>
		Private components As System.ComponentModel.IContainer = Nothing

		''' <summary>
		''' Clean up any resources being used.
		''' </summary>
		''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		Protected Overrides Sub Dispose(ByVal disposing As Boolean)
			If disposing AndAlso (components IsNot Nothing) Then
				components.Dispose()
			End If
			MyBase.Dispose(disposing)
		End Sub

		#Region "Windows Form Designer generated code"

		''' <summary>
		''' Required method for Designer support - do not modify
		''' the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
			Me.pivotGridControl1 = New WindowsFormsSample.MyPivotGridControl()
			CType(Me.pivotGridControl1, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.SuspendLayout()
			' 
			' pivotGridControl1
			' 
			Me.pivotGridControl1.Cursor = System.Windows.Forms.Cursors.Default
			Me.pivotGridControl1.Dock = System.Windows.Forms.DockStyle.Fill
			Me.pivotGridControl1.Location = New System.Drawing.Point(0, 0)
			Me.pivotGridControl1.Name = "pivotGridControl1"
			Me.pivotGridControl1.OptionsData.DataFieldUnboundExpressionMode = DevExpress.XtraPivotGrid.DataFieldUnboundExpressionMode.UseSummaryValues
			Me.pivotGridControl1.Size = New System.Drawing.Size(449, 286)
			Me.pivotGridControl1.TabIndex = 0
'			Me.pivotGridControl1.CustomUnboundFieldData += New DevExpress.XtraPivotGrid.CustomFieldDataEventHandler(Me.pivotGridControl1_CustomUnboundFieldData);
'			Me.pivotGridControl1.AfterShowUnboundExpressionEditor += New System.EventHandler(Of WindowsFormsSample.PivotGridFieldEventArgs)(Me.pivotGridControl1_AfterShowUnboundExpressionEditor);
'			Me.pivotGridControl1.BeforeShowUnboundExpressionEditor += New System.EventHandler(Of WindowsFormsSample.PivotGridFieldEventArgs)(Me.pivotGridControl1_BeforeShowUnboundExpressionEditor);
			' 
			' Form1
			' 
			Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
			Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
			Me.ClientSize = New System.Drawing.Size(449, 286)
			Me.Controls.Add(Me.pivotGridControl1)
			Me.Name = "Form1"
			Me.Text = "Form1"
'			Me.Load += New System.EventHandler(Me.Form1_Load);
			CType(Me.pivotGridControl1, System.ComponentModel.ISupportInitialize).EndInit()
			Me.ResumeLayout(False)

		End Sub

		#End Region

		Private WithEvents pivotGridControl1 As MyPivotGridControl
	End Class
End Namespace

