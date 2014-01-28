<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta charset="utf-8">
    <title id="title" runat="server"><%:ViewData["CompanyName"]%></title>
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <meta name="description" content="">
    <meta name="author" content="">
    <link rel="shortcut icon" href="http://cesarlab.com/templates/social/assets/img/favicon.ico" />
    <link rel="icon" type="image/gif" href="../../assets/img/favicon.gif">
    <link href="../../assets/css/twitter-bootstrap/bootstrap.css" rel="stylesheet">
    <link href="../../assets/css/social.css" rel="stylesheet">
    <link href="../../assets/css/social.plugins.css" rel="stylesheet">
    <link href="../../assets/css/social.examples.css" rel="stylesheet">
    <link href="../../assets/css/font-awesome.css" rel="stylesheet">
    <link href="../../assets/css/twitter-bootstrap/bootstrap-responsive.css" rel="stylesheet">
    <link href="../../assets/css/docs.css" rel="stylesheet">
    <style type="text/css">
        body
        {
            padding-top: 40px;
            padding-bottom: 40px;
            background-color: #e9eaed;
        }
    </style>
    <style>
        .wraper #main
        {
            margin-top: 40px;
        }
    </style>
    <script>
        ie = false;
    </script>
    <!--[if lt IE 9]>
      <script src="/templates/social/assets/js/html5shiv.js"></script>
    <![endif]-->
    <!--[if lte IE 8]>
    <script src="/templates/social/assets/js/respond/respond.min.js"></script>
    <script>
        ie = 8;
    </script>
    <![endif]-->
    <!--[if lte IE 8]><script language="javascript" type="text/javascript" src="/templates/social/assets/js/jquery-flot/excanvas.min.js"></script><![endif]-->
    <script type="text/javascript">
      /*<![CDATA[*/
      var _gaq = _gaq || [];
      _gaq.push(['_setAccount', 'UA-38708835-1']);
      _gaq.push(['_trackPageview']);
      (function() {
        var ga = document.createElement('script'); ga.type = 'text/javascript'; ga.async = true;
        ga.src = ('https:' == document.location.protocol ? 'https://ssl' : 'http://www') + '.google-analytics.com/ga.js';
        var s = document.getElementsByTagName('script')[0]; s.parentNode.insertBefore(ga, s);
      })();
      /*]]>*/
    </script>
</head>
<body>
    <div class="container">
        <form class="form-login" id="formLogin" runat="server">
        <h2 class="form-heading">
            <span id="title_login"><%: ViewData["CompanyName"] %></span></h2>
        <input type="text" id="userName"  class="input-block-level" data-bind="value:userName" placeholder="用户名"/>
        <input type="password" id="passWord"  class="input-block-level" data-bind="value:passWord" placeholder="密码"/>
        <div class="row-fluid">
            <%--<label class="checkbox span6">
                <input type="checkbox" value="remember-me"/>记住密码
            </label>--%>
            <button id="login"  class="btn btn-primary pull-right span12" data-bind="click:login">登录</button>
        </div>
        </form>
        <div class="form-footer-copyright">
            2013 © <small>原子科技</small>
        </div>
        <% Html.RenderPartial("MessageControl"); %>
    </div>
    <script src="http://ajax.googleapis.com/ajax/libs/jquery/1.9.1/jquery.min.js" ></script>
    <script>        window.jQuery || document.write('<script src="../assets/js/jquery-1.9.1.min.js"><\/script>')</script>
    <script src="../../assets/js/jquery-ui/js/jquery-ui-1.10.1.custom.min.js"></script>
    <script src="../../assets/js/twitter-bootstrap/bootstrap.js"></script>
    <script src="../../assets/js/jquery-slimscroll/jquery.slimscroll.min.js"></script>
    <!--[if lte IE 8]>
    <script src="/templates/social/assets/js/placeholders/placeholders.min.js"></script>
    <![endif]-->
    <script src="../../assets/js/extents.js"></script>
    <script src="../../assets/js/app.js"></script>
    <script src="../../assets/js/knockout-2.3.0.js"></script>
    <script src="../../Scripts/Home/Login.js"></script>
    <script>
      /*<![CDATA[*/
      var _gauges = _gauges || [];
      (function() {
        var t   = document.createElement('script');
        t.type  = 'text/javascript';
        t.async = true;
        t.id    = 'gauges-tracker';
        t.setAttribute('data-site-id', '');
        t.src = '..///secure.gaug.es/track.js';
        var s = document.getElementsByTagName('script')[0];
        s.parentNode.insertBefore(t, s);
      })();
      /*]]>*/
    </script>
</body>
</html>
