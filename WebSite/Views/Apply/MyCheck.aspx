<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<body>
    <div class="row-fluid">
        <div class="span12">
            <h3 class="page-title">
                我的审核
            </h3>
        </div>
    </div>
    <div class="row-fluid">
        <div class="span12">
            <div class="social-box">
                <%--<div class="header">
                    <div class="btn-group hidden-phone">
                        <a class="btn btn-primary" id="add-row-mycheck" href="#"><i class="icon-plus"></i>添加
                        </a><a class="btn btn-danger disabled" href="#" id="delete-row-mycheck"><i class="icon-trash">
                        </i>批量删除 </a>
                        <input style="visibility: hidden" id="mycheckID" />
                        <input style="visibility: hidden" id="mycheckCheckedNum" value="0" />
                    </div>
                    <div class="tools">
                        <a class="btn btn-success btn-advanced" id="btn-advanced" href="javascript:void(0)"
                            data-toggle="collapse" data-target="#advanced-search"><i class="icon-filter"></i>
                            高级查询 </a>
                        <div class="btn-group">
                            <button class="btn dropdown-toggle" data-toggle="dropdown">
                                <i class="icon-cog"></i>
                            </button>
                            <ul class="dropdown-menu pull-right">
                                <li><a href="#">打印</a></li>
                                <li><a href="#">保存至PDF</a></li>
                                <li class="divider"></li>
                                <li><a href="#">导出EXCEL</a></li>
                            </ul>
                        </div>
                    </div>
                </div>--%>
                <div class="body">
                    <table cellpadding="0" cellspacing="0" border="0" class="table table-striped table-bordered"
                        id="mycheckTable">
                        <thead>
                            <tr>
                                <th>
                                    <input type="checkbox" class="toggle-checkboxes" />
                                </th>
                                <th>
                                    操作
                                </th>
                                <th>
                                    申请类型
                                </th>
                                <th>
                                    申请人
                                </th>
                                <th>
                                    审核状态
                                </th>
                                <th>
                                    申请时间
                                </th>
                                <th>
                                    审核备注
                                </th>
                            </tr>
                        </thead>
                        <tbody>
                            <% foreach (var item in (this.ViewData["CheckLog"] as IEnumerable<Domain.CheckLog>).OrderByDescending(f => f.CreateTime))
                               { %>
                            <tr class="gradeX">
                                <td>
                                    <input type="checkbox" class="checkbox" value='<%= item.ID%>' />
                                </td>
                                <td>
                                    <% if (item.CheckState == 0)
                                       { %>
                                    <a class="btn btn-success btn-mini modify" href="#" applyid='<%= item.Apply.ID%>' value='<%= item.ID%>'><i class="icon-edit">
                                    </i>审核 </a>
                                    <% } %>
                                    <% if (item.CheckState == 1 && !item.IsRecommit)
                                       { %>
                                    <a class="btn btn-danger btn-mini reapply" href="#" value='<%= item.ID%>'><i class="icon-edit">
                                    </i>提交其他角色审核 </a>
                                    <% } %>
                                    
                                </td>
                                <td>
                                    <%= item.Apply.ApplyType.ApplyTypeName%>
                                </td>
                                <td>
                                    <%= item.Apply.SendUser.Name%>
                                </td>
                                <td>
                                    <% if (item.CheckState == 0)
                                       { %>
                                    待审核
                                    <% } %>
                                    <% else if (item.CheckState == 1)
                                        { %>
                                    审核通过
                                    <% } %>
                                    <% else
                                        { %>
                                    未通过
                                    <% } %>
                                </td>
                                <td>
                                    <%= item.CreateTime%>
                                </td>
                                <td>
                                    <%= item.Remark%>
                                </td>
                            </tr>
                            <% } %>
                        </tbody>
                    </table>
                </div>
            </div>
        </div>
    </div>
    <aside id="modify" class="modal hide fade" tabindex="-1" role="dialog" aria-labelledby="myModalLabel"
        aria-hidden="true">
        <div class="modal-header">
            <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
            <h3 id="roleAddOrUpdateTitle"><span id="Span5">审核</span></h3>
        </div>
        <div class="modal-body">
            <div class="control-group">
                <div class="controls">
                    <span><a href="javascript:void(0)">申请类型:</a><span id="applyType_detail"></span></span>
                </div>
                <div class="controls">
                    <span><a href="javascript:void(0)">申请人:</a><span id="applyUser_detail"></span></span>
                </div>
                <a href="javascript:void(0)">申请详细:</a>
                <div class="controls">
                    <textarea id="content_detail" class="span3"  rows="5" readonly="readonly"></textarea>
                </div>
                <div class="controls">
                    <a href="javascript:void(0)">附件</a>
                    <table id="attach" class="table">
                        
                    </table>
                </div>
                <div class="controls">
                    <select id="sel_checkState" class="span3">
                        <option  value="1">通过</option>
                        <option  value="-1">退回</option>
                    </select>
                </div>
                <a href="javascript:void(0)">审核备注:</a>
                <div class="controls">
                    <textarea id="checkRemark" class="span3" ></textarea>
                </div>
                <span id="checklogId" class="hidden"></span>
            </div>
        <div class="modal-footer">
                <button class="btn btn-danger" data-dismiss="modal">关闭</button>
            <a class="btn btn-success" id="save" href="javascript:void(0)">确定</a>
        </div>
    </aside>
    <aside id="reapply" class="modal hide fade" tabindex="-1" role="dialog" aria-labelledby="myModalLabel"
        aria-hidden="true">
        <div class="modal-header">
            <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
            <h3 id="H1"><span id="Span1">提交他人审核</span></h3>
        </div>
        <div class="modal-body">
            <div class="control-group">
                <div class="controls">
                    <select id="sel_receiveRole"  class="span3">
                        <option class="opt_receiveRole" value="0">请选择下级审核角色</option>
                        <% foreach (var item in (this.ViewData["Role"] as IList<Domain.Role>).OrderBy(f => f.RoleName))
                           { %>
                        <option class="opt_receiveRole" value="<%= item.ID %>">
                            <%= item.RoleName%></option>
                        <% } %>
                    </select>
                </div>
            </div>
        </div>
        <div class="modal-footer">
                <button class="btn btn-danger" data-dismiss="modal">关闭</button>
            <a class="btn btn-success" id="saveReapply" href="javascript:void(0)">确定</a>
        </div>
    </aside>
</body>
<script src="../../Scripts/Apply/MyCheck.js"></script>
</html>
