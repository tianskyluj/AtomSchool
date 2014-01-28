<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

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
    <script language="javascript" type="text/javascript">

        function submit() {
            $('#form').form('submit', {
                onSubmit: function () {
                    return $(this).form('validate');
                },
                success: function (msg) {
                    $.messager.alert('提示', "保存成功", 'info', function () {
                        window.location.href = "/Forum/Index/";
                    });
                }
            });
        }

    </script>
</head>
<body class="easyui-layout">
    <div region="center" border="false">
        <div region="north" border="true" class="title" style="text-align: center; height: 40px;
            line-height: 40px; font-size: x-large;">
            版块信息
        </div>
        <div region="center">

            <form id="form" method="post" action="/Forum/Save/" enctype="application/x-www-form-urlencoded">
            <input type="hidden" id="id" name="entity.ID" value="<%= ((dynamic)this.ViewData["entity"]).ID %>" />
            <table style="width: 100%">
                <tr>
                    <td style="text-align: right; width: 120px;">
                        排序顺序(<font color="red">*</font>)：
                    </td>
                    <td>
                        <input type="text" class="easyui-validatebox" required="true" name="entity.OrderNo"
                            value="<%= ((dynamic)this.ViewData["entity"]).OrderNo %>" />
                    </td>
                </tr>
                <tr>
                    <td style="text-align: right; width: 120px;">
                        中文名(<font color="red">*</font>)：
                    </td>
                    <td>
                        <input type="text" class="easyui-validatebox" required="true" name="entity.Name"
                            value="<%= ((dynamic)this.ViewData["entity"]).Name %>" />
                    </td>
                </tr>
                <tr>
                    <td style="text-align: right; width: 120px;">
                        英文名(<font color="red">*</font>)：
                    </td>
                    <td>
                        <input type="text" class="easyui-validatebox" required="true" name="entity.NameEn"
                            value="<%= ((dynamic)this.ViewData["entity"]).NameEn %>" />
                    </td>
                </tr>
                <tr>
                    <td style="text-align: right; width: 120px;">
                        显示(<font color="red">*</font>)：
                    </td>
                    <td>
                        <input type="checkbox" name="entity.IsEnabled" <%= ((dynamic)this.ViewData["entity"]).IsEnabled?"checked=\"checked\"":string.Empty
                                %> value="<%= ((dynamic)this.ViewData["entity"]).IsEnabled %>" onclick="this.value=checked=='checked'||'true';"/>
                    </td>
                </tr>
               
            </table>
            </form>
        </div>
    </div>
    <div region="south" border="true" style="text-align: right; height: 40px; line-height: 30px;
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
</body>
</html>
