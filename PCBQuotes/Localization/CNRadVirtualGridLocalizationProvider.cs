using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Telerik.WinControls.UI.Localization;

namespace PCBQuotes.Localization
{
    public class CNRadVirtualGridLocalizationProvider: RadVirtualGridLocalizationProvider
    {
        public override string GetLocalizedString(string id)
        {
            switch (id)
            {
                case RadVirtualGridStringId.NoDataText: return "没有数据显示";// "No data to display";
                case RadVirtualGridStringId.FilterFunctionBetween: return "在…之间";// "Between";
                case RadVirtualGridStringId.FilterFunctionContains: return "包含";// "Contains";
                case RadVirtualGridStringId.FilterFunctionDoesNotContain: return "不包含";// "Does not contain";
                case RadVirtualGridStringId.FilterFunctionEndsWith: return "以…结束";// "Ends with";
                case RadVirtualGridStringId.FilterFunctionEqualTo: return "等于";// "Equals";
                case RadVirtualGridStringId.FilterFunctionGreaterThan: return "大于";//"Greater than";
                case RadVirtualGridStringId.FilterFunctionGreaterThanOrEqualTo: return "大于或等于";// "Greater than or equal to";
                case RadVirtualGridStringId.FilterFunctionIsEmpty: return "Is empty";
                case RadVirtualGridStringId.FilterFunctionIsNull: return "Is null";
                case RadVirtualGridStringId.FilterFunctionLessThan: return "小于";// "Less than";
                case RadVirtualGridStringId.FilterFunctionLessThanOrEqualTo: return " 小于或等于";//"Less than or equal to";
                case RadVirtualGridStringId.FilterFunctionNoFilter: return "不过滤";// "No filter";
                case RadVirtualGridStringId.FilterFunctionNotBetween: return "不在…之间";// "Not between";
                case RadVirtualGridStringId.FilterFunctionNotEqualTo: return "不等于";// "Not equal to";
                case RadVirtualGridStringId.FilterFunctionNotIsEmpty: return "Is not empty";
                case RadVirtualGridStringId.FilterFunctionNotIsNull: return "Is not null";
                case RadVirtualGridStringId.FilterFunctionStartsWith: return "以…开始";//"Starts with";
                case RadVirtualGridStringId.FilterFunctionCustom: return "自定义";//"Custom";
                case RadVirtualGridStringId.FilterOperatorNoFilter: return "不过滤";// "No filter";
                case RadVirtualGridStringId.FilterOperatorCustom: return "自定义"; // "Custom";
                case RadVirtualGridStringId.FilterOperatorIsLike: return "Like";
                case RadVirtualGridStringId.FilterOperatorNotIsLike: return "NotLike";
                case RadVirtualGridStringId.FilterOperatorLessThan: return "小于";// "LessThan";
                case RadVirtualGridStringId.FilterOperatorLessThanOrEqualTo: return "小于等于";//   "LessThanOrEquals";
                case RadVirtualGridStringId.FilterOperatorEqualTo: return "等于";// "Equals";
                case RadVirtualGridStringId.FilterOperatorNotEqualTo: return "不等于";// "NotEquals";
                case RadVirtualGridStringId.FilterOperatorGreaterThanOrEqualTo: return "大于等于";// "GreaterThanOrEquals";
                case RadVirtualGridStringId.FilterOperatorGreaterThan: return "大于";// "GreaterThan";
                case RadVirtualGridStringId.FilterOperatorStartsWith: return "开始于";// "StartsWith";
                case RadVirtualGridStringId.FilterOperatorEndsWith: return "结束于";// "EndsWith";
                case RadVirtualGridStringId.FilterOperatorContains: return "包含";// "Contains";
                case RadVirtualGridStringId.FilterOperatorDoesNotContain: return "不包含";// "NotContains";
                case RadVirtualGridStringId.FilterOperatorIsNull: return "IsNull";
                case RadVirtualGridStringId.FilterOperatorNotIsNull: return "NotNull";
                case RadVirtualGridStringId.FilterOperatorIsContainedIn: return "ContainedIn";
                case RadVirtualGridStringId.FilterOperatorNotIsContainedIn: return "NotContainedIn";
                case RadVirtualGridStringId.AddNewRowString: return "点击此处添加新行";// "Click here to add a new row";
                case RadVirtualGridStringId.PagingPanelPagesLabel: return "Page";
                case RadVirtualGridStringId.PagingPanelOfPagesLabel: return "of";
                case RadVirtualGridStringId.BestFitMenuItem: return "自适应尺寸";// "Best Fit";
                case RadVirtualGridStringId.ClearSortingMenuItem: return "取消排序";//"Clear Sorting";
                case RadVirtualGridStringId.SortDescendingMenuItem: return "降序";//"Sort Descending";
                case RadVirtualGridStringId.SortAscendingMenuItem: return "升序";// "Sort Ascending";
                case RadVirtualGridStringId.PinAtRightMenuItem: return "固定在右边";//"Pin at right";
                case RadVirtualGridStringId.PinAtLeftMenuItem: return "固定在左边";//"Pin at left";
                case RadVirtualGridStringId.PinAtBottomMenuItem: return "固定在底部";//"Pin at bottom";
                case RadVirtualGridStringId.PinAtTopMenuItem: return "固定在顶部";//"Pin at top";
                case RadVirtualGridStringId.UnpinColumnMenuItem: return "取消列固定";//"Unpin Column";
                case RadVirtualGridStringId.UnpinRowMenuItem: return "取消行固定";// "Unpin Row";
                case RadVirtualGridStringId.PinMenuItem: return "固定状态";// "Pinned state";
                case RadVirtualGridStringId.DeleteRowMenuItem: return "删除行";//"Delete Row";
                case RadVirtualGridStringId.ClearValueMenuItem: return "清除值"; //"Clear Value";
                case RadVirtualGridStringId.EditMenuItem: return "编辑";// "Edit";
                case RadVirtualGridStringId.PasteMenuItem: return "粘贴";// "Paste";
                case RadVirtualGridStringId.CutMenuItem: return "剪切";//"Cut";
                case RadVirtualGridStringId.CopyMenuItem: return "拷贝";//"Copy";
                default:
                    return base.GetLocalizedString(id);
            }
        }

    }
}
