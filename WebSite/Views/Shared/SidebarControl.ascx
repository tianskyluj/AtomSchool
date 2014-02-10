<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>
<aside class="social-sidebar sidebar-full">
    <div class="social-sidebar-content">
        <div class="scrollable">
            <div>
                <div class="user">
                    <img  id="avatar" class="avatar" width="25" height="25" src=<%: ViewData["Avatar"] %> alt="Julio Marquez"/>
                    <span data-toggle="dropdown" ><%: ViewData["name"] %> <a style="display:none " class="sign" href="javascript:void(0)" style="float:right"><%: ViewData["registration"]%></a></span>
                </div>
                <div class="navigation-sidebar">
                    <i class="switch-sidebar-icon icon-chevron-left"></i>
                    <i class="switch-sidebar-full icon-chevron-right"></i>
                    <span>我的菜单</span>
                </div>
            </div>
            <section class="menu">
                <div class="accordion" id="accordion2">
                    <div class="accordion-group active">
                        <div class="accordion-heading">
                            <a class="accordion-toggle opened" href="/Home/Index">
                                <img src="../assets/img/icons/stuttgart-icon-pack/32x32/home.png" alt="工作台"/>
                                <span>工作台</span>
                            </a>
                        </div>
                    </div>
                    <% foreach (var item in (this.ViewData["SystemModel"] as IList<Domain.SystemModel>).Where(f => f.ParentId == new Guid()).OrderBy(f => f.OrderIndex))
                                       { %>
                    <div class="accordion-group ">
                        <div class="accordion-heading">
                            <a class="accordion-toggle " data-toggle="collapse" data-parent="#accordion2" href="#<%= item.ID %>">
                                <img src='<%= item.Icon %>' alt="Charts"/>
                                <span><%= item.Name%></span>
                                <span class="<%= item.ShortName %>"></span>
                                <span class="arrow "></span>
                            </a>
                        </div>
                        <ul id="<%= item.ID %>" class="accordion-body collapse nav nav-list collapse ">
                            <% foreach (var childrenItem in (this.ViewData["SystemModel"] as IList<Domain.SystemModel>).Where(f => f.ParentId == item.ID).OrderBy(f => f.OrderIndex))
                                               {  %>
                            <li>
                                <a href="javascript:redirect('<%= childrenItem.Url%>')">
                                    <%= childrenItem.Name%>
                                    <span  class="<%= childrenItem.ShortName %>"></span>
                                </a>
                            </li>
                            <% } %>
                        </ul> 
                    </div>
                    <% } %>
                </div>
            </section>
        </div>
    </div>
</aside>