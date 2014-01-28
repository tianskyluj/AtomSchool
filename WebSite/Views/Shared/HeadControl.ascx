<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>
<meta charset="utf-8">
    <title runat="server" id="title"><%:ViewData["CompanyName"]%></title>
    <meta name="viewport" content="width=device-width, initial-scale=1.0"/>
    <meta name="description" content=""/>
    <meta name="author" content="">
    <link rel="shortcut icon" href="http://cesarlab.com/templates/social/assets/img/favicon.ico" />
    <link rel="icon" type="image/gif" href="../assets/img/favicon.gif"/>
    <link href="../assets/css/twitter-bootstrap/bootstrap.css" rel="stylesheet"/>
    <link href="../assets/css/social.css" rel="stylesheet"/>
    <link href="../assets/css/social.plugins.css" rel="stylesheet"/>
    <link href="../assets/css/social.examples.css" rel="stylesheet"/>
    <link href="../assets/css/font-awesome.css" rel="stylesheet"/>
    <link href="../assets/css/twitter-bootstrap/bootstrap-responsive.css" rel="stylesheet"/>
    <link href="../assets/js/bootstrap-fileupload/bootstrap-fileupload.min.css" rel="stylesheet"/>
    <link href="../assets/css/docs.css" rel="stylesheet"/>
    <link href="../assets/js/jqvmap/jqvmap/jqvmap.css" rel="stylesheet"/>
    <link href="../assets/js/datatables/media/DT_bootstrap.css" rel="stylesheet"/>
    <link href="../assets/css/bootstrap-multiselect.css" rel="stylesheet" type="text/css"/>
    <link href="../assets/css/prettify.css" rel="stylesheet" type="text/css"/>
    <link href="../assets/css/bootstrap-tree.min.css" rel="stylesheet" type="text/css"/>
    <link href="../assets/css/fineuploader.min.css" rel="stylesheet"/>
    <link href="../assets/css/slider.css" rel="stylesheet">
    <style>
        #g1, #g2, #g3
        {
            width: 200px;
            height: 160px;
            display: inline-block;
        }
    </style>
    <style>
        .wraper #main
        {
            margin-top: 40px;
        }
    </style>
    <style>
        /*mangoChat 在谷歌浏览器下不工作解决方案*/
        .chat-dialog {
        pointer-events:all;
        }
        .dialog-container {
        pointer-events:none;
        visibility:visible !important;
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