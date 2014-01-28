<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<body>
    <div class="row-fluid">
        <div class="span12">
            <h3 class="page-title">
                已发送
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
                        <input style="visibility: hidden" id="provinceID" />
                        <input style="visibility: hidden" id="provinceCheckedNum" value="0" />
                        <span style="visibility: hidden" id="provinceIdd"></span>
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
                        id="sentboxTable">
                        <thead>
                            <tr>
                                <th>
                                    <input type="checkbox" class="toggle-checkboxes" />
                                </th>
                                <th>
                                    操作
                                </th>
                                <th>
                                    标题
                                </th>
                                <th>
                                    发件人
                                </th>
                                <th>
                                    收件人
                                </th>
                                <th>
                                    发送时间
                                </th>
                            </tr>
                        </thead>
                        <tbody>
                            <% foreach (var item in (this.ViewData["Email"] as IEnumerable<Domain.Email>).OrderByDescending(f => f.SendTime))
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
                                    <%= item.Title%>
                                </td>
                                 <td>
                                    <%= item.SendUser.Name%>
                                </td>
                                <td>
                                    <% foreach (var receiveUsers in (this.ViewData["EmailReceiveUserRelation"] as IEnumerable<Domain.EmailReceiveUserRelation>).Where(f=>f.Email.ID==item.ID))
                               { %>
                                    <span><%= receiveUsers.ReceiveUser.Name%></span>&nbsp;
                                <% } %>
                                </td>
                                <td>
                                    <%= item.SendTime%>
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
                    <span><a href="javascript:void(0)">邮件标题:&nbsp;&nbsp;</a><span id="title_detail"></span></span>
                </div>
                <div class="controls">
                     <span><a href="javascript:void(0)">发件人:&nbsp;&nbsp;</a><span  id="sendUser_detail"></span></span>
                </div>
                <div class="controls">
                     <span><a href="javascript:void(0)">收件人:&nbsp;&nbsp;</a><span  id="receive_detail"></span></span>
                </div>
                <a href="javascript:void(0)">正文:</a>
                <div class="controls">
                    <textarea id="content_detail" class="span3"  rows="5" readonly="readonly"></textarea>
                </div>
                <div class="controls">
                    <a href="javascript:void(0)">附件</a>
                    <table id="attach" class="table">
                        
                    </table>
                </div>
            </div>
        </div>
        <div class="modal-footer">
            <button class="btn btn-danger" data-dismiss="modal">关闭</button>
        </div>
    </aside>
</body>
<script src="../../Scripts/Email/Sentbox.js"></script>
</html>
