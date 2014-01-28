<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Browser.aspx.cs" Inherits="MvcFckEditor.Views.FckEditor.Browser" %>
<%@ Import Namespace="MvcFckEditor.Models" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
  <title><%=this.ViewData["PageTitle"]%></title>
  <style type="text/css">
    body { margin-top:5px; margin-bottom:5px;}
    *{ font-size:12px; }
    h1 {font-size:16px;}
    form {padding:0px; margin:0px;}
    .Error { color:Red; }
    .Content { border:1px solid #000; overflow:auto; height:500px; }
    .Content ul { margin:10px 0px; padding:0px;}
    .Content ul li { float:left; width:110px; height:135px; margin-left:10px; list-style:none; } 
    .Content ul li div {width:110px; height:110px; border-style:solid; border-color:#cccccc; border-width:1px; text-align:center; vertical-align:middle; line-height:110px;}
    .Content ul li div img { border:0px;}
    .Content ul li h5 { font-weight:normal; line-height:18px; margin:0px; padding:0px; overflow:hidden; height:18px;}
  </style>
		<script type="text/javascript" language="javascript">
		  function OpenFile(fileUrl) {
		    window.top.opener.SetUrl(encodeURI(fileUrl).replace('#', '%23'));
		    window.top.close();
		    window.top.opener.focus();
		  }
		</script>
</head>
<body>
  <%using (Html.BeginForm("UploadFile", "FckEditor", FormMethod.Post, new { enctype="multipart/form-data" }))  {%>
  <table width="100%">
    <tr>
      <td><h1><%=this.ViewData["PageTitle"]%></h1></td>
      <td align="right">
        <input type="file" name="NewFile" />
        <input type="submit" value="上传文件" />
        <span class="Error"><%=this.TempData["Error"]%></span>
        <%=Html.Hidden("FFolder", this.ViewData["CurrentFolder"])%>
        <%=Html.Hidden("FType", this.ViewData["Type"])%>
      </td>
    </tr>
  </table>
  <% } %>
  <hr />
  <%using (Html.BeginForm("CreateFolder", "FckEditor")){%>
  <table width="100%">
    <tr>
      <td>
        当前目录：
        <%=this.ViewData["CurrentFolder"]%><%=Html.TextBox("NewFolder")%>
        <input type="submit" value="创建新目录" />
        <%=Html.Hidden("CFolder", this.ViewData["CurrentFolder"])%>
        <%=Html.Hidden("CType", this.ViewData["Type"])%>
      </td>
    </tr>
  </table>
  <% } %>
  <div class="Content">
  <ul>
  <%foreach (FckItemInfo objItem in this.ViewData.Model)
    {%>
    <li>
      <div>&nbsp;<a href="<%=objItem.Url %>"><img src="<%=objItem.Icon %>" alt="<%=objItem.Name %>" width="<%=objItem.ThumbWidth %>" height="<%=objItem.ThumbHeight %>" /></a>&nbsp;</div>
      <h5><a href="<%=objItem.Url %>" title="<%=objItem.Name %>"><%=objItem.Name %></a></h5>
    </li>
  <%} %>
  </ul>
  <div style="clear:both;"></div>
  </div>
</body>
</html>
