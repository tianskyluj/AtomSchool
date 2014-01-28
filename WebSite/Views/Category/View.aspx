<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<%@ Import Namespace="MvcFckEditor.Models" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>View</title>
    <link href="/Content/Site.css" rel="stylesheet" type="text/css" />
    <link href="/easyui/themes/default/easyui.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" type="text/css" href="/easyui/themes/icon.css" />
    <script src="/Scripts/jquery-1.4.1.min.js" type="text/javascript"></script>
    <script src="/easyui/jquery.easyui.min.js" type="text/javascript"></script>
    <script src="/easyui/locale/easyui-lang-zh_CN.js" type="text/javascript"></script>
    <script type="text/javascript" src="/fckeditor2.3.6/fckeditor.js"></script>
    <script language="javascript" type="text/javascript">

        function submit() {
            $('#form').form('submit', {
                onSubmit: function () {
                    return $(this).form('validate');
                },
                success: function (msg) {
                    $.messager.alert('提示', "保存成功", 'info', function () {
                        window.location.href = "/Category/Index/";
                    });
                }
            });
        }

    </script>
</head>
<body class="easyui-layout" fit="true">
    <div region="center" border="false" fit="true">
        <div region="north" border="false" class="title" style="text-align: center; height: 40px;
            line-height: 40px; font-size: x-large;">
            分类信息
        </div>
        <form region="center" border="false" fit="true" id="form" method="post" 
            action="/Category/Save/" enctype="application/x-www-form-urlencoded">
        <div region="center" title="主要信息">
            <div class="title" style="text-align: center; height: 20px;
                line-height: 20px; font-size: large;color: White;background-color:#6699FF">
                主要信息
            </div>
            <input type="hidden" id="id" name="entity.ID" value="<%= ((Domain.Category)this.ViewData["entity"]).ID %>" />
            <table>
                <tr>
                    <td style="text-align: right; width: 120px;">
                        排序顺序(<font color="red">*</font>)：
                    </td>
                    <td>
                        <input type="text" class="easyui-validatebox" required="true" name="entity.OrderNo"
                            value="<%= ((Domain.Category)this.ViewData["entity"]).OrderNo %>" />
                    </td>
                </tr>
                <tr>
                    <td style="text-align: right; width: 120px;">
                        中文名(<font color="red">*</font>)：
                    </td>
                    <td>
                        <input type="text" class="easyui-validatebox" required="true" name="entity.Name"
                            value="<%= ((Domain.Category)this.ViewData["entity"]).Name %>" />
                    </td>
                </tr>
                <tr>
                    <td style="text-align: right; width: 120px;">
                        英文名(<font color="red">*</font>)：
                    </td>
                    <td>
                        <input type="text" class="easyui-validatebox" required="true" name="entity.NameEn"
                            value="<%= ((Domain.Category)this.ViewData["entity"]).NameEn %>" />
                    </td>
                </tr>
                <tr>
                    <td style="text-align: right; width: 120px;">
                        分类类型(<font color="red">*</font>)：
                    </td>
                    <td>
                        <select name="entity.CategoryType" class="easyui-combobox" required="true">
                            <%  if (string.IsNullOrEmpty(((Domain.Category)this.ViewData["entity"]).CategoryType)
                                        || ((Domain.Category)this.ViewData["entity"]).CategoryType == "内容"
                                       || ((Domain.Category)this.ViewData["entity"]).CategoryType != "列表")
                                { %>
                            <option value="内容" selected="selected">内容</option>
                            <option value="列表">列表</option>
                            <% }
                                else
                                { %>
                            <option value="内容">内容</option>
                            <option value="列表" selected="selected">列表</option>
                            <% } %>
                        </select>
                    </td>
                </tr>
                <tr>
                    <td style="text-align: right; width: 120px;">
                        版块(<font color="red">*</font>)：
                    </td>
                    <td>
                        <select id="cc" class="easyui-combobox" name="forumId" required="true">
                            <% foreach (dynamic item in this.ViewData["ForumList"] as IEnumerable)
                               {%>
                            <option value="<%= item.ID %>" <%= (((dynamic)this.ViewData["entity"]).Forum==null 
                                        || ((dynamic)this.ViewData["entity"]).Forum.Name!=item.Name )?string.Empty:"selected=\"selected\"" %>>
                                <%= item.Name %></option>
                            <% } %>
                        </select>
                    </td>
                </tr>
                <tr>
                    <td style="text-align: right; width: 120px;">
                        显示(<font color="red">*</font>)：
                    </td>
                    <td>
                        <input type="checkbox" name="entity.IsEnabled" <%= ((Domain.Category)this.ViewData["entity"]).IsEnabled?"checked=\"checked\"":string.Empty
                                %> value="<%= ((Domain.Category)this.ViewData["entity"]).IsEnabled %>" onclick="this.value=checked=='checked'||'true';" />
                    </td>
                </tr>
            </table>
        </div>
        <div region="south" title="中文信息">
         <div class="title" style="text-align: center; height: 20px;
                line-height: 20px; font-size: large;color: White;background-color:#6699FF">
                中文信息
            </div>
            <table style="width:100%;">
                <tr>
                    <td style="text-align: right; width: 120px;">
                        关键字：
                    </td>
                    <td>
                        <input type="text" style="width: 300px;"
                        class="easyui-validatebox" name="entity.Keyword" value="<%= ((Domain.Category)this.ViewData["entity"]).Keyword %>" />
                    </td>
                </tr>
                <tr>
                    <td style="text-align: right; width: 120px;">
                        描述：
                    </td>
                    <td>
                        <textarea style="width: 300px;"
                        class="easyui-validatebox" name="entity.Description"><%= ((Domain.Category)this.ViewData["entity"]).Description %></textarea>
                    </td>
                </tr>
                <tr>
                    <td colspan="2"  style="text-align: center; width: 120px;">
                        内容：
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <%=Html.FckEditor("entity.Content", string.IsNullOrEmpty(((Domain.Category)this.ViewData["entity"]).Content) ?
                                                        string.Empty : ((Domain.Category)this.ViewData["entity"]).Content.Replace("\r", string.Empty).Replace("\n", string.Empty).Replace("'", "\\'"), 
        new FckConfig { Width="100%", Height="400", Skin= FckSkin.Office2003, ToolbarSet= FckToolbarSet.Default })%>
                    </td>
                </tr>
            </table>
        </div>
        <div title="英文信息" region="south">
              <div class="title" style="text-align: center; height: 20px;
                line-height: 20px; font-size: large;color:  White;background-color:#6699FF">
                英文信息
            </div>
            <table style="width:100%;">
                <tr>
                    <td style="text-align: right; width: 120px;">
                        关键字：
                    </td>
                    <td>
                        <input type="text" style="width: 300px;"
                         class="easyui-validatebox" name="entity.KeywordEn" value="<%= ((Domain.Category)this.ViewData["entity"]).KeywordEn %>" />
                    </td>
                </tr>
                <tr>
                    <td style="text-align: right; width: 120px;">
                        描述：
                    </td>
                    <td>
                        <textarea style="width: 300px;"
                        class="easyui-validatebox" name="entity.DescriptionEn"><%= ((Domain.Category)this.ViewData["entity"]).DescriptionEn %></textarea>
                    </td>
                </tr>
                <tr>
                    <td  style="text-align: center; width: 120px;" colspan="2">
                        内容：
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <%=Html.FckEditor("entity.ContentEn", string.IsNullOrEmpty(((Domain.Category)this.ViewData["entity"]).ContentEn) ?
                                                        string.Empty : ((Domain.Category)this.ViewData["entity"]).ContentEn.Replace("\r", string.Empty).Replace("\n", string.Empty).Replace("'", "\\'"), 
        new FckConfig { Width="100%", Height="400", Skin= FckSkin.Office2003, ToolbarSet= FckToolbarSet.Default })%>
                    </td>
                </tr>
            </table>
        </div>
        </form>

        <div region="south" border="false" style="text-align: right; height: 40px; line-height: 30px;
            background-color: #f7f7f7;">
            <table style="width: 100%">
                <tr>
                    <td>
                    </td>
                    <td style="text-align: right">
                   
                        <a href="#" class="easyui-linkbutton" iconcls="icon-save" onclick="submit();">提交</a>
                        <a href="#" class="easyui-linkbutton" iconcls="icon-cancel" onclick="location.href = document.referrer;">
                            返回</a>
                    </td>
                </tr>
            </table>
        </div>
    </div>
</body>
</html>
