﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Telerik.WinControls.UI.Localization;

namespace PCBQuotes.Localization
{
    public class CNRadGridLocalizationProvider: RadGridLocalizationProvider
    {
        public override string GetLocalizedString(string id)
        {
            switch (id)
            {
                case RadGridStringId.ConditionalFormattingPleaseSelectValidCellValue: return "Please select valid cell value";
                case RadGridStringId.ConditionalFormattingPleaseSetValidCellValue: return "Please set a valid cell value";
                case RadGridStringId.ConditionalFormattingPleaseSetValidCellValues: return "Please set a valid cell values";
                case RadGridStringId.ConditionalFormattingPleaseSetValidExpression: return "Please set a valid expression";
                case RadGridStringId.ConditionalFormattingItem: return "Item";
                case RadGridStringId.ConditionalFormattingInvalidParameters: return "Invalid parameters";
                case RadGridStringId.FilterFunctionBetween: return "Between";
                case RadGridStringId.FilterFunctionContains: return "Contains";
                case RadGridStringId.FilterFunctionDoesNotContain: return "Does not contain";
                case RadGridStringId.FilterFunctionEndsWith: return "Ends with";
                case RadGridStringId.FilterFunctionEqualTo: return "Equals";
                case RadGridStringId.FilterFunctionGreaterThan: return "Greater than";
                case RadGridStringId.FilterFunctionGreaterThanOrEqualTo: return "Greater than or equal to";
                case RadGridStringId.FilterFunctionIsEmpty: return "Is empty";
                case RadGridStringId.FilterFunctionIsNull: return "Is null";
                case RadGridStringId.FilterFunctionLessThan: return "Less than";
                case RadGridStringId.FilterFunctionLessThanOrEqualTo: return "Less than or equal to";
                case RadGridStringId.FilterFunctionNoFilter: return "No filter";
                case RadGridStringId.FilterFunctionNotBetween: return "Not between";
                case RadGridStringId.FilterFunctionNotEqualTo: return "Not equal to";
                case RadGridStringId.FilterFunctionNotIsEmpty: return "Is not empty";
                case RadGridStringId.FilterFunctionNotIsNull: return "Is not null";
                case RadGridStringId.FilterFunctionStartsWith: return "Starts with";
                case RadGridStringId.FilterFunctionCustom: return "Custom";
                case RadGridStringId.FilterOperatorBetween: return "Between";
                case RadGridStringId.FilterOperatorContains: return "Contains";
                case RadGridStringId.FilterOperatorDoesNotContain: return "NotContains";
                case RadGridStringId.FilterOperatorEndsWith: return "EndsWith";
                case RadGridStringId.FilterOperatorEqualTo: return "Equals";
                case RadGridStringId.FilterOperatorGreaterThan: return "GreaterThan";
                case RadGridStringId.FilterOperatorGreaterThanOrEqualTo: return "GreaterThanOrEquals";
                case RadGridStringId.FilterOperatorIsEmpty: return "IsEmpty";
                case RadGridStringId.FilterOperatorIsNull: return "IsNull";
                case RadGridStringId.FilterOperatorLessThan: return "LessThan";
                case RadGridStringId.FilterOperatorLessThanOrEqualTo: return "LessThanOrEquals";
                case RadGridStringId.FilterOperatorNoFilter: return "No filter";
                case RadGridStringId.FilterOperatorNotBetween: return "NotBetween";
                case RadGridStringId.FilterOperatorNotEqualTo: return "NotEquals";
                case RadGridStringId.FilterOperatorNotIsEmpty: return "NotEmpty";
                case RadGridStringId.FilterOperatorNotIsNull: return "NotNull";
                case RadGridStringId.FilterOperatorStartsWith: return "StartsWith";
                case RadGridStringId.FilterOperatorIsLike: return "Like";
                case RadGridStringId.FilterOperatorNotIsLike: return "NotLike";
                case RadGridStringId.FilterOperatorIsContainedIn: return "ContainedIn";
                case RadGridStringId.FilterOperatorNotIsContainedIn: return "NotContainedIn";
                case RadGridStringId.FilterOperatorCustom: return "Custom";
                case RadGridStringId.CustomFilterMenuItem: return "Custom";
                case RadGridStringId.CustomFilterDialogCaption: return "RadGridView Filter Dialog [{0}]";
                case RadGridStringId.CustomFilterDialogLabel: return "Show rows where:";
                case RadGridStringId.CustomFilterDialogRbAnd: return "And";
                case RadGridStringId.CustomFilterDialogRbOr: return "Or";
                case RadGridStringId.CustomFilterDialogBtnOk: return "OK";
                case RadGridStringId.CustomFilterDialogBtnCancel: return "Cancel";
                case RadGridStringId.CustomFilterDialogCheckBoxNot: return "Not";
                case RadGridStringId.CustomFilterDialogTrue: return "True";
                case RadGridStringId.CustomFilterDialogFalse: return "False";
                case RadGridStringId.FilterMenuBlanks: return "Empty";
                case RadGridStringId.FilterMenuAvailableFilters: return "Available Filters";
                case RadGridStringId.FilterMenuSearchBoxText: return "Search...";
                case RadGridStringId.FilterMenuClearFilters: return "Clear Filter";
                case RadGridStringId.FilterMenuButtonOK: return "OK";
                case RadGridStringId.FilterMenuButtonCancel: return "Cancel";
                case RadGridStringId.FilterMenuSelectionAll: return "All";
                case RadGridStringId.FilterMenuSelectionAllSearched: return "All Search Result";
                case RadGridStringId.FilterMenuSelectionNull: return "Null";
                case RadGridStringId.FilterMenuSelectionNotNull: return "Not Null";
                case RadGridStringId.FilterFunctionSelectedDates: return "Filter by specific dates:";
                case RadGridStringId.FilterFunctionToday: return "Today";
                case RadGridStringId.FilterFunctionYesterday: return "Yesterday";
                case RadGridStringId.FilterFunctionDuringLast7days: return "During last 7 days";
                case RadGridStringId.FilterLogicalOperatorAnd: return "AND";
                case RadGridStringId.FilterLogicalOperatorOr: return "OR";
                case RadGridStringId.FilterCompositeNotOperator: return "NOT";
                case RadGridStringId.DeleteRowMenuItem: return "删除行";// "Delete Row";
                case RadGridStringId.SortAscendingMenuItem: return "升序";// "Sort Ascending";
                case RadGridStringId.SortDescendingMenuItem: return "降序";// "Sort Descending";
                case RadGridStringId.ClearSortingMenuItem: return "取消排序";// "Clear Sorting";
                case RadGridStringId.ConditionalFormattingMenuItem: return "Conditional Formatting";
                case RadGridStringId.GroupByThisColumnMenuItem: return "Group by this column";
                case RadGridStringId.UngroupThisColumn: return "Ungroup this column";
                case RadGridStringId.ColumnChooserMenuItem: return "Column Chooser";
                case RadGridStringId.HideMenuItem: return "Hide Column";
                case RadGridStringId.HideGroupMenuItem: return "Hide Group";
                case RadGridStringId.UnpinMenuItem: return "Unpin Column";
                case RadGridStringId.UnpinRowMenuItem: return "Unpin Row";
                case RadGridStringId.PinMenuItem: return "Pinned state";
                case RadGridStringId.PinAtLeftMenuItem: return "Pin at left";
                case RadGridStringId.PinAtRightMenuItem: return "Pin at right";
                case RadGridStringId.PinAtBottomMenuItem: return "Pin at bottom";
                case RadGridStringId.PinAtTopMenuItem: return "Pin at top";
                case RadGridStringId.BestFitMenuItem: return "自适应尺寸";//"Best Fit";
                case RadGridStringId.PasteMenuItem: return "粘贴";//"Paste";
                case RadGridStringId.EditMenuItem: return "编辑";//"Edit";
                case RadGridStringId.ClearValueMenuItem: return "Clear Value";
                case RadGridStringId.CopyMenuItem: return   "拷贝";//"Copy";
                case RadGridStringId.CutMenuItem: return "剪切";//"Cut";
                case RadGridStringId.AddNewRowString: return "点击此处添加新行";//"Click here to add a new row";
                case RadGridStringId.ConditionalFormattingSortAlphabetically: return "Sort columns alphabetically";
                case RadGridStringId.ConditionalFormattingCaption: return "Conditional Formatting Rules Manager";
                case RadGridStringId.ConditionalFormattingLblColumn: return "Format only cells with";
                case RadGridStringId.ConditionalFormattingLblName: return "Rule name";
                case RadGridStringId.ConditionalFormattingLblType: return "Cell value";
                case RadGridStringId.ConditionalFormattingLblValue1: return "Value 1";
                case RadGridStringId.ConditionalFormattingLblValue2: return "Value 2";
                case RadGridStringId.ConditionalFormattingGrpConditions: return "Rules";
                case RadGridStringId.ConditionalFormattingGrpProperties: return "Rule Properties";
                case RadGridStringId.ConditionalFormattingChkApplyToRow: return "Apply this formatting to entire row";
                case RadGridStringId.ConditionalFormattingChkApplyOnSelectedRows: return "Apply this formatting if the row is selected";
                case RadGridStringId.ConditionalFormattingBtnAdd: return "Add new rule";
                case RadGridStringId.ConditionalFormattingBtnRemove: return "Remove";
                case RadGridStringId.ConditionalFormattingBtnOK: return "OK";
                case RadGridStringId.ConditionalFormattingBtnCancel: return "Cancel";
                case RadGridStringId.ConditionalFormattingBtnApply: return "Apply";
                case RadGridStringId.ConditionalFormattingRuleAppliesOn: return "Rule applies to";
                case RadGridStringId.ConditionalFormattingCondition: return "Condition";
                case RadGridStringId.ConditionalFormattingExpression: return "Expression";
                case RadGridStringId.ConditionalFormattingChooseOne: return "[Choose one]";
                case RadGridStringId.ConditionalFormattingEqualsTo: return "equals to [Value1]";
                case RadGridStringId.ConditionalFormattingIsNotEqualTo: return "is not equal to [Value1]";
                case RadGridStringId.ConditionalFormattingStartsWith: return "starts with [Value1]";
                case RadGridStringId.ConditionalFormattingEndsWith: return "ends with [Value1]";
                case RadGridStringId.ConditionalFormattingContains: return "contains [Value1]";
                case RadGridStringId.ConditionalFormattingDoesNotContain: return "does not contain [Value1]";
                case RadGridStringId.ConditionalFormattingIsGreaterThan: return "is greater than [Value1]";
                case RadGridStringId.ConditionalFormattingIsGreaterThanOrEqual: return "is greater than or equal [Value1]";
                case RadGridStringId.ConditionalFormattingIsLessThan: return "is less than [Value1]";
                case RadGridStringId.ConditionalFormattingIsLessThanOrEqual: return "is less than or equal to [Value1]";
                case RadGridStringId.ConditionalFormattingIsBetween: return "is between [Value1] and [Value2]";
                case RadGridStringId.ConditionalFormattingIsNotBetween: return "is not between [Value1] and [Value1]";
                case RadGridStringId.ConditionalFormattingLblFormat: return "Format";
                case RadGridStringId.ConditionalFormattingBtnExpression: return "Expression editor";
                case RadGridStringId.ConditionalFormattingTextBoxExpression: return "Expression";
                case RadGridStringId.ConditionalFormattingPropertyGridCaseSensitive: return "CaseSensitive";
                case RadGridStringId.ConditionalFormattingPropertyGridCellBackColor: return "CellBackColor";
                case RadGridStringId.ConditionalFormattingPropertyGridCellForeColor: return "CellForeColor";
                case RadGridStringId.ConditionalFormattingPropertyGridEnabled: return "Enabled";
                case RadGridStringId.ConditionalFormattingPropertyGridRowBackColor: return "RowBackColor";
                case RadGridStringId.ConditionalFormattingPropertyGridRowForeColor: return "RowForeColor";
                case RadGridStringId.ConditionalFormattingPropertyGridRowTextAlignment: return "RowTextAlignment";
                case RadGridStringId.ConditionalFormattingPropertyGridTextAlignment: return "TextAlignment";
                case RadGridStringId.ConditionalFormattingPropertyGridCaseSensitiveDescription: return "Determines whether case-sensitive comparisons will be made when evaluating string values.";
                case RadGridStringId.ConditionalFormattingPropertyGridCellBackColorDescription: return "Enter the background color to be used for the cell.";
                case RadGridStringId.ConditionalFormattingPropertyGridCellForeColorDescription: return "Enter the foreground color to be used for the cell.";
                case RadGridStringId.ConditionalFormattingPropertyGridEnabledDescription: return "Determines whether the condition is enabled (can be evaluated and applied).";
                case RadGridStringId.ConditionalFormattingPropertyGridRowBackColorDescription: return "Enter the background color to be used for the entire row.";
                case RadGridStringId.ConditionalFormattingPropertyGridRowForeColorDescription: return "Enter the foreground color to be used for the entire row.";
                case RadGridStringId.ConditionalFormattingPropertyGridRowTextAlignmentDescription: return "Enter the alignment to be used for the cell values, when ApplyToRow is true.";
                case RadGridStringId.ConditionalFormattingPropertyGridTextAlignmentDescription: return "Enter the alignment to be used for the cell values.";
                case RadGridStringId.ColumnChooserFormCaption: return "Column Chooser";
                case RadGridStringId.ColumnChooserFormMessage: return "Drag a column header from the\ngrid here to remove it from\nthe current view.";
                case RadGridStringId.GroupingPanelDefaultMessage: return "Drag a column here to group by this column.";
                case RadGridStringId.GroupingPanelHeader: return "Group by:";
                case RadGridStringId.PagingPanelPagesLabel: return "Page";
                case RadGridStringId.PagingPanelOfPagesLabel: return "of";
                case RadGridStringId.NoDataText: return "No data to display";
                case RadGridStringId.CompositeFilterFormErrorCaption: return "Filter Error";
                case RadGridStringId.CompositeFilterFormInvalidFilter: return "The composite filter descriptor is not valid.";
                case RadGridStringId.ExpressionMenuItem: return "Expression";
                case RadGridStringId.ExpressionFormTitle: return "Expression Builder";
                case RadGridStringId.ExpressionFormFunctions: return "Functions";
                case RadGridStringId.ExpressionFormFunctionsText: return "Text";
                case RadGridStringId.ExpressionFormFunctionsAggregate: return "Aggregate";
                case RadGridStringId.ExpressionFormFunctionsDateTime: return "Date-Time";
                case RadGridStringId.ExpressionFormFunctionsLogical: return "Logical";
                case RadGridStringId.ExpressionFormFunctionsMath: return "Math";
                case RadGridStringId.ExpressionFormFunctionsOther: return "Other";
                case RadGridStringId.ExpressionFormOperators: return "Operators";
                case RadGridStringId.ExpressionFormConstants: return "Constants";
                case RadGridStringId.ExpressionFormFields: return "Fields";
                case RadGridStringId.ExpressionFormDescription: return "Description";
                case RadGridStringId.ExpressionFormResultPreview: return "Result preview";
                case RadGridStringId.ExpressionFormTooltipPlus: return "Plus";
                case RadGridStringId.ExpressionFormTooltipMinus: return "Minus";
                case RadGridStringId.ExpressionFormTooltipMultiply: return "Multiply";
                case RadGridStringId.ExpressionFormTooltipDivide: return "Divide";
                case RadGridStringId.ExpressionFormTooltipModulo: return "Modulo";
                case RadGridStringId.ExpressionFormTooltipEqual: return "Equal";
                case RadGridStringId.ExpressionFormTooltipNotEqual: return "Not Equal";
                case RadGridStringId.ExpressionFormTooltipLess: return "Less";
                case RadGridStringId.ExpressionFormTooltipLessOrEqual: return "Less Or Equal";
                case RadGridStringId.ExpressionFormTooltipGreaterOrEqual: return "Greater Or Equal";
                case RadGridStringId.ExpressionFormTooltipGreater: return "Greater";
                case RadGridStringId.ExpressionFormTooltipAnd: return "Logical \"AND\"";
                case RadGridStringId.ExpressionFormTooltipOr: return "Logical \"OR\"";
                case RadGridStringId.ExpressionFormTooltipNot: return "Logical \"NOT\"";
                case RadGridStringId.ExpressionFormAndButton: return string.Empty; //if empty, default button image is used
                case RadGridStringId.ExpressionFormOrButton: return string.Empty; //if empty, default button image is used
                case RadGridStringId.ExpressionFormNotButton: return string.Empty; //if empty, default button image is used
                case RadGridStringId.ExpressionFormOKButton: return "OK";
                case RadGridStringId.ExpressionFormCancelButton: return "Cancel";
                case RadGridStringId.SearchRowChooseColumns: return "SearchRowChooseColumns";
                case RadGridStringId.SearchRowSearchFromCurrentPosition: return "SearchRowSearchFromCurrentPosition";
                case RadGridStringId.SearchRowMenuItemMasterTemplate: return "SearchRowMenuItemMasterTemplate";
                case RadGridStringId.SearchRowMenuItemChildTemplates: return "SearchRowMenuItemChildTemplates";
                case RadGridStringId.SearchRowMenuItemAllColumns: return "SearchRowMenuItemAllColumns";
                case RadGridStringId.SearchRowTextBoxNullText: return "SearchRowTextBoxNullText";
                case RadGridStringId.SearchRowResultsOfLabel: return "SearchRowResultsOfLabel";
                case RadGridStringId.SearchRowMatchCase: return "Match case";
            }
            return string.Empty;
        }

    }
}
