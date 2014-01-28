<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>
<header>
    <nav class="navbar navbar-blue navbar-fixed-top social-navbar">
    <div class="navbar-inner">
        <div class="container-fluid">
            <a class="btn btn-navbar" data-toggle="collapse" data-target=".social-sidebar">
                <span class="icon-bar"></span>
                <span class="icon-bar"></span>
                <span class="icon-bar"></span>
            </a>
            <a class="brand" runat="server" href="/Home/index" id="brand">
               <%: ViewData["CompanyName"] %>
            </a>
            <ul class="nav pull-right nav-indicators">
                <li class="dropdown nav-notifications">
                    <a href="#" class="dropdown-toggle" data-toggle="dropdown">
                        <% if ((int)ViewData["NoticeCount"] > 0)
                           { %>
                    <span class="badge"><%: ViewData["NoticeCount"]%></span>
                     <% } %>
                        <i class="icon-warning-sign"></i>
                    </a>
                    <ul class="dropdown-menu">
                        <li class="nav-notifications-header">
                            <a tabindex="-1" href="#">您有 <strong><%: ViewData["NoticeCount"]%></strong> 条通知</a>
                        </li>
                        <% foreach (var noticeItem in (this.ViewData["Notice"] as IEnumerable<Domain.Notice>).OrderBy(f => f.CreateTime))
                                   { %>
                        <li class="nav-notification-body text-info">
                            <a href="#">
                            <i class="icon-user"></i> <%= noticeItem.Content%>
                            <small class="pull-right"> <%= noticeItem.CreateTime%></small>
                            </a>
                        </li>
                        <% } %>
                        <%--<li class="nav-notifications-footer">
                            <a tabindex="-1" href="#">查看全部消息
                            </a>
                        </li>--%>
                    </ul>
                </li>
                
                <li class="divider-vertical"></li>
                <li class="dropdown">
                <a href="#" class="dropdown-toggle" data-toggle="dropdown"><i class="icon-caret-down"></i></a>
                                        <ul class="dropdown-menu">
            <li><a href="javascript:redirect('/Account/Index')"><i class="icon-user"></i> 个人资料</a></li>
            <% if ((bool)ViewData["visible"])
               { %>
                <li><a href="javascript:redirect('/System/Index')"><i class="icon-cogs"></i> 系统设置</a></li>
            <% } %>
            <li> <a  id="loginOut" href="/Home/LoginOut"><i class="icon-off"></i> 登出</a></li>
            <%--<li class="divider"></li>
            <li><a href="#"><i class="icon-info-sign"></i> 帮助</a></li>--%>
            </ul>
                </li>
            </ul>
        </div>
    </div>
    </nav> 
</header>
