<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>
<footer id="footer" >
    <div class="container-fluid">
    2013 © <em>原子网络科技公司</em> by <a href="http://orchidcoder.com//" target="_blank">orchidcoder.com</a>.

    <div style="visibility:hidden">
        <input class="userId" value=<%: ViewData["userId"] %> />
    </div>
    </div>
</footer>