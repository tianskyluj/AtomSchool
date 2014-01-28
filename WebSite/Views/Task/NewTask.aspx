<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<body>
    <div class="row-fluid">
        <div class="span12">
            <h3 class="page-title">
                分配任务
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
                            <input id="title_edit" type="text" placeholder="填写任务(必填)..." class="span3" />
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
                            <div id="datetimepicker_deadline" class="input-append date">
                                <input id="datetimepicker1" data-format="yyyy-MM-dd hh:mm:ss" placeholder="选择任务时限" type="text" class="input-block-level">
                                <span class="add-on"><i data-time-icon="icon-time" data-date-icon="icon-calendar"
                                    class="icon-calendar"></i></span>
                            </div>
                        </div>
                        <div class="controls" style="margin-bottom: 10px">
                            <select id="sel_taskLevel" class="span3">
                                <% foreach (var item in (this.ViewData["TaskLevel"] as IList<Domain.TaskLevel>).OrderBy(f => f.OrderIndex))
                                   { %>
                                <option class="opt_taskLevel" value="<%= item.ID %>">
                                    <%= item.LevelName%></option>
                                <% } %>
                            </select>
                        </div>
                        <div class="controls">
                            <textarea id="task_edit" placeholder="输入任务详细(非必填)..." class="span9" style="height: 150px"> </textarea>
                        </div>
                    </div>
                    <div>
                        <a id="btn_sendTask" class="btn btn-primary">确定 </a><a id="btn_reset" class="btn">重置
                        </a>
                    </div>
                    </form>
                </div>
            </div>
        </div>
    </div>
</body>
<script src="../../assets/js/wysihtml5/dist/wysihtml5-0.3.0.min.js"></script>
<script src="../../assets/js/bootstrap-wysihtml5/src/bootstrap-wysihtml5.js"></script>
<script src="../../Scripts/Task/NewTask.js"></script>

<script src="../../assets/js/bootstrap-tree.js"></script>
<link href="../../assets/js/bootstrap-wysihtml5/src/bootstrap-wysihtml5.css" rel="stylesheet">

</html>
