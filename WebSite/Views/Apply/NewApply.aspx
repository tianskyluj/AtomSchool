<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<body>
    <div class="row-fluid">
        <div class="span12">
            <h3 class="page-title">
                提交申请
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
                            <select id="sel_applyType"  class="span3">
                                 <option class="opt_applyType" value="0">请选择申请类型</option>
                                <% foreach (var item in (this.ViewData["ApplyType"] as IList<Domain.ApplyType>).OrderBy(f => f.OrderIndex))
                                   { %>
                                <option class="opt_applyType" value="<%= item.ID %>">
                                    <%= item.ApplyTypeName%></option>
                                <% } %>
                            </select>
                        </div>
                        <div class="controls" style="margin-bottom: 10px">
                            <select id="sel_receiveRole"  class="span3">
                                <option class="opt_receiveRole" value="0">请选择下级审核角色</option>
                                <% foreach (var item in (this.ViewData["Role"] as IList<Domain.Role>).OrderBy(f => f.RoleName))
                                   { %>
                                <option class="opt_receiveRole" value="<%= item.ID %>">
                                    <%= item.RoleName%></option>
                                <% } %>
                            </select>
                        </div>
                        <div class="controls">
                            <textarea id="apply_edit" placeholder="输入申请详细(必填)..." class="span9" style="height: 150px"> </textarea>
                        </div>
                        <div class="controls">
                            <div id="jquery-wrapped-fine-uploader" ></div>
                        </div>
                    </div>
                    <div>
                        <a id="btn_sendApply" class="btn btn-primary">确定 </a>
                        <a id="btn_reset" class="btn">重置</a>
                    </div>
                    </form>
                </div>
            </div>
        </div>
    </div>
</body>
<script src="../../assets/js/wysihtml5/dist/wysihtml5-0.3.0.min.js"></script>
<script src="../../assets/js/bootstrap-wysihtml5/src/bootstrap-wysihtml5.js"></script>
<script src="../../Scripts/Apply/NewApply.js"></script>
<script src="../../assets/js/bootstrap-tree.js"></script>
<link href="../../assets/js/bootstrap-wysihtml5/src/bootstrap-wysihtml5.css" rel="stylesheet">

</html>
