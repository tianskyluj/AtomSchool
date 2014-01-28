<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<body>
    <div class="row-fluid">
        <div class="span12">
            <h3 class="page-title">
                发起传阅
            </h3>
        </div>
    </div>
    <div class="row-fluid">
        <div class="span12">
            <div class="social-box">
                <div class="body">
                    <form action="#" id="form_newTask">
                    <div class="control-group">
                        <div class="controls">
                            <input id="title_edit" type="text" placeholder="传阅主题(必填)..." class="span3" />
                        </div>
                        <div class="controls" style="margin-bottom: 10px">
                            <select id="sel_receiveUser" multiple="multiple" class="span3">
                                <% foreach (var item in (this.ViewData["UserInfo"] as IList<Domain.UserInfo>).OrderBy(f => f.Account))
                                   { %>
                                <option class="opt_receiveUser" value="<%= item.ID %>">
                                    <%= item.Name%>[<%= item.Phone%>]</option>
                                <% } %>
                            </select>
                        </div>
                        <div class="controls">
                            <div id="jquery-wrapped-fine-uploader" ></div><span>同时只能传阅一份文件,只能上传pdf格式文件</span>
                        </div>
                    </div>
                    <div>
                        <a id="btn_sendPass" class="btn btn-primary">确定 </a><a id="btn_reset" class="btn">重置
                        </a>
                    </div>
                    </form>
                </div>
            </div>
        </div>
    </div>
</body>
<script src="../../Scripts/DocPass/NewDocPass.js"></script>
</html>
