<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<body>
    <div class="row-fluid">
        <div class="span12">
            <h3 class="page-title">
                <%: ViewData["Title"]%>
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
                            <select id="sel_customType" class="span3">
                                <option class="opt_customType" value="0">请选择客户类型</option>
                                <% foreach (var item in (this.ViewData["CustomType"] as IList<Domain.CustomType>).OrderBy(f => f.OrderIndex))
                                   { %>
                                <option class="opt_customType" value="<%= item.ID %>">
                                    <%= item.TypeName%></option>
                                <% } %>
                            </select>
                        </div>
                    </div>
                    <div class="control-group">
                        <div class="controls">
                            <input id="customName_edit" type="text" class="input-xlarge" placeholder="填写客户姓名" />
                        </div>
                    </div>
                    <div class="control-group">
                        <div class="controls">
                            <input id="telphone_edit" type="text" class="input-xlarge" placeholder="填写联系电话" />
                        </div>
                    </div>
                    <div class="control-group">
                        <div class="controls">
                            <div id="birthday_edit" class="input-append date">
                                <input data-format="yyyy-MM-dd " placeholder="选择客户生日"
                                    type="text" class="input-block-level"/>
                                <span class="add-on"><i data-time-icon="icon-time" data-date-icon="icon-calendar"
                                    class="icon-calendar"></i></span>
                            </div>
                        </div>
                    </div>
                    <div class="control-group">
                        <div class="controls">
                            <textarea rows="5" id="remark" type="text" class="input-xlarge" placeholder="填写备注" ></textarea>
                        </div>
                    </div>
                    <div>
                        <a id="btn_save" class="btn btn-primary">确定 </a><a id="btn_reset" class="btn">重置
                        </a>
                    </div>
                    </form>
                    <input id="customID" class="hidden" value='<%: ViewData["CustomID"] %>' />
                </div>
            </div>
        </div>
    </div>
</body>
<script src="../../Scripts/Custom/NewCustom.js"></script>
</html>
