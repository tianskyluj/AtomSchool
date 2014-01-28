<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<body>
    <div class="row-fluid">
        <div class="span12">
            <h3 class="page-title">
                阅览文件
            </h3>
        </div>
    </div>
    <div class="row-fluid">
        <div class="span12">
            <div class="social-box">
                <div class="body">
                    <ul id="myTab" class="nav nav-tabs">
                    <% foreach (var item in (this.ViewData["PDFs"] as IEnumerable<Domain.UploadFile>).OrderBy(f => f.CreateTime))
                               { %>
                        <li ><a href="#<%= item.FileName%>" data-toggle="tab"><%= item.FileName%></a></li>
                        <% } %>
                    </ul>
                    <div id="myTabContent" class="tab-content">
                        <% foreach (var item in (this.ViewData["PDFs"] as IEnumerable<Domain.UploadFile>).OrderBy(f => f.CreateTime))
                               { %>
                        <div class="tab-pane fade active in" id="<%= item.FileName%>">
                            <div class="row-fluid">
                                <div class="span12">
                                    <div class="body">
                                        <iframe id="iframeContent" name="contentIframe" style="scroll: no;" frameborder="0"  
                                            width="100%" height="500px" src="<%= item.FileURL%>"></iframe>  
                                    </div>
                                </div>
                            </div>
                        </div>
                        <% } %>
                    </div>
                </div>
            </div>
        </div>
    </div>
</body>
<script src="../../Scripts/UploadFile/PDFView.js"></script>
</html>
