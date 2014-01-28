<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<body>
    <div class="row-fluid">
        <div class="span12">
            <h3 class="page-title">
                个人资料
            </h3>
        </div>
    </div>
    <div class="row-fluid">
        <div class="span12">
            <div class="social-box">
                <div class="body">
                    <ul id="myTab" class="nav nav-tabs">
                        <li class="active"><a href="#basic" data-toggle="tab"><i class="icon-user"></i>基本资料</a></li>
                        <li class=""><a href="#setSvatar" data-toggle="tab"><i class="icon-picture"></i>设置头像</a></li>
                        <li class=""><a href="#changePassword" data-toggle="tab"><i class="icon-key"></i>重置密码</a></li>
                    </ul>
                    <div id="myTabContent" class="tab-content">
                        <div class="tab-pane fade active in" id="basic">
                            <div class="row-fluid">
                                <div class="span12">
                                    <div class="body">
                                        <div class="control-group">
                                            <label class="control-label">
                                                电话</label>
                                            <div class="controls">
                                                <input ID="telephone_edit"  class="input-xlarge"
                                                 placeholder="填写个人联系电话" data-bind="value:telephone" 
                                                 value="<%= ((Domain.UserInfo)this.ViewData["userInfo"]).Phone %>"/>
                                            </div>
                                        </div>
                                        <div class="control-group">
                                            <label class="control-label">
                                                邮件</label>
                                            <div class="controls">
                                                <input ID="email_edit"  class="input-xlarge" 
                                                 placeholder="填写个人邮件"   data-bind="value:email" 
                                                 value="<%= ((Domain.UserInfo)this.ViewData["userInfo"]).Email %>"/>
                                            </div>
                                        </div>
                                        <div class="control-group">
                                            <label class="control-label">
                                                QQ </label>
                                            <div class="controls">
                                                <input ID="QQ_edit"  class="input-xlarge"
                                                 placeholder="填写QQ号"   data-bind="value:QQ" 
                                                 value="<%= ((Domain.UserInfo)this.ViewData["userInfo"]).QQ %>"/>
                                            </div>
                                        </div>
                                        <div>
                                            <button id="profile_confirm" class="btn btn-primary"  data-bind="click:profileChange">
                                                确认修改
                                            </button>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="tab-pane fade " id="setSvatar">
                            <div class="row-fluid">
                                <div class="span6">
                                    <div class="social-box">
                                        <div class="body">
                                            <h3>
                                                上传头像
                                            </h3>
                                            <div class="row-fluid">
                                                <div class="span6">
                                                    <div class="fileupload fileupload-new" data-provides="fileupload">
                                                        <div class="fileupload-new thumbnail" style="width: 200px; height: 150px;">
                                                            <img id="avatarNow" src="<%= ViewData["avatar"] %>" alt="Selected image"/>
                                                        </div>
                                                        <div class="fileupload-preview fileupload-exists thumbnail" style="max-width: 200px;
                                                            max-height: 150px; line-height: 20px;">
                                                        </div>
                                                        <div>
                                                            <span class="btn btn-file">
                                                                <span class="fileupload-new">选择图片</span>
                                                                <span class="fileupload-exists">修改</span>
                                                                <input id="selectFile"  type="file"/>
                                                            </span> 
                                                            <a href="#" class="btn fileupload-exists" data-dismiss="fileupload">移除</a>
                                                            <button id="UploadButton" class="btn btn-primary"  data-bind="click:UploadAvatar">
                                                                上传图片
                                                            </button>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="tab-pane fade " id="changePassword">
                            <div class="row-fluid">
                                <div class="span12">
                                    <div class="body">
                                        <div class="control-group">
                                            <label class="control-label">
                                                旧密码</label>
                                            <div class="controls">
                                                <input id="oldPassword_edit" type="password"  class ="input-xlarge"
                                                    placeholder="请输入旧密码"   data-bind="value:oldPassword"/>
                                            </div>
                                        </div>
                                        <div class="control-group">
                                            <label class="control-label">
                                                新密码</label>
                                            <div class="controls">
                                                <input id="newPassword_edit"  type="password"  class="input-xlarge"
                                                    placeholder="请输入新密码"  data-bind="value:newPassword"/>
                                            </div>
                                        </div>
                                        <div class="control-group">
                                            <label class="control-label">
                                                再次输入新密码</label>
                                            <div class="controls">
                                                <input id="newPasswordAgain_edit"  type="password"  class="input-xlarge"
                                                    placeholder="请再次输入新密码" data-bind="value:newPasswordAgain"/>
                                            </div>
                                        </div>
                                        <div>
                                            <button id="changePassword_confirm" class="btn btn-primary"  data-bind="click:UpdatePassword">
                                                修改密码
                                            </button>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    

</body>
<script src="../../Scripts/Account/Index.js"></script>
</html>
