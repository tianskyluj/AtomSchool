<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <% Html.RenderPartial("HeadControl"); %>
</head>
<body>
    <div class="wraper sidebar-full">
        <form id="form1" runat="server">
        <% Html.RenderPartial("SidebarControl"); %>
        <% Html.RenderPartial("HeaderControl"); %>
        <div id="main">
            <div class="container-fluid" id="mainContent" style="min-height: 800px">
                <div class="row-fluid">
                    <div class="span12">
                        <h3 class="page-title">
                            工作台
                        </h3>
                    </div>
                </div>
                <div class="row-fluid">
                    <div class="span6">
                        <div class="social-box">
                            <div class="header">
                                <h4>
                                    我的邮件</h4>
                                    <a href="javascript:redirect('/Email/InBox')" style="float:right">查看更多</a>
                            </div>
                            <div class="body">
                                <table class="table">
                                    <thead>
                                        <tr>
                                            <th>
                                                标题
                                            </th>
                                            <th>
                                                发件人
                                            </th>
                                            <th>
                                                发件时间
                                            </th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        <% foreach (var item in (this.ViewData["EmailReceiveUserRelation"] as IEnumerable<Domain.EmailReceiveUserRelation>).OrderBy(f => f.Email.SendTime))
                                           { %>
                                        <tr class="gradeX">
                                            <td>
                                                <%= item.Email.Title%>
                                            </td>
                                            <td>
                                                <%= item.Email.SendUser.Name%>
                                            </td>
                                            <td>
                                                <%= item.Email.SendTime%>
                                            </td>
                                        </tr>
                                        <% } %>
                                    </tbody>
                                </table>
                            </div>
                        </div>
                    </div>
                    <div class="span6">
                        <div class="social-box">
                            <div class="header">
                                <h4>
                                    我的任务</h4>
                                    <a href="javascript:redirect('/Task/MyTask')" style="float:right">查看更多</a>
                            </div>
                            <div class="body">
                                <table class="table">
                                    <thead>
                                        <tr>
                                            <th>
                                                任务主题
                                            </th>
                                            <th>
                                                任务等级
                                            </th>
                                            <th>
                                                任务发送时间
                                            </th>
                                            <th>
                                                任务完成时间
                                            </th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        <% foreach (var item in (this.ViewData["TaskReceiveUserRelation"] as IEnumerable<Domain.TaskReceiveUserRelation>).OrderBy(f => f.Task.SendTime))
                                           { %>
                                        <tr class="gradeX">
                                            <td>
                                                <%= item.Task.Title%>
                                            </td>
                                            <td>
                                                <%= item.Task.TaskLevel.LevelName%>
                                            </td>
                                            <td>
                                                <%= item.Task.SendTime%>
                                            </td>
                                            <td>
                                                <%= item.FinishTime%>
                                            </td>
                                        </tr>
                                        <% } %>
                                    </tbody>
                                </table>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <% Html.RenderPartial("FooterControl"); %>
        </div>
        <% Html.RenderPartial("MessageControl"); %>
        <% Html.RenderPartial("JsIncludeControl"); %>
        </form>
    </div>
</body>
<script src="../../Scripts/Home/Index.js"></script>
</html>
