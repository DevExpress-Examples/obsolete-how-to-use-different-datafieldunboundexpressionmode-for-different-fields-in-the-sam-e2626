﻿namespace WindowsFormsSample {
    partial class Form1 {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.pivotGridControl1 = new WindowsFormsSample.MyPivotGridControl();
            ((System.ComponentModel.ISupportInitialize)(this.pivotGridControl1)).BeginInit();
            this.SuspendLayout();
            // 
            // pivotGridControl1
            // 
            this.pivotGridControl1.Cursor = System.Windows.Forms.Cursors.Default;
            this.pivotGridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pivotGridControl1.Location = new System.Drawing.Point(0, 0);
            this.pivotGridControl1.Name = "pivotGridControl1";
            this.pivotGridControl1.OptionsData.DataFieldUnboundExpressionMode = DevExpress.XtraPivotGrid.DataFieldUnboundExpressionMode.UseSummaryValues;
            this.pivotGridControl1.Size = new System.Drawing.Size(449, 286);
            this.pivotGridControl1.TabIndex = 0;
            this.pivotGridControl1.CustomUnboundFieldData += new DevExpress.XtraPivotGrid.CustomFieldDataEventHandler(this.pivotGridControl1_CustomUnboundFieldData);
            this.pivotGridControl1.AfterShowUnboundExpressionEditor += new System.EventHandler<WindowsFormsSample.PivotGridFieldEventArgs>(this.pivotGridControl1_AfterShowUnboundExpressionEditor);
            this.pivotGridControl1.BeforeShowUnboundExpressionEditor += new System.EventHandler<WindowsFormsSample.PivotGridFieldEventArgs>(this.pivotGridControl1_BeforeShowUnboundExpressionEditor);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(449, 286);
            this.Controls.Add(this.pivotGridControl1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pivotGridControl1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private MyPivotGridControl pivotGridControl1;
    }
}

