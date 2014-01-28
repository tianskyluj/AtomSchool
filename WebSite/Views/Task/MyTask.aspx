<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<body>
    <div class="row-fluid">
        <div class="span12">
            <h3 class="page-title">
                我的任务
            </h3>
        </div>
    </div>
    <div class="row-fluid">
        <div class="span12">
            <div class="social-box">
                <%--<div class="header">
                    <div class="btn-group hidden-phone">
                        <a class="btn btn-primary" id="add-row-province" href="#"><i class="icon-plus"></i>添加
                        </a><a class="btn btn-danger disabled" href="#" id="delete-row-province"><i class="icon-trash">
                        </i>批量删除 </a>
                        <input style="visibility: hidden" id="taskID" />
                        <input style="visibility: hidden" id="taskCheckedNum" value="0" />
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
                        id="taskTable">
                        <thead>
                            <tr>
                                <th>
                                    <input type="checkbox" class="toggle-checkboxes" />
                                </th>
                                <th>
                                    操作
                                </th>
                                <th>
                                    任务概述
                                </th>
                                <th>
                                    分配人
                                </th>
                                <th>
                                    任务等级
                                </th>
                                <th>
                                    任务时限
                                </th>
                                 <th>
                                    分配时间
                                </th>
                                <th>
                                    任务状态
                                </th>
                                <th>
                                    完成比例
                                </th>
                            </tr>
                        </thead>
                        <tbody>
                            <% foreach (var item in (this.ViewData["TaskReceiveUserRelation"] as IEnumerable<Domain.TaskReceiveUserRelation>).OrderByDescending(f => f.Task.SendTime))
                               { %>
                            <tr class="gradeX">
                                <td>
                                    <input type="checkbox" class="checkbox" value='<%= item.ID%>' />
                                </td>
                                <td>
                                    <a class="btn btn-mini detail" href="#" value='<%= item.ID%>'>
                                        变更状态 
                                    </a>
                                </td>
                                <td>
                                    <%= item.Task.Title%>
                                </td>
                                 <td>
                                    <%= item.Task.SendUser.Name%>
                                </td>
                                <td>
                                    <%= item.Task.TaskLevel.LevelName%>
                                </td>
                                 <td>
                                    <%= item.Task.Deadline%>
                                </td>
                                 <td>
                                    <%= item.Task.SendTime%>
                                </td>
                                <td class="stateName">
                                    <%= item.TaskState.StateName%>
                                </td>
                                <td class="taskPercentage">
                                    <%= item.TaskPercentage%>%
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
            <h3 id="roleAddOrUpdateTitle"><span id="Span5">修改任务状态</span></h3>
        </div>
        <div class="modal-body">
            <div class="control-group">
                <div class="controls">
                    <select id="sel_TaskState"  class="span3">
                        <% foreach (var item in (this.ViewData["TaskState"] as IList<Domain.TaskState>).OrderBy(f => f.OrderIndex))
                            { %>
                        <option class="opt_TaskState" value="<%= item.ID %>">
                            <%= item.StateName%></option>
                        <% } %>
                    </select>
                </div>
                <div class="controls">
                     <div class="well">
                        <div class="slider slider-horizontal" >
                            <input type="text" 
                                data-slider-min="0" data-slider-max="100" data-slider-step="1" 
                                data-slider-value="0" value="0" class="span5"  id="sl1" />
                        </div>
                     </div>    
                </div>
                <input id="reviceRelationID" class="hidden"  />
            </div>
        </div>
        <div class="modal-footer">
            <button class="btn btn-danger" data-dismiss="modal">关闭</button>
            <a class="btn btn-success"  id="saveState">保存状态</a>
        </div>
    </aside>
</body>
<script src="../../Scripts/Task/MyTask.js"></script>
</html>
