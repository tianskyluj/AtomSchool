<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<body>
    <div class="row-fluid">
        <div class="span12">
            <h3 class="page-title">
                添加客户维护
            </h3>
        </div>
    </div>
    <div class="row-fluid">
        <div class="span12">
            <div class="social-box">
                <div class="body">
                    <form action="#" id="form_newCustom">
                    <div class="control-group">
                        <div class="controls">
                            <select id="sel_maintainMethod" class="span3">
                                <option class="opt_maintainMethod" value="0">请选择维护方式</option>
                                <% foreach (var item in (this.ViewData["MaintainMethod"] as IList<Domain.MaintainMethod>).OrderBy(f => f.OrderIndex))
                                   { %>
                                <option class="opt_maintainMethod" value="<%= item.ID %>">
                                    <%= item.MethodName%></option>
                                <% } %>
                            </select>
                        </div>
                    </div>
                    <div class="control-group">
                        <div class="controls">
                            <select id="sel_maintainType" class="span3">
                                <option class="opt_maintainType" value="0">请选择维护类型</option>
                                <% foreach (var item in (this.ViewData["MaintainType"] as IList<Domain.MaintainType>).OrderBy(f => f.OrderIndex))
                                   { %>
                                <option class="opt_maintainType" value="<%= item.ID %>">
                                    <%= item.TypeName%></option>
                                <% } %>
                            </select>
                        </div>
                    </div>
                    <div class="control-group">
                        <div class="controls">
                            <select id="sel_custom" class="span3">
                                <option class="opt_custom" value="0">请选择维护客户</option>
                                <% foreach (var item in (this.ViewData["Custom"] as IList<Domain.Custom>).OrderBy(f => f.CreateTime))
                                   { %>
                                <option class="opt_custom" value="<%= item.ID %>">
                                    <%= item.Name%></option>
                                <% } %>
                            </select>
                        </div>
                    </div>
                    <div class="control-group">
                        <div class="controls">
                            <div id="maintainTime_edit" class="input-append date">
                                <input data-format="yyyy-MM-dd " placeholder="选择维系时间"
                                    type="text" class="input-block-level" />
                                <span class="add-on"><i data-time-icon="icon-time" data-date-icon="icon-calendar"
                                    class="icon-calendar"></i></span>
                            </div>
                        </div>
                    </div>
                    <div class="control-group">
                        <div class="controls">
                            <textarea rows="5" cols="5" id="result_edit"  class="input-xlarge" placeholder="填写维系结果" ></textarea>
                        </div>
                    </div>
                    <div>
                        <a id="btn_save" class="btn btn-primary">确定 </a><a id="btn_reset" class="btn">重置
                        </a>
                    </div>
                    </form>
                </div>
            </div>
        </div>
    </div>
</body>
<script src="../../Scripts/Custom/NewActive.js"></script>
</html>
