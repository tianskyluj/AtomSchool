<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<body>
    <div class="row-fluid">
        <div class="span12">
            <h3 class="page-title">
                维护业务统计
            </h3>
        </div>
    </div>
    <div class="row-fluid">
        <div class="span12">
            <div class="social-box">
               <%-- <div class="header">
                    <div class="btn-group hidden-phone">
                        <a class="btn btn-primary" id="add-row-custom" href="#"><i class="icon-plus"></i>添加
                        </a><a class="btn btn-danger disabled" href="#" id="delete-row-custom"><i class="icon-trash">
                        </i>批量删除 </a>
                        <input style="visibility: hidden" id="customID" />
                        <input style="visibility: hidden" id="customCheckedNum" value="0" />
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
                        id="customTable">
                        <thead>
                            <tr>
                                <th>
                                    <input type="checkbox" class="toggle-checkboxes" />
                                </th>
                                <th>
                                    操作
                                </th>
                                <th>
                                    客户
                                </th>
                                <th>
                                    维护方式
                                </th>
                                <th>
                                    维护类型
                                </th>
                                <th>
                                    维护人
                                </th>
                                <th>
                                    维护时间
                                </th>
                                 <th>
                                    维护结果
                                </th>
                                 
                            </tr>
                        </thead>
                        <tbody>
                            <% foreach (var item in (this.ViewData["CustomMaintain"] as IEnumerable<Domain.CustomMaintain>).OrderBy(f => f.CreateTime))
                               { %>
                            <tr class="gradeX">
                                <td>
                                    <input type="checkbox" class="checkbox" value='<%= item.ID%>' />
                                </td>
                                <td>
                                    <a class="btn btn-mini detail" href="#" value='<%= item.ID%>'>
                                        <i class="icon-delete"></i>查看 
                                    </a>
                                </td>
                                <td>
                                    <%= item.Custom.Name%>
                                </td>
                                <td>
                                    <%= item.MaintainMethod.MethodName%>
                                </td>
                                <td>
                                    <%= item.MaintainType.TypeName%>
                                </td>
                                 <td>
                                    <%= item.MaintainUser.Name%>
                                </td>
                                <td>
                                    <%= item.MaintainTime%>
                                </td>
                                 <td>
                                    <%= item.Result%>
                                </td>
                            </tr>
                            <% } %>
                        </tbody>
                    </table>
                </div>
            </div>
        </div>
    </div>
    <aside id="detail" class="modal hide fade" tabindex="-1" role="dialog"
        aria-labelledby="myModalLabel" aria-hidden="true">
        <div class="modal-header">
            <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
            <h3 id="roleAddOrUpdateTitle"><span id="Span5">详细</span></h3>
        </div>
        <div class="modal-body">
            <div class="control-group">
                <div class="controls">
                    <span><a href="javascript:void(0)">维护方式:</a><span id="maintainMethod_detail"></span></span>
                </div>
                <div class="controls">
                     <span><a href="javascript:void(0)">择维护类型:</a><span  id="maintainType_detail"></span></span>
                </div>
               <div class="controls">
                     <span><a href="javascript:void(0)">维护客户:</a><span  id="custom_detail"></span></span>
                </div>
                <div class="controls">
                     <span><a href="javascript:void(0)">维护时间:</a><span  id="maintainTime_detail"></span></span>
                </div>
                <div class="controls">
                    <div class="controls">
                        <textarea rows="5" cols="5" id="result_detail" readonly="readonly"  class="input-xlarge"  ></textarea>
                    </div>
                </div>
            </div>
        </div>
        <div class="modal-footer">
            <button class="btn btn-danger" data-dismiss="modal">关闭</button>
        </div>
    </aside>
</body>
<script src="../../Scripts/Custom/ActiveSummary.js"></script>
</html>
