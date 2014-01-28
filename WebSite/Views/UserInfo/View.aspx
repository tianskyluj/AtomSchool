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
            var code = "00000000-0000-0000-0000-000000000000";
            if ($("#id").val() == code) {
                var parm = { account: $("#iptAccount").val() }
                $.ajax({
                    type: "POST",
                    url: "/UserInfo/Exist",
                    data: $.param(parm),
                    success: function (msg) {
                        if (msg != "False") {
                            $.messager.alert('提示', "请输入的账号已存在，请重新输入！");
                        }
                        else {
                            post();
                        }
                    }
                });
            }
            else {
                post();
            }
        }

        function post() {
            $('#form').form('submit', {
                onSubmit: function () {
                    return $(this).form('validate');
                },
                success: function (msg) {
                    $.messager.alert('提示', "保存成功", 'info', function () {
                        window.location.href = "/UserInfo/Index/";
                    });
                }
            });
        }

    </script>
</head>
<body class="easyui-layout">
    <div region="center" border="false">
        <div region="north" border="true" class="title" style="text-align: center; height: 40px; line-height: 40px;font-size: x-large; ">
            用户信息
        </div>
        <div region="center">
            <% var isInsert = ((dynamic)this.ViewData["entity"]).ID == Guid.Empty; %>
            <form id="form" method="post" action="/UserInfo/Save/" enctype="application/x-www-form-urlencoded">
            <input type="hidden" id="id" name="entity.ID" value="<%= ((dynamic)this.ViewData["entity"]).ID %>" />
            <table style="width: 100%">
                <tr>
                    <td style="text-align: right; width: 120px;">
                        账号(<font color="red">*</font>)：
                    </td>
                    <td>
                        <input id="iptAccount" type="text" class="easyui-validatebox" required="true" name="entity.Account"
                            <%= isInsert?string.Empty:"readonly=\"readonly\""  %> value="<%= ((dynamic)this.ViewData["entity"]).Account %>" />
                    </td>
                </tr>
                <tr>
                    <td style="text-align: right; width: 120px;">
                        姓名(<font color="red">*</font>)：
                    </td>
                    <td>
                        <input type="text" class="easyui-validatebox" required="true" name="entity.Name"
                            value="<%= ((dynamic)this.ViewData["entity"]).Name %>" />
                    </td>
                </tr>
                <tr>
                    <td style="text-align: right; width: 120px;">
                        状态(<font color="red">*</font>)：
                    </td>
                    <td>
                        <select name="entity.IsEnabled">
                            <% if (((dynamic)this.ViewData["entity"]).IsEnabled)
                               { %>
                            <option selected="selected" value="true">激活</option>
                            <option value="false">禁用</option>
                            <% }
                               else
                               {%>
                            <option value="true">激活</option>
                            <option selected="selected" value="false">禁用</option>
                            <%  } %>
                        </select>
                    </td>
                </tr>
                <% if (!isInsert)
                   { %>
                <tr>
                    <td style="text-align: right; width: 120px;">
                        创建时间：
                    </td>
                    <td>
                        <%=  ((dynamic)this.ViewData["entity"]).CreateTime.ToString("yyyy-MM-dd")%>
                    </td>
                </tr>
                <% } %>
            </table>
            </form>
        </div>
    </div>
    <div region="south" border="true" style="text-align: right; height: 40px; line-height: 30px;background-color:#f7f7f7;">
        <table style="width: 100%">
            <tr>
                <td>
                </td>
                <td style="text-align: right">
                    <a href="#" class="easyui-linkbutton" iconcls="icon-save" onclick="submit();">提交</a> <a href="#" class="easyui-linkbutton"
                        iconcls="icon-cancel" onclick="location.href = document.referrer;">返回</a>
                </td>
            </tr>
        </table>
    </div>
</body>
</html>
