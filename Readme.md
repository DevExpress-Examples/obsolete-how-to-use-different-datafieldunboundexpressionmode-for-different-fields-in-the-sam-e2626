<!-- default file list -->
*Files to look at*:

* [Form1.cs](./CS/WindowsFormsSample/Form1.cs) (VB: [Form1.vb](./VB/WindowsFormsSample/Form1.vb))
<!-- default file list end -->
# Obsolete: How to use different DataFieldUnboundExpressionMode for different fields in the same PivotGridControl
<!-- run online -->
**[[Run Online]](https://codecentral.devexpress.com/e2626)**
<!-- run online end -->


<p><strong>Update:</strong> Starting with version 15.1, it is possible to define the expression calculation mode for individual fields using the <a href="https://documentation.devexpress.com/#CoreLibraries/DevExpressXtraPivotGridPivotGridFieldBase_UnboundExpressionModetopic">PivotGridField.UnboundExpressionMode</a> property. Refer to the <a href="https://www.devexpress.com/Support/Center/p/S135276">S135276: Provide the capability to define DataFieldUnboundExpressionMode at the Data Field level</a> thread for additional information. <br><br>In this example, the <a href="https://documentation.devexpress.com/#CoreLibraries/DevExpressXtraPivotGridPivotGridOptionsData_DataFieldUnboundExpressionModetopic">DataFieldUnboundExpressionMode </a> property is set to <a href="https://documentation.devexpress.com/#CoreLibraries/DevExpressXtraPivotGridDataFieldUnboundExpressionModeEnumtopic">UseSummaryValues</a>. For fields where it is required to calculate unbound values using the standard behavior the <a href="https://documentation.devexpress.com/#windowsforms/DevExpressXtraPivotGridPivotGridControl_CustomUnboundFieldDatatopic">CustomUnboundFieldData</a> event is handled. The <strong>ExpressionEvaluator.Evaluate</strong> method is used to calculate a summary value based on an unbound expression that has been passed.<br> Since the <a href="https://documentation.devexpress.com/#windowsforms/DevExpressXtraPivotGridPivotGridControl_CustomUnboundFieldDatatopic">CustomUnboundFieldData</a> event is not raised for fields with a predefined <a href="https://documentation.devexpress.com/#CoreLibraries/DevExpressXtraPivotGridPivotGridFieldBase_UnboundExpressiontopic">UnboundExpression Property</a>, unbound expressions for these fields are stored in separate dictionaries, and their <a href="https://documentation.devexpress.com/#CoreLibraries/DevExpressXtraPivotGridPivotGridFieldBase_UnboundExpressiontopic">UnboundExpression Property</a> is cleared.</p>

<br/>


