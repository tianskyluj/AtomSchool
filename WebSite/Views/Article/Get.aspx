<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <% var language = HttpContext.Current.Session["isCN"];
       var isCN = language == null || language.ToString() != false.ToString();
       var entity = (Domain.Article)this.ViewData["entity"]; %>
    <meta name="keywords" content="<%= isCN?entity.Keyword:entity.KeywordEn %>" />
    <meta name="description" content="<%= isCN?entity.Description:entity.DescriptionEn %>" />
    <title>
        <%= this.Html.Language("CompanyName") %>
        --
        <%=isCN ? entity.Name : entity.NameEn %>
    </title>
    <link href="/Content/Site.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <div id="body">
        <div id="headc">
            <div id="name">
                <img src="/Images/<%= this.Html.Language("LogoImage") %>.jpg" alt="logo" style="border-width: 0px;" /></div>
            <div id="title">
                <img alt="中文" src="/Images/list1.jpg" /><a href="/Home/ChangeLanguage/?language=zh-CN">中文</a>
                <img alt="English" src="/Images/list1.jpg" /><a href="/Home/ChangeLanguage/?language=en-US">English</a>
                <span>
                    <%= DateTime.Now.ToString(this.Html.Language("DateTimeToString"))%></span></div>
            <div id="menu">
                <span><a href="/Index.html"><font color="#ffffff">
                    <%= this.Html.Language("Home") %>
                </font></a>|
                    <% foreach (var item in this.ViewData["ForumList"] as IEnumerable<Domain.Forum>)
                       { %>
                    <a href="/<%= item.ID %>/Category.html"><font color="#ffffff">
                        <%= isCN ? item.Name : item.NameEn %></font></a> |
                    <%} %>
                </span>
            </div>
        </div>
        <div id="middle">
            <div id="left">
                <!--左菜单-->
                <div>
                    <img src="/Images/menulist1.jpg" alt="menu" />
                    <ul>
                        <%foreach (var item in (IEnumerable<Domain.Category>)this.ViewData["CategoryList"])
                          {%>
                        <li><a href="/<%= item.Forum.ID %>/<%= item.ID %>/Category.html">
                            <%= isCN ? item.Name : item.NameEn %></a></li>
                        <% } %>
                    </ul>
                </div>
                <div id="ImgaeList">
                    <tt>
                        <%= isCN ? entity.Category.Name : entity.Category.NameEn %></tt>
                    <br />
                    <br />
                    <ul>
                    </ul>
                </div>
            </div>
            <div id="content">
                <div>
                    <!--内容-->
                    <div class="title" style="text-align: center">
                        <span>
                            <%= isCN ? entity.Name : entity.NameEn%></span><br />
                        <span class="grey"><span>
                            <%= this.Html.Language("CreatDate")%>
                            :
                            <%= entity.CreateDate.ToString(this.Html.Language("DateTimeToString"))%>
                        </span><span>
                            <%= this.Html.Language("ViewCount")%>
                            :
                            <%= entity.ViewCount %>
                        </span><span>
                            <%= this.Html.Language("From")%>
                            :
                            <%= entity.From %></span></span>
                    </div>
                    <div class="content">
                        <%= isCN ? entity.Content : entity.ContentEn %>
                    </div>
                </div>
            </div>
        </div>
        <div id="bottom">
            <div class="hr">
            </div>
            <div id="copy">
                <div class="gs">
                    <img alt="copy" src="/Images/gs.jpg" /></div>
                <div class="txt">
                    <%= this.Html.Language("Address") %>
                    Email：postmaster@91realsoft.com
                    <br />
                    <%= this.Html.Language("Telephone") %>
                    : +86-991-6684302
                    <%= this.Html.Language("Fax") %>
                    ：+86-991-3839396
                    <br />
                    新ICP2009019
                     &nbsp;&nbsp;
                    <script src="http://s21.cnzz.com/stat.php?id=3163441&web_id=3163441&show=pic" language="JavaScript"></script>
                    </div>
            </div>
        </div>
</body>
</html>
