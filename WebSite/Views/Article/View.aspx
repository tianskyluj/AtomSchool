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
                        window.location.href = "/Article/Admin/<%= ((Domain.Category)this.ViewData["Category"]).ID %>/";
                    });
                }
            });
        }

    </script>
</head>
<body class="easyui-layout">
    <div region="center" border="false" fit="true">
        <div region="north" border="false" class="title" style="text-align: center; height: 40px;
            line-height: 40px; font-size: x-large;">
            <%= ((Domain.Category)this.ViewData["Category"]).Name%>
        </div>
        <form region="center" border="false" fit="true" id="form" method="post" action="/Article/Save/"
        enctype="application/x-www-form-urlencoded">
        <div title="主要信息">
            <div class="title" style="text-align: center; height: 20px; line-height: 20px; font-size: large;
                color: White; background-color: #6699FF">
                主要信息
            </div>
            <input type="hidden" id="id" name="entity.ID" value="<%= ((Domain.Article)this.ViewData["entity"]).ID %>" />
            <input type="hidden" name="categoryID" value="<%= ((Domain.Category)this.ViewData["Category"]).ID %>" />
            <table>
                <tr>
                    <td style="text-align: right; width: 120px;">
                        中文标题(<font color="red">*</font>)：
                    </td>
                    <td>
                        <input type="text" class="easyui-validatebox" required="true" name="entity.Name"
                            value="<%= ((Domain.Article)this.ViewData["entity"]).Name %>" />
                    </td>
                </tr>
                <tr>
                    <td style="text-align: right; width: 120px;">
                        英文标题(<font color="red">*</font>)：
                    </td>
                    <td>
                        <input type="text" class="easyui-validatebox" required="true" name="entity.NameEn"
                            value="<%= ((Domain.Article)this.ViewData["entity"]).NameEn %>" />
                    </td>
                </tr>
                <tr>
                    <td style="text-align: right; width: 120px;">
                        置顶(<font color="red">*</font>)：
                    </td>
                    <td>
                        <input type="checkbox" name="entity.IsFirst" <%= ((Domain.Article)this.ViewData["entity"]).IsFirst?"checked=\"checked\"":string.Empty
                                %> value="<%= ((Domain.Article)this.ViewData["entity"]).IsFirst %>" onclick="this.value=checked=='checked'||'true';" />
                    </td>
                </tr>
                <tr>
                    <td style="text-align: right; width: 120px;">
                        显示(<font color="red">*</font>)：
                    </td>
                    <td>
                        <input type="checkbox" name="entity.IsEnabled" <%= ((Domain.Article)this.ViewData["entity"]).IsEnabled?"checked=\"checked\"":string.Empty
                                %> value="<%= ((Domain.Article)this.ViewData["entity"]).IsEnabled %>" onclick="this.value=checked=='checked'||'true';" />
                    </td>
                </tr>
                <tr>
                    <td style="text-align: right; width: 120px;">
                        来源(<font color="red">*</font>)：
                    </td>
                    <td>
                        <input type="text" class="easyui-validatebox" required="true" name="entity.From"
                            value="<%= ((Domain.Article)this.ViewData["entity"]).From %>" />
                    </td>
                </tr>
                <tr>
                    <td style="text-align: right; width: 120px;">
                        浏览次数：
                    </td>
                    <td>
                        <%= ((Domain.Article)this.ViewData["entity"]).ViewCount %>
                    </td>
                </tr>
            </table>
        </div>
        <div title="中文信息">
            <div class="title" style="text-align: center; height: 20px; line-height: 20px; font-size: large;
                color: White; background-color: #6699FF">
                中文信息
            </div>
            <table style="width:100%;">
                <tr>
                    <td style="text-align: right; width: 120px;">
                        关键字：
                    </td>
                    <td>
                        <input type="text" style="width: 300px;" class="easyui-validatebox" name="entity.Keyword"
                            value="<%= ((Domain.Article)this.ViewData["entity"]).Keyword %>" />
                    </td>
                </tr>
                <tr>
                    <td style="text-align: right; width: 120px;">
                        描述：
                    </td>
                    <td>
                        <textarea style="width: 300px;" class="easyui-validatebox" name="entity.Description"><%= ((Domain.Article)this.ViewData["entity"]).Description%></textarea>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" style="text-align: center; width: 120px;">
                        内容：
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <%=Html.FckEditor("entity.Content", string.IsNullOrEmpty(((Domain.Article)this.ViewData["entity"]).Content) ?
                                                        string.Empty : ((Domain.Article)this.ViewData["entity"]).Content.Replace("\r", string.Empty).Replace("\n", string.Empty).Replace("'", "\\'"), 
        new FckConfig { Width="100%", Height="400", Skin= FckSkin.Office2003, ToolbarSet= FckToolbarSet.Default })%>
                    </td>
                </tr>
            </table>
        </div>
        <div title="英文信息">
            <div class="title" style="text-align: center; height: 20px; line-height: 20px; font-size: large;
                color: White; background-color: #6699FF">
                英文信息
            </div>
            <table style="width:100%;">
                <tr>
                    <td style="text-align: right; width: 120px;">
                        关键字：
                    </td>
                    <td>
                        <input type="text" style="width: 300px;" class="easyui-validatebox" name="entity.KeywordEn"
                            value="<%= ((Domain.Article)this.ViewData["entity"]).KeywordEn %>" />
                    </td>
                </tr>
                <tr>
                    <td style="text-align: right; width: 120px;">
                        描述：
                    </td>
                    <td>
                        <textarea style="width: 300px;" class="easyui-validatebox" name="entity.DescriptionEn"><%= ((Domain.Article)this.ViewData["entity"]).DescriptionEn%></textarea>
                    </td>
                </tr>
                <tr>
                    <td style="text-align: center; width: 120px;" colspan="2">
                        内容：
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <%=Html.FckEditor("entity.ContentEn", string.IsNullOrEmpty(((Domain.Article)this.ViewData["entity"]).ContentEn) ?
                                                        string.Empty : ((Domain.Article)this.ViewData["entity"]).ContentEn.Replace("\r", string.Empty).Replace("\n", string.Empty).Replace("'", "\\'"), 
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
