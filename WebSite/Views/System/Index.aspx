<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<body>
    <div class="row-fluid">
        <div class="span12">
            <h3 class="page-title">
                系统设置
            </h3>
        </div>
    </div>
    <div class="row-fluid">
        <div class="span12">
            <div class="social-box">
                <div class="body">
                    <ul id="myTab" class="nav nav-tabs">
                        <li class="active"><a href="#home" data-toggle="tab"><i class="icon-globe"></i>全局设置</a></li>
                        <li class=""><a href="#model" data-toggle="tab"><i class="icon-th"></i>模块</a></li>
                       <%-- <li class=""><a href="#province" data-toggle="tab"><i class="icon-move"></i>省份</a></li>
                        <li class=""><a href="#city" data-toggle="tab"><i class="icon-move"></i>地市</a></li>
                        <li class=""><a href="#region" data-toggle="tab"><i class="icon-move"></i>区域</a></li>--%>
                        <li class=""><a href="#department" data-toggle="tab"><i class="icon-sitemap"></i>部门</a></li>
                        <li class=""><a href="#role" data-toggle="tab"><i class="icon-group"></i>角色</a></li>
                        <li class=""><a href="#user" data-toggle="tab"><i class="icon-user"></i>用户</a></li>
                        <li class=""><a href="#rights" data-toggle="tab"><i class="icon-lock"></i>权限</a></li>
                        <li class=""><a href="#subject" data-toggle="tab"><i class="icon-lock"></i>科目</a></li>
                        <li class=""><a href="#teacher" data-toggle="tab"><i class="icon-lock"></i>教师</a></li>
                        <li class=""><a href="#class" data-toggle="tab"><i class="icon-lock"></i>班级</a></li>
                    </ul>
                    <div id="myTabContent" class="tab-content">
                        <div class="tab-pane fade active in" id="home">
                            <div class="row-fluid">
                                <div class="span12">
                                    <div class="body">
                                        <form action="#" class="form-horizontal">
                                        <div class="control-group">
                                            <label class="control-label">
                                                公司名称</label>
                                            <div class="controls">
                                                <input id="companyName_edit" type="text" class="input-xlarge" placeholder="填写公司名称"
                                                    value='<%:ViewData["companyName"]%>' data-bind="value:companyName" />
                                            </div>
                                        </div>
                                        <div class="control-group">
                                            <label class="control-label">
                                                是否开启省份权限控制</label>
                                            <div class="controls">
                                                <label class="checkbox inline">
                                                    <input id="isProvince_edit" type="checkbox" value='<%:ViewData["isProvince"]%>' data-bind="checked:isProvince" />
                                                </label>
                                            </div>
                                        </div>
                                        <div class="control-group">
                                            <label class="control-label">
                                                是否开启地市权限控制</label>
                                            <div class="controls">
                                                <label class="checkbox inline">
                                                    <input id="isCity_edit" type="checkbox" value='<%:ViewData["isCity"]%>' data-bind="checked:isCity" />
                                                </label>
                                            </div>
                                        </div>
                                        <div class="control-group">
                                            <label class="control-label">
                                                是否开启区域权限控制</label>
                                            <div class="controls">
                                                <label class="checkbox inline">
                                                    <input id="isRegion_edit" type="checkbox" value='<%:ViewData["isRegion"]%>' data-bind="checked:isRegion" />
                                                </label>
                                            </div>
                                        </div>
                                        <div class="control-group">
                                            <label class="control-label">
                                                是否开启部门权限控制</label>
                                            <div class="controls">
                                                <label class="checkbox inline">
                                                    <input id="isDepartment_edit" type="checkbox" value='<%:ViewData["isDepartment"]%>'
                                                        data-bind="checked:isDepartment" />
                                                </label>
                                            </div>
                                        </div>
                                        <div>
                                            <button id="confirm_globalSetting" class="btn btn-primary" data-bind="click:change">
                                                确认修改
                                            </button>
                                        </div>
                                        </form>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="tab-pane fade " id="model">
                            <div style="margin-bottom: 10px">
                                <button id="btn_addModel" class="btn btn-primary" data-bind="click:addModel">
                                    添加
                                </button>
                                <button id="btn_isExpand" class="btn btn-primary isExpand" data-bind="click:isExpand">
                                    收起
                                </button>
                            </div>
                            <div class="tree modelTree">
                                <ul>
                                    <% foreach (var item in (this.ViewData["SystemModel"] as IList<Domain.SystemModel>).Where(f => f.ParentId == new Guid()).OrderBy(f => f.OrderIndex))
                                       { %>
                                    <li>
                                        <span class="badge badge-success"><i class="icon-calendar"></i><span><%= item.Name %></span>&nbsp;&nbsp;&nbsp;&nbsp; </span>
                                        <a href="#" class="btn btn-mini modifyModel"><i class="icon-edit modifyModel"></i>修改 </a>&nbsp; 
                                        <a href="#" class="btn btn-mini deleteModel"><i class="icon-trash deleteModel"></i>删除 </a>
                                        <ul>
                                            <% foreach (var childrenItem in (this.ViewData["SystemModel"] as IList<Domain.SystemModel>).Where(f => f.ParentId == item.ID).OrderBy(f => f.OrderIndex))
                                               {  %>
                                            <li>
                                                <span><i class="icon-minus-sign"></i><span><%= childrenItem.Name%></span>&nbsp;URL:<%= childrenItem.Url%>&nbsp;&nbsp;&nbsp;&nbsp;</span>
                                                <a href="#" class="btn btn-mini modifyModel"><i class="icon-edit modifyModel"></i>修改 </a>&nbsp; 
                                                <a href="#" class="btn btn-mini deleteModel"><i class="icon-trash deleteModel"></i>删除 </a>
                                            </li>
                                            <% } %>
                                        </ul>
                                    </li>
                                    <% } %>
                                </ul>
                            </div>
                        </div>
                        <div class="tab-pane fade " id="province">
                            <div class="row-fluid">
                                <div class="span12">
                                    <div class="social-box">
                                        <div class="header">
                                            <div class="btn-group hidden-phone">
                                                <a class="btn btn-primary" id="add-row-province" href="#"><i class="icon-plus"></i>添加 </a>
                                                <a class="btn btn-danger disabled" href="#" id="delete-row-province"><i class="icon-trash"></i>批量删除 </a>
                                                <input style="visibility:hidden" id="provinceID"  />
                                                <input style="visibility:hidden" id="provinceCheckedNum" value="0" />
                                                <span style="visibility:hidden" id="provinceIdd"></span>
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
                                        </div>
                                        <div class="body">
                                            <table cellpadding="0" cellspacing="0" border="0" class="table table-striped table-bordered"
                                                id="provinceListTable">
                                                <thead>
                                                    <tr>
                                                        <th>
                                                            <input type="checkbox" class="toggle-checkboxes" />
                                                        </th>
                                                        <th>
                                                            操作
                                                        </th>
                                                        <th>
                                                            省份
                                                        </th>
                                                    </tr>
                                                </thead>
                                                <tbody>
                                                    <% foreach (var item in (this.ViewData["Province"] as IList<Domain.Province>).OrderBy(f => f.ProvinceName))
                                                       { %>
                                                    <tr class="gradeX">
                                                        <td>
                                                            <input type="checkbox" class="checkbox" value='<%= item.ID%>'/>
                                                        </td>
                                                        <td>
                                                            <a class="btn btn-success btn-mini modify" href="#" value='<%= item.ID%>'><i class="icon-edit"></i>修改 </a>
                                                            <a class="btn btn-danger btn-mini delete" href="#" value='<%= item.ID%>'><i class="icon-delete"></i>删除 </a>
                                                        </td>
                                                        <td>
                                                            <%= item.ProvinceName%>
                                                            
                                                        </td>
                                                    </tr>
                                                     <% } %>
                                                </tbody>
                                            </table>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="tab-pane fade " id="city">
                            <div class="row-fluid">
                                <div class="span12">
                                    <div class="social-box">
                                        <div class="header">
                                            <div class="btn-group hidden-phone">
                                                <a class="btn btn-primary" id="add-row-city" href="#"><i class="icon-plus"></i>添加 </a>
                                                <a class="btn btn-danger disabled" href="#" id="delete-row-city"><i class="icon-trash"></i>批量删除 </a>
                                                <input style="visibility:hidden" id="cityID"  />
                                                <input style="visibility:hidden" id="cityCheckedNum" value="0" />
                                                <span style="visibility:hidden" id="cityIdd"></span>
                                            </div>
                                            <div class="tools">
                                                <a class="btn btn-success btn-advanced" id="A3" href="javascript:void(0)"
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
                                        </div>
                                        <div class="body">
                                            <table cellpadding="0" cellspacing="0" border="0" class="table table-striped table-bordered"
                                                id="cityListTable">
                                                <thead>
                                                    <tr>
                                                        <th>
                                                            <input type="checkbox" class="toggle-checkboxes" />
                                                        </th>
                                                        <th>
                                                            操作
                                                        </th>
                                                        <th>
                                                            地市
                                                        </th>
                                                        <th>
                                                            所属省份
                                                        </th>
                                                    </tr>
                                                </thead>
                                                <tbody>
                                                    <% foreach (var item in (this.ViewData["City"] as IList<Domain.City>).OrderBy(f => f.CityName))
                                                       { %>
                                                    <tr class="gradeX">
                                                        <td>
                                                            <input type="checkbox" class="checkbox" value='<%= item.ID%>'/>
                                                        </td>
                                                        <td>
                                                            <a class="btn btn-success btn-mini modify" href="#" value='<%= item.ID%>'><i class="icon-edit"></i>修改 </a>
                                                            <a class="btn btn-danger btn-mini delete" href="#" value='<%= item.ID%>'><i class="icon-delete"></i>删除 </a>
                                                        </td>
                                                        <td>
                                                            <%= item.CityName%>
                                                        </td>
                                                         <td>
                                                            <%= item.Province.ProvinceName%>
                                                        </td>
                                                    </tr>
                                                     <% } %>
                                                </tbody>
                                            </table>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="tab-pane fade " id="region">
                            <div class="row-fluid">
                                <div class="span12">
                                    <div class="social-box">
                                        <div class="header">
                                            <div class="btn-group hidden-phone">
                                                <a class="btn btn-primary" id="add-row-region" href="#"><i class="icon-plus"></i>添加 </a>
                                                <a class="btn btn-danger disabled" href="#" id="delete-row-region"><i class="icon-trash"></i>批量删除 </a>
                                                <input style="visibility:hidden" id="regionID"  />
                                                <input style="visibility:hidden" id="regionCheckedNum" value="0" />
                                                <span style="visibility:hidden" id="regionIdd"></span>
                                            </div>
                                            <div class="tools">
                                                <a class="btn btn-success btn-advanced" id="A4" href="javascript:void(0)"
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
                                        </div>
                                        <div class="body">
                                            <table cellpadding="0" cellspacing="0" border="0" class="table table-striped table-bordered"
                                                id="regionListTable">
                                                <thead>
                                                    <tr>
                                                        <th>
                                                            <input type="checkbox" class="toggle-checkboxes" />
                                                        </th>
                                                        <th>
                                                            操作
                                                        </th>
                                                        <th>
                                                            区域
                                                        </th>
                                                        <th>
                                                            所属地市
                                                        </th>
                                                        <th>
                                                            所属省份
                                                        </th>
                                                    </tr>
                                                </thead>
                                                <tbody>
                                                    <% foreach (var item in (this.ViewData["Region"] as IList<Domain.Region>).OrderBy(f => f.RegionName))
                                                       { %>
                                                    <tr class="gradeX">
                                                        <td>
                                                            <input type="checkbox" class="checkbox" value='<%= item.ID%>'/>
                                                        </td>
                                                        <td>
                                                            <a class="btn btn-success btn-mini modify" href="#" value='<%= item.ID%>'><i class="icon-edit"></i>修改 </a>
                                                            <a class="btn btn-danger btn-mini delete" href="#" value='<%= item.ID%>'><i class="icon-delete"></i>删除 </a>
                                                        </td>
                                                        <td>
                                                            <%= item.RegionName%>
                                                        </td>
                                                         <td>
                                                            <%= item.City.CityName%>
                                                        </td>
                                                         <td>
                                                            <%= item.Province.ProvinceName%>
                                                        </td>
                                                    </tr>
                                                     <% } %>
                                                </tbody>
                                            </table>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="tab-pane fade " id="department">
                            <div class="row-fluid">
                                <div class="span12">
                                    <div class="social-box">
                                        <div class="header">
                                            <div class="btn-group hidden-phone">
                                                <a class="btn btn-primary" id="add-row-department" href="#"><i class="icon-plus"></i>添加 </a>
                                                <a class="btn btn-danger disabled" href="#" id="delete-row-department"><i class="icon-trash"></i>批量删除 </a>
                                                <input style="visibility:hidden" id="departmentID"  />
                                                <input style="visibility:hidden" id="departmentCheckedNum" value="0" />
                                                <span style="visibility:hidden" id="departmentIdd"></span>
                                            </div>
                                            <div class="tools">
                                                <a class="btn btn-success btn-advanced" id="A5" href="javascript:void(0)"
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
                                        </div>
                                        <div class="body">
                                            <table cellpadding="0" cellspacing="0" border="0" class="table table-striped table-bordered"
                                                id="departmentListTable">
                                                <thead>
                                                    <tr>
                                                        <th>
                                                            <input type="checkbox" class="toggle-checkboxes" />
                                                        </th>
                                                        <th>
                                                            操作
                                                        </th>
                                                        <th>
                                                            部门
                                                        </th>
                                                    </tr>
                                                </thead>
                                                <tbody>
                                                    <% foreach (var item in (this.ViewData["Department"] as IList<Domain.Department>).OrderBy(f => f.DepartmentName))
                                                       { %>
                                                    <tr class="gradeX">
                                                        <td>
                                                            <input type="checkbox" class="checkbox" value='<%= item.ID%>'/>
                                                        </td>
                                                        <td>
                                                            <a class="btn btn-success btn-mini modify" href="#" value='<%= item.ID%>'><i class="icon-edit"></i>修改 </a>
                                                            <a class="btn btn-danger btn-mini delete" href="#" value='<%= item.ID%>'><i class="icon-delete"></i>删除 </a>
                                                        </td>
                                                        <td>
                                                            <%= item.DepartmentName%>
                                                            
                                                        </td>
                                                    </tr>
                                                     <% } %>
                                                </tbody>
                                            </table>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="tab-pane fade " id="role">
                            <div class="row-fluid">
                                <div class="span12">
                                    <div class="social-box">
                                        <div class="header">
                                            <div class="btn-group hidden-phone">
                                                <a class="btn btn-primary" id="add-row-role" href="#"><i class="icon-plus"></i>添加 </a>
                                                <a class="btn btn-danger disabled" href="#" id="delete-row-role"><i class="icon-trash"></i>批量删除 </a>
                                                <input style="visibility:hidden" id="roleID"  />
                                                <input style="visibility:hidden" id="roleCheckedNum" value="0" />
                                                <span style="visibility:hidden" id="roleIdd"></span>
                                            </div>
                                            <div class="tools">
                                                <a class="btn btn-success btn-advanced" id="A6" href="javascript:void(0)"
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
                                        </div>
                                        <div class="body">
                                            <table cellpadding="0" cellspacing="0" border="0" class="table table-striped table-bordered"
                                                id="roleListTable">
                                                <thead>
                                                    <tr>
                                                        <th>
                                                            <input type="checkbox" class="toggle-checkboxes" />
                                                        </th>
                                                        <th>
                                                            操作
                                                        </th>
                                                        <th>
                                                            角色
                                                        </th>
                                                        <th>
                                                            所属部门
                                                        </th>
                                                    </tr>
                                                </thead>
                                                <tbody>
                                                    <% foreach (var item in (this.ViewData["Role"] as IList<Domain.Role>).OrderBy(f => f.RoleName))
                                                       { %>
                                                    <tr class="gradeX">
                                                        <td>
                                                            <input type="checkbox" class="checkbox" value='<%= item.ID%>'/>
                                                        </td>
                                                        <td>
                                                            <a class="btn btn-success btn-mini modify" href="#" value='<%= item.ID%>'><i class="icon-edit"></i>修改 </a>
                                                            <a class="btn btn-danger btn-mini delete" href="#" value='<%= item.ID%>'><i class="icon-delete"></i>删除 </a>
                                                        </td>
                                                        <td>
                                                            <%= item.RoleName%>
                                                        </td>
                                                        <td>
                                                            <%= item.Department.DepartmentName%>
                                                        </td>
                                                    </tr>
                                                     <% } %>
                                                </tbody>
                                            </table>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="tab-pane fade " id="user">
                            <div class="row-fluid">
                                <div class="span12">
                                    <div class="social-box">
                                        <div class="header">
                                            <div class="btn-group hidden-phone">
                                                <a class="btn btn-primary" id="add-row-sysUser" href="#"><i class="icon-plus"></i>添加 </a>
                                                <a class="btn btn-danger disabled" href="#" id="delete-row-sysUser"><i class="icon-trash"></i>批量删除 </a>
                                                <input style="visibility:hidden" id="sysUserID"  />
                                                <input style="visibility:hidden" id="sysUserCheckedNum" value="0" />
                                                <span style="visibility:hidden" id="sysUserIdd"></span>
                                            </div>
                                            <div class="tools">
                                                <a class="btn btn-success btn-advanced" id="A7" href="javascript:void(0)"
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
                                        </div>
                                        <div class="body">
                                            <table cellpadding="0" cellspacing="0" border="0" class="table table-striped table-bordered"
                                                id="sysUserListTable">
                                                <thead>
                                                    <tr>
                                                        <th>
                                                            <input type="checkbox" class="toggle-checkboxes" />
                                                        </th>
                                                        <th>
                                                            操作
                                                        </th>
                                                        <th>
                                                            登录名
                                                        </th>
                                                        <th>
                                                            用户姓名
                                                        </th>
                                                    </tr>
                                                </thead>
                                                <tbody>
                                                    <% foreach (var item in (this.ViewData["SysUser"] as IList<Domain.UserInfo>).OrderBy(f => f.Account))
                                                       { %>
                                                    <tr class="gradeX">
                                                        <td>
                                                            <input type="checkbox" class="checkbox" value='<%= item.ID%>'/>
                                                        </td>
                                                        <td>
                                                            <a class="btn btn-success btn-mini modify" href="#" value='<%= item.ID%>'><i class="icon-edit"></i>修改 </a>
                                                            <a class="btn btn-danger btn-mini delete" href="#" value='<%= item.ID%>'><i class="icon-delete"></i>删除 </a>
                                                        </td>
                                                        <td>
                                                            <%= item.Account%>
                                                        </td>
                                                        <th>
                                                            <%= item.Name%>
                                                        </th>
                                                    </tr>
                                                     <% } %>
                                                </tbody>
                                            </table>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="tab-pane fade " id="rights">
                            <div style="margin-bottom: 10px">
                                <a id="rightIsExpend" class="btn btn-primary" href="javascript:void(0)" >
                                    收起
                                </a>
                                <a id="selectAllRights" class="btn btn-primary" href="javascript:void(0)" >
                                    权限全选
                                </a>
                                <a id="initAllRights" class="btn btn-primary" href="javascript:void(0)" >
                                    权限重置
                                </a>
                                
                                <a id="saveRights" class="btn btn-primary btn-success" href="javascript:void(0)" >
                                    保存
                                </a>
                            </div>
                            <div class="tree rightTree">
                                <select id="sel_roleRights" class="span3">
                                    <% foreach (var item in (this.ViewData["Role"] as IList<Domain.Role>).OrderBy(f => f.RoleName))
                                       { %>
                                    <option class="opt_roleRights" value="<%= item.ID %>">
                                        <%= item.RoleName%></option>
                                    <% } %>
                                </select>
                                <ul>
                                    <% foreach (var item in (this.ViewData["SystemModel"] as IList<Domain.SystemModel>).Where(f => f.ParentId == new Guid()).OrderBy(f => f.OrderIndex))
                                       { %>
                                    <li>
                                        <span class="badge badge-success"><i class="icon-calendar"></i><%= item.Name %>&nbsp;&nbsp;&nbsp;&nbsp; </span>
                                        <ul>
                                            <% foreach (var childrenItem in (this.ViewData["SystemModel"] as IList<Domain.SystemModel>).Where(f => f.ParentId == item.ID).OrderBy(f => f.OrderIndex))
                                               {  %>
                                            <li>
                                                <span class="rightRow">
                                                    <i class="icon-minus-sign"></i>
                                                    <%= childrenItem.Name%>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                    <input id="pageModelID" class="hidden" value="<%= childrenItem.ID%>" />
                                                    <% foreach (var childrenRights in (this.ViewData["Rights"] as IList<Domain.Rights>).OrderBy(f => f.OrderIndex))
                                                   { %>
                                                        <label class="checkbox rightCheckBox inline">
                                                            <input type="checkbox" value="<%= childrenRights.ID %>"/> <%= childrenRights.RightName %>
                                                        </label>
                                                   <% } %>
                                                    <label class="checkbox inline">
                                                        <input type="checkbox" class="selectAll" /> 全选
                                                    </label>
                                                </span>
                                            </li>
                                            <% } %>
                                        </ul>
                                    </li>
                                    <% } %>
                                </ul>
                            </div>
                        </div>
                        <div class="tab-pane fade " id="subject">
	                        <div class="row-fluid">
		                        <div class="span12">
			                        <div class="social-box">
				                        <div class="header">
					                        <div class="btn-group hidden-phone">
						                        <a class="btn btn-primary" id="add-row-subject" href="#"><i class="icon-plus"></i>添加 </a>
						                        <a class="btn btn-danger disabled" href="#" id="delete-row-subject"><i class="icon-trash"></i>批量删除 </a>
						                        <input style="visibility:hidden" id="subjectID"  />
						                        <input style="visibility:hidden" id="subjectCheckedNum" value="0" />
						                        <span style="visibility:hidden" id="subjectIdd"></span>
					                        </div>
					                        <div class="tools">
						                        <a class="btn btn-success btn-advanced" id="A1" href="javascript:void(0)"
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
				                        </div>
				                        <div class="body">
					                        <table cellpadding="0" cellspacing="0" border="0" class="table table-striped table-bordered"
						                        id="subjectListTable">
						                        <thead>
							                        <tr>
								                        <th>
									                        <input type="checkbox" class="toggle-checkboxes" />
								                        </th>
								                        <th>
									                        操作
								                        </th>
								                        <th>
									                        科目
								                        </th>
							                        </tr>
						                        </thead>
						                        <tbody>
							                        <% foreach (var item in (this.ViewData["subject"] as IList<Domain.Subject>).OrderBy(f => f.Name))
							                           { %>
							                        <tr class="gradeX">
								                        <td>
									                        <input type="checkbox" class="checkbox" value='<%= item.ID%>'/>
								                        </td>
								                        <td>
									                        <a class="btn btn-success btn-mini modify" href="#" value='<%= item.ID%>'><i class="icon-edit"></i>修改 </a>
									                        <a class="btn btn-danger btn-mini delete" href="#" value='<%= item.ID%>'><i class="icon-delete"></i>删除 </a>
								                        </td>
								                        <td>
									                        <%= item.Name%>
									
								                        </td>
							                        </tr>
							                         <% } %>
						                        </tbody>
					                        </table>
				                        </div>
			                        </div>
		                        </div>
	                        </div>
                        </div>
                        <div class="tab-pane fade " id="class">
	                        <div class="row-fluid">
		                        <div class="span12">
			                        <div class="social-box">
				                        <div class="header">
					                        <div class="btn-group hidden-phone">
						                        <a class="btn btn-primary" id="add-row-class" href="#"><i class="icon-plus"></i>添加 </a>
						                        <a class="btn btn-danger disabled" href="#" id="delete-row-class"><i class="icon-trash"></i>批量删除 </a>
						                        <input style="visibility:hidden" id="classID"  />
						                        <input style="visibility:hidden" id="classCheckedNum" value="0" />
						                        <span style="visibility:hidden" id="classIdd"></span>
					                        </div>
					                        <div class="tools">
						                        <a class="btn btn-success btn-advanced" id="A2" href="javascript:void(0)"
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
				                        </div>
				                        <div class="body">
					                        <table cellpadding="0" cellspacing="0" border="0" class="table table-striped table-bordered"
						                        id="classListTable">
						                        <thead>
							                        <tr>
								                        <th>
									                        <input type="checkbox" class="toggle-checkboxes" />
								                        </th>
								                        <th>
									                        操作
								                        </th>
								                        <th>
									                        班级
								                        </th>
							                        </tr>
						                        </thead>
						                        <tbody>
							                        <% foreach (var item in (this.ViewData["class"] as IList<Domain.Classes>).OrderBy(f => f.Name))
							                           { %>
							                        <tr class="gradeX">
								                        <td>
									                        <input type="checkbox" class="checkbox" value='<%= item.ID%>'/>
								                        </td>
								                        <td>
									                        <a class="btn btn-success btn-mini modify" href="#" value='<%= item.ID%>'><i class="icon-edit"></i>修改 </a>
									                        <a class="btn btn-danger btn-mini delete" href="#" value='<%= item.ID%>'><i class="icon-delete"></i>删除 </a>
								                        </td>
								                        <td>
									                        <%= item.Name%>
								                        </td>
							                        </tr>
							                         <% } %>
						                        </tbody>
					                        </table>
				                        </div>
			                        </div>
		                        </div>
	                        </div>
                        </div>
                        <div class="tab-pane fade " id="teacher">
	                        <div class="row-fluid">
		                        <div class="span12">
			                        <div class="social-box">
				                        <div class="header">
					                        <div class="btn-group hidden-phone">
						                        <a class="btn btn-primary" id="add-row-teacher" href="#"><i class="icon-plus"></i>添加 </a>
						                        <a class="btn btn-danger disabled" href="#" id="delete-row-teacher"><i class="icon-trash"></i>批量删除 </a>
						                        <input style="visibility:hidden" id="teacherID"  />
						                        <input style="visibility:hidden" id="teacherCheckedNum" value="0" />
						                        <span style="visibility:hidden" id="teacherIdd"></span>
					                        </div>
					                        <div class="tools">
						                        <a class="btn btn-success btn-advanced" id="A8" href="javascript:void(0)"
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
				                        </div>
				                        <div class="body">
					                        <table cellpadding="0" cellspacing="0" border="0" class="table table-striped table-bordered"
						                        id="teacherListTable">
						                        <thead>
							                        <tr>
								                        <th>
									                        <input type="checkbox" class="toggle-checkboxes" />
								                        </th>
								                        <th>
									                        操作
								                        </th>
								                        <th>
									                        教师
								                        </th>
							                        </tr>
						                        </thead>
						                        <tbody>
							                        <% foreach (var item in (this.ViewData["Teacher"] as IList<Domain.Teacher>).OrderBy(f => f.Name))
							                           { %>
							                        <tr class="gradeX">
								                        <td>
									                        <input type="checkbox" class="checkbox" value='<%= item.ID%>'/>
								                        </td>
								                        <td>
									                        <a class="btn btn-success btn-mini modify" href="#" value='<%= item.ID%>'><i class="icon-edit"></i>修改 </a>
									                        <a class="btn btn-danger btn-mini delete" href="#" value='<%= item.ID%>'><i class="icon-delete"></i>删除 </a>
								                        </td>
								                        <td>
									                        <%= item.Name%>
								                        </td>
							                        </tr>
							                         <% } %>
						                        </tbody>
					                        </table>
				                        </div>
			                        </div>
		                        </div>
	                        </div>
                        </div>


                        <!-- tab页完成 -->
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!-- 系统模块添加修改弹出框 -->
    <aside id="addAndUpdateModel" class="modal hide fade" tabindex="-1" role="dialog"
        aria-labelledby="myModalLabel" aria-hidden="true">
        <div class="modal-header">
            <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
            <h3 id="H1"><span id="modelAddAndUpdateTitle">添加</span></h3>
        </div>
        <div class="modal-body">
            <div class="control-group">
                <label class="control-label">
                    模块名称</label>
                <div class="controls">
                     <input id="modelName_edit" type="text" class="input-xlarge" placeholder="填写模块名称"
                       data-bind="value:modelName" />
                </div>
            </div>
            <div class="control-group">
                <label class="control-label">
                    访问地址</label>
                <div class="controls">
                    <input id="modelUrl_edit" type="text" class="input-xlarge" placeholder="填写访问地址"
                       data-bind="value:modelUrl" />
                </div>
            </div>
            <div class="control-group">
                <label class="control-label">
                    上级模块</label>
                <div class="controls">
                    <select id="parentModel" class="span3" placeholder="填写访问地址">
                        <option value='<%:ViewData["NullGuid"]%>'>根目录</option>
                        <% foreach (var item in (this.ViewData["SystemModel"] as IList<Domain.SystemModel>).Where(f => f.ParentId == new Guid()).OrderBy(f => f.OrderIndex))
                           { %>
                        <option value="<%= item.ID %>"><%= item.Name %></option>
                        <% } %>
                    </select>
                </div>
            </div>
            <div class="control-group">
                <label class="control-label">
                    左兄弟模块(排序在选择模块之后)</label>
                <div class="controls">
                    <select id="ddl_siblingModel" class="span3" placeholder="填写访问地址">
                        <% foreach (var item in (this.ViewData["SystemModel"] as IList<Domain.SystemModel>).OrderBy(f => f.OrderIndex))
                           { %>
                        <option class="opt_siblingModel" value="<%= item.ID %>" parentid="<%= item.ParentId %>"><%= item.Name %></option>
                        <% } %>
                    </select>
                </div>
            </div>
            <div class="control-group">
                <label class="control-label">
                    是否启用</label>
                <div class="controls">
                    <input id="modelIsEnable_edit" type="checkbox" checked="checked"  />
                </div>
            </div>
        </div>
        <div class="modal-footer">
            <button class="btn btn-danger" data-dismiss="modal">关闭</button>
            <a class="btn btn-primary" id="saveModel"  data-bind="click:saveModel">保存</a>
        </div>
    </aside>
    <!-- 省份添加修改弹出框 -->
    <aside id="addAndUpdateProvince" class="modal hide fade" tabindex="-1" role="dialog"
        aria-labelledby="myModalLabel" aria-hidden="true">
        <div class="modal-header">
            <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
            <h3 id="provinceAddOrUpdateTitle"><span id="Span1">添加</span></h3>
        </div>
        <div class="modal-body">
            <div class="control-group">
                <label class="control-label">
                    省份</label>
                <div class="controls">
                     <input id="provinceName_edit" type="text" class="input-xlarge" placeholder="填写省份" />
                </div>
            </div>
        </div>
        <div class="modal-footer">
            <button class="btn btn-danger" data-dismiss="modal">关闭</button>
            <a class="btn btn-primary" id="saveProvince">保存</a>
        </div>
    </aside>
    <!-- 地市添加修改弹出框 -->
    <aside id="addAndUpdateCity" class="modal hide fade" tabindex="-1" role="dialog"
        aria-labelledby="myModalLabel" aria-hidden="true">
        <div class="modal-header">
            <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
            <h3 id="cityAddOrUpdateTitle"><span id="Span2">添加</span></h3>
        </div>
        <div class="modal-body">
            <div class="control-group">
                <label class="control-label">
                    地市</label>
                <div class="controls">
                     <input id="cityName_edit" type="text" class="input-xlarge" placeholder="填写地市" />
                </div>
            </div>
            <div class="control-group">
                <label class="control-label">
                    所属省份</label>
                <div class="controls">
                    <select id="provinceAttrCity" class="span3" >
                        <% foreach (var item in (this.ViewData["Province"] as IList<Domain.Province>).OrderBy(f => f.ProvinceName))
                           { %>
                        <option class="opt_provinceAttrCity" value="<%= item.ID %>" ><%= item.ProvinceName%></option>
                        <% } %>
                    </select>
                </div>
            </div>
        </div>
        <div class="modal-footer">
            <button class="btn btn-danger" data-dismiss="modal">关闭</button>
            <a class="btn btn-primary" id="saveCity">保存</a>
        </div>
    </aside>
     <!-- 区域添加修改弹出框 -->
    <aside id="addAndUpdateRegion" class="modal hide fade" tabindex="-1" role="dialog"
        aria-labelledby="myModalLabel" aria-hidden="true">
        <div class="modal-header">
            <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
            <h3 id="regionAddOrUpdateTitle"><span id="Span3">添加</span></h3>
        </div>
        <div class="modal-body">
            <div class="control-group">
                <label class="control-label">
                    区域</label>
                <div class="controls">
                     <input id="regionName_edit" type="text" class="input-xlarge" placeholder="填写区域" />
                </div>
            </div>
            <div class="control-group">
                <label class="control-label">
                    所属省份</label>
                <div class="controls">
                    <select id="provinceAttrRegion" class="span3" >
                        <% foreach (var item in (this.ViewData["Province"] as IList<Domain.Province>).OrderBy(f => f.ProvinceName))
                           { %>
                        <option class="opt_provinceAttrRegion" value="<%= item.ID %>" ><%= item.ProvinceName%></option>
                        <% } %>
                    </select>
                </div>
            </div>
             <div class="control-group">
                <label class="control-label">
                    所属地市</label>
                <div class="controls">
                    <select id="cityAttrRegion" class="span3" >
                        <% foreach (var item in (this.ViewData["City"] as IList<Domain.City>).OrderBy(f => f.CityName))
                           { %>
                        <option class="opt_cityAttrRegion" value="<%= item.ID %>" parentid="<%= item.Province.ID %>"><%= item.CityName%></option>
                        <% } %>
                    </select>
                </div>
            </div>
        </div>
        <div class="modal-footer">
            <button class="btn btn-danger" data-dismiss="modal">关闭</button>
            <a class="btn btn-primary" id="saveRegion">保存</a>
        </div>
    </aside>
    <!-- 部门添加修改弹出框 -->
    <aside id="addAndUpdateDepartment" class="modal hide fade" tabindex="-1" role="dialog"
        aria-labelledby="myModalLabel" aria-hidden="true">
        <div class="modal-header">
            <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
            <h3 id="departmentAddOrUpdateTitle"><span id="Span4">添加</span></h3>
        </div>
        <div class="modal-body">
            <div class="control-group">
                <label class="control-label">
                    部门</label>
                <div class="controls">
                     <input id="departmentName_edit" type="text" class="input-xlarge" placeholder="填写部门" />
                </div>
            </div>
        </div>
        <div class="modal-footer">
            <button class="btn btn-danger" data-dismiss="modal">关闭</button>
            <a class="btn btn-primary" id="saveDepartment">保存</a>
        </div>
    </aside>
     <!-- 角色添加修改弹出框 -->
    <aside id="addAndUpdateRole" class="modal hide fade" tabindex="-1" role="dialog"
        aria-labelledby="myModalLabel" aria-hidden="true">
        <div class="modal-header">
            <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
            <h3 id="roleAddOrUpdateTitle"><span id="Span5">添加</span></h3>
        </div>
        <div class="modal-body">
            <div class="control-group">
                <label class="control-label">
                    角色</label>
                <div class="controls">
                     <input id="roleName_edit" type="text" class="input-xlarge" placeholder="填写角色" />
                </div>
                <label class="control-label">
                    所属部门</label>
                <div class="controls">
                    <select id="departmentAttrRole"  class="span3" >
                        <% foreach (var item in (this.ViewData["Department"] as IList<Domain.Department>).OrderBy(f => f.DepartmentName))
                           { %>
                        <option class="opt_departmentAttrRole" value="<%= item.ID %>"><%= item.DepartmentName%></option>
                        <% } %>
                    </select>
                </div>
            </div>
        </div>
        <div class="modal-footer">
            <button class="btn btn-danger" data-dismiss="modal">关闭</button>
            <a class="btn btn-primary" id="saveRole">保存</a>
        </div>
    </aside>
     <!-- 系统用户添加修改弹出框 -->
    <aside id="addAndUpdateSysUser" class="modal hide fade" tabindex="-1" role="dialog"
        aria-labelledby="myModalLabel" aria-hidden="true">
        <div class="modal-header">
            <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
            <h3 id="sysUserAddOrUpdateTitle"><span id="Span6">添加</span></h3>
        </div>
        <div class="modal-body">
            <div class="control-group">
                <label class="control-label">
                    系统登录用户名</label>
                <div class="controls">
                     <input id="sysUserName_edit" type="text" class="input-xlarge" placeholder="填写系统登录用户名" />
                </div>
                <label class="control-label">
                    用户姓名</label>
                <div class="controls">
                     <input id="name_edit" type="text" class="input-xlarge" placeholder="填写用户姓名" />
                </div>
            </div>
             <div class="control-group">
                <label class="control-label">
                    所属角色</label>
                <div class="controls">
                    <select id="roleAttrUser"  multiple="multiple" class="span3" >
                        <% foreach (var item in (this.ViewData["Role"] as IList<Domain.Role>).OrderBy(f => f.RoleName))
                           { %>
                        <option class="opt_roleAttrUser" value="<%= item.ID %>"><%= item.RoleName%></option>
                        <% } %>
                    </select>
                </div>
            </div>
            <div style="height:100px;">
                
            </div>
        </div>
        <div class="modal-footer">
            <button class="btn btn-danger" data-dismiss="modal">关闭</button>
            <a class="btn btn-primary" id="saveSysUser">保存</a>
        </div>
    </aside>
    <!-- 科目添加修改弹出框 -->
    <aside id="addAndUpdateSubject" class="modal hide fade" tabindex="-1" role="dialog"
        aria-labelledby="myModalLabel" aria-hidden="true">
        <div class="modal-header">
            <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
            <h3 id="subjectAddOrUpdateTitle"><span id="Span7">添加</span></h3>
        </div>
        <div class="modal-body">
            <div class="control-group">
                <label class="control-label">
                    科目</label>
                <div class="controls">
                     <input id="subjectName_edit" type="text" class="input-xlarge" placeholder="填写科目名称" />
                </div>
            </div>
        </div>
        <div class="modal-footer">
            <button class="btn btn-danger" data-dismiss="modal">关闭</button>
            <a class="btn btn-primary" id="saveSubject">保存</a>
        </div>
    </aside>
    <!-- 班级添加修改弹出框 -->
    <aside id="addAndUpdateClass" class="modal hide fade" tabindex="-1" role="dialog"
        aria-labelledby="myModalLabel" aria-hidden="true">
        <div class="modal-header">
            <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
            <h3 id="classAddOrUpdateTitle"><span id="Span8">添加</span></h3>
        </div>
        <div class="modal-body">
            <div class="control-group">
                <label class="control-label">
                    班级名称</label>
                <div class="controls">
                     <input id="className_edit" type="text" class="input-xlarge" placeholder="填写班级名称" />
                </div>
            </div>
             <div class="control-group">
                <label class="control-label">
                    年级</label>
                <div class="controls">
                    <select id="gradeAttrClass"   class="span3" >
                        <% foreach (var item in (this.ViewData["Grade"] as IList<Domain.Grade>).OrderBy(f => f.GradeType.Name))
                           { %>
                        <option class="opt_gradeAttrClass" value="<%= item.ID %>"><%= item.GradeType.Name%><%= item.Name%></option>
                        <% } %>
                    </select>
                </div>
            </div>
            <div class="control-group">
                <label class="control-label">
                    班主任</label>
                <div class="controls">
                    <select id="teacherAttrClass"  class="span3" >
                        <% foreach (var item in (this.ViewData["Teacher"] as IList<Domain.Teacher>).OrderBy(f => f.Name))
                           { %>
                        <option class="opt_teacherAttrClass" value="<%= item.ID %>"><%= item.Subject.Name%><%= item.Name%></option>
                        <% } %>
                    </select>
                </div>
            </div>
            <div style="height:100px;">
                
            </div>
        </div>
        <div class="modal-footer">
            <button class="btn btn-danger" data-dismiss="modal">关闭</button>
            <a class="btn btn-primary" id="saveClass">保存</a>
        </div>
    </aside>
    <!-- 教师添加修改弹出框 -->
    <aside id="addAndUpdateTeacher" class="modal hide fade" tabindex="-1" role="dialog"
        aria-labelledby="myModalLabel" aria-hidden="true">
        <div class="modal-header">
            <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
            <h3 id="TeacherAddOrUpdateTitle"><span id="Span9">添加</span></h3>
        </div>
        <div class="modal-body">
            <div class="control-group">
                <label class="control-label">
                    姓名</label>
                <div class="controls">
                     <input id="teacherName_edit" type="text" class="input-xlarge" placeholder="填写教师姓名" />
                </div>
                <label class="control-label">
                    教师登录名</label>
                <div class="controls">
                     <input id="teacherUserName_edit" type="text" class="input-xlarge" placeholder="填写教师登录名" />
                </div>
            </div>
             <div class="control-group">
                <label class="control-label">
                    教授科目</label>
                <div class="controls">
                    <select id="subjectAttrTeacher"  class="span3" >
                        <% foreach (var item in (this.ViewData["Subject"] as IList<Domain.Subject>).OrderBy(f => f.Name))
                           { %>
                        <option class="opt_subjectAttrTeacher" value="<%= item.ID %>"><%= item.Name%></option>
                        <% } %>
                    </select>
                </div>
            </div>
            <div style="height:100px;">
                
            </div>
        </div>
        <div class="modal-footer">
            <button class="btn btn-danger" data-dismiss="modal">关闭</button>
            <a class="btn btn-primary" id="saveTeacher">保存</a>
        </div>
    </aside>

    <div style="visibility: hidden">
        <input data-bind="value:companyName" />
    </div>
</body>
<script src="../../Scripts/System/Index.js"></script>
<script src="../../Scripts/System/Province.js"></script>
<script src="../../Scripts/System/City.js"></script>
<script src="../../Scripts/System/Region.js"></script>
<script src="../../Scripts/System/Department.js"></script>
<script src="../../Scripts/System/Role.js"></script>
<script src="../../Scripts/System/SysUser.js"></script>
<script src="../../Scripts/System/Rights.js"></script>
<script src="../../Scripts/System/Subject.js"></script>
<script src="../../Scripts/System/Class.js"></script>
<script src="../../Scripts/System/Teacher.js"></script>
<script src="../../assets/js/bootstrap-tree.js"></script>
</html>
